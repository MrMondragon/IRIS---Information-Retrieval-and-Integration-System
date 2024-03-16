using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Connections;
using System.ComponentModel;
using System.Drawing.Design;
using System.CodeDom.Compiler;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;
using Runner;
using Iris.PropertyEditors;
using Iris.Interfaces;
using System.Reflection;
using Iris.Runtime.Core;
using System.Xml;
using Iris.Runtime.Model.PropertyEditors.Interfaces;
using System.Windows.Forms;
using System.Web;
using System.Web.Services;
using Iris.Runtime.Model.PropertyEditors;
using System.Drawing;
using Databridge.Engine;
using Databridge.Interfaces;
using System.Linq;
using Iris.Runtime.Model.Operations.SchemaOperations;

namespace Iris.Runtime.Model.BaseObjects
{
  [Serializable]
  public class Structure : IStructure, IAssemblyUser, ILoggable
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Structure"/> class.
    /// </summary>
    public Structure()
    {
      operations = new IrisList<IOperation>("operations");
      connections = new IrisList<DynConnection>("connections");
      scalarVars = new IrisList<ScalarVar>("scalarVars");
      resultSets = new IrisList<ResultSet>("resultSets");
      schemas = new IrisList<SchemaEntity>("schemas");
      Log = null;
      ClearOnRestart = true;
      ClassName = "DynStructure";
    }

    [NonSerialized]
    private IProccessLog log;
    /// <summary>
    /// Gets or sets the log.
    /// Objeto de log da estrutura
    /// </summary>
    /// <value>The log.</value>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IProccessLog Log
    {
      get { return log; }
      set { log = value; }
    }

    [NonSerialized]
    private bool stop;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Stop
    {
      get { return stop; }
      set
      {
        if (value && running)
          stop = value;
      }
    }

    public void ExecuteStop()
    {
      stop = false;
      AddToLog("---------------------------> Processo Interrompido <---------------------------", null);
    }

