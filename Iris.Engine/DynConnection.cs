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
  /// Conexão dinâmica
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
    /// O nome da instância
    /// </summary>
    protected string name;
    /// <summary>
    /// Determina o Nome da instância
    /// </summary>
    /// <value>Nome da instância</value>
    [Browsable(true), DisplayName("Nome"), Category("Identificação"), Description("Nome da conexão")]
    public virtual string Name
    {
      get { return name; }
      set { name = value; }
    }


    /// <summary>
    /// Inicializa um objeto datatable com uma única coluna, utilizando o nome da
    /// coluna passado como parâmetro
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
    /// Adiciona um valor a uma tabela de uma única coluna
    /// </summary>
    /// <param name="tabela">The tabela.</param>
    /// <param name="value">The value.</param>
    internal void AddValueToTable(DataTable tabela, string value)
    {
      DataRow row = tabela.NewRow();
      row[0] = value;
      tabela.Rows.Add(row);
    }

    #region Manipulação de schema

    /// <summary>
    /// Data table com a lista de tabelas da conexão
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
    /// Determina se o schema da instância é válido
    /// </summary>
    /// <value>
    /// 	<c>true</c> se o schema é válido; caso contrário, <c>false</c>.
    /// </value>
    [Browsable(false)]
    public bool IsSchemaValid
    {
      get { return schemaValid; }
    }

    /// <summary>
    /// Valida o schema, fazendo com que ele seja acessado em cache da próxima
    /// vez que for solicitado
    /// </summary>
    public virtual void ValidateSchema()
    {
      schemaValid = true;
    }
    #endregion

    #region Manipulação da conexão

    /// <summary>
    /// Método de abertura da conexão
    /// </summary>
    public void Open()
    {
      if ((Connection.State == ConnectionState.Closed) || (Connection.State == ConnectionState.Broken))
        Connection.Open();
    }

    /// <summary>
    /// Método de fechamento da conexão
    /// </summary>
    public void Close()
    {
      if ((Connection.State != ConnectionState.Closed) && (Connection.State != ConnectionState.Broken))
        Connection.Close();
    }

    [Browsable(true), Category("Conexão"), DisplayName("Connection State")]
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
    /// Método de inicialização de transações
    /// </summary>
    public void StartTransaction()
    {
      if (this.SuportsTransactions)
        transaction = Connection.BeginTransaction();
    }

    /// <summary>
    /// Método de Conclusão de transações
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
    /// Método de Rollback de transação
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


    #region Manipulação de Provider e Factory
    private string connectionString;

    /// <summary>
    /// Determina se o objeto DBConnection é válido ou se precisa ser re-criado
    /// </summary>
    [NonSerialized]
    protected bool validConnection;

    private string provider;

    private string internalProvider;

    /// <summary>
    /// Determina o ConnectionString da instância
    /// </summary>
    /// <value>ConnectionString da instância</value>
    [Browsable(true), Category("Conexão"), DisplayName("String de Conexão"), Description("String de Conexão com o banco de dados")]
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
    /// Determina o InternalProvider da instância, conforme necessário para inicializar a Factory
    /// </summary>
    /// <value>InternalProvider da instância</value>
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
    /// Torna o schema da instância inválido, o que fará com que ele seja
    /// atualizado da próxima vez que for solicitado
    /// </summary>
    public void InvalidateSchema()
    {
      validConnection = false;
      schemaValid = false;
    }

    /// <summary>
    /// Representação mais amigável do provider armazenado na propriedade InternalProvider
    /// </summary>
    /// <value>Provider da instância</value>
    [Browsable(true), ReadOnly(false), Category("Conexão"), DisplayName("Provedor"), Description("Provedor de acesso ao banco de dados")]
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
    /// Objeto responsável pela criação dos objetos de acesso à fonte de dados
    /// </summary>
    /// <value>Factory da instância</value>
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
    /// Objeto de conexão com o banco
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
    /// Rotina de montagem do DataTable que será retornado pelo método GetSchema
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
    /// Formata o nome de campo passado como argumento na forma de um parâmetro aceito pelo tipo 
    /// de provider da conexão.
    /// </summary>
    /// <param name="fieldName">Name of the field.</param>
    /// <returns>O nome formatado do parâmetro</returns>
    internal string FormatParamName(String paramName)
    {
      if ((ParameterNameMaxLength < paramName.Length) && (ParameterNameMaxLength > 0))
        paramName = paramName.Substring(0, ParameterNameMaxLength);

      return String.Format(ParameterMarkerFormat, paramName);
    }

    private string parameterMarkerFormat;
    /// <summary>
    /// Determina o ParameterMarkerFormat da instância
    /// </summary>
    /// <value>ParameterMarkerFormat da instância</value>
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
    /// Retorna o tamanho máximo de um nome de parâmetro
    /// </summary>
    /// <value>O tamanho máximo de um nome de parâmetro</value>
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
    /// Determina se a conexão suporta transações.
    /// </summary>
    /// <value>
    /// 	<c>true</c> caso a conexão suporte transações; caso contrário, <c>false</c>.
    /// </value>
    [Browsable(true), DisplayName("Suporta Transações"), Category("Conexão"), Description("Suporta Transações")]
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
    /// Inicializa e retorna um DataAdapter para a tabela passada como parâmetro
    /// </summary>
    /// <param name="tabela">A tabela que se deseja atualizar/carregar</param>
    /// <param name="generateUpdate">true caso o seja necessário gerar comando de Update</param>
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
    [DisplayName("Descrição"), Category("Design")]
    public string Description
    {
      get { return description; }
      set { description = value; }
    }

    private string displayText;
    [DisplayName("Texto de Apresentação"), Category("Design")]
    public string DisplayText
    {
      get { return displayText; }
      set { displayText = value; }
    }
  }
}
