using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using Iris.Interfaces;
using System.Data;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "IsNumber")]
  public class IsNumber : ColumnBasedOperation
  {
    public IsNumber(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    private string replacement;
    [DisplayName("Valor de Substituição"), Category("Expressão"), Description("Valor que será utilizado sempre que a coluna apresentar um valor numérico")]
    public string Replacement
    {
      get { return replacement; }
      set
      {
        if (replacement != value)
        {
          replacement = value;
          Reset();
        }
      }
    }

    [DisplayName("Valor Alternativo"), Category("Expressão")]
    public string ElseReplacement { get; set; }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      DataTable table = Entrada.Table;

      if (string.IsNullOrEmpty(ColumnName))
        throw new Exception("A propriedade Coluna Resultante não foi atribuída");

      if (Column == null)
        throw new Exception("A Coluna Base não foi atribuída");



      if (table.Columns.Contains(ColumnName))
      {
        dColumn = table.Columns[ColumnName];
        dColumn.Expression = "";
      }
      else
      {
        dColumn = new DataColumn(ColumnName, typeof(String));
        table.Columns.Add(dColumn);
      }


      foreach (DataRow row in table.Rows)
      {
        string value = Convert.ToString(row[Column]);

        int intVal = 0;

        string rowValue = "";

        List<string> testString = value.ToCharArray().Select(x => Convert.ToString(x)).ToList();
        bool testResult = testString.All(x => Int32.TryParse(x, out intVal));

        if (testResult)
          rowValue = Replacement;
        else
          rowValue = ElseReplacement;

        if (!rowValue.Contains("'"))
          row[ColumnName] = row[rowValue];
        else
          row[ColumnName] = rowValue.Trim('\'');


      }


      return (IEntity)Entrada;
    }
  }
}
