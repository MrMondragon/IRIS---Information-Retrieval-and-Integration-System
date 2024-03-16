using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Iris.Runtime.ControlOperations.Dialogs
{
  public partial class RequestValueDialog : Form
  {
    public RequestValueDialog()
    {
      InitializeComponent();
    }

    public DialogResult Execute(string label, string title, string value)
    {
      this.Text = title;
      label1.Text = label;
      textBox1.Text = value;
      return this.ShowDialog();
    }


    public string Value
    {
      get { return textBox1.Text; }
      set { textBox1.Text = value; }
    }

  }
}
