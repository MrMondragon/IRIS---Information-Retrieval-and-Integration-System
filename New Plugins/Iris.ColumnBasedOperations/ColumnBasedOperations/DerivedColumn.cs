using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using System.Data;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.Runtime.Model.PropertyEditors;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Operações de Colunas", "Coluna Derivada")]
  public class DerivedColumn: ColumnBasedOperation
  {

    public DerivedColumn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    private string columnType;
    [Editor(typeof(ColumnTypeEditor), typeof(UITypeEditor))]
    [DisplayName("Tipo da Coluna"), Category("Expressão")]
    public string ColumnType
    {
      get { return columnType; }
      set 
      {
        if (columnType != value)
        {
          columnType = value;
          Reset();
        }
      }
    }

    private string expression;
    [DisplayName("Expressão"), Category("Expressão")]
    public string Expression
    {
      get { return expression; }
      set 
      {
        if (expression != value)
        {
          expression = value;
          Reset();
        }
      }
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

    protected override IEntity doExecute()
    {
      DataTable table = Entrada.Table;
      if ((dColumn == null) || (!table.Columns.Contains(ColumnName)))
      {
        Type type = Type.GetType("System." + ColumnType);

        if (table.Columns.Contains(ColumnName))
        {
          dColumn = table.Columns[ColumnName];
          dColumn.Expression = Expression;
          dColumn.DataType = type;
        }
        else
        {
          dColumn = new DataColumn(ColumnName, type, Expression);
          table.Columns.Add(dColumn);
        }
      }
      return (IEntity)Entrada;
    }
  }
}
