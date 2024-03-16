using System;
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
using Iris.Runtime.Core.ParserObjects;
using Iris.PropertyEditors;
using Iris.Interfaces;
using Iris.Compression;
using System.Reflection;
using Iris.Runtime.Core;
using Iris.Runtime.Core.ParserEngine;
using Iris.Runtime.Core.ParserEngine.ParserObjects;
using DatasetQuery;
using System.Xml;
using Iris.Runtime.Model.PropertyEditors.Interfaces;
using Iris.Runtime.Core.Conexao;
using System.Windows.Forms;
using System.Web;
using System.Web.Services;
using Iris.Runtime.Model.PropertyEditors;

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
      operations = new IrisList<Operation>("operations");
      connections = new IrisList<DynConnection>("connections");
      scalarVars = new IrisList<ScalarVar>("scalarVars");
      resultSets = new IrisList<ResultSet>("resultSets");
      schemas = new IrisList<SchemaEntity>("schemas");
      Log = null;
      ClassName = "DynStructure";
    }

    [NonSerialized]
    private SqlParser sqlParser;
    /// <summary>
    /// Gets the SQL parser.
    /// </summary>
    /// <value>The SQL parser.</value>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public SqlParser SqlParser
    {
      get
      {
        if (sqlParser == null)
          sqlParser = new SqlParser();
        return sqlParser;
      }
    }

    [NonSerialized]
    private XEvalParser xevalPrarser;
    /// <summary>
    /// Gets the xeval prarser.
    /// </summary>
    /// <value>The xeval prarser.</value>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public XEvalParser XevalPrarser
    {
      get
      {
        if (xevalPrarser == null)
          xevalPrarser = new XEvalParser(this);
        return xevalPrarser;
      }
    }
    [NonSerialized]
    private MergerParser mergerParser;
    /// <summary>
    /// Gets the merger parser.
    /// </summary>
    /// <value>The merger parser.</value>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public MergerParser MergerParser
    {
      get
      {
        if (mergerParser == null)
          mergerParser = new MergerParser(this);
        return mergerParser;
      }
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
          Dataset = new DataSet();
          Dataset.DataSetName = ClassName;
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
        while (table.ParentRelations.Count > 0)
        {
          table.ParentRelations.RemoveAt(0);
        }

        while (table.ChildRelations.Count > 0)
        {
          table.ChildRelations.RemoveAt(0);
        }
      }

      //Limpa tabelas dos rs's
      foreach (ResultSet rs in ResultSets)
      {
        DataTable table = rs.Table;
        rs.Table = null;
        if (table != null)
        {
          table.Clear();
          try { Dataset.Tables.Remove(table); }
          catch { }
          table.Dispose();
        }
      }

      foreach (SchemaEntity schema in Schemas)
      {
        schema.ClearTables();
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
          AddBaseAssemblies(new List<string>());
        }
        return assemblies;
      }
      set { assemblies = value; }
    }

    private string description;
    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    [DisplayName("Descrição"), Category("Estrutura"), Description("Descrição opcional da estrutura")]
    public string Description
    {
      get { return description; }
      set { description = value; }
    }


    /// <summary>
    /// Adiciona uma entrada regular ao log de execução
    /// </summary>
    /// <param name="logEntry">The log entry.</param>
    public void AddToLog(string logEntry, IOperation operation)
    {
      if (Log != null)
      {
        Log.AddToLog(logEntry, operation);
      }
    }


    public void AddToErrorLog(string logEntry, IOperation operation)
    {
      if (Log != null)
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
      if (Log != null)
      {
        Log.AddToLog(_name, e, operation);
      }
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

    private Entity result;
    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    /// <value>The result.</value>
    [DisplayName("Variável de Retorno"), Category("Estrutura"), Description("Variável contendo o valor que será retornado ao final da execução da estrutura")]
    [Editor(typeof(EndPointEditor), typeof(UITypeEditor))]
    public Entity Result
    {
      get { return result; }
      set
      {
        if (result != value)
        {
          if (BeforeEndPointChanged != null)
            BeforeEndPointChanged(this, new EventArgs());

          result = value;

          if (AfterEndPointChanged != null)
            AfterEndPointChanged(this, new EventArgs());
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


    IEntity IStructure.Execute(bool _debug)
    {
      return this.Execute(_debug);
    }

    /// <summary>
    /// Método de execução da estrutura
    /// </summary>
    /// <param name="_debug">Caso seja <c>true</c>, indica que a execução está ocorrendo em modo de debug e que os breakpoints estabelecidos serão respeitados</param>
    /// <returns></returns>
    public Entity Execute(bool _debug)
    {
#if !LockRun
      DateTime t1 = DateTime.Now;
      AddToLog("Início da execução do processo " + ClassName, null);
      debug = _debug;

      try
      {
        inStep = false;
        if (RunningOper != null)
          RunningOper.Execute();
      }
      finally
      {
        if (!debug)
          RunningOper = StartPoint;

        debug = false;
      }
      TimeSpan ts = DateTime.Now - t1;
      AddToLog("Término da execução do processo " + ClassName + "       Duração:" + ts.ToString(), null);
      foreach (DynConnection connection in Connections)
      {
        connection.Close();
      }
#else
      AddToLog("A execução automática de projetos está desabilitada para a versão de demonstração", null);
#endif
      return Result;
    }

    [NonSerialized]
    public bool inStep;

    /// <summary>
    /// Restarts this instance.
    /// </summary>
    public void Restart()
    {
      foreach (Operation oper in operations)
      {
        oper.Reset();
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

      if ((RunningOper.Status == ExecutionStatus.WaitingExecution) || (RunningOper.Status == ExecutionStatus.PreparingInputs))
        RunningOper.Execute();
    }

    private IrisList<Operation> operations;
    /// <summary>
    /// Lista de operações da estrutura
    /// </summary>
    /// <value>The operations.</value>
    [Browsable(false)]
    public IrisList<Operation> Operations
    {
      get
      {
        if (operations == null)
          operations = new IrisList<Operation>("operations");
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
    public event EventHandler BeforeEndPointChanged;
    [field: NonSerialized()]
    public event EventHandler AfterEndPointChanged;

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

    #region IStructure Members

    IDynConnection[] IStructure.Connections
    {
      get
      {
        return (IDynConnection[])Connections.ToArray();
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

    IDynConnection IStructure.GetConnection(string conName)
    {
      return GetConnection(conName);
    }
    #endregion

    #region Geração de código

#if !LockBuild


    /// <summary>
    /// Gera código para a classe principal da estrutura
    /// </summary>
    /// <param name="web">if set to <c>true</c> [web].</param>
    /// <returns></returns>
    public string GetCode(bool web)
    {
      string code =
@"using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;
using System.ComponentModel;";

      if (!web)
        code += @"
using System.Drawing.Design;";
      else
        code += @"
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web;";

      code += @"
using Iris.Interfaces;
using Iris.Compression;
using Iris.Runtime.Core.Connections;
using Iris.PropertyEditors;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.ClientObjects;

namespace Iris.Runtime.Model.BaseObjects
{";
      if (web)
        code += "  [WebService(Namespace = \"http://IrisProject.com/\")]" + @"
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [ToolboxItem(false)]
  public class " + ClassName + ": WebService";
      else
        code += "public class " + ClassName + ": IIrisRunnable, ILoggable";

      code += @"
  {
    private Structure structure;
    [Browsable(false)]
    public IStructure Structure
    {
      get { return structure; }
    }

    public " + ClassName + @"()
    {";

      BinaryFormatter formatter = new BinaryFormatter();
      MemoryStream ms = new MemoryStream();
      formatter.Serialize(ms, this);
      ms.Position = 0;
      byte[] buffer = ms.ToArray();
      ms.Close();

      buffer = Compressor.CompressBytes(buffer, "");

      StringBuilder bufferStr = new StringBuilder((buffer.Length * 4) + 100);


      bufferStr.Append(@"   
      byte[] buffer = new byte[]{");
      for (int i = 0; i < buffer.Length; i++)
      {
        bufferStr.Append(Convert.ToString(buffer[i]) + ",");
      }

      bufferStr.Remove(bufferStr.Length - 1, 1);

      bufferStr.Append("};");

      code += bufferStr.ToString();
      code += @"
      buffer = Compressor.DecompressBytes(buffer," + '"' + '"' + @");
      BinaryFormatter formatter = new BinaryFormatter();
      MemoryStream ms = new MemoryStream(buffer);

      structure = (Structure) formatter.Deserialize(ms);
      ms.Close();
";
      if (web)
        code += " SetupConfigObj();";

      code += @"

    }

    [Browsable(false)]
    public IProccessLog Log
    {
      get { return structure.Log; }
      set { structure.Log = value; }
    }

    public Object Execute()
    {
      structure.Restart();
      structure.Execute(false);
      Object result = structure.Result;
      if(structure.Result != null)
      {
        if(structure.Result is ScalarVar)
          result = ((ScalarVar)structure.Result).RawValue;
        else if(structure.Result is ResultSet)
          result =  ((ResultSet)structure.Result).Table;
      }

      return result;
    }

";
      string structType = DataType.ToString();

      code += GetMethodHead("ExecProc", structType, web) + @"
      structure.Restart();" + GetMethodTail(structType, web);

      code += GetDynamicMethods(web);

      if (!web)
      {
        code += GetAccessors<DynConnection>(connections, true) +
        GetAccessors<ScalarVar>(scalarVars, true) +
        GetAccessors<ResultSet>(resultSets, true);
      }
      else
      {
        code += @"
    private string GetLogDir()
    {        
      string virtualdirectory =" + "\"~/Log/\";" + @"
      string physicaldirectory = HttpContext.Current.Server.MapPath(virtualdirectory);
      if (!Directory.Exists(physicaldirectory))
        Directory.CreateDirectory(physicaldirectory);
      return physicaldirectory;
    }

    private ClientConfig config;

    private void SetupConfigObj()
    {
      string filename = GetLogDir()+" + "\"log_" + ClassName + "_\"+DateTime.Now.Ticks.ToString()+\".config\"" + @";       
      config = ClientConfig.CreateConfig(structure, filename);
    }
      ";
      }

      code += @"

  }
}";
      return code;
    }

    /// <summary>
    /// Gera o código dos métodos dinâmicos da estrutura
    /// </summary>
    /// <param name="web">if set to <c>true</c> [web].</param>
    /// <returns></returns>
    private string GetDynamicMethods(bool web)
    {
      string methods = "";
      foreach (Operation oper in Operations)
      {
        if (oper.ExternalParam)
        {
          string operType = oper.DataType.ToString();
          methods += GetMethodHead(oper.Name, operType, web) + @"
      Structure.RunningOper = (Operation)Structure.GetOperation(" + "\"" + oper.Name + "\");" +
          GetMethodTail(operType, web);
        }
      }
      return methods;
    }

    /// <summary>
    /// Gera a declaração e o início de um método dinâmico
    /// </summary>
    /// <param name="methodName">Name of the method.</param>
    /// <param name="returnType">Type of the return.</param>
    /// <param name="web">if set to <c>true</c> [web].</param>
    /// <returns></returns>
    private string GetMethodHead(string methodName, string returnType, bool web)
    {
      string method;
      string attribute = "";
      string paramList = GetParamList();

      if (web)
        attribute = "[WebMethod]";

      if (!string.IsNullOrEmpty(paramList))
      {
        method = attribute + @"  
    public " + returnType + " " + methodName + "(" + paramList + @")
    {
" + GetParamAssignmentCode();
      }
      else
      {

        method = attribute + @"
    public " + returnType + " " + methodName + @"()
    {";
      }

      return method;
    }

    /// <summary>
    /// Gera o retorno e o fechamento de métodos dinâmicos
    /// </summary>
    /// <param name="returnType">Type of the return.</param>
    /// <param name="web">if set to <c>true</c> [web].</param>
    /// <returns></returns>
    private string GetMethodTail(string returnType, bool web)
    {
      string executor;

      if (web)
        executor = "config.Run()";
      else
        executor = "structure.Execute(false).Value";

      string method = @"
      return (" + returnType + ") Convert.ChangeType(" + executor + ", typeof(" + returnType + @"));
    }
";
      return method;
    }

    /// <summary>
    /// Retorna a lista de parâmetros que devem ser passados aos métodos dinâmicos da estrutura
    /// </summary>
    /// <returns></returns>
    private string GetParamList()
    {
      string paramList = "";

      foreach (ScalarVar var in ScalarVars)
      {
        if (var.ExternalParam)
        {
          string dataType;
          if (var.DataType == null)
            dataType = "object";
          else
            dataType = var.DataType.ToString();
          paramList += dataType + " _" + var.Name + ", ";
        }
      }

      paramList = paramList.Trim().TrimEnd(',');

      return paramList;
    }

    /// <summary>
    /// Retorna o código de atribuição de valor aos parâmetros dos métodos dinâmicos
    /// </summary>
    /// <returns></returns>
    private string GetParamAssignmentCode()
    {
      string paramCode = "";
      foreach (ScalarVar var in ScalarVars)
      {
        if (var.ExternalParam)
        {
          paramCode += "      Structure.GetScalarVar(\"" + var.Name + "\").RawValue = _" + var.Name + ";\r\n";
        }
      }
      paramCode += "\r\n";
      return paramCode;
    }

    /// <summary>
    /// Gera o código da classe Program de um executável
    /// </summary>
    /// <returns></returns>
    public string GetProgramCode()
    {
      string code = @"
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientObjects.WinFormsExe;
using Iris.Interfaces;

namespace Iris.Runtime.Model.BaseObjects
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      IIrisRunnable dynStrcture = new " + ClassName + @"();

      Application.Run(new BaseJobForm(dynStrcture));
    }
  }
}
";
      return code;
    }

    /// <summary>
    /// Compiles the executable.
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <returns></returns>
    public CompilerResults CompileExecutable(string filename)
    {
      List<String> assemblyRefs = new List<string>();
      AddBaseAssemblies(assemblyRefs);
      //System.Windows.Form
      assemblyRefs.Add((typeof(Form)).Assembly.Location);
      //System.Drawing.Design
      assemblyRefs.Add((typeof(UITypeEditor)).Assembly.Location);

      string[] code = new string[2];
      code[0] = GetProgramCode();
      code[1] = GetCode(false);
      CompilerResults results = CodeRunner.CompileExecutable(assemblyRefs, code, filename);
      return results;
    }

    /// <summary>
    /// Compiles the assembly.
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <returns></returns>
    public CompilerResults CompileAssembly(string filename)
    {
      List<String> assemblyRefs = new List<string>();
      AddBaseAssemblies(assemblyRefs);
      //System.Drawing.Design
      assemblyRefs.Add((typeof(UITypeEditor)).Assembly.Location);

      string code = GetCode(false);
      CompilerResults results = CodeRunner.CompileAssembly(assemblyRefs, code, filename);
      return results;
    }

    /// <summary>
    /// Compiles the web service.
    /// </summary>
    /// <param name="outputPath">The output path.</param>
    /// <returns></returns>
    public CompilerResults CompileWebService(string outputPath)
    {
      List<String> assemblyRefs = new List<string>();
      AddBaseAssemblies(assemblyRefs);
      //System.Web
      assemblyRefs.Add((typeof(HttpResponse)).Assembly.Location);
      //System.WebService
      assemblyRefs.Add((typeof(WebService)).Assembly.Location);

      string binPath = outputPath.Substring(0, outputPath.LastIndexOf('\\')) + "\\bin";

      if (!Directory.Exists(binPath))
        Directory.CreateDirectory(binPath);

      string filename = binPath + "\\" + ClassName + ".dll";

      string code = GetCode(true);
      CompilerResults results = CodeRunner.CompileAssembly(assemblyRefs, code, filename);

      using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.Default))
      {
        writer.WriteLine("<%@ WebService Class=\"Iris.Runtime.Model.BaseObjects." + ClassName + "\" %>");
      }

      return results;

    }

#endif

    /// <summary>
    /// Adiciona as referências de assembly da estrutura à lista que será passada ao compilador dinâmico
    /// </summary>
    /// <param name="assemblyRefs">The assembly refs.</param>
    public void AddBaseAssemblies(List<string> assemblyRefs)
    {
      if (assemblies == null)
        assemblies = new Dictionary<string, string>();

      //mscorelib
      assemblies[(typeof(List<string>)).Assembly.ManifestModule.ToString()] = (typeof(List<string>)).Assembly.Location;
      //System
      assemblies[(typeof(Component)).Assembly.ManifestModule.ToString()] = (typeof(Component)).Assembly.Location;
      //Data
      assemblies[(typeof(DataColumn)).Assembly.ManifestModule.ToString()] = (typeof(DataColumn)).Assembly.Location;
      //XML
      assemblies[(typeof(XmlNode)).Assembly.ManifestModule.ToString()] = (typeof(XmlNode)).Assembly.Location;
      //Interfaces
      assemblies[(typeof(IEntity)).Assembly.ManifestModule.ToString()] = (typeof(IEntity)).Assembly.Location;
      //Core
      assemblies[(typeof(CodeRunner)).Assembly.ManifestModule.ToString()] = (typeof(CodeRunner)).Assembly.Location;
      //Model
      assemblies[(typeof(ResultSet)).Assembly.ManifestModule.ToString()] = (typeof(ResultSet)).Assembly.Location;

      foreach (KeyValuePair<string, string> assembly in assemblies)
        if (!assemblyRefs.Contains(assembly.Value))
          assemblyRefs.Add(assembly.Value);

    }

    /// <summary>
    /// Gera propriedades para acesso aos objetos da estrutura por operações de código C#
    /// </summary>
    /// <returns></returns>
    public string GetBaseAccessorCode()
    {
      string code = @"
  public class BaseAccessor
  {
    public BaseAccessor(Structure aStructure)
    {
      structure = aStructure;
    }

    protected Structure structure;

    public IStructure Structure
    {
      get { return structure; }
    }          
      ";

      code += GetAccessors<Operation>(operations, false);
      code += GetAccessors<DynConnection>(connections, false);
      code += GetAccessors<ScalarVar>(scalarVars, false);
      code += GetAccessors<ResultSet>(resultSets, false);

      code += @"
  }
";

      return code;
    }

    /// <summary>
    /// Gera acessores para os objetos da estruutra
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="external">if set to <c>true</c> [external].</param>
    /// <returns></returns>
    private string GetAccessors<T>(IrisList<T> list, bool external)
    {
      string code = "";
      T[] tArray = list.ToArray();
      for (int i = 0; i < tArray.Length; i++)
      {
        T obj = tArray[i];
        bool testFlag = true;
        Object tmp = obj;

        if ((external) && (!(obj is DynConnection)))
        {
          if (tmp is Operation)
            testFlag = ((Operation)tmp).ExternalParam;
        }

        if (testFlag)
        {
          string typeName = "";
          string objCode = "";
          string objName = obj.ToString();
          string listName = "\"" + list.Name + "\"";
          string objString = "\"" + objName + "\"";
          string attribute = "";

          if (external)
          {
            if (obj is ScalarVar)
            {
              ScalarVar sVar = (ScalarVar)tmp;
              string displayText = sVar.DisplayText;
              if (string.IsNullOrEmpty(displayText))
                displayText = sVar.Name;


              attribute = "[DisplayName(\"" + displayText + "\"),Description(\"" + sVar.Description + "\"), Category(\"Parâmetros\")]";


              Type type = ((ScalarVar)tmp).DataType;
              if ((type == typeof(Int16)) || (type == typeof(Int32)) || (type == typeof(Int64)) || (type == typeof(UInt16))
                || (type == typeof(UInt32)) || (type == typeof(UInt64)) || (type == typeof(Byte)) || (type == typeof(SByte))
                || (type == typeof(Decimal)) || (type == typeof(Double)) || (type == typeof(Single)) || (type == typeof(Boolean)))
                typeName = "Nullable<" + type.ToString() + ">";
              else
                typeName = type.ToString();

              objCode = @"get
                          { 
                            Object result = ((ScalarVar)Structure.GetObject(" + objString + "," + listName + @")).RawValue;
                            if(result == null)
                              return null;
                            else    
                              return (" + type.ToString() + @") result;
                          }
                         set{ ((ScalarVar)Structure.GetObject(" + objString + "," + listName + @")).RawValue = value;}";
            }
            else if (obj is ResultSet)
            {
              attribute = "[Browsable(false)]";
              typeName = typeof(DataTable).ToString();
              objCode = "get{ return ((ResultSet)Structure.GetObject(" + objString + "," + listName + @")).Table;}
                         set{ ((ResultSet)Structure.GetObject(" + objString + "," + listName + @")).Table = value;}";

            }
            else if (obj is DynConnection)
            {
              DynConnection conn = (DynConnection)tmp;
              string displayText = conn.DisplayText;
              if (string.IsNullOrEmpty(displayText))
                displayText = conn.Name;


              attribute = "    [Browsable(true), Category(\"Conexão\"), DisplayName(\"" + displayText + "\"), Description(\"" + conn.Description + "\")]" + @"
    [Editor(typeof(DynamicConnectionStringEditor), typeof(UITypeEditor))]";


              typeName = typeof(String).ToString();
              objCode = "get{ return ((DynConnection)Structure.GetObject(" + objString + "," + listName + @")).ConnectionString;}
                         set{ ((DynConnection)Structure.GetObject(" + objString + "," + listName + @")).ConnectionString = value;}";
            }
          }

          if (string.IsNullOrEmpty(objCode))
          {
            typeName = obj.GetType().ToString();
            objCode = "get{ return (" + typeName + ")Structure.GetObject(" + objString + "," + listName + ");}";
          }

          code += attribute + @"
          public " + typeName + " " + objName + @"
          {
            " + objCode + @"
          }
          ";
        }
      }

      return code;
    }



    /// <summary>
    /// Circunda o código gerado por uma operação C# em um name-space
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns></returns>
    public string InsertInNamespace(string code)
    {
      code = @"using Iris.Runtime.Model.BaseObjects;
      namespace Iris.Runtime.Model.BaseObjects
      {
      
      " + code + @"
      }";
      return code;
    }

    #endregion


  }
}
