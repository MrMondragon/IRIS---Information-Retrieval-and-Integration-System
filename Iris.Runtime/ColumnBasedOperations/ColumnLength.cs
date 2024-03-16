using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.ComponentModel;
using Iris.Runtime.Model.Entities;
using System.Data;

namespace Iris.Runtime.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Largura da Coluna")]
  public class ColumnLength : ColumnBasedOperation
  {
    public ColumnLength(Structure aStructure, string aName) : base(aStructure, aName)
    {
    }

    protected override IEntity doExecute()
    {
      ResultSet rs = (ResultSet)Entrada;
      DataTable table = rs.Table;
      DataColumn column;

      if (table.Columns.Contains(ColumnName))
        column = table.Columns[ColumnName];
      else
      {
        column = new DataColumn(ColumnName, typeof(Int32));
        table.Columns.Add(column);
      }


      int idx = table.Columns.IndexOf(column);

      foreach (DataRow row in table.Rows)
      {
        row.BeginEdit();

        string value = Convert.ToString(row[Column]);
        row[column] = value.Length;

        row.EndEdit();
      }


      return (IEntity)Entrada;
    }
  }
}
