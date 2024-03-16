using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;


namespace Iris.Runtime.Engine
{
  /// <summary>
  /// Conex�o din�mica
  /// </summary>
  [Serializable]
  public class DynConnection
  {

    public DynConnection(string aName)
    {
      Name = aName;
      schema = InitDataTable("Table_Name");
      InvalidateSchema();
      validConnection = false;
    }

    /// <summary>
    /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
    /// </returns>
    public override string ToString()
    {
      return Name;
    }

    /// <summary>
    /// O nome da inst�ncia
    /// </summary>
    protected string name;
    /// <summary>
    /// Determina o Nome da inst�ncia
    /// </summary>
    /// <value>Nome da inst�ncia</value>
    [Browsable(true), DisplayName("Nome"), Category("Identifica��o"), Description("Nome da conex�o")]
    public virtual string Name
    {
      get { return name; }
      set { name = value; }
    }


    /// <summary>
    /// Inicializa um objeto datatable com uma �nica coluna, utilizando o nome da
    /// coluna passado como par�metro
    /// </summary>
    /// <param name="columnName">Name of the column.</param>
    /// <returns></returns>
    internal DataTable InitDataTable(string columnName)
    {
      DataTable result = new DataTable();
      DataColumn column = new DataColumn(columnName);
      result.Columns.Add(column);
      return result;
    }

    /// <summary>
    /// Adiciona um valor a uma tabela de uma �nica coluna
    /// </summary>
    /// <param name="tabela">The tabela.</param>
    /// <param name="value">The value.</param>
    internal void AddValueToTable(DataTable tabela, string value)
    {
      DataRow row = tabela.NewRow();
      row[0] = value;
      tabela.Rows.Add(row);
    }

    #region Manipula��o de schema

    /// <summary>
    /// Data table com a lista de tabelas da conex�o
    /// Colunas: "Table_Name"
    /// </summary>
    [NonSerialized]
    protected DataTable schema;

    /// <summary>
    /// Retorna um objeto DataTable com todos os campos de uma tabela.
    /// Colunas: "Column_Name"
    /// </summary>
    /// <param name="tableName"></param>
    /// <returns></returns>
    /// <summary>
    /// Retorna um objeto DataTable com todos os campos de uma tabela.
    /// Colunas: "Column_Name"
    /// </summary>
    /// <param name="tableName"></param>
    /// <returns></returns>
    public DataTable GetFields(string tableName)
    {
      DataTable dTab = new DataTable();
      DataColumn col = new DataColumn("Column_Name", typeof(string));
      dTab.Columns.Add(col);

      DataTable tmpTable = GetTableSchema(tableName);

      for (int i = 0; i < tmpTable.Columns.Count; i++)
      {
        DataRow row = dTab.NewRow();
        string colName = tmpTable.Columns[i].ColumnName;
        row["Column_Name"] = colName;
        dTab.Rows.Add(row);
      }

      tmpTable.Dispose();
      dTab.AcceptChanges();

      return dTab;
    }

    public DataTable GetTableSchema(string tableName)
    {
      //string sql = "Select * from " + tableName + " where 1=2";
      //SelectQuery query = (SelectQuery)Parser.Parse(sql);
      //DataTable tmpTable = this.ExecQuery(query, null);
      //return tmpTable;
      return null;
    }


    /// <summary>
    /// Retorna um objeto DataTable com todos os campos de uma tabela.
    /// Colunas: "Table_Name".
    /// </summary>
    /// <returns></returns>
    public virtual DataTable GetSchema()
    {
      DataTable result = null;
      if (!string.IsNullOrEmpty(ConnectionString))
      {
        if (schema == null)
        {
          schema = new DataTable();
          InvalidateSchema();
        }

        if (!IsSchemaValid)
        {
          schema.Rows.Clear();
          doGetSchema();
        }


        ValidateSchema();
        result = schema;
      }
      return result;
    }

    [NonSerialized]
    private bool schemaValid;
    /// <summary>
    /// Determina se o schema da inst�ncia � v�lido
    /// </summary>
    /// <value>
    /// 	<c>true</c> se o schema � v�lido; caso contr�rio, <c>false</c>.
    /// </value>
    [Browsable(false)]
    public bool IsSchemaValid
    {
      get { return schemaValid; }
    }

