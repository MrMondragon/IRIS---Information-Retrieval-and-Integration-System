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
  [OperationCategory("Opera��es de Colunas", "Constante")]
  public class ConstantColumn : ColumnBasedOperation
  {
    public ConstantColumn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Vari�vel");
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IScalarVar VarEntrada
    {
      get
      {
        IOperation oper = GetInput("Vari�vel");

        if (oper == null)
          return null;
        else if (oper is IScalarVar)
          return (IScalarVar)oper;
        else
          return (IScalarVar)oper.EntityValue;
      }
    }

    private string valor;
    [DisplayName("Valor"), Category("Express�o"), Description("Valor da Constante")]
    public string Valor
    {
      get { return valor; }
      set { valor = value; }
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      if (string.IsNullOrEmpty(ColumnName))
        throw new Exception("A propriedade Coluna Resultante n�o foi atribu�da");

      DataTable table = Entrada.Table;
      
      string expression;
      if (VarEntrada != null)
      {
        object constValue = VarEntrada.RawValue;
        expression = Convert.ToString(constValue);

        if (constValue is string)
          expression = "'" + expression + "'";
        else if (constValue is DateTime)
          expression = "#" + expression + "#";
      }
      else
        expression = valor;


      if (string.IsNullOrEmpty(expression))
        expression = "null";

      if (table.Columns.Contains(ColumnName))
      {
        dColumn = table.Columns[ColumnName];
        dColumn.Expression = expression;
      }
      else
      {
        Type t = typeof(Object);
        t = this.DataType;
        dColumn = new DataColumn(ColumnName, t, expression);
        table.Columns.Add(dColumn);
      }

      return (IEntity)Entrada;
    }
  }
}
