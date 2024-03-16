using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.WebOperations;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using Iris.Interfaces;
using System.Data;
using Iris.Runtime.Model.PropertyEditors;
using Databridge.PropertyEditors;
using Iris.Runtime.Model.Operations.NetworkOperations;
using System.Net;
using Iris.PropertyEditors.PropertyEditors;
using System.Web.Services.Protocols;
using Iris.Runtime.NetworkOperations;
using System.Drawing.Design;

namespace Iris.DynamicsServices
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Dynamics Updater")]
  public class DynamicsUpdater : NetworkOperation, IBaseWebServiceOperation
  {
    public DynamicsUpdater(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Configs");
      applyInserts = true;
      applyUpdates = true;
      applyDeletes = false;
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

    private List<CRMPropMapper> mappings;
    [Editor(typeof(GenericListEditor<CRMPropMapper>), typeof(UITypeEditor))]
    public List<CRMPropMapper> Mappings
    {
      get { return mappings; }
      set { mappings = value; }
    }

    public string Organization { get; set; }

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

    private string entityName;

    public string EntityName
    {
      get { return entityName; }
      set { entityName = value; }
    }

    protected string wsdlLocation;
    [Category("Web Service"), DisplayName("WSDL"), Description("Endereço do documento wsdl de definição do webservice")]
    public string WsdlLocation
    {
      get { return wsdlLocation; }
      set
      {
        if (wsdlLocation != value)
        {
          wsdlLocation = value;
          UpdaterHelper.ResetService();
        }
      }
    }

    public override void SetInput(int idx, IOperation input)
    {
      if (input != GetInput(idx))
      {
        base.SetInput(idx, input);
        mappings = new List<CRMPropMapper>();
        if (input != null)
        {
          IResultSet rs = input.EntityValue as IResultSet;
          if ((rs != null) && (rs.Table != null))
          {
            for (int i = 0; i < rs.Table.Columns.Count; i++)
            {
              DataColumn col = rs.Table.Columns[i];
              CRMPropMapper mapper = new CRMPropMapper();
              mapper.FieldName = col.ColumnName;
              switch (Type.GetTypeCode(col.DataType))
              {
                case TypeCode.Boolean:
                  mapper.DataType = PropertyType.Bit;
                  break;
                case TypeCode.Byte:
                  mapper.DataType = PropertyType.Integer;
                  break;
                case TypeCode.Char:
                  mapper.DataType = PropertyType.Text;
                  break;
                case TypeCode.DBNull:
                  mapper.DataType = PropertyType.None;
                  break;
                case TypeCode.DateTime:
                  mapper.DataType = PropertyType.None;
                  break;
                case TypeCode.Decimal:
                  mapper.DataType = PropertyType.Decimal;
                  break;
                case TypeCode.Double:
                  mapper.DataType = PropertyType.Float;
                  break;
                case TypeCode.Empty:
                  mapper.DataType = PropertyType.None;
                  break;
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                  mapper.DataType = PropertyType.Integer;
                  break;
                case TypeCode.SByte:
                  mapper.DataType = PropertyType.Integer;
                  break;
                case TypeCode.Single:
                  mapper.DataType = PropertyType.Float;
                  break;
                case TypeCode.String:
                  mapper.DataType = PropertyType.Text;
                  break;
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                  mapper.DataType = PropertyType.Integer;
                  break;
                default:
                  if (col.DataType == typeof(Guid))
                  {
                    mapper.DataType = PropertyType.Id;
                    mapper.Id = true;
                  }
                  else if (col.DataType == typeof(DateTime))
                    mapper.DataType = PropertyType.DateTime;
                  else
                    mapper.DataType = PropertyType.None;
                  break;
              }
              mappings.Add(mapper);
            }

          }
        }
      }
    }

    protected override Interfaces.IEntity doExecute()
    {
      SetupConfigs();
      DataView view = Entrada.View;

      UpdaterHelper.ResetService();

      Dictionary<string, CRMPropMapper> propMap = mappings.ToDictionary(x => x.FieldName);

      int updOk = 0;
      int updEr = 0;
      int insOk = 0;
      int insEr = 0;
      int delOk = 0;
      int delEr = 0;

      DataView internalView = new DataView(view.Table, view.RowFilter, view.Sort, view.RowStateFilter);

      try
      {
        if (ApplyUpdates)
        {
          internalView.RowStateFilter=DataViewRowState.ModifiedCurrent;
          DataRow[] updatedRows = internalView.Cast<DataRowView>().Select(x=>x.Row).ToArray();

          for (int i = 0; i < updatedRows.Length; i++)
          {
            DataRow row = updatedRows[i];
            try
            {
              UpdaterHelper.UpdateRow(WebCredentials, WsdlLocation, Organization, row, propMap, EntityName);
              updOk++;
              if (!string.IsNullOrEmpty(ResultColumn))
              {
                row[ResultColumn] = "Sucesso";
              }
            }
            catch (SoapException e)
            {
              updEr = HandleSoapException(updEr, row, e);
            }
          }
        }

        if (ApplyInserts)
        {
          internalView.RowStateFilter = DataViewRowState.Added;
          DataRow[] addedRows = internalView.Cast<DataRowView>().Select(x => x.Row).ToArray();

          for (int i = 0; i < addedRows.Length; i++)
          {
            DataRow row = addedRows[i];
            try
            {
              string id = UpdaterHelper.InsertRow(WebCredentials, WsdlLocation, Organization, row, propMap, EntityName);
              insOk++;
              if (!string.IsNullOrEmpty(ResultColumn))
              {
                row[ResultColumn] = string.Format("Sucesso - {0}", id);
              }
            }
            catch (SoapException e)
            {
              insEr = HandleSoapException(insEr, row, e);
            }
          }
        }

        if (ApplyDeletes)
        {
          internalView.RowStateFilter = DataViewRowState.Deleted;
          DataRow[] deletedRows = internalView.Cast<DataRowView>().Select(x => x.Row).ToArray();
          
          for (int i = 0; i < deletedRows.Length; i++)
          {
            DataRow row = deletedRows[i];
            try
            {
              UpdaterHelper.InactivateRow(WebCredentials, WsdlLocation, Organization, row, propMap, EntityName);
              delOk++;
            }
            catch (SoapException e)
            {
              delEr = HandleSoapException(delEr, row, e);
            }
          }
        }
      }
      finally
      {
        Structure.AddToLog(string.Format("{0} registros atualizados com sucesso", updOk), this);
        Structure.AddToLog(string.Format("{0} falhas de atualização", updEr), this);
        Structure.AddToLog(string.Format("{0} registros inseridos com sucesso", insOk), this);
        Structure.AddToLog(string.Format("{0} falhas de inserção", insEr), this);
        if ((updEr > 0) || (insEr > 0))
          this.Status = ExecutionStatus.Failure;
      }
    
      return null;
    }

    private int HandleSoapException(int insEr, DataRow row, SoapException e)
    {
      //row[ResultColumn] = e.Detail.InnerText;
      insEr++;
      if (e.Detail != null)
      {
        Structure.AddToErrorLog(e.Detail.InnerText, this);
        Structure.AddToErrorLog(RowToString(row), this);
        if (!this.IgnoreFailure)
          throw new Exception(e.Detail.InnerText);
      }
      else
      {
        Structure.AddToErrorLog(e.Message, this);
        if (!this.IgnoreFailure)
          throw new Exception(e.Message);
      }
      return insEr;
    }

    private string RowToString(DataRow row)
    {
      StringBuilder builder = new StringBuilder();
      builder.AppendFormat("Registro [{0}]: ", this.EntityName);

      for (int i = 0; i < row.Table.Columns.Count; i++)
      {
        if (!String.IsNullOrEmpty(Convert.ToString(row[i])))
          builder.AppendFormat("{0}={1}, ", row.Table.Columns[i].ColumnName, row[i]);
      }

      string result = builder.ToString().TrimEnd(' ', ',');
      return result;
    }

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
    [ Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    string IBaseWebServiceOperation.ProxyServer
    { get { return null; } set { } }

    [ Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    bool IBaseWebServiceOperation.UseDefaultCredentials
    { get { return true; } set { } }

    [ Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    bool IBaseWebServiceOperation.UseWebProxy 
     { get { return false; } set { } }

    Type IBaseWebServiceOperation.GetRemoteType(string typeName)
    {
      return null;
    }
  }
}
