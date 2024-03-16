using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;

namespace Iris.Runtime.Model.DisignSuport
{
  public partial class SortFieldsDialog : BaseDialog
  {
    public SortFieldsDialog()
    {
      InitializeComponent();
    }

    public void Execute(TextLine line)
    {
      Dictionary<string, TextField> fields = new Dictionary<string,TextField>();

      DataTable table = new DataTable();
      table.Columns.Add("Field Name", typeof(string));
      table.Columns.Add("Order", typeof(int));

      for (int i = 0; i < line.Fields.Count; i++)
      {
        fields[line.Fields[i].Name] = line.Fields[i];
        DataRow row = table.NewRow();

        row["Field Name"] = line.Fields[i].Name;


        table.Rows.Add(row);
      }
      DataView view = new DataView(table);


      dataGridView.DataSource = view;
      dataGridView.Columns[0].Width = 234;
      dataGridView.Columns[1].Width = 42;

      if (this.ShowDialog() == DialogResult.OK)
      {
        line.Fields.Clear();
        view.Sort = "Order";
        for (int i = 0; i < view.Count; i++)
        {
          line.Fields.Add(fields[Convert.ToString(view[i]["Field Name"])]);
        }
      }
    }
  }
}