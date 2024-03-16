using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.NetworkOperations;
using Iris.Runtime.NetworkOperations;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.WebOperations;
using System.ComponentModel;
using Iris.Runtime.Model.PropertyEditors;
using System.Drawing.Design;
using System.Net;
using CRMFramework2011;
using System.ServiceModel.Description;
using System.Data;
using System.Threading.Tasks;
using Iris.Runtime.Model.Entities;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk;

namespace Iris.Dynamics2011
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Dynamics Updater 2011")]
  public class CRM2011Updater : NetworkOperation, IBaseWebServiceOperation
  {
    public CRM2011Updater(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Configs");
      applyInserts = true;
      applyUpdates = true;
      applyDeletes = false;
      RemoveUnchanged = true;
      LogicalExclusion = true;
      setState = false;
      MaxErrors = 0;
      Timeout = 2;
      DelStateCode = 1;
      DelStatusCode = 2;
    }

    protected void SetupConfigs()
    {
      if (GetInput("Configs") != null)
      {
        IScalarVar configVar = GetInput("Configs") as IScalarVar;
        if (configVar != null)
        {
          if (configVar.RawValue is WsConfigs)
          {
            WsConfigs configs = (WsConfigs)configVar.RawValue;
            configs.SetupOperation(this);
          }
        }
      }
    }

    [Browsable(false)]
    public IResultSet Entrada
    {
      get
      {
        IOperation input = GetInput("Entrada");
        if (input == null)
          throw new Exception("Resultset de entrada não atribuído");
        else
          return (IResultSet)input.EntityValue;
      }
    }

    public string Organization { get; set; }

    public int MaxErrors { get; set; }

    private string resultColumn;
    [Editor(typeof(CBOColumnSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Coluna Resultado")]
    public string ResultColumn
    {
      get { return resultColumn; }
      set { resultColumn = value; }
    }

    private bool applyUpdates;

    public bool ApplyUpdates
    {
      get { return applyUpdates; }
      set { applyUpdates = value; }
    }

    private bool applyInserts;

    public bool ApplyInserts
    {
      get { return applyInserts; }
      set { applyInserts = value; }
    }

    private bool applyDeletes;

    public bool ApplyDeletes
    {
      get { return applyDeletes; }
      set { applyDeletes = value; }
    }


    private bool setState;

    public bool SetState
    {
      get { return setState; }
      set { setState = value; }
    }

    private string entityName;

    public string EntityName
    {
      get { return entityName; }
      set { entityName = value; }
    }



    [DisplayName("Exclusão Lógica"), Description("Desabilita registros ao invés de excluir")]
    public bool LogicalExclusion { get; set; }

    protected string wsdlLocation;
    [Category("Web Service"), DisplayName("Servidor"), Description("Endereço do servidor do CRM 2011")]
    public string WsdlLocation
    {
      get { return wsdlLocation; }
      set
      {
        if (wsdlLocation != value)
        {
          wsdlLocation = value;
          Reset();
        }
      }
    }

    public override void Reset()
    {
      base.Reset();
      exceptionList = new ConcurrentQueue<string>();
    }


    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private ServiceManager service;
    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private ConcurrentQueue<String> exceptionList;

    public bool MultiThread { get; set; }
    private int errorCount;

    protected override IEntity doExecute()
    {

      exceptionList = new ConcurrentQueue<string>();
      InitializeService();

      DataView view = Entrada.View;

      if (!String.IsNullOrWhiteSpace(ResultColumn))
      {
        if (!view.Table.Columns.Contains(ResultColumn))
          view.Table.Columns.Add(ResultColumn, typeof(string));
      }

      errorCount = 0;
      insertCount = 0;
      updateCount = 0;
      deleteCount = 0;

      try
      {
        if (ApplyUpdates)
        {
          ProcessProxyList(view.ToProxyList(EntityName, DataViewRowState.ModifiedCurrent));
        }
        if (ApplyInserts)
        {
          ProcessProxyList(view.ToProxyList(EntityName, DataViewRowState.Added));
        }
        if (ApplyDeletes)
        {
          ProcessProxyList(view.ToProxyList(EntityName, DataViewRowState.Deleted));
        }
      }
      finally
      {
        if (ApplyInserts)
          Structure.AddToLog(string.Format("{0} registros inseridos com sucesso", insertCount), this);
        if (ApplyUpdates)
          Structure.AddToLog(string.Format("{0} registros atualizados com sucesso", updateCount), this);
        if (ApplyInserts)
          Structure.AddToLog(string.Format("{0} registros excluídos com sucesso", deleteCount), this);

        if (exceptionList.Count > 0)
        {
          int localErrorCount = 0;
          string item = "";
          while (exceptionList.TryDequeue(out item))
          {
            Structure.AddToErrorLog(item, this);
            localErrorCount++;
          }
          Structure.AddToErrorLog(String.Format("Total de erros: {0}", localErrorCount), this);
        }

        exceptionList = new ConcurrentQueue<string>();
      }
      return null;
    }

    private int batchSize;

    public int BatchSize
    {
      get { return batchSize; }
      set { batchSize = value; }
    }

    public bool UseExecMultiple { get; set; }

    private void ProcessProxyList(List<DynamicEntityProxy> list)
    {
      int recordCount = list.Count;
      int firstRecord = 0;
      int batchNumber = 0;
      int batchSize = BatchSize;

      if (batchSize == 0)
        batchSize = recordCount;

      int batchCount;

      if (BatchSize != 0)
        batchCount = Convert.ToInt32(Math.Ceiling((decimal)(recordCount) / (decimal)(BatchSize)));
      else
        batchCount = 1;


      Stopwatch sw = new Stopwatch();


      for (firstRecord = 0; firstRecord < recordCount; firstRecord += batchSize)
      {
        batchNumber++;


        int lastRecord = firstRecord + batchSize;
        if (lastRecord > recordCount)
          lastRecord = recordCount;

        InitializeService();

        sw.Start();
        //if (UseExecMultiple)
        //  ExecMultiple(list, firstRecord, lastRecord);
        //else
          ExecSingle(list, firstRecord, lastRecord);
        sw.Stop();

        int recordsProccessed = lastRecord - firstRecord;

        int remainingBatches = batchCount - batchNumber;
        long ticks = sw.Elapsed.Ticks;
        long remainingTicks = ticks * remainingBatches;

        Structure.AddToLog(string.Format("Lote {0} de {1} -- {2} Registros processados -- Tempo: {3} -- Tempo restante estimado: {4}",
          batchNumber, batchCount, recordsProccessed, sw.Elapsed, new TimeSpan(remainingTicks)), this);        

        sw.Reset();

        Application.DoEvents();

        if(Structure.Stop)
        {
          Structure.ExecuteStop();          
          break;
        }
      }
    }

    /*

    private void ExecMultiple(List<DynamicEntityProxy> list, int firstRecord, int lastRecord)
    {
      Structure.AddToLog("Preparando a requisição", this);
      ServiceManager localService = new ServiceManager(service);
      localService.TimeOut = new TimeSpan(0, Timeout,0);
      localService.Stateless = true;

      ExecuteMultipleRequest requestWithResults = new ExecuteMultipleRequest()
      {
        // Assign settings that define execution behavior: continue on error, return responses. 
        Settings = new ExecuteMultipleSettings()
        {
          ContinueOnError = true,
          ReturnResponses = true
        },
        // Create an empty organization request collection.
        Requests = new OrganizationRequestCollection()
      };

      Dictionary<OrganizationRequest, DataRow> rows = new Dictionary<OrganizationRequest, DataRow>();

      for (int i = firstRecord; i < lastRecord; i++)
      {
        Microsoft.Xrm.Sdk.Entity entity = list[i].ToEntity(service, false);
        if (list[i].Insert)
        {
          CreateRequest createRequest = new CreateRequest { Target = entity };
          rows[createRequest] = list[i].OriginalRow;
          requestWithResults.Requests.Add(createRequest);
        }
        else if (list[i].Delete)
        {
          DeleteRequest delRequest = new DeleteRequest { Target = new EntityReference(entity.LogicalName, entity.Id) };
          rows[delRequest] = list[i].OriginalRow;
          requestWithResults.Requests.Add(delRequest);
        }
        else
        {
          if (RemoveUnchanged)
          {
            DynamicEntityProxy proxy = list[i];
            RemoveUnchangedFields(proxy, localService);
            if (proxy.Properties.Count != 0)
              entity = proxy.ToEntity(localService, false);
            else
              entity = null;
          }
          if (entity != null)
          {
            UpdateRequest updRequest = new UpdateRequest { Target = entity };
            rows[updRequest] = list[i].OriginalRow;
            requestWithResults.Requests.Add(updRequest);
          }
        }
      }

      // Execute all the requests in the request collection using a single web method call.
      ExecuteMultipleResponse responseWithResults = (ExecuteMultipleResponse)service.ServiceProxy.Execute(requestWithResults);

      // Display the results returned in the responses.
      foreach (var responseItem in responseWithResults.Responses)
      {
        OrganizationRequest requestItem = requestWithResults.Requests[responseItem.RequestIndex];

        if (responseItem.Fault != null)
        {
          StringBuilder sb = new StringBuilder();
          sb.Append(string.Format("Falha na aplicação do registro {0}. ", responseItem.RequestIndex));
          sb.Append("Mensagem Original: ");

          OrganizationServiceFault fault = responseItem.Fault;
          while (fault != null)
          {
            sb.Append(fault.TraceText + "; ");
            fault = fault.InnerFault;
          }

          sb.AppendLine();

          if (requestItem is CreateRequest)
          {
            sb.Append("Dados: ");
            foreach (KeyValuePair<string, object> item in ((CreateRequest)requestItem).Target.Attributes)
            {
              sb.AppendFormat("[{0}] = {1}; ", item.Key, item.Value);
            }
          }
          else if (requestItem is DeleteRequest)
          {
            sb.AppendFormat("ID: {0}", ((DeleteRequest)requestItem).Target.Id);
          }
          else
          {
            sb.AppendFormat("ID: {0}", ((UpdateRequest)requestItem).Target.Id);
          }
          exceptionList.Enqueue(sb.ToString());
        }
        else
        {
          if (rows.ContainsKey(requestItem) && (rows[requestItem] != null))
            rows[requestItem].AcceptChanges();
        }
      }
    }
*/
    private void ExecSingle(List<DynamicEntityProxy> list, int firstRecord, int lastRecord)
    {
      if (MultiThread)
      {
        Parallel.For(firstRecord, lastRecord, (i) => UpdateProxy(list[i]));
      }
      else
      {
        for (int i = firstRecord; i < lastRecord; i++)
        {
          UpdateProxy(list[i]);
        }
      }
    }

    public bool UseSettingsInstaller { get; set; }
    public bool ClaimsBased { get; set; }

    private void InitializeService()
    {

      if (service != null)
        service.Dispose();
      if (!UseSettingsInstaller)
      {
        SetupConfigs();
        ClientCredentials serviceCredentials = new ClientCredentials();

        if (ClaimsBased)
        {
          serviceCredentials.UserName.UserName = WebCredentials.Domain + "\\" + WebCredentials.UserName;
          serviceCredentials.UserName.Password = WebCredentials.Password;
          serviceCredentials.Windows.ClientCredential = WebCredentials;
          serviceCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
        }
        else
        {
          serviceCredentials.Windows.ClientCredential = WebCredentials;
        }

        service = new ServiceManager(Organization, serviceCredentials, WsdlLocation, UseHttps);
        service.Online = ClaimsBased;


      }
      else
      {
        if (ClaimsBased)
          service = new ServiceManager(Organization, UseHttps, ClaimsBased);
        else
          service = new ServiceManager(Organization);
      }

      if ((!String.IsNullOrEmpty(WsdlLocation)) && WsdlLocation.Contains("?wsdl"))
        service.ServerAddress = WsdlLocation.Replace("?wsdl", ""); ;

      service.TimeOut = new TimeSpan(0, Timeout, 0);
      service.Stateless = true;

      idPropertyName = service.GetIdPropertyName(EntityName);
    }

    public int FloatPrecision { get; set; }

    [Description("Timeout em minutos")]
    public int Timeout { get; set; }

    [Description("Remove valores que não foram atualizados da chamada do serviço")]
    public bool RemoveUnchanged { get; set; }

    [NonSerialized]
    private int insertCount;
    [NonSerialized]
    private int updateCount;
    [NonSerialized]
    private int deleteCount;
    [NonSerialized]
    private string idPropertyName;

    public bool LogDifferences { get; set; }

    public bool ApplyNulls { get; set; }

    public int DelStateCode { get; set; }
    public int DelStatusCode { get; set; }

    private void UpdateProxy(DynamicEntityProxy proxy)
    {
      ServiceManager localService = new ServiceManager(service);
      localService.Stateless = true;
      RemoveUnchangedFields(proxy, localService);

      try
      {
        if ((!((proxy.Properties.Count == 1) && (proxy.Properties.ContainsKey(idPropertyName)))) || proxy.Delete || proxy.Insert)
        {

          proxy.SetState = (SetState && (proxy.Properties["statecode"] != null));
          Guid? tmpId = null;
          if (proxy.Delete && LogicalExclusion)
          {
            proxy["statecode"] = DelStateCode;
            proxy["statuscode"] = DelStatusCode;
            localService.SetState(proxy);
          }
          else
            tmpId = localService.UpdateProxy(proxy, ApplyNulls);

          if (proxy.Insert)
          {
            insertCount++;
            if ((!String.IsNullOrWhiteSpace(ResultColumn)) && (proxy.OriginalRow != null))
            {
              proxy.OriginalRow[ResultColumn] = tmpId;
            }
          }
          else if (proxy.Delete)
            deleteCount++;
          else
            updateCount++;
        }


      }
      catch (Exception ex)
      {
        lock (this)
        {
          AddToLog(proxy, ex);
          InitializeService();
          errorCount++;

          if (errorCount > MaxErrors)
            throw;
        }
      }
    }

    private void RemoveUnchangedFields(DynamicEntityProxy proxy, ServiceManager localService)
    {

      if ((RemoveUnchanged) && ((!proxy.Insert) && (!proxy.Delete)))
      {

        Dictionary<string, string> camposAlterados = new Dictionary<string, string>();

        foreach (KeyValuePair<string, object> originalValue in proxy.OriginalValues)
        {
          if ((
            (((originalValue.Value == null) || (Convert.IsDBNull(originalValue.Value))) && ((proxy[originalValue.Key] == null) || (Convert.IsDBNull(proxy[originalValue.Key])))) ||
            ((originalValue.Value != null) && (originalValue.Value.Equals(proxy[originalValue.Key]))) ||
            ((proxy[originalValue.Key] is DateTime) && (IsSameDate(originalValue.Value, proxy[originalValue.Key]))) ||
            (((proxy[originalValue.Key] is float) || (proxy[originalValue.Key] is decimal)) && (IsSameNumber(originalValue.Value, proxy[originalValue.Key]))) ||
            (Convert.ToString(originalValue.Value).Trim() == Convert.ToString(proxy[originalValue.Key]).Trim()) ||
            (((proxy[originalValue.Key] == null) || string.IsNullOrWhiteSpace(Convert.ToString(proxy[originalValue.Key]))) && (!ApplyNulls))) &&
            (originalValue.Key != idPropertyName))
          {
            if (proxy.Properties.ContainsKey(originalValue.Key))
              proxy.Properties.Remove(originalValue.Key);
          }
          else
          {
            if ((!camposAlterados.ContainsKey(originalValue.Key)) && (LogDifferences) && (originalValue.Key != idPropertyName))
            {
              camposAlterados[originalValue.Key] = string.Format("{0} --> {1}", originalValue.Value, proxy[originalValue.Key]);
            }
          }
        }

        if (camposAlterados.Count != 0)
        {
          StringBuilder sb = new StringBuilder();
          sb.Append("       Alteração de Registro: Id=" + proxy.Id.ToString());
          foreach (KeyValuePair<string, string> item in camposAlterados)
          {
            sb.AppendFormat(" {0}:{1};", item.Key, item.Value);
          }

          Structure.AddToLog(sb.ToString(), this);
        }

        List<string> validProperties = localService.GetRelevantProperties(EntityName, proxy.Properties.Select(x => x.Key).ToList());
        List<string> propertiesToRemove = proxy.Properties.Select(x => x.Key).Where(y => !validProperties.Contains(y)).ToList();


        foreach (string item in propertiesToRemove)
        {
          proxy.Properties.Remove(item);
        }
      }
    }

    private bool IsSameNumber(object value1, object value2)
    {
      if (Convert.IsDBNull(value1) || (value1 == null) || Convert.IsDBNull(value2) || (value2 == null) || (FloatPrecision == 0))
        return false;

      double f1 = Convert.ToDouble(value1);
      double f2 = Convert.ToDouble(value2);

      string str1 = Math.Round(f1, FloatPrecision).ToString();
      string str2 = Math.Round(f2, FloatPrecision).ToString();

      return (str1 == str2);
    }

    [Description("Tratar campos data/hora como apenas data para efeito de testes de update")]
    public bool TreatDateTimeAsDate { get; set; }

    private bool IsSameDate(object value1, object value2)
    {
      if (!TreatDateTimeAsDate)
        return false;

      if (Convert.IsDBNull(value1) || (value1 == null) || Convert.IsDBNull(value2) || (value2 == null))
        return false;

      DateTime dt1 = Convert.ToDateTime(value1).ToLocalTime();
      DateTime dt2 = Convert.ToDateTime(value2);

      return ((dt1.Day == dt2.Day) && (dt1.Month == dt2.Month) && (dt1.Year == dt2.Year));
    }

    private void AddToLog(DynamicEntityProxy proxy, Exception ex)
    {
      StringBuilder builder = new StringBuilder();
      GetFullExceptionMessage(ex, builder);


      exceptionList.Enqueue(builder.ToString());
    }




    private void GetFullExceptionMessage(Exception ex, StringBuilder sb)
    {
      sb.AppendFormat("{0};", ex.Message);
      if (ex.InnerException != null)
        GetFullExceptionMessage(ex.InnerException, sb);
    }


    public Boolean UseHttps { get; set; }

    #region Explicit interface
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    NetworkCredential IBaseWebServiceOperation.Credentials { get { return null; } set { } }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    System.Reflection.MethodInfo IBaseWebServiceOperation.Method { get { return null; } set { } }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    System.Reflection.MethodInfo[] IBaseWebServiceOperation.MethodList
    {
      get
      {
        return null;
      }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    int IBaseWebServiceOperation.Port
    { get { return 0; } set { } }
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    string IBaseWebServiceOperation.ProxyServer
    { get { return null; } set { } }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    bool IBaseWebServiceOperation.UseDefaultCredentials
    { get { return true; } set { } }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    bool IBaseWebServiceOperation.UseWebProxy
    { get { return false; } set { } }

    Type IBaseWebServiceOperation.GetRemoteType(string typeName)
    {
      return null;
    }

    #endregion
  }
}
