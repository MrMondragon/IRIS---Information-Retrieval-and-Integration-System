using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.Data;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Operações de Colunas", "Trim")]
  public class TrimOper : ColumnBasedOperation
  {
    public TrimOper(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }



    protected override Iris.Interfaces.IEntity doExecute()
    {
      DataTable table = Entrada.Table;
      if ((dColumn == null) || (!table.Columns.Contains(ColumnName)))
      {
        if (string.IsNullOrEmpty(ColumnName))
          throw new Exception("A propriedade Coluna Resultante não foi atribuída");

        if (Column == null)
          throw new Exception("A Coluna Base não foi atribuída");

        string expression = "TRIM(" + Column + ")";

        if (table.Columns.Contains(ColumnName))
        {
          dColumn = table.Columns[ColumnName];
          dColumn.Expression = expression;
        }
        else
        {
          dColumn = new DataColumn(ColumnName, typeof(String), expression);
          table.Columns.Add(dColumn);
        }
      }
   
      return (IEntity)Entrada;
    }
  }
}
