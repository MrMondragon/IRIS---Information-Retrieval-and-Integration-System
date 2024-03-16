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
using Databridge.Engine.Parsers.QueryObjects;
using Databridge.Engine.Parsers;
using Databridge.Engine;
using Databridge.Engine.Parsers.QueryObjects.Interfaces;
using Databridge.Interfaces;
namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "SQL em Memória")]
  public class DatasetSQL : Operation, IScriptedObject
  {

    public DatasetSQL(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetOutputs("Saída");
      QueryType = QueryType.Comando;
      Parameters = new Dictionary<string, object>();
    }

    [Editor(typeof(ScriptEditor), typeof(UITypeEditor))]
    public string Sql
    {
      get;
      set;
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

    protected override IEntity doExecute()
    {
      if (QueryType == QueryType.Registros)
      {
        IOperation oResultset = GetOutput(0);

        if ((oResultset != null) && (oResultset.EntityValue is ResultSet))
        {
          ResultSet rs = ((ResultSet)oResultset.EntityValue);
          rs.Sql = Sql;
          rs.InMemory = true;
          rs.Fill();
          Structure.AddToLog(String.Format("{0} registros carregados", rs.View.Count), this);
          return rs;
        }
        else
        {
          return null;
        }
      }
      else
      {
        ExecutionContext context = Structure.GetContext();
        context.Parameters = Parameters;

        Query q = QueryParser.GetParser().Parse(Sql, context);

        if (QueryType == QueryType.Valor_Escalar)
        {
          object value = ((IExecuteScalar)q.Statements[0]).ExecuteScalar(context);
   
          IOperation oScalarVar = GetOutput(0);
          Structure.AddToLog(String.Format("Valor = {0}", value), this);

          if ((oScalarVar != null) && (oScalarVar.EntityValue is ScalarVar))
          {
            ((ScalarVar)oScalarVar.EntityValue).RawValue = value;
            return (ScalarVar)oScalarVar;
          }
          else
          {
            return null;
          }

        }
        else if (QueryType == QueryType.Comando)
        {
          int value = ((IExecuteNonQuery)q.Statements[0]).ExecuteNonQuery(context);

          IOperation oScalarVar = GetOutput(0);
          Structure.AddToLog(String.Format("{0} registros afetados", value), this);

          if ((oScalarVar != null) && (oScalarVar.EntityValue is ScalarVar))
          {
            ((ScalarVar)oScalarVar.EntityValue).RawValue = value;
            return (ScalarVar)oScalarVar.EntityValue;
          }
          else
          {
            return null;
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

    [Browsable(false)]
    IExecutionContext IScriptedObject.Context
    {
      get { return Structure.GetContext(); }
    }
    #endregion
  }
}
