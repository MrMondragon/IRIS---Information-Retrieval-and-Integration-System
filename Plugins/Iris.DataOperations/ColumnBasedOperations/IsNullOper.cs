using System;
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
  [OperationCategory("Opera��es de Colunas", "IsNull")]
  public class IsNullOper : ColumnBasedOperation
  {
    public IsNullOper(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    private string replacement;
    [DisplayName("Valor de Substitui��o"), Category("Express�o"), Description("Valor que ser� utilizado sempre que a coluna apresentar um valor nulo")]
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

    protected override Iris.Interfaces.IEntity doExecute()
    {
      DataTable table = Entrada.Table;

      if (string.IsNullOrEmpty(ColumnName))
        throw new Exception("A propriedade Coluna Resultante n�o foi atribu�da");

      if (Column == null)
        throw new Exception("A Coluna Base n�o foi atribu�da");

      string expression = "ISNULL(" + Column + "," + Replacement + ")";

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


      return (IEntity)Entrada;
    }
  }
}