    private Type dataType;
    /// <summary>
    /// Gets or sets the type of the data.
    /// O tipo para o qual o resultado da estrutura será convertido em um web-service
    /// </summary>
    /// <value>The type of the data.</value>
    [Editor(typeof(TypeSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Tipo"), Category("Design"), Description("Tipo de retorno da execução da estrutura.")]
    public Type DataType
    {
      get
      {
        if (dataType == null)
          dataType = typeof(System.String);

        return dataType;
      }
      set { dataType = value; }
    }

    [NonSerialized]
    private DataSet dataset;
    /// <summary>
    /// Gets or sets the dataset.
    /// Dataset interno da estrutura
    /// </summary>
    /// <value>The dataset.</value>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataSet Dataset
    {
      get
      {
        if (dataset == null)
        {
          dataset = new DataSet();
          dataset.DataSetName = ClassName;
        }
        return dataset;
      }
      set
      {
        if (value != null)
        {
          dataset = value;
          Dataset.DataSetName = ClassName;
          foreach (ResultSet rs in ResultSets)
          {
            try
            {
              if ((rs.Table != null) && (rs.Table.DataSet != Dataset))
              {
                if (dataset.Tables.Contains(rs.Table.TableName))
                {
                  if (rs.InMemory)
                    rs.Table = dataset.Tables[rs.Table.TableName];
                  else
                    rs.SetTable(dataset.Tables[rs.Table.TableName]);
                }
                else
                  rs.SetTable(null);
              }
            }
            catch (Exception e)
            {
              AddToLog(rs.Name, e, rs);
            }
          }

          foreach (SchemaEntity schema in Schemas)
          {
            schema.ClearTables();
          }
        }
      }
    }


    /// <summary>
    /// Clears the dataset.
    /// </summary>
    public void ClearDataset()
    {
      foreach (DataTable table in Dataset.Tables)
      {
        try
        {
          table.Clear();
          while (table.ParentRelations.Count > 0)
          {
            table.ParentRelations.RemoveAt(0);
          }

          while (table.ChildRelations.Count > 0)
          {
            table.ChildRelations.RemoveAt(0);
          }
        }
        catch (Exception e)
        {
          AddToLog(table.TableName, e, null);
        }
      }

      //Limpa tabelas dos rs's
      foreach (ResultSet rs in ResultSets)
      {
        try
        {
          rs.Clear();
          DataTable table = rs.Table;
          if (table != null)
          {

            try
            {
              if (table.DataSet == Dataset)
                Dataset.Tables.Remove(table);
              else if (Dataset.Tables.Contains(table.TableName))
                Dataset.Tables.Remove(table.TableName);
            }
            catch { }
            table.Dispose();
          }
          rs.Table = null;

        }
        catch (Exception e)
        {
          AddToLog(rs.Name, e, rs);
        }
      }

      foreach (SchemaEntity schema in Schemas)
      {
        try
        {
          schema.ClearTables();
        }
        catch (Exception e)
        {
          AddToLog(schema.Name, e, schema);
        }
      }

      Dataset.Clear();
      Dataset.AcceptChanges();
      Dataset.Dispose();
      Dataset = null;

      if (CollectOnClear)
        GC.Collect();
    }

    private Dictionary<string, string> assemblies;
    /// <summary>
    /// Gets or sets the assemblies.
    /// Assembly references da estrutura, que são passadas ao compilador dinâmico
    /// </summary>
    /// <value>The assemblies.</value>
    [Editor(typeof(AssemblyListEditor), typeof(UITypeEditor))]
    [DisplayName("Assemblies"), Category("Estrutura"), Description("Assembly references da estrutura, que são passadas ao compilador dinâmico")]
    public Dictionary<string, string> Assemblies
    {
      get
      {
        if (assemblies == null)
        {
          assemblies = new Dictionary<string, string>();
          StructureBuilder.AddBaseAssemblies(new List<string>(), this);
        }
        return assemblies;
      }
      set { assemblies = value; }
    }

    [NonSerialized]
    private Dictionary<string, string> typeLookupTable;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Dictionary<string, string> TypeLookupTable
    {
      get
      {
        if (typeLookupTable == null)
        {
          typeLookupTable = new Dictionary<string, string>();
          Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
          foreach (Assembly assembly in asms)
          {
            if (assembly.FullName.ToLower().StartsWith("iris"))
            {
              foreach (Type t in assembly.GetTypes())
              {
                if (t.IsSubclassOf(typeof(Operation)) && (!t.IsAbstract))
                {
                  typeLookupTable[t.FullName] = assembly.FullName;
                }
              }
            }
          }
        }
        return typeLookupTable;
      }
      set { typeLookupTable = value; }
    }

    private string description;
    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    [DisplayName("Descrição"), Category("Design"), Description("Descrição opcional da estrutura")]
    public string Description
    {
      get { return description; }
      set { description = value; }
    }

    private string displayName;
    [DisplayName("Nome de apresentação"), Category("Plugin"), Description("Nome pelo qual a estrutura será identificada quando compilada como plugin.")]
    public string DisplayName
    {
      get { return displayName; }
      set { displayName = value; }
    }

    private string category;
    [DisplayName("Categoria"), Category("Plugin"), Description("Categoria da estrutura compilada como plugin na barra de ferramentas")]
    public string Category
    {
      get { return category; }
      set { category = value; }
    }

    private Image icon;
    [DisplayName("Ícone"), Category("Design"), Description("Imagem de representação da estrutura")]
    public Image Icon
    {
      get { return icon; }
      set { icon = value; }
    }

    /// <summary>
    /// Adiciona uma entrada regular ao log de execução
    /// </summary>
    /// <param name="logEntry">The log entry.</param>
    public void AddToLog(string logEntry, IOperation operation)
    {
      if ((Log != null) && (!logDisabled))
      {
        Log.AddToLog(logEntry, operation);
      }
    }


    public void AddToErrorLog(string logEntry, IOperation operation)
    {
      if ((Log != null) && (!logDisabled))
      {
        Log.AddToErrorLog(logEntry, operation);
      }
    }

    /// <summary>
    /// Adiciona uma entrada de excessão ao log de execução
    /// </summary>
    /// <param name="_name">The _name.</param>
    /// <param name="e">The e.</param>
    public void AddToLog(string _name, Exception e, IOperation operation)
    {
      if ((Log != null) && (!logDisabled))
      {
        Log.AddToLog(_name, e, operation);
      }
      else
        throw e;
    }

    [NonSerialized]
    private bool logDisabled;

    public void DisableLog()
    {
      logDisabled = true;
    }

    public void EnableLog()
    {
      logDisabled = false;
    }

    private Operation startPoint;
    /// <summary>
    /// Gets or sets the start point.
    /// </summary>
    /// <value>The start point.</value>
    [Editor(typeof(StartPointEditor), typeof(UITypeEditor))]
    [DisplayName("Start Point"), Category("Estrutura"), Description("Ponto inicial da execução da estrutura")]
    public Operation StartPoint
    {
      get { return startPoint; }
      set
      {
        if (startPoint != value)
        {
          if (BeforeStartPointChanged != null)
            BeforeStartPointChanged(this, new EventArgs());

          startPoint = value;

          if (AfterStartPointChanged != null)
            AfterStartPointChanged(this, new EventArgs());
        }
      }
    }

    private Operation outputPoint;
    /// <summary>
    /// Gets or sets the output point.
    /// </summary>
    /// <value>The output point.</value>
    [Editor(typeof(StartPointEditor), typeof(UITypeEditor))]
    [DisplayName("Output Point"), Category("Estrutura"), Description("Ponto de saída da estrutura")]
    public Operation OutputPoint
    {
      get { return outputPoint; }
      set
      {
        if (outputPoint != value)
        {
          if (BeforeOutputPointChanged != null)
            BeforeOutputPointChanged(this, new EventArgs());

          outputPoint = value;

          if (AfterOutputPointChanged != null)
            AfterOutputPointChanged(this, new EventArgs());
        }
      }
    }

    private Operation defaultExceptionHandler;
    [Editor(typeof(StartPointEditor), typeof(UITypeEditor))]
    [DisplayName("Default Exeption Handler"), Category("Estrutura"), Description("Ponto padrão de manipulação de erros")]
    public Operation DefaultExceptionHandler
    {
      get { return defaultExceptionHandler; }
      set
      {
        if (defaultExceptionHandler != value)
        {
          if (BeforeDexChanged != null)
            BeforeDexChanged(this, EventArgs.Empty);

          defaultExceptionHandler = value;

          if (AfterDexChanged != null)
            AfterDexChanged(this, EventArgs.Empty);
        }
      }
    }

    private bool isHandlingException;

    public bool IsHandlingException
    {
      get { return isHandlingException; }
      set { isHandlingException = value; }
    }


    private IEntity result;
    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    /// <value>The result.</value>
    [DisplayName("Variável de Retorno"), Category("Estrutura"), Description("Variável contendo o valor que será retornado ao final da execução da estrutura")]
    [Editor(typeof(EndPointEditor), typeof(UITypeEditor))]
    public IEntity Result
    {
      get { return result; }
      set
      {
        if (result != value)
        {
          if (BeforeResultPointChanged != null)
            BeforeResultPointChanged(this, new EventArgs());

          result = value;

          if (AfterResultPointChanged != null)
            AfterResultPointChanged(this, new EventArgs());
        }
      }
    }

    private Operation runningOper;
    /// <summary>
    /// Gets or sets the running oper.
    /// </summary>
    /// <value>The running oper.</value>
    [ReadOnly(true)]
    [DisplayName("Ponto em execução"), Category("Estrutura"), Description("Informa qual será a próxima operação a ser executada na estrutura")]
    public Operation RunningOper
    {
      get
      {
        if (runningOper == null)
          runningOper = StartPoint;
        return runningOper;
      }
      set { runningOper = value; }
    }

    [NonSerialized]
    internal bool debug;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
    internal bool Debug
    {
      get { return debug; }
      private set { debug = value; }
    }


    IEntity IStructure.Execute(bool _debug)
    {
      return this.Execute(_debug);
    }

    [NonSerialized]
    private bool running;

    /// <summary>
    /// Método de execução da estrutura
    /// </summary>
    /// <param name="_debug">Caso seja <c>true</c>, indica que a execução está ocorrendo em modo de debug e que os breakpoints estabelecidos serão respeitados</param>
    /// <returns></returns>
    public IEntity Execute(bool _debug)
    {
      IsHandlingException = false;
      running = true;
      try
      {
        DateTime t1 = DateTime.Now;
        AddToLog("Início da execução do processo " + ClassName, null);
        Debug = _debug;


        try
        {
          inStep = false;
          if (RunningOper != null)
            RunningOper.Execute();
        }
        finally
        {
          if (!Debug)
            RunningOper = StartPoint;

          Debug = false;
        }
        TimeSpan ts = DateTime.Now - t1;
        AddToLog("Término da execução do processo " + ClassName + "       Duração:" + ts.ToString(), null);
        foreach (DynConnection connection in Connections)
        {
          connection.Close();
        }
      }
      finally
      {
        IsHandlingException = false;
        running = false;
      }
      return Result;
    }

    [NonSerialized]
    private bool inStep;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool InStep
    {
      get { return inStep; }
      set { inStep = value; }
    }

    /// <summary>
    /// Restarts this instance.
    /// </summary>
    public void Restart()
    {
      foreach (Operation oper in operations)
      {
        try
        {
          oper.Reset();
        }
        catch (Exception e)
        {
          AddToLog(oper.DisplayText, e, oper);
        }
      }

      foreach (ScalarVar sVar in ScalarVars)
      {
        try
        {
          sVar.Reset();
        }
        catch (Exception e)
        {
          AddToLog(sVar.DisplayText, e, sVar);
        }
      }

      foreach (DynConnection connection in Connections)
      {
        //inserido para garantir compatibilidade retroativa com projetos criados antes da implementação
        //do schema temporário em tabelas com erro
        connection.Structure = this;
      }

      if (ClearOnRestart)
        ClearDataset();

      RunningOper = StartPoint;
    }

    private bool clearOnRestart;
    [DisplayName("Clear On Restart"), Category("Estrutura"), Description("Define se a estrutura deve limpar seu dataset ao ser reiniciada")]
    public bool ClearOnRestart
    {
      get { return clearOnRestart; }
      set { clearOnRestart = value; }
    }

    private bool collectOnClear;
    [DisplayName("Colect On Clear"), Category("Estrutura"), Description("Define se a estrutura deve forçar o processo de Grabage Collection ao limpar seu dataset")]
    public bool CollectOnClear
    {
      get { return collectOnClear; }
      set { collectOnClear = value; }
    }

    /// <summary>
    /// Steps this instance.
    /// </summary>
    public void Step()
    {
      inStep = true;

      if (runningOper == null)
        runningOper = StartPoint;

      if (RunningOper != null)
      {
        if ((RunningOper.Status == ExecutionStatus.WaitingExecution) || (RunningOper.Status == ExecutionStatus.PreparingInputs))
          RunningOper.Execute();
      }
    }

    private IrisList<IOperation> operations;
    /// <summary>
    /// Lista de operações da estrutura
    /// </summary>
    /// <value>The operations.</value>
    [Browsable(false)]
    public IrisList<IOperation> Operations
    {
      get
      {
        if (operations == null)
          operations = new IrisList<IOperation>("operations");
        return operations;
      }
    }

    private IrisList<DynConnection> connections;
    /// <summary>
    /// Lista de conexões da estrutura
    /// </summary>
    /// <value>The connections.</value>
    [Browsable(false)]
    public IrisList<DynConnection> Connections
    {
      get
      {
        if (connections == null)
          connections = new IrisList<DynConnection>("connections");
        return connections;
      }
    }

    private IrisList<ScalarVar> scalarVars;
    /// <summary>
    /// Lista de variáveis escalares da estrutura
    /// </summary>
    /// <value>The scalar vars.</value>
    [Browsable(false)]
    public IrisList<ScalarVar> ScalarVars
    {
      get
      {
        if (scalarVars == null)
          scalarVars = new IrisList<ScalarVar>("scalarVars");
        return scalarVars;
      }
    }

    private IrisList<ResultSet> resultSets;
    /// <summary>
    /// Lista de resultsets da estrutura
    /// </summary>
    /// <value>The result sets.</value>
    [Browsable(false)]
    public IrisList<ResultSet> ResultSets
    {
      get
      {
        if (resultSets == null)
          resultSets = new IrisList<ResultSet>("resultSets");
        return resultSets;
      }
    }

    private IrisList<SchemaEntity> schemas;
    /// <summary>
    /// Lista de file entities da estrutura
    /// </summary>
    /// <value>The file entities.</value>
    [Browsable(false)]
    public IrisList<SchemaEntity> Schemas
    {
      get
      {
        if (schemas == null)
          schemas = new IrisList<SchemaEntity>("schemas");
        return schemas;
      }
    }

    private string className;
    /// <summary>
    /// Gets or sets the name of the class.
    /// </summary>
    /// <value>The name of the class.</value>
    [DisplayName("Nome da Classe"), Category("Estrutura"), Description("Nome que será atribuído à classe compilada da estrutura")]
    public string ClassName
    {
      get { return className; }
      set
      {
        className = value;
        Dataset.DataSetName = className;
      }
    }

    [field: NonSerialized()]
    public event EventHandler BeforeStartPointChanged;
    [field: NonSerialized()]
    public event EventHandler AfterStartPointChanged;

    [field: NonSerialized()]
    public event EventHandler BeforeOutputPointChanged;
    [field: NonSerialized()]
    public event EventHandler AfterOutputPointChanged;

    [field: NonSerialized()]
    public event EventHandler BeforeResultPointChanged;
    [field: NonSerialized()]
    public event EventHandler AfterResultPointChanged;

    [field: NonSerialized()]
    public event EventHandler BeforeDexChanged;
    [field: NonSerialized()]
    public event EventHandler AfterDexChanged;


    /// <summary>
    /// Retorna um objeto em uma lista a partir do nome
    /// </summary>
    /// <param name="objName">Name of the obj.</param>
    /// <param name="objList">The obj list.</param>
    /// <returns></returns>
    public object GetObject(string objName, string objList)
    {
      switch (objList)
      {
        case "operations": return Operations.FindByName(objName);
        case "connections": return Connections.FindByName(objName);
        case "scalarVars": return ScalarVars.FindByName(objName);
        case "resultSets": return ResultSets.FindByName(objName);
        case "schemas": return Schemas.FindByName(objName);
      }
      return null;
    }

    /// <summary>
    /// Retorna um objeto da estrutura a partir do nome
    /// </summary>
    /// <param name="objName">Name of the obj.</param>
    /// <returns></returns>
    public object GetObject(string objName)
    {
      object result = GetObject(objName, "operations");
      if (result == null)
        result = GetObject(objName, "connections");
      if (result == null)
        result = GetObject(objName, "scalarVars");
      if (result == null)
        result = GetObject(objName, "resultSets");
      if (result == null)
        result = GetObject(objName, "schemas");
      return result;
    }

    public bool Contains(string objName)
    {
      return GetObject(objName) == null;
    }

    /// <summary>
    /// Retorna o próximo nome válido para um identificador, a partir do nome informado
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns></returns>
    internal string GetValidName(string name)
    {
      List<string> names = new List<string>();

      foreach (Operation op in Operations)
      {
        names.Add(op.Name);
      }
      foreach (DynConnection con in Connections)
      {
        names.Add(con.Name);
      }
      foreach (ScalarVar gv in ScalarVars)
      {
        names.Add(gv.Name);
      }
      foreach (ResultSet rs in ResultSets)
      {
        names.Add(rs.Name);
      }
      foreach (SchemaEntity fe in Schemas)
      {
        names.Add(fe.Name);
      }

      string tempName = name;
      int i = 1;

      while (names.Contains(tempName))
      {
        tempName = name + i.ToString();
        i++;
      }

      return tempName;
    }

    public ExecutionContext GetContext()
    {
      ExecutionContext context = new ExecutionContext();
      context.Dataset = this.Dataset;
      context.Parameters = new Dictionary<string, object>();
      context.Variables = new Dictionary<string, object>();
      context.Objects = new Dictionary<string, object>();

      foreach (ScalarVar sVar in this.ScalarVars)
      {
        context.Variables[sVar.Name] = sVar.RawValue;
      }

      foreach (Operation oper in this.Operations)
      {
        context.Objects[oper.Name] = oper;
      }

      foreach (DynConnection connection in this.Connections)
      {
        context.Objects[connection.Name] = connection;
      }

      foreach (SchemaEntity schema in this.Schemas)
      {
        context.Objects[schema.Name] = schema;
      }

      return context;
    }

    public void RefreshSchemas()
    {
      if (this.Schemas.Count > 0)
      {
        foreach (SchemaEntity se in this.Schemas)
          se.RefreshResultSets();
      }
    }

    #region IStructure Members

    IDataConnection[] IStructure.Connections
    {
      get
      {
        return (IDataConnection[])Connections.ToArray();
      }
    }

    ISchemaEntity[] IStructure.Schemas
    {
      get
      {
        return (ISchemaEntity[])Schemas.ToArray();
      }
    }

    IResultSet[] IStructure.ResultSets
    {
      get
      {
        return (IResultSet[])ResultSets.ToArray();
      }
    }

    IScalarVar[] IStructure.ScalarVars
    {
      get
      {
        return (IScalarVar[])ScalarVars.ToArray();
      }
    }

    IOperation[] IStructure.Operations
    {
      get
      {
        return (IOperation[])Operations.ToArray();
      }
    }
    public DynConnection GetConnection(string conName)
    {
      return connections.FindByName(conName);
    }

    public IResultSet GetResultSet(string rsName)
    {
      return resultSets.FindByName(rsName);
    }

    public IScalarVar GetScalarVar(string varname)
    {
      return scalarVars.FindByName(varname);
    }

    public IOperation GetOperation(string operName)
    {
      return operations.FindByName(operName);
    }

    IOperation IStructure.RunningOper
    {
      get { return this.runningOper; }
      set { this.runningOper = (Operation)value; }
    }

    IDataConnection IStructure.GetConnection(string conName)
    {
      return GetConnection(conName);
    }
    #endregion


    #region IStructure Members


    public string GetBaseAccessorCode()
    {
      return StructureBuilder.GetBaseAccessorCode(this);
    }

    #endregion

    public object this[string objName]
    {
      get
      {
        return GetObject(objName);
      }

      set
      {
        object result = GetObject(objName);
        if (result != null)
        {
          if (result is DynConnection)
          {
            ((DynConnection)result).ConnectionString = Convert.ToString(value);

            List<string> csParts = Convert.ToString(value).Split(';').ToList();

            string dataSource = csParts.Where(x => x.ToLower().Contains("data source=")).FirstOrDefault();

            string catalog = csParts.Where(x => x.ToLower().Contains("initial catalog=") ||
              x.ToLower().Contains("database=")).FirstOrDefault();

            string message = (string.IsNullOrEmpty(dataSource) && string.IsNullOrEmpty(catalog)) ? Convert.ToString(value) : dataSource + ";" + catalog;

            AddToLog(String.Format("Conexão {1} apontada para {0}", message, objName), null);

          }
          else if (result is ScalarVar)
          {
            ((ScalarVar)result).RawValue = value;
            AddToLog(String.Format("Valor {0} atribuído à variável {1}", value, objName), null);
          }
          else if (result is SchemaEntity)
          {
            ((SchemaEntity)result).FileName = Convert.ToString(value);
            AddToLog(String.Format("Caminho {0} atribuído ao schema {1}", value, objName), null);
          }
          else if(result is ResultSet)
          {
            ((ResultSet)result).Sql = Convert.ToString(value);
            AddToLog(String.Format("Sentença {0} atribuído ao resultset {1}", value, objName), null);
          }
          else if(result is Operation)
          {
            ((Operation)result).AssignObject(value);
          }
        }
      }
    }


    public void EnableConnections()
    {
      foreach (IDataConnection connection in Connections)
      {
        connection.Disabled = false;
      }
    }

    public void DisableConnections()
    {
      foreach (IDataConnection connection in Connections)
      {
        connection.Disabled = true;
      }
    }

    [Browsable(false)]
    public string Notes { get; set; }

    internal void ApplyBindings()
    {
      IEnumerable<ScalarVar> boundVars = scalarVars.Where(x => x.BindingScope != BindingScope.None);
      boundVars.ToList().ForEach(x => x.ApplyBindings());
    }
  }
}
