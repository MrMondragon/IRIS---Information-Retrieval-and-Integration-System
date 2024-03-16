using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;

namespace Iris.Runtime.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Split Column")]
  public class SplitColumn : ColumnBasedOperation
  {

    public SplitColumn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      TamanhoMaximo = 250;
    }

    public string Prefixo { get; set; }
    public int TamanhoMaximo { get; set; }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string ColumnName
    {
      get
      {
        return base.ColumnName;
      }
      set
      {
        base.ColumnName = value;
      }
    }

    protected override Interfaces.IEntity doExecute()
    {
      if (GetInput("Entrada") == null)
        throw new Exception("Resultset de entrada não atribuído");

      if (String.IsNullOrEmpty(Column))
        throw new Exception("Coluna base não atribuída");

      string prefix = Prefixo;

      if (string.IsNullOrEmpty(prefix))
        prefix = Column;

      DataTable table = Entrada.Table;

      List<string> values = table.Rows.Cast<DataRow>().Select(x => Convert.IsDBNull(x[Column]) ? "" : Convert.ToString(x[Column])).ToList();

      decimal maxLength = values.Select(x => x.Length).Max();

      int colunas = Convert.ToInt32(Math.Ceiling(maxLength / TamanhoMaximo));
      for (int i = 0; i < colunas; i++)
      {
        string columnName = string.Format("{0}{1}", Prefixo, i + 1);
        if (!table.Columns.Contains(columnName))
          table.Columns.Add(columnName, typeof(string));
      }


      foreach (DataRow row in table.Rows)
      {

        string valor = Convert.IsDBNull(row[Column]) ? "" : Convert.ToString(row[Column]);

        row.BeginEdit();

        for (int i = 0; i < colunas; i++)
        {
          int start = TamanhoMaximo * i;

          if (start > valor.Length - 1)
            break;

          int end = TamanhoMaximo;

          if ((start + end) > valor.Length)
            end = valor.Length - start;

          if (!string.IsNullOrEmpty(valor))
          {
            string columnName = string.Format("{0}{1}", Prefixo, i + 1);
            string rowValue = valor.Substring(start, end);
            row[columnName] = rowValue;
          }
        }
        row.EndEdit();
      }

      return null;
    }
  }
}
