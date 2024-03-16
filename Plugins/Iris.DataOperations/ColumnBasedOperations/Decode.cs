using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using System.Data;
using Iris.Interfaces;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing.Design;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Operações de Colunas", "Decode")]
  public class Decode : ColumnBasedOperation, IDecode
  {
    public Decode(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      Items = new Dictionary<string, string>();
    }

    private Dictionary<string, string> items;
    [Editor(typeof(DecodeEditor), typeof(UITypeEditor))]
    [DisplayName("Items"), Category("Expressão")]
    public Dictionary<string, string> Items
    {
      get { return items; }
      set { items = value; }
    }

    private string defaultValue;

    public string DefaultValue
    {
      get { return defaultValue; }
      set { defaultValue = value; }
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      DataTable table = Entrada.Table;
      if ((dColumn == null) || (!table.Columns.Contains(ColumnName)))
      {
        if (string.IsNullOrEmpty(ColumnName))
          throw new Exception("A propriedade Coluna Resultante não foi atribuída");
      }

      if (Column == null)
        throw new Exception("A Coluna Base não foi atribuída");

      string expression = string.Format("'{0}'", DefaultValue);
      foreach (KeyValuePair<string, string> item in Items)
      {
        string testExp = string.Format("{0} = '{1}'", Column, item.Key);
        expression = string.Format("IIF({0},'{1}',{2})", testExp, item.Value, expression);
      }

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
