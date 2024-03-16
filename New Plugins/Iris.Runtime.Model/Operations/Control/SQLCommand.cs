using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Model.Entities;
using System.ComponentModel;
using Iris.Interfaces;
using Iris.Runtime.Core.PropertyEditors.Interfaces;
using Iris.Runtime.Model.DisignSuport;
using System.Drawing.Design;
using Iris.PropertyEditors;
using System.Data;
using Iris.Runtime.Core.ParserEngine.ParserObjects;
using Iris.Runtime.Core.ParserObjects;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Comando SQL")]
  public class SQLCommand : ControlOperation, IScriptedObject
  {

    public SQLCommand(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetOutputs("Saída");
      QueryType = QueryType.Comando;
    }

    private MergedObject sql;
    [Editor(typeof(ScriptEditor), typeof(UITypeEditor))]
    public string Sql
    {
      get
      {
        if (sql == null)
          return "";
        else
          return sql.Text;
      }
      set
      {
        if (string.IsNullOrEmpty(value))
          sql = null;
        else
        {
          BaseParserObject bpo = (BaseParserObject)Structure.SqlParser.Parse(value);
          sql = Structure.MergerParser.Parse(bpo.GetText());
        }
      }
    }

    public Dictionary<string, object> Parameters
    {
      get
      {
        if (sql == null)
          return null;
        else
          return sql.Parameters;
      }
    }

    private QueryType queryType;

    public QueryType QueryType
    {
      get { return queryType; }
      set { queryType = value; }
    }

    private DynConnection connection;
    [Editor(typeof(ConnectionSelectorEditor), typeof(UITypeEditor))]
    public DynConnection Connection
    {
      get { return connection; }
      set { connection = value; }
    }

    protected override IEntity doExecute()
    {
      switch (QueryType)
      {
        case QueryType.Registros:
          {
            ResultSet rs;
            if (Outputs[0] is ResultSet)
            {
              rs = ((ResultSet)Outputs[0]);
              rs.Connection = Connection;
              rs.SQL = Sql;
            }
            else
            {
              rs = Structure.CreateResultSet("DS_" + Name, Connection, Sql, true);
            }
            rs.Fill();
            return rs;
          }
        case QueryType.Valor_Escalar:
          {
            Object value = Connection.ExecuteScalar(sql.ParamText, sql.Parameters);
            if (Outputs[0] is ScalarVar)
            {
              ((ScalarVar)Outputs[0]).InternalValue = value;
              return (ScalarVar)Outputs[0];
            }
            else
            {
              ScalarVar var = Structure.CreateVar("Var_" + Name, true);
              var.InternalValue = value;
              return var;
            }
          }
        case QueryType.Comando:
          {
            int value = Connection.ExecuteNonQuery(sql.ParamText, sql.Parameters);
            if (Outputs[0] is ScalarVar)
            {
              ((ScalarVar)Outputs[0]).InternalValue = value;
              return (ScalarVar)Outputs[0];
            }
            else
            {
              ScalarVar var = Structure.CreateVar("Var_" + Name, true);
              var.InternalValue = value;
              return var;
            }
          }
      }
      return null;
    }

    #region IScriptedObject Members
    [Browsable(false)]
    public string Script
    {
      get
      {
        return Sql;
      }
      set
      {
        Sql = value;
      }
    }
    [Browsable(false)]
    public string Language
    {
      get { return "SQL"; }
    }

    #endregion
  }
}
