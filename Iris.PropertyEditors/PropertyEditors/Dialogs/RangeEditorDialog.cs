using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors.Dialogs
{
  public partial class RangeEditorDialog : Form
  {
    public RangeEditorDialog()
    {
      InitializeComponent();

      if (Application.OpenForms.Count > 0)
        this.Icon = Application.OpenForms[0].Icon;
    }


    public Dictionary<decimal, decimal> Ranges { get; set; }
    public Dictionary<decimal, string> Labels { get; set; }

    public DialogResult Edit(Dictionary<decimal, decimal> ranges, Dictionary<decimal, string> labels)
    {
      foreach (KeyValuePair<decimal, decimal> item in ranges)
      {
        dataGridView1.Rows.Add(item.Key, item.Value, labels[item.Key]);
      }

      if (this.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        Ranges = new Dictionary<decimal, decimal>();
        Labels = new Dictionary<decimal, string>();

        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
          if ((!string.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value))) &&
              (!string.IsNullOrEmpty(Convert.ToString(row.Cells[1].Value))) &&
              (!string.IsNullOrEmpty(Convert.ToString(row.Cells[2].Value))))
          {
            Ranges[Convert.ToDecimal(row.Cells[0].Value)] = Convert.ToDecimal(row.Cells[1].Value);
            Labels[Convert.ToDecimal(row.Cells[0].Value)] = Convert.ToString(row.Cells[2].Value);
          }
        }
      }

      return this.DialogResult;
    }
  }
}
