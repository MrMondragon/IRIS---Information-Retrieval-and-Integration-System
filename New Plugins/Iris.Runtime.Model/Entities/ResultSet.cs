using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Core.ParserObjects;
using System.Data.Odbc;
using System.Data.Common;
using Iris.Runtime.Core.Expressions;
using Iris.Runtime.Core;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.PropertyEditors;
using Iris.Interfaces;
using Iris.Runtime.Model.PropertyEditors;
using Iris.Runtime.Core.PropertyEditors.Interfaces;
using Iris.Runtime.Core.ParserEngine.ParserObjects;
using DatasetQuery;
using System.ComponentModel.Design;
using Iris.Runtime.Core.Conexao;

namespace Iris.Runtime.Model.Entities
{
  [Serializable]
  public class ResultSet : Entity, IResultSet, IScriptedObject
  {
    public ResultSet(string aName, Structure aStructure, DynConnection aConnection, String sql)
      : this(aName, aStructure)
    {
      connection = aConnection;
      UpdateQuery(sql);
      UpdateAdapter();
    }

    public ResultSet(string aName, Structure aStructure)
      : base(aName, aStructure)
    {
      Structure.ResultSets.Add(this);
    }


    private void UpdateQuery(string Sql)
    {
      if (!string.IsNullOrEmpty(Sql))
      {
        if (parser == null)
          parser = Structure.SqlParser;
        query = (SelectQuery)parser.Parse(Sql);
        InMemory = false;
      }
      else
      {
        query = null;
      }
    }



    [NonSerialized]
    private SqlParser parser;
    [NonSerialized]
    private DbDataAdapter adapter;
    private SelectQuery query;

    private bool inMemory;
    [DisplayName("Virtual"), Description("Resultsets virtuais não fazem conexões com banco de dados e apenas realizam operações em memória.")]
    public bool InMemory
    {
      get { return inMemory; }
      set { inMemory = value; }
    }


    /// <summary>
    /// Gets the query.
    /// Este objeto é somente leitura. A manipulação direta dele é feita apenas pelo resultset
    /// </summary>
    /// <value>The query.</value>
    [DisplayName("Select"), Category("SQL")]
    [Editor(typeof(ScriptEditor), typeof(UITypeEditor))]
    public SelectQuery Query
    {
      get
      {
        return query;
      }
    }

    /// <summary>
    /// Gets the SQL.
    /// </summary>
    /// <value>The SQL.</value>
    [Browsable(false)]
    public string SQL
    {
      get
      {
        if (query != null)
          return query.GetText();
        else
          return "";
      }
      set
      {
        UpdateQuery(value);
      }
    }

