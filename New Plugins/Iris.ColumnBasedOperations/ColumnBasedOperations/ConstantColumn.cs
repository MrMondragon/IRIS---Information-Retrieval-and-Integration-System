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
        Operation oper = GetInput("Vari�vel");

        if (oper == null)
          throw new Exception("Vari�vel de entrada n�o atribu�da");
        else if (oper is IScalarVar)
          return (IScalarVar)oper;
        else
          return (IScalarVar)oper.EntityValue;
      }
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      if (string.IsNullOrEmpty(ColumnName))
        throw new Exception("A propriedade Coluna Resultante n�o foi atribu�da");

      DataTable table = Entrada.Table;
      object constValue = VarEntrada.RawValue;
      string expression = Convert.ToString(constValue);

      if (constValue is string)
        expression = "'" + expression + "'";
      else if (constValue is DateTime)
        expression = "#" + expression + "#";

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
        if (constValue != null)
          t = constValue.GetType();
        dColumn = new DataColumn(ColumnName, t, expression);
        table.Columns.Add(dColumn);
      }

      return (IEntity)Entrada;
    }
  }
}
