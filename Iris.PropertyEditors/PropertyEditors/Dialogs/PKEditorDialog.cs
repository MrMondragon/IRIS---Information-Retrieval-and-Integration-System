using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.Dialogs
{
  public partial class PKEditorDialog : BaseDialog
  {
    public PKEditorDialog()
    {
      InitializeComponent();
    }

    public List<DataColumn> Execute(List<DataColumn> columns, DataTable _table, string caption)
    {
      this.Text = caption;
      return Execute(columns, _table);
    }

    private DataTable table;

    public List<DataColumn> Execute(List<DataColumn> columns, DataTable _table)
    {
      table = _table;
      return InternalExecute(columns);
    }

    public List<DataColumn> Execute(DataTable _table)
    {
      table = _table;
      List<DataColumn> pk = new List<DataColumn>(table.PrimaryKey);
      return InternalExecute(pk);
    }

    private List<DataColumn> InternalExecute(List<DataColumn> columnList)
    {
      cbxColumns.Items.Clear();
      foreach (DataColumn col in table.Columns)
      {
        cbxColumns.Items.Add(col.ColumnName);
      }

      foreach (DataColumn col in columnList)
      {
        if(!table.Columns.Contains(col.ColumnName))
          cbxColumns.Items.Add(col.ColumnName);
      }

      for (int i = 0; i < cbxColumns.Items.Count; i++)
      {
        string colName = cbxColumns.Items[i].ToString();

        if (columnList.Any(x=> x.ColumnName == colName))
        {
          cbxColumns.SetItemChecked(i, true);
        }
      }

      if (ShowDialog() == DialogResult.OK)
      {
        columnList = new List<DataColumn>();
        foreach (object key in cbxColumns.CheckedItems)
        {
          columnList.Add(table.Columns[Convert.ToString(key)]);
        }
      }
      return columnList;
    }
  }
}

