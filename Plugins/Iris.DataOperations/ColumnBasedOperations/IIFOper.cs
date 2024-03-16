using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using System.Data;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Operações de Colunas", "IIF")]
  public class IIFOper : ColumnBasedOperation
  {
    public IIFOper(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    private string testExpression;
    [DisplayName("Expressão"), Category("Expressão"), Description("Expressão de Teste")]
    public string TestExpression
    {
      get { return testExpression; }
      set 
      {
        if (testExpression != value)
        {
          testExpression = value;
          Reset();
        }
      }
    }

    private string valTrue;
    [DisplayName("Verdadeiro"), Category("Expressão"), Description("Valor que será usado quando a expressão de teste avaliar verdadeiro")]
    public string ValTrue
    {
      get { return valTrue; }
      set 
      {
        if (valTrue != value)
        {
          valTrue = value;
          Reset();
        }
      }
    }

    private string valFalse;
    [DisplayName("Falso"), Category("Expressão"), Description("Valor que será usado quando a expressão de teste avaliar falso")]
    public string ValFalse
    {
      get {return valFalse;}
      set 
      {
        if (valFalse != value)
        {
          valFalse = value;
          Reset();
        }
      }
    }

    [Browsable(false)]
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

	  protected override Iris.Interfaces.IEntity doExecute()
    {
      DataTable table = Entrada.Table; 
      if ((dColumn == null) || (!table.Columns.Contains(ColumnName)))
      {
        if (string.IsNullOrEmpty(ColumnName))
          throw new Exception("A propriedade Coluna Resultante não foi atribuída");

        string expression = "IIF(" + TestExpression + "," + ValTrue + "," + ValFalse + ")";

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
