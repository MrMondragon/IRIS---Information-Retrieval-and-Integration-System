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
  [OperationCategory("Transformações", "Constante")]
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
        IOperation oper = GetInput("Variável");

        if (oper == null)
          return null;
        else if (oper is IScalarVar)
          return (IScalarVar)oper;
        else
          return (IScalarVar)oper.EntityValue;
      }
    }

    private string valor;
    [DisplayName("Valor"), Category("Expressão"), Description("Valor da Constante")]
    public string Valor
    {
      get { return valor; }
      set { valor = value; }
    }

    [DisplayName("Editar Coluna"), Category("Expressão")]
    public bool EditColumn { get; set; }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      if (string.IsNullOrEmpty(ColumnName))
        throw new Exception("A propriedade Coluna Resultante não foi atribuída");

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
        else if (constValue is Guid)
        {
          expression = "Convert('" + expression + "', System.Guid)";
        }
        else if ((constValue is decimal) || (constValue is float))
        {
          expression = expression.Replace(',', '.');
        }
      }
      else
        expression = valor;


      if (string.IsNullOrEmpty(expression))
        expression = "null";
      if (!EditColumn)
      {
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
      }
      else
      {
        if(!table.Columns.Contains(ColumnName))
        {
          Type t = this.DataType;      
          dColumn = new DataColumn(ColumnName, t);
          table.Columns.Add(dColumn);
        }
        
        for (int i = 0; i < table.Rows.Count; i++)
        {
          table.Rows[i][ColumnName] = VarEntrada != null? VarEntrada.RawValue:Valor;
        }
      }
      return (IEntity)Entrada;
    }
  }
}
