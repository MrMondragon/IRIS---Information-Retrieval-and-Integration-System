using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.Interfaces;
using System.Data;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.PropertyEditors;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Operações de Colunas", "Convert")]
  public class ConvertColumn: ColumnBasedOperation
  {

    public ConvertColumn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    private string columnType;
    [Editor(typeof(ColumnTypeEditor), typeof(UITypeEditor))]
    [DisplayName("Tipo da Coluna"), Category("Expressão")]
    public string ColumnType
    {
      get 
      { 
        if(string.IsNullOrEmpty(columnType))
          columnType = "String";
        return columnType; 
      }
      set
      {
        if (columnType != value)
        {
          columnType = value;
          Reset();
        }
      }
    }

    protected override IEntity doExecute()
    {
      DataTable table = Entrada.Table; 
      if ((dColumn == null) || (!table.Columns.Contains(ColumnName)))
      {
        Type type = Type.GetType("System." + ColumnType);
        string expression = "Convert(" + Column + ", System." + ColumnType + ")";

        if (table.Columns.Contains(ColumnName))
        {
          dColumn = table.Columns[ColumnName];
          dColumn.Expression = expression;
          dColumn.DataType = type;
        }
        else
        {
          dColumn = new DataColumn(ColumnName, type, expression);
          table.Columns.Add(dColumn);
        }
      }
    
      return (IEntity)Entrada;
    }
  }
}
