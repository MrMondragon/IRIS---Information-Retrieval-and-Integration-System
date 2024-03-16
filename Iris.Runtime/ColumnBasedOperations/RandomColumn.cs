using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using System.Data;
using System.ComponentModel;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;

namespace Iris.Runtime.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Valor Aleatório")]
  public class RandomColumn : ColumnBasedOperation
  {
    public RandomColumn(Structure aStructure, string aName) : base(aStructure, aName)
    {
    }

    private Random rnd;

    protected override IEntity doExecute()
    {
      ResultSet rs = (ResultSet)Entrada;
      DataTable table = rs.Table;
      DataColumn column;

      if (rnd == null)
        rnd = new Random();

      if (table.Columns.Contains(ColumnName))
        column = table.Columns[ColumnName];
      else
      {
        column = new DataColumn(ColumnName, typeof(int));
        table.Columns.Add(column);
      }

      int count = table.Rows.Count;
      List<int> baseList = new List<int>(count);
      for (int i = 0; i < count; i++)
      {
        baseList.Add(i);
      }

      for (int i = 0; i < count; i++)
      {
        int idx = rnd.Next(baseList.Count);        
        table.Rows[i][column] = baseList[idx];
        baseList.RemoveAt(idx);
      }
      
      return null;
    }
  }
}
