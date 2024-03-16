using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using Iris.Interfaces;
using Iris.WebOperations.ROMapping;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Iris.Runtime.Model.PropertyEditors;
using System.Drawing.Design;
using System.Reflection;
using System.Linq.Expressions;
using System.Data;

namespace Iris.WebOperations
{
  public class BatchWebService : BaseWebServiceOperation, IColumnBasedOperation
  {

    public BatchWebService(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
      parameterMappings = new List<ParameterMapping>();
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


    private List<ParameterMapping> parameterMappings;

    public List<ParameterMapping> ParameterMappings
    {
      get { return parameterMappings; }
      set { parameterMappings = value; }
    }

    private string resultColumn;
    [Editor(typeof(CBOColumnSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Coluna Resultado")]
    public string ResultColumn
    {
      get { return resultColumn; }
      set { resultColumn = value; }
    }

    public override System.Reflection.MethodInfo Method
    {
      get
      {
        return base.Method;
      }
      set
      {
        base.Method = value;
        parameterMappings = new List<ParameterMapping>();
        foreach (ParameterInfo pInfo in paramInfos)
        {
          ParameterMapping mapping = new ParameterMapping(pInfo.ParameterType, pInfo.Name);
        }
      }
    }

    public override void Reset()
    {
      foreach (ParameterMapping map in ParameterMappings)
      {
        map.Reset();
      }      
    }

    private bool fullCommit;

    public bool FullCommit
    {
      get { return fullCommit; }
      set { fullCommit = value; }
    }

    protected override IEntity doExecute()
    {
      Dictionary<string, ParameterMapping> mapDictionary = ParameterMappings.ToDictionary(x => x.ParamName);
      bool feedback = false;

      if (!string.IsNullOrEmpty(ResultColumn))
      {
        if (!Entrada.Table.Columns.Contains(ResultColumn))
          Entrada.Table.Columns.Add(ResultColumn);

        feedback = true;
      }

      for (int i = 0; i < Entrada.Table.Rows.Count; i++)
      {
        DataRow row = Entrada.Table.Rows[i];               

        object[] paramValues = new object[paramInfos.Length];
        for (int j = 0; j < paramInfos.Length; j++)
        {
          paramValues[j] = mapDictionary[paramInfos[j].Name].Lambda(row);
        }

        Object returnValue = Proxy.Invoke(Method.Name, paramValues);

        if (feedback)
        {
          row.BeginEdit();
          row[ResultColumn] = returnValue;

          if (FullCommit)
            row.EndEdit();
        }
      }

      return (IEntity)Entrada;
    }

    #region IColumnBasedOperation Members

    string IColumnBasedOperation.Column
    {
      get
      {
        return ResultColumn;
      }
      set
      {
        ResultColumn = value;
      }
    }

    string IColumnBasedOperation.ColumnName
    {
      get
      {
        return ResultColumn;
      }
      set
      {
        ResultColumn = value;
      }
    }


    #endregion
  }
}
