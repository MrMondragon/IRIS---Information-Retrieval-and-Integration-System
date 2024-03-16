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

namespace Iris.Runtime.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Time Span")]
  public class TimeSpanOperation : ColumnBasedOperation
  {
    public TimeSpanOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    [DisplayName("Data Início"), Category("Expressão")]
    public override string Column
    {
      get
      {
        return base.Column;
      }
      set
      {
        base.Column = value;
      }
    }

    [DisplayName("Data Fim"), Category("Expressão")]
    [Editor(typeof(CBOColumnSelectorEditor), typeof(UITypeEditor))]
    public string ColDataFim { get; set; }

    [DisplayName("Unidade"), Category("Expressão")]
    public TimeUnit Unit { get; set; }

    protected override IEntity doExecute()
    {
      ResultSet rs = (ResultSet)Entrada;
      DataTable table = rs.Table;
      DataColumn dataInicio = table.Columns[Column];
      DataColumn dataFim = table.Columns[ColDataFim];
      DataColumn colResultado;

      if (table.Columns.Contains(ColumnName))
        colResultado = table.Columns[ColumnName];
      else
      {
        colResultado = new DataColumn(ColumnName, typeof(Int32));
        table.Columns.Add(colResultado);
      }

      foreach (DataRow row in table.Rows)
      {
        if (((!Convert.IsDBNull(row[dataInicio])) && (row[dataInicio] is DateTime)) &&
          ((!Convert.IsDBNull(row[dataFim])) && (row[dataFim] is DateTime)))
        {
          DateTime inicio = (DateTime)row[dataInicio];
          DateTime fim = (DateTime)row[dataFim];
          TimeSpan ts = fim - inicio;

          int resultado = 0;
          switch (Unit)
          {
            case TimeUnit.Ano:
              {
                resultado = ((fim.Month - inicio.Month) + 12 * (fim.Year - inicio.Year)) / 12;
              }
              break;
            case TimeUnit.Mes:
              {
                resultado = (fim.Month - inicio.Month) + 12 * (fim.Year - inicio.Year);
              }
              break;
            case TimeUnit.Dia:
              resultado = Convert.ToInt32(ts.TotalDays);
              break;
            case TimeUnit.Hora:
              resultado = Convert.ToInt32(ts.TotalHours);
              break;
            case TimeUnit.Minuto:
              resultado = Convert.ToInt32(ts.TotalMinutes);
              break;
            case TimeUnit.Segundo:
              resultado = Convert.ToInt32(ts.TotalSeconds);

              break;
            default:
              break;
          }

          row[colResultado] = resultado;

        }
        else
        {
          row[colResultado] = DBNull.Value;
        }

      }

      return null;
    }

    public static Bitmap GetIcon()
    {
      return Resources.TimeSpan;
    }
  }

  public enum TimeUnit
  {
    Ano,
    Mes,
    Dia,
    Hora,
    Minuto,
    Segundo
  }

}
