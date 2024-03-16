using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Model.Entities;
using System.ComponentModel;
using Iris.Interfaces;
using Iris.Runtime.Model.DisignSuport;
using System.Drawing.Design;
using Iris.PropertyEditors;
using System.Data;
using Iris.Runtime.Core.ParserEngine.ParserObjects;
using Databridge.Engine;
using Databridge.Interfaces;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Comando SQL")]
  public class SQLCommand : ControlOperation, IScriptedObject, IConnectedObject
  {

    public SQLCommand(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetOutputs("Saída");
      QueryType = QueryType.Comando;
      Parameters = new Dictionary<string, object>();
    }

    [Editor(typeof(ScriptEditor), typeof(UITypeEditor))]
    public string Sql { get; set; }

    public override void AssignObject(object value)
    {
      this.Sql = Convert.ToString(value);
      Structure.AddToLog(string.Format("Sentença {0} atribuída à operação {1}", value, this.Name), this);
    }


    public Dictionary<string, object> Parameters
    {
      get;
      private set;
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

    public int CommandTimeOut { get; set; }

    protected override IEntity doExecute()
    {
      if((Structure.Connections.Count == 1)&&(this.Connection == null))
        this.Connection = Structure.Connections[0];

      switch (QueryType)
      {
        case QueryType.Registros:
          {
            ResultSet rs;
            if ((GetOutput(0) != null) && (GetOutput(0).EntityValue is ResultSet))
            {
              rs = ((ResultSet)GetOutput(0).EntityValue);

              if (CommandTimeOut > 0)
                rs.TimeOut = CommandTimeOut;

              rs.Connection = Connection;
              rs.Sql = Sql;
              rs.Fill();
              Structure.AddToLog(String.Format("{0} registros carregados", rs.Table.Rows.Count), this);
              return rs;
            }
            else
            {
              return null;
            }

          }
        case QueryType.Valor_Escalar:
          {
            try
            {
              Object value = Connection.ExecuteScalar(Sql, GetContext(), CommandTimeOut);
              Structure.AddToLog(String.Format("Valor = {0}", value), this);
              if ((GetOutput(0) != null) && (GetOutput(0).EntityValue is ScalarVar))
              {
                ((ScalarVar)GetOutput(0).EntityValue).RawValue = value;
                return (ScalarVar)GetOutput(0).EntityValue;
              }
              else
              {
                return null;
              }
            }
            catch (Exception ex)
            {
              Structure.AddToLog(this.Name, ex, this);
              return null;

            }
          }
        case QueryType.Comando:
          {
            int value = Connection.ExecuteNonQuery(Sql, GetContext(), CommandTimeOut);
            Structure.AddToLog(String.Format("{0} registros afetados", value), this);
            if ((GetOutput(0) != null) && (GetOutput(0).EntityValue is ScalarVar))
            {
              ((ScalarVar)GetOutput(0).EntityValue).RawValue = value;
              return (ScalarVar)GetOutput(0).EntityValue;
            }
            else
            {
              return null;
            }
          }
      }
      return null;
    }

    private ExecutionContext GetContext()
    {
      ExecutionContext context = Structure.GetContext();
      context.Parameters = Parameters;
      return context;
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

    IDataConnection IConnectedObject.Connection
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

    IExecutionContext IScriptedObject.Context
    {
      get { return Structure.GetContext(); }
    }

  }
}
