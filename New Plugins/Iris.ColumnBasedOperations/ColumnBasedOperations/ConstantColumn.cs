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
  [OperationCategory("Operações de Colunas", "Constante")]
  public class ConstantColumn : ColumnBasedOperation
  {
    public ConstantColumn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Variável");
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
        Operation oper = GetInput("Variável");

        if (oper == null)
          throw new Exception("Variável de entrada não atribuída");
        else if (oper is IScalarVar)
          return (IScalarVar)oper;
        else
          return (IScalarVar)oper.EntityValue;
      }
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      if (string.IsNullOrEmpty(ColumnName))
        throw new Exception("A propriedade Coluna Resultante não foi atribuída");

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
