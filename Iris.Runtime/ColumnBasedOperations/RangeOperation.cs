using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using System.Data;
using System.ComponentModel;
using Iris.Runtime.Properties;
using System.Drawing;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using System.Drawing.Design;
using Iris.Runtime.Model.PropertyEditors;
using Iris.PropertyEditors.PropertyEditors;
using System.Linq;

namespace Iris.Runtime.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Categorizador")]
  public class RangeOperation: ColumnBasedOperation, Iris.Runtime.ColumnBasedOperations.IRangeOperation
  {
    public RangeOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      Ranges = new Dictionary<decimal, decimal>();
      Labels = new Dictionary<decimal, string>();
    }

    [Browsable(false)]
    public Dictionary<decimal, decimal> Ranges { get; set; }

    [Editor(typeof(RangeEditor), typeof(UITypeEditor))]
    public Dictionary<decimal, string> Labels { get; set; }

    protected override IEntity doExecute()
    {
      ResultSet rs = (ResultSet)Entrada;
      DataTable table = rs.Table;
      DataColumn column;
      DataColumn colunaBase = table.Columns[Column];

      if (table.Columns.Contains(ColumnName))
        column = table.Columns[ColumnName];
      else
      {
        column = new DataColumn(ColumnName);
        table.Columns.Add(column);
      }

      foreach (DataRow row in table.Rows)
      {
        if (!Convert.IsDBNull(row[colunaBase]))
        {
          decimal valor = Convert.ToDecimal(row[colunaBase]);
          decimal? key = Ranges.Where(x => (valor >= x.Key) && (valor <= x.Value)).Select(y => y.Key).FirstOrDefault();

          if (key.HasValue)
            row[column] = Labels[key.Value];
          else
            row[column] = DBNull.Value;
        }
      }

      return null;
    }

    public static Bitmap GetIcon()
    {
      return Resources.Ranges;
    }
  }
}
