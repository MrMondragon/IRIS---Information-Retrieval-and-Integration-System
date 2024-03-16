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
using Iris.Runtime.NetworkOperations;
using Iris.PropertyEditors.PropertyEditors;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.NetworkOperations;

namespace Iris.WebOperations
{

  /// <summary>
  /// Esta operação itera todos os registros de uma tabela,
  /// convertendo-os um a um em um em objetos e passando estes objetos como parâmetro para um ws
  /// </summary>
  [Serializable]
  [OperationCategory("Operações de Controle", "Batch Web Service")]
  public class BatchWebService : BaseWebServiceOperation, IColumnBasedOperation, IBatchWebService, IInvokeWebService
  {

    public BatchWebService(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Configs");
      parameterMappings = new List<IParameterMapping>();
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


    private List<IParameterMapping> parameterMappings;
    [Editor(typeof(ParameterMappingEditor), typeof(UITypeEditor))]
    public List<IParameterMapping> ParameterMappings
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
        parameterMappings = new List<IParameterMapping>();
        foreach (ParameterInfo pInfo in ParamInfos)
        {
          ParameterMapping mapping = new ParameterMapping(pInfo.ParameterType, pInfo.Name, this,0);
          parameterMappings.Add(mapping);
        }
      }
    }

    public override void Reset()
    {
      base.Reset();
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
      SetupConfigs();
      Dictionary<string, IParameterMapping> mapDictionary = ParameterMappings.ToDictionary(x => x.ParamName);
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

        object[] paramValues = new object[ParamInfos.Length];
        for (int j = 0; j < ParamInfos.Length; j++)
        {
          paramValues[j] = mapDictionary[ParamInfos[j].Name].Lambda(row);
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
