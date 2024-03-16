using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using System.Data;
using Databridge.Engine.Extensions;
using Iris.Runtime.Properties;
using System.Drawing;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;

namespace Iris.Runtime.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Cálculo de Idade")]
  public class Idade : ColumnBasedOperation
  {
    public Idade(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    public DateRange Range { get; set; }

    public string Formato { get; set; }

    protected override Iris.Interfaces.IEntity doExecute()
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

      foreach (DataRow row in table.Rows)
      {
        if ((!Convert.IsDBNull(row[colunaBase]))&& (!String.IsNullOrWhiteSpace(Convert.ToString(row[colunaBase]))))
        {
          if (string.IsNullOrEmpty(Formato))
            Formato = "";
          try
          {
            DateTime dataNascimento = Convert.ToString(row[colunaBase]).ToDate(Formato);
            TimeSpan tempoDecorrido = DateTime.Today - dataNascimento;
            switch (Range)
            {
              case DateRange.Dias:
                row[idx] = tempoDecorrido.TotalDays;
                break;
              case DateRange.Meses:
                row[idx] = tempoDecorrido.TotalDays / 30;
                break;
              case DateRange.Anos:
                row[idx] = ((new DateTime() + tempoDecorrido).AddYears(-1)).Year;
                break;
              default:
                break;
            }
          }
          catch
          {

          }

          
        }
      }

      return null;
    }

    public static Bitmap GetIcon()
    {
      return Resources.Idade;
    }
  }

  public enum DateRange
  {
    Dias,
    Meses,
    Anos

  }
}
