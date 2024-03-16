using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      DataTable table = dataSet11.Tables[0];
      for (int i = 0; i < table.Columns.Count; i++)
      {
        EditControl control = new EditControl();
        flowLayoutPanel1.Controls.Add(control);
        control.Column = table.Columns[i];
      }

    }
  }
}