    [NonSerialized]
    private DataTable table;
    [ReadOnly(true), Editor(typeof(TableEditor), typeof(UITypeEditor))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataTable Table
    {
      get
      {
        if ((table == null) || ((table.DataSet == null) || (table.DataSet != Structure.Dataset)))
        {
          if (!InMemory)
          {
            UpdateAdapter();
          }
          else if (Schema != null)
          {
            Schema.RefreshResultSets(this);
          }
        }
        return table;
      }
      set
      {
        if (value != null)
        {
          SQL = "";
          adapter = null;
          InMemory = true;
          SetTable(value);
          view = new DataView(value);
        }
        else
        {
          SetTable(null);
          view = null;
        }
      }
    }

    public void SetTable(DataTable _table)
    {
      if (table != null)
      {
        try { table.Clear(); }
        catch { }
        table.Dispose();
      }

      table = _table;
    }

    [NonSerialized]
    private DataView view;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataView View
    {
      get 
      {
        if ((view == null) && (table != null))
          view = new DataView(table);
        return view; 
      }
      set 
      {
        Table = view.Table;
        view = value; 
      }
    }

    [DisplayName("Registros"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int RecCount
    {
      get
      {
        try
        {
          if (Table != null)
            return Table.Rows.Count;
          else
            return 0;
        }
        catch (Exception)
        {
          return 0;
        }
      }
    }

    private DynConnection connection;

    /// <summary>
    /// Gets the connection.
    /// </summary>
    /// <value>The connection.</value>
    [Editor(typeof(ConnectionSelectorEditor), typeof(UITypeEditor))]
    public DynConnection Connection
    {
      get
      {
        if (InMemory)
          return null;
        else
          return connection;
      }
      set { connection = value; }
    }

    private string insertCommand;
    /// <summary>
    /// Gets or sets the insert command.
    /// </summary>
    /// <value>The insert command.</value>
    [DisplayName("SQL Insert"), Category("SQL")]
    [Editor(typeof(ResultSetInsertEditor), typeof(UITypeEditor))]
    public string InsertCommand
    {
      get { return insertCommand; }
      set
      {
        if (!string.IsNullOrEmpty(value))
          genInsert = false;
        insertCommand = value;
        UpdateAdapter();
      }
    }

    private bool genInsert;
    /// <summary>
    /// Indica se deve ou não ser gerado comando de INSERT
    /// </summary>
    /// <value><c>true</c> if [gen insert]; otherwise, <c>false</c>.</value>
    [DisplayName("Gerar Insert"), Category("SQL")]
    public bool GenInsert
    {
      get
      {
        return genInsert;
      }
      set
      {
        if (value)
          insertCommand = "";
        genInsert = value;
        UpdateAdapter();
      }
    }

    private string deleteCommand;
    /// <summary>
    /// Gets or sets the insert command.
    /// </summary>
    /// <value>The insert command.</value>
    [DisplayName("SQL Delete"), Category("SQL")]
    [Editor(typeof(ResultSetDeleteEditor), typeof(UITypeEditor))]
    public string DeleteCommand
    {
      get { return deleteCommand; }
      set
      {
        if (!string.IsNullOrEmpty(value))
          genDelete = false;
        deleteCommand = value;
        UpdateAdapter();
      }
    }

    private bool genDelete;
    /// <summary>
    /// Indica se deve ou não ser gerado comando de DELETE
    /// </summary>
    /// <value><c>true</c> if [gen delete]; otherwise, <c>false</c>.</value>
    [DisplayName("Gerar Delete"), Category("SQL")]
    public bool GenDelete
    {
      get
      {
        return genDelete;
      }
      set
      {
        if (value)
          deleteCommand = "";
        genDelete = value;
        UpdateAdapter();
      }
    }

    private string updateCommand;
    /// <summary>
    /// Gets or sets the insert command.
    /// </summary>
    /// <value>The insert command.</value>
    [DisplayName("SQL Update"), Category("SQL")]
    [Editor(typeof(ResultSetUpdateEditor), typeof(UITypeEditor))]
    public string UpdateCommand
    {
      get { return updateCommand; }
      set
      {
        if (!string.IsNullOrEmpty(value))
          genUpdate = false;
        updateCommand = value;
        UpdateAdapter();
      }
    }

    private bool genUpdate;

    /// <summary>
    /// Indica se deve ou não ser gerado comando de UPDATE
    /// </summary>
    /// <value><c>true</c> if [gen update]; otherwise, <c>false</c>.</value>
    [DisplayName("Gerar Update"), Category("SQL")]
    public bool GenUpdate
    {
      get { return genUpdate; }
      set
      {
        if (value)
          updateCommand = "";
        genUpdate = value;
        UpdateAdapter();
      }
    }


    private int updateBatchSize;
    [DisplayName("Regs. por Lote"), Category("Adapter")]
    public int UpdateBatchSize
    {
      get { return updateBatchSize; }
      set
      {
        updateBatchSize = value;
        if (adapter != null)
          adapter.UpdateBatchSize = value;
      }
    }

    private bool continueUpdateOnError;
    [DisplayName("Continuar em caso de erro"), Category("Adapter")]
    public bool ContinueUpdateOnError
    {
      get { return continueUpdateOnError; }
      set
      {
        continueUpdateOnError = value;
        if (adapter != null)
          adapter.ContinueUpdateOnError = value;
      }
    }

    private void UpdateAdapter()
    {
      if ((Connection != null) && (!InMemory) && (!string.IsNullOrEmpty(SQL)))
      {
        string tmpQuery;
        SqlParser sqlParser;
        Dictionary<string, object> tmpParams;
        PreParseQuery(out tmpQuery, out sqlParser, out tmpParams);
        List<DataColumn> primaryKey = PrimaryKey;

        List<string> pk = new List<string>();
        if (table != null)
        {
          foreach (DataColumn col in primaryKey)
          {
            pk.Add(col.ColumnName);
          }
        }

        adapter = Connection.GetAdapter(this, ref table);
        string tableName = Name;
        if (Structure.Dataset.Tables.Contains(tableName))
        {
          DataTable tmpTable = Structure.Dataset.Tables[tableName];
          tmpTable.Clear();
          ClearRelations(Structure.Dataset.Tables[tableName]);
          Structure.Dataset.Tables.Remove(tableName);
          tmpTable.Dispose();
        }
        table.TableName = tableName;

        //Algumas conexões não suportam estas propriedades e o catch vazio garante que isto não interrompa a execução
        //ao se alternar entre duas conexões diferentes.
        try
        {
          adapter.ContinueUpdateOnError = ContinueUpdateOnError;
          adapter.UpdateBatchSize = UpdateBatchSize;
        }
        catch { }

        if (pk.Count > 0)
        {
          List<DataColumn> pkList = new List<DataColumn>();
          foreach (DataColumn col in table.Columns)
          {
            if (pk.Contains(col.ColumnName))
              pkList.Add(col);
          }
          if (pkList.Count > 0)
            table.PrimaryKey = pkList.ToArray();
        }
        RestoreQuery(tmpQuery, sqlParser, tmpParams);
      }
    }


    private void ClearRelations(DataTable _table)
    {
      foreach (DataRelation rel in _table.ParentRelations)
      {
        DataTable parentTable = rel.ParentTable;
        foreach (DataColumn col in parentTable.Columns)
        {
          if (col.Expression.Contains(rel.RelationName))
            col.Expression = "";
        }
      }

      foreach (DataRelation rel in _table.ChildRelations)
      {
        DataTable childTable = rel.ChildTable;
        foreach (DataColumn col in childTable.Columns)
        {
          if (col.Expression.Contains(rel.RelationName))
            col.Expression = "";
        }
      }

      while (_table.ParentRelations.Count > 0)
        _table.ParentRelations.RemoveAt(0);

      while (_table.ChildRelations.Count > 0)
        _table.ChildRelations.RemoveAt(0);

    }

    public override string Name
    {
      get
      {
        return base.Name;
      }
      set
      {
        base.Name = value;
        if (Table != null)
        {
          table.TableName = value;
        }
      }
    }

    /// <summary>
    /// Fills this instance.
    /// </summary>
    public void Fill()
    {
      UpdateAdapter();
      if (!InMemory)
        adapter.Fill(Table);
      else
      {
        if (!string.IsNullOrEmpty(SQL))
        {
          string text = Query.GetText();
          view = DatasetQueryCommand.Execute(text, Structure.Dataset);
        }
      }
    }

    private void RestoreQuery(string tmpQuery, SqlParser sqlParser, Dictionary<string, object> tmpParams)
    {
      if (sqlParser != null)
      {
        query.Parameters.Clear();
        query = (SelectQuery)sqlParser.Parse(tmpQuery);
        foreach (KeyValuePair<string, object> kvp in query.Parameters)
        {
          if (!kvp.Key.StartsWith(":XEval_"))
            query.Parameters[kvp.Key] = tmpParams[kvp.Key];
        }
      }
    }

    private void PreParseQuery(out string tmpQuery, out SqlParser sqlParser, out Dictionary<string, object> tmpParams)
    {
      tmpQuery = query.GetText();
      sqlParser = null;
      if (query.Parameters == null)
        tmpParams = new Dictionary<string, object>();
      else
        tmpParams = new Dictionary<string, object>(query.Parameters);

      if (tmpQuery.IndexOf('{') != -1)
      {
        XEvalParser parser = new XEvalParser(Structure);
        string workQuery = tmpQuery;
        int ct = 0;
        while (workQuery.IndexOf('{') != -1)
        {
          int i = workQuery.IndexOf('{');
          int f = workQuery.IndexOf('}');
          string xpression = workQuery.Substring(0, f);
          xpression = xpression.Substring(i + 1);
          object value = parser.Parse(xpression);
          string parName = ":XEval_" + ct.ToString();
          tmpParams[parName] = value;
          workQuery = workQuery.Substring(0, i) + " " + parName + " " + workQuery.Substring(f + 1);
          ct++;
        }
        sqlParser = Structure.SqlParser;
        query = (SelectQuery)sqlParser.Parse(workQuery);
        foreach (KeyValuePair<string, object> kvp in tmpParams)
        {
          query.Parameters[kvp.Key] = kvp.Value;
        }
      }
    }

    public DataRow this[int index]
    {
      get
      {
        return Table.Rows[index];
      }
    }


    /// <summary>
    /// Filters using the specified expression
    /// and resets the original query when done.
    /// </summary>
    /// <param name="filter">The filter.</param>
    public void SqlFilter(Expression filter, bool resetState)
    {
      Expression tmpWhere = query.Where;

      if (query.Where != null)
        query.Where = new LogicExpression(query.Where, filter, LogicOperator.AND, false, false);
      else
        query.Where = filter;

      Fill();

      if (resetState)
        query.Where = tmpWhere;
    }

    /// <summary>
    /// Filtra um resultset pelo outro
    /// </summary>
    /// <param name="resultset">The resultset.</param>
    /// <param name="fieldMap">Correspondência dos campos do dataset atual (key)
    /// com os campos do dataset de filtro (value)</param>
    /// <param name="addToFilter">if set to <c>true</c> [add to filter].</param>
    public DataRow[] Filter(IResultSet master, List<KeyValuePair<string, string>> fieldMap)
    {
      string filter = "";
      string op = "";
      Query.Parameters.Clear();

      if (adapter != null)
        adapter.SelectCommand.Parameters.Clear();

      DataTable masterTable = master.Table;
      int idx = 0;
      foreach (DataRow row in masterTable.Rows)
      {
        foreach (KeyValuePair<string, string> fm in fieldMap)
        {
          if (!string.IsNullOrEmpty(filter))
            op = " OR ";

          if (inMemory)
          {
            string valor = Expression.GetDelimitedValue(row[fm.Key]);
            if (valor != " IS NULL")
              valor = " = " + valor;
            filter += op + "(" + fm.Value + valor + ")";
          }
          else
          {
            filter += op + "(" + fm.Value + "= :" + fm.Value + idx.ToString() + ")";
            Query.Parameters.Add(":" + fm.Value + idx.ToString(), row[fm.Key]);
            idx++;
          }
        }
      }

      filter = "(" + filter + ")";

      if (!inMemory)
      {
        Expression exp = Expression.CreateExpression(filter);
        SqlFilter(exp, true);
        return null;
      }
      else
      {
        return Table.Select(filter);
      }

    }

    public void Clear()
    {
      if (Table != null)
      {
        Table.Clear();
      }
    }

    public void Apply(DataRow[] rows)
    {
      if (!InMemory)
      {
        adapter.Update(rows);

        if (ContinueUpdateOnError)
        {
          DataRow[] erros = Table.GetErrors();
          if (erros.Length > 0)
          {
            string msg = "Erro de atualização: \n\r";
            for (int i = 0; i < erros.Length; i++)
            {
              msg += erros[i].RowError + "\n\r";
            }
            throw new Exception(msg);
          }
        }
      }
    }

    public DataColumnCollection Columns
    {
      get 
      {
        if (Table != null)
          return Table.Columns;
        else
          return null;
      }
    }

    [Browsable(false)]
    public override object Value
    {
      get { return Table; }
    }

    protected override IEntity doExecute()
    {
      return this;
    }

    [Editor(typeof(PKEditor), typeof(UITypeEditor))]
    [DisplayName("Chave Primária")]
    public List<DataColumn> PrimaryKey
    {
      get
      {
        if (table == null)
          return null;
        else
          return new List<DataColumn>(table.PrimaryKey);
      }
      set
      {
        Table.PrimaryKey = value.ToArray();
      }
    }

    [DisplayName("Relações Mestre"), Category("Relations")]
    [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
    public DataRelationCollection ParentRelations
    {
      get
      {
        if (Table != null)
          return Table.ParentRelations;
        else
          return null;
      }
    }

    [DisplayName("Relações Detalhe"), Category("Relations")]
    [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
    public DataRelationCollection ChildRelations
    {
      get
      {
        if (Table != null)
          return Table.ChildRelations;
        else
          return null;
      }
    }

    [Browsable(true), DisplayName("RS Externo"), Category("Design")]
    public override bool ExternalParam
    {
      get
      {
        return base.ExternalParam;
      }
      set
      {
        base.ExternalParam = value;
      }
    }

    private SchemaEntity schema;
    [Browsable(false)]
    internal SchemaEntity Schema
    {
      get { return schema; }
      set { schema = value; }
    }


    #region IResultSet Members


    IStructure IResultSet.Structure
    {
      get
      {
        return Structure;
      }
    }

    void IResultSet.SqlFilter(IExpression filter, bool resetState)
    {
      SqlFilter((Expression)filter, resetState);
    }

    #endregion

    #region IScriptedObject Members

    [Browsable(false)]
    public string Script
    {
      get
      {
        return SQL;
      }
      set
      {
        SQL = value;
      }
    }

    [Browsable(false)]
    public string Language
    {
      get { return "SQL"; }
    }

    [Browsable(false)]
    IStructure IScriptedObject.Structure
    {
      get { return Structure; }
    }
    #endregion

    #region IResultSet Members


    ISelectQuery IResultSet.Query
    {
      get { return (ISelectQuery)Query; }
    }


    #endregion

    #region IConnectedObject Members

    IDynConnection IConnectedObject.Connection
    {
      get
      {
        return Connection;
      }
      set
      {
        Connection = (DynConnection)value;
      }
    }

    #endregion
  }
}
