using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using System.Data;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Expressions;
using System.Drawing;
using Iris.Runtime.Model.Properties;
using System.ComponentModel;
using System.Data.SqlClient;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing.Design;
using System.Linq;

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Alias")]
  public class ColumnAlias : ResultSetOperation, IColumnAlias, IDecode
  {
    public ColumnAlias(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
      items = new Dictionary<string, string>();
    }


    private Dictionary<string, string> items;
    [Editor(typeof(DecodeEditor), typeof(UITypeEditor))]
    [DisplayName("Items"), Category("Expressão")]
    public Dictionary<string, string> Items
    {
      get { return items; }
      set { items = value; }
    }

    public override void SetInput(int idx, IOperation input)
    {
      if (input != null)
      {
        if (!(input.EntityValue is IResultSet))
          throw new Exception("Objeto de entrada não é um ResultSet");

        IResultSet resultset = (IResultSet)input.EntityValue;

        base.SetInput(idx, input);

        DataTable table = resultset.Table;

        if (table != null)
        {
          if (Items.Count != 0)
          {
            List<string> missingItems = Items.Where(x => !table.Columns.Contains(x.Key) && !table.Columns.Contains(x.Value)).
              Select(y => y.Key).ToList();
            foreach (string missingItem in missingItems)
            {
              Items.Remove(missingItem);
            }
          }

          foreach (DataColumn column in table.Columns)
          {
            if ((!Items.ContainsKey(column.ColumnName)) && (!Items.ContainsValue(column.ColumnName)))
              Items[column.ColumnName] = column.ColumnName;
          }
        }
      }
    }

    protected override IEntity doExecute()
    {
      IOperation rs = GetInput(0);

      if (rs == null)
        throw new Exception("Objeto de entrada não atribuído");

      if (!(rs.EntityValue is IResultSet))
        throw new Exception("Objeto de entrada não é um ResultSet");

      IResultSet resultset = (IResultSet)rs.EntityValue;

      foreach (KeyValuePair<string, string> item in Items)
      {
        if (resultset.Table.Columns.Contains(item.Key))
          resultset.Table.Columns[item.Key].ColumnName = item.Value;
      }

      return null;
    }

    string IDecode.DefaultValue
    {
      get
      {
        return "";
      }
      set
      {

      }
    }


  }
}
