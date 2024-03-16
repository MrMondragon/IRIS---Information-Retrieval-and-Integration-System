using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.Data;
using Iris.Runtime.Model.DisignSuport;
using System.ComponentModel;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Sub-String")]
  public class SubString : ColumnBasedOperation
  {

    public SubString(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }    

    private int start;
    [DisplayName("Início"), Category("Sub-String"), Description("Início da sub-string, iniciando em 1.")]
    public int Start
    {
      get { return start; }
      set 
      {
        if (start != value)
        {
          start = value;
          Reset();
        }
      }
    }

    private int len;
    [DisplayName("Quantidade"), Category("Sub-String"), Description("Quantidade de caracteres.")]
    public int Len
    {
      get { return len; }
      set 
      {
        if (len != value)
        {
          len = value;
          Reset();
        }
      }
    }
	
    protected override IEntity doExecute()
    {
      DataTable table = Entrada.Table;
     
      if ((dColumn == null) || (!table.Columns.Contains(ColumnName)))
      {
        if (string.IsNullOrEmpty(Column))
          throw new Exception("A propriedade Coluna Base não foi atribuída");

        if (string.IsNullOrEmpty(ColumnName))
          throw new Exception("A propriedade Coluna Resultante não foi atribuída");

        if (Len == 0)
          throw new Exception("A Quantidade de caracteres não pode ser 0");

        string expression = "SUBSTRING(" + Column + "," + Convert.ToString(Start) + "," + Convert.ToString(Len) + ")";

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