    /// <summary>
    /// Valida o schema, fazendo com que ele seja acessado em cache da pr�xima
    /// vez que for solicitado
    /// </summary>
    public virtual void ValidateSchema()
    {
      schemaValid = true;
    }
    #endregion

    #region Manipula��o da conex�o

    /// <summary>
    /// M�todo de abertura da conex�o
    /// </summary>
    public void Open()
    {
      if ((Connection.State == ConnectionState.Closed) || (Connection.State == ConnectionState.Broken))
        Connection.Open();
    }

    /// <summary>
    /// M�todo de fechamento da conex�o
    /// </summary>
    public void Close()
    {
      if ((Connection.State != ConnectionState.Closed) && (Connection.State != ConnectionState.Broken))
        Connection.Close();
    }

    [Browsable(true), Category("Conex�o"), DisplayName("Connection State")]
    public ConnectionState ConnectionState
    {
      get { return Connection.State; }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DbTransaction Transaction
    {
      get { return transaction; }
    }

    [NonSerialized]
    private DbTransaction transaction;

    /// <summary>
    /// M�todo de inicializa��o de transa��es
    /// </summary>
    public void StartTransaction()
    {
      if (this.SuportsTransactions)
        transaction = Connection.BeginTransaction();
    }

    /// <summary>
    /// M�todo de Conclus�o de transa��es
    /// </summary>
    public void CommitTransaction()
    {
      if ((transaction != null) && (this.SuportsTransactions))
      {
        transaction.Commit();
        transaction = null;
      }
    }

    /// <summary>
    /// M�todo de Rollback de transa��o
    /// </summary>
    public void RollbackTransaction()
    {
      if ((transaction != null) && (this.SuportsTransactions))
      {
        transaction.Rollback();
        transaction = null;
      }
    }
    #endregion


    #region Manipula��o de Provider e Factory
    private string connectionString;

    /// <summary>
    /// Determina se o objeto DBConnection � v�lido ou se precisa ser re-criado
    /// </summary>
    [NonSerialized]
    protected bool validConnection;

    private string provider;

    private string internalProvider;

    /// <summary>
    /// Determina o ConnectionString da inst�ncia
    /// </summary>
    /// <value>ConnectionString da inst�ncia</value>
    [Browsable(true), Category("Conex�o"), DisplayName("String de Conex�o"), Description("String de Conex�o com o banco de dados")]
    public string ConnectionString
    {
      get
      {
        return connectionString;
      }
      set
      {
        DbConnectionStringBuilder csBuilder = this.Factory.CreateConnectionStringBuilder();
        csBuilder.ConnectionString = value;
        connectionString = value;
        InvalidateSchema();
      }
    }

    /// <summary>
    /// Determina o InternalProvider da inst�ncia, conforme necess�rio para inicializar a Factory
    /// </summary>
    /// <value>InternalProvider da inst�ncia</value>
    [Browsable(false)]
    public string InternalProvider
    {
      get { return internalProvider; }
      set
      {
        internalProvider = value;
        InvalidateSchema();
      }
    }

    /// <summary>
    /// Torna o schema da inst�ncia inv�lido, o que far� com que ele seja
    /// atualizado da pr�xima vez que for solicitado
    /// </summary>
    public void InvalidateSchema()
    {
      validConnection = false;
      schemaValid = false;
    }

    /// <summary>
    /// Representa��o mais amig�vel do provider armazenado na propriedade InternalProvider
    /// </summary>
    /// <value>Provider da inst�ncia</value>
    [Browsable(true), ReadOnly(false), Category("Conex�o"), DisplayName("Provedor"), Description("Provedor de acesso ao banco de dados")]
    public string Provider
    {
      get
      {
        return provider;
      }
      set
      {
        if (provider != value)
        {
          provider = value;
          ConnectionString = "";
          InvalidateSchema();
        }
      }
    }

    /// <summary>
    /// Objeto respons�vel pela cria��o dos objetos de acesso � fonte de dados
    /// </summary>
    /// <value>Factory da inst�ncia</value>
    [Browsable(false)]
    public DbProviderFactory Factory
    {
      get
      {
        if (internalProvider != null)
          return DbProviderFactories.GetFactory(this.InternalProvider);
        else
          return null;
      }
    }

    [NonSerialized]
    private DbConnection connection;
    /// <summary>
    /// Objeto de conex�o com o banco
    /// </summary>
    [Browsable(false)]
    public DbConnection Connection
    {
      get
      {
        if (((!validConnection) || (connection == null)) && (Factory != null))
        {
          connection = Factory.CreateConnection();
          connection.ConnectionString = this.ConnectionString;
          validConnection = true;
        }
        return connection;
      }
    }


    /// <summary>
    /// Rotina de montagem do DataTable que ser� retornado pelo m�todo GetSchema
    /// </summary>
    public void doGetSchema()
    {
      if (Connection != null)
      {
        DbConnection Conn = Connection;
        if (Conn.ConnectionString != ConnectionString)
        {
          Close();
          Conn.ConnectionString = ConnectionString;
        }

        Open();
        DataTable dbSchema = Conn.GetSchema("DataSourceInformation");
        schema = Connection.GetSchema("Tables");

        if (dbSchema.Rows.Count > 0)
        {
          parameterMarkerFormat = Convert.ToString(dbSchema.Rows[0]["ParameterMarkerFormat"]);
          parameterNameMaxLength = Convert.ToInt32(dbSchema.Rows[0]["ParameterNameMaxLength"]);
        }
      }
    }


    /// <summary>
    /// Formata o nome de campo passado como argumento na forma de um par�metro aceito pelo tipo 
    /// de provider da conex�o.
    /// </summary>
    /// <param name="fieldName">Name of the field.</param>
    /// <returns>O nome formatado do par�metro</returns>
    internal string FormatParamName(String paramName)
    {
      if ((ParameterNameMaxLength < paramName.Length) && (ParameterNameMaxLength > 0))
        paramName = paramName.Substring(0, ParameterNameMaxLength);

      return String.Format(ParameterMarkerFormat, paramName);
    }

    private string parameterMarkerFormat;
    /// <summary>
    /// Determina o ParameterMarkerFormat da inst�ncia
    /// </summary>
    /// <value>ParameterMarkerFormat da inst�ncia</value>
    [Browsable(false)]
    public string ParameterMarkerFormat
    {
      get
      {
        GetSchema();
        if (Provider == "SqlClient Data Provider")
          return "@" + parameterMarkerFormat;
        else
          return parameterMarkerFormat;
      }
    }

    internal int parameterNameMaxLength;
    /// <summary>
    /// Retorna o tamanho m�ximo de um nome de par�metro
    /// </summary>
    /// <value>O tamanho m�ximo de um nome de par�metro</value>
    [Browsable(false)]
    public int ParameterNameMaxLength
    {
      get
      {
        GetSchema();
        return parameterNameMaxLength;
      }
    }
    private bool suportsTransactions;

    /// <summary>
    /// Determina se a conex�o suporta transa��es.
    /// </summary>
    /// <value>
    /// 	<c>true</c> caso a conex�o suporte transa��es; caso contr�rio, <c>false</c>.
    /// </value>
    [Browsable(true), DisplayName("Suporta Transa��es"), Category("Conex�o"), Description("Suporta Transa��es")]
    public virtual bool SuportsTransactions
    {
      get { return suportsTransactions; }
      set { suportsTransactions = value; }
    }

    #endregion


    #region Adapter

    //public DbDataAdapter GetAdapter(SelectQuery query)
    //{
    //  DbDataAdapter adapter = Factory.CreateDataAdapter();
    //  adapter.FillLoadOption = LoadOption.OverwriteChanges;
    //  adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    //  DbCommand command = Factory.CreateCommand();
    //  string select = AddParams(command, query, adapter);
    //  command.CommandText = select;
    //  command.Connection = Connection;
    //  adapter.SelectCommand = command;
    //  return adapter;
    //}

    public DbDataAdapter GetAdapter(string query, Dictionary<string, object> parameters)
    {
      DbDataAdapter adapter = Factory.CreateDataAdapter();
      adapter.FillLoadOption = LoadOption.OverwriteChanges;
      adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
      DbCommand command = Connection.CreateCommand();
      AddExecParams(command, query, parameters);
      adapter.SelectCommand = command;
      return adapter;
    }

    /// <summary>
    /// Inicializa e retorna um DataAdapter para a tabela passada como par�metro
    /// </summary>
    /// <param name="tabela">A tabela que se deseja atualizar/carregar</param>
    /// <param name="generateUpdate">true caso o seja necess�rio gerar comando de Update</param>
    /// <returns></returns>
    //public DbDataAdapter GetAdapter(IResultSet resultset, ref DataTable table)
    //{
    //  DbDataAdapter adapter = null;// GetAdapter((SelectQuery)resultset.Query);
    //  DbCommandBuilder builder = Factory.CreateCommandBuilder();

    //  builder.DataAdapter = adapter;

    //  if (table != null)
    //  {
    //    table.Clear();
    //    DataSet ds = table.DataSet;
    //    if (ds != null)
    //    {
    //      while (table.ParentRelations.Count > 0)
    //        ds.Relations.Remove(table.ParentRelations[0]);
    //      while (table.ChildRelations.Count > 0)
    //        ds.Relations.Remove(table.ChildRelations[0]);

    //      ds.Tables.Remove(table.TableName);
    //    }
    //    table.Dispose();
    //  }

    //  table = adapter.FillSchema(resultset.Structure.Dataset, SchemaType.Mapped)[0];


    //  if (resultset.GenInsert)
    //    adapter.InsertCommand = builder.GetInsertCommand();
    //  else
    //  {
    //    if (!string.IsNullOrEmpty(resultset.InsertCommand))
    //    {
    //      adapter.InsertCommand = Factory.CreateCommand();
    //      AddCommandParams(adapter.InsertCommand, resultset.InsertCommand, table);
    //    }
    //  }
    //  if (resultset.GenUpdate)
    //    adapter.UpdateCommand = builder.GetUpdateCommand();
    //  else
    //  {
    //    if (!string.IsNullOrEmpty(resultset.UpdateCommand))
    //    {
    //      adapter.UpdateCommand = Factory.CreateCommand();
    //      AddCommandParams(adapter.UpdateCommand, resultset.UpdateCommand, table);
    //    }
    //  }
    //  if (resultset.GenDelete)
    //    adapter.DeleteCommand = builder.GetDeleteCommand();
    //  else
    //  {
    //    if (!string.IsNullOrEmpty(resultset.DeleteCommand))
    //    {
    //      adapter.DeleteCommand = Factory.CreateCommand();
    //      AddCommandParams(adapter.DeleteCommand, resultset.DeleteCommand, table);
    //    }
    //  }

    //  return adapter;
    //}


    ////[NonSerialized]
    //private SqlParser parser;
    //[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public SqlParser Parser
    //{
    //  get
    //  {
    //    //if (parser == null)
    //    //  parser = new SqlParser();
    //    return parser;
    //  }
    //}

    private void AddCommandParams(DbCommand command, string commandText, DataTable table)
    {

      //SimpleParserObject simpleCommand = (SimpleParserObject)Parser.Parse(commandText);

      //if ((simpleCommand.Parameters != null) && (simpleCommand.Parameters.Count > 0))
      //{
      //  List<string> keys = new List<string>(simpleCommand.Parameters.Keys);
      //  for (int i = 0; i < simpleCommand.Parameters.Count; i++)
      //  {
      //    string paramName = keys[i].Substring(1);
      //    string columnName = paramName;
      //    DbType type = DbType.String;
      //    paramName = FormatParamName(paramName);
      //    DbParameter param = Factory.CreateParameter();
      //    param.ParameterName = paramName;

      //    if (table.Columns.Contains(columnName))
      //    {
      //      param.SourceColumn = columnName;
      //      type = GetDbType(table.Columns[columnName].DataType);
      //    }
      //    param.DbType = type;

      //    command.Parameters.Add(param);

      //    commandText = commandText.Replace(keys[i], paramName);
      //  }
      //}

      //command.CommandText = commandText;
    }

    //private string AddParams(DbCommand command, SelectQuery query, DbDataAdapter adapter)
    //{
    //  string select = query.GetText();
    //  if ((query.Parameters != null) && (query.Parameters.Count > 0))
    //  {
    //    List<string> keys = new List<string>(query.Parameters.Keys);
    //    List<object> values = new List<object>(query.Parameters.Values);
    //    for (int i = 0; i < query.Parameters.Count; i++)
    //    {
    //      string paramName = keys[i].Substring(1);
    //      object value = values[i];
    //      paramName = FormatParamName(paramName);
    //      select = select.Replace(keys[i], paramName);

    //      if (adapter is OdbcDataAdapter)
    //        ((OdbcParameterCollection)command.Parameters).AddWithValue(paramName, value);
    //      else if (adapter is OleDbDataAdapter)
    //        ((OleDbParameterCollection)command.Parameters).AddWithValue(paramName, value);
    //      else if (adapter is OracleDataAdapter)
    //        ((OracleParameterCollection)command.Parameters).AddWithValue(paramName, value);
    //      else if (adapter is SqlDataAdapter)
    //        ((SqlParameterCollection)command.Parameters).AddWithValue(paramName, value);
    //    }
    //  }
    //  return select;
    //}


    private static DbType GetDbType(Type type)
    {
      TypeCode code = Type.GetTypeCode(type);
      switch (code)
      {
        case TypeCode.Boolean:
          return DbType.Boolean;
        case TypeCode.Byte:
          return DbType.Byte;
        case TypeCode.DateTime:
          return DbType.DateTime;
        case TypeCode.Decimal:
          return DbType.Decimal;
        case TypeCode.Double:
          return DbType.Double;
        case TypeCode.Int16:
          return DbType.Int16;
        case TypeCode.Int32:
          return DbType.Int32;
        case TypeCode.Int64:
          return DbType.Int64;
        case TypeCode.Object:
          return DbType.Object;
        case TypeCode.SByte:
          return DbType.SByte;
        case TypeCode.Single:
          return DbType.Single;
        case TypeCode.UInt16:
          return DbType.UInt16;
        case TypeCode.UInt32:
          return DbType.UInt32;
        case TypeCode.UInt64:
          return DbType.Int64;
        default:
          return DbType.String;
      }
    }


    #endregion

    private void AddExecParams(DbCommand command, string commandText, Dictionary<string, object> parameters)
    {
      if ((parameters != null) && (parameters.Count > 0))
      {
        List<string> keys = new List<string>(parameters.Keys);
        for (int i = 0; i < parameters.Count; i++)
        {
          string paramName = keys[i].Substring(1);
          string columnName = paramName;
          object value = parameters[keys[i]];
          DbParameter param = CreateParam(value);

          param.ParameterName = paramName;
          paramName = FormatParamName(paramName);

          command.Parameters.Add(param);
          commandText = commandText.Replace(keys[i], paramName);
        }
      }

      command.CommandText = commandText;
    }

    private DbParameter CreateParam(object value)
    {
      DbType type = GetDbType(value.GetType());
      DbParameter param = Factory.CreateParameter();
      param.DbType = type;
      param.Value = value;
      return param;
    }

    public DataTable ExecQuery(string query, Dictionary<string, object> parameters)
    {
      DbDataAdapter adapter = GetAdapter(query, parameters);
      DataTable table = new DataTable();
      adapter.Fill(table);
      return table;
    }

    //public DataTable ExecQuery(SelectQuery query, Dictionary<string, object> parameters)
    //{
    //  DbDataAdapter adapter = GetAdapter(query);
    //  DataTable table = new DataTable(query.FromClause.Members[0].Alias);
    //  DataSet ds = new DataSet();
    //  ds.Tables.Add(table);
    //  ds.EnforceConstraints = false;
    //  adapter.Fill(table);
    //  ds.Tables.Remove(table);
    //  ds.Dispose();
    //  return table;
    //}

    public int ExecuteNonQuery(string Sql, Dictionary<string, object> parameters)
    {
      DbCommand command = Factory.CreateCommand();
      AddExecParams(command, Sql, parameters);
      command.Connection = this.Connection;
      Open();
      return command.ExecuteNonQuery();
    }

    public object ExecuteScalar(string Sql, Dictionary<string, object> parameters)
    {
      DbCommand command = Factory.CreateCommand();
      AddExecParams(command, Sql, parameters);
      command.Connection = this.Connection;
      Open();
      return command.ExecuteScalar();
    }

    private string description;
    [DisplayName("Descri��o"), Category("Design")]
    public string Description
    {
      get { return description; }
      set { description = value; }
    }

    private string displayText;
    [DisplayName("Texto de Apresenta��o"), Category("Design")]
    public string DisplayText
    {
      get { return displayText; }
      set { displayText = value; }
    }
  }
}
