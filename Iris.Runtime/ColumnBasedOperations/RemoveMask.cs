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

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Remove Mask")]
  public class RemoveMask : ColumnBasedOperation
  {
    public RemoveMask(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    public string CaracteresMascara { get; set; }
    public bool AcceptChanges { get; set; }

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

      int idx = table.Columns.IndexOf(column);

      char[] caracteres = CaracteresMascara.ToCharArray();

      foreach (DataRow row in table.Rows)
      {
        if (!Convert.IsDBNull(row[colunaBase]))
        {
          row.BeginEdit();

          string valor = Convert.ToString(row[colunaBase]);

          foreach (char item in caracteres)
          {
            valor = valor.Replace(item.ToString(), "");
          }

          row[column] = valor;

          row.EndEdit();
        }
      }
      if (AcceptChanges)
        table.AcceptChanges();
      return null;
    }

    public static Bitmap GetIcon()
    {
      return Resources.RemoveMask;
    }

  }
}
