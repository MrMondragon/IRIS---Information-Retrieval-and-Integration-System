using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.Operations;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using System.Data;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.DataGenerator
{
  [Serializable]
  public abstract class BaseRowGenerator : DynamicLinkOperation
  {

    public BaseRowGenerator(Structure structure, string name)
      : base(structure, name)
    {
      SetOutputs("Saída", "RowNum");
    }

    protected override void doRefreshIO()
    {
      Dictionary<string, IOperation> oldInputs = new Dictionary<string, IOperation>();
      for (int i = 0; i < InputCount; i++)
      {
        oldInputs[GetInputName(i)] = GetInput(i);
      }

      IOperation saida = GetOutput("Saída");
      IOperation rowNum = GetOutput("RowNum");

      SetInputs(GetFieldList());

      for (int i = 0; i < InputCount; i++)
      {
        string inputName = GetInputName(i);
        if (oldInputs.ContainsKey(inputName))
          SetInput(inputName, oldInputs[inputName]);
      }

      SetOutput("Saída", saida);
      SetOutput("RowNum", rowNum);
    }

    protected abstract void GetInstanceInputs(List<string> fieldList);


    private string[] GetFieldList()
    {
      List<string> fieldList = new List<string>();
      GetInstanceInputs(fieldList);

      FillFieldList(fieldList);
      return fieldList.ToArray();
    }

    private void FillFieldList(List<string> fieldList)
    {
      if ((GetOutput(0) != null) && (GetOutput(0) is ResultSet))
      {
        ResultSet rs = (ResultSet)GetOutput(0);
        DataTable table = rs.Table;
        if (table == null)
          fieldList.Clear();
        else
        {
          foreach (DataColumn column in table.Columns)
          {
            fieldList.Add(column.ColumnName);
          }
        }
      }
    }


    public override void SetOutput(int idx, IOperation output)
    {
      IOperation oldOutput = GetOutput(idx);

      base.SetOutput(idx, output);

      if ((idx == 0) && (oldOutput != output))
      {
        RefreshIO();
      }
    }

    protected override bool PrepareInputs()
    {
      return false;
    }

    protected abstract int GetRowCount();
    private Dictionary<string, Operation> inputOperations;
    private int count;

    protected override IEntity doExecute()
    {
      count = GetRowCount();
      List<string> fieldList = new List<string>();
      FillFieldList(fieldList);
      ResultSet rs = (ResultSet)GetOutput("Saída");
      DataTable table = rs.Table;

      FillInputOperations();
      table.BeginLoadData();

      Structure.DisableLog();
      try
      {
        for (int i = 0; i < count; i++)
        {
          DataRow row = table.NewRow();
          SetValue("RowNum", i);
          List<String> processed = new List<String>();
          foreach (KeyValuePair<string, Operation> item in inputOperations)
          {

            if (!processed.Contains(item.Key))
            {
              try
              {
                item.Value.Execute();
              }
              catch(Exception e)
              {
                Structure.EnableLog();
                this.Structure.AddToErrorLog("Falha da execução da operação " + item.Value.DisplayText, item.Value);
                this.Structure.AddToLog(item.Value.DisplayText, e, item.Value);
                throw;
              }
              processed.Add(item.Key);
            }

            object value = GetValue(item.Key);
            if (value is ScalarVar)
              value = ((ScalarVar)value).Value;
            row[item.Key] = value;
          }

          table.LoadDataRow(row.ItemArray, false);
        }
      }
      finally
      {
        Structure.EnableLog();
      }

      Structure.AddToLog(string.Format("{0} Registros inseridos", count), this);

      table.EndLoadData();

      return (IEntity)GetValue("Entrada");

    }  

    private void FillInputOperations()
    {
      inputOperations = new Dictionary<string, Operation>();
      List<string> fieldList = new List<string>();
      FillFieldList(fieldList);
      foreach (string fieldName in fieldList)
      {
        if (InputNames.Contains(fieldName))
        {
          if (GetInput(fieldName) != null)
          {
            Operation oper;

            if (!(GetInput(fieldName) is ScalarVar))
              oper = ((Operation)GetInput(fieldName));
            else
            {
              oper = GetFeedingOper((ScalarVar)GetInput(fieldName));
            }

            inputOperations[fieldName] = oper;
          }
        }
      }
    }

    private Operation GetFeedingOper(ScalarVar scalarVar)
    {
      return Structure.Operations.Select(x => (Operation)x).Where(x => (x.Outputs != null) && (x.Outputs.Contains(scalarVar))).FirstOrDefault();
    }


  }
}
