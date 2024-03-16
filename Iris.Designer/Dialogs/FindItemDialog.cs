using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Designer
{
  public partial class FindItemDialog : BaseDialog
  {
    public FindItemDialog()
    {
      InitializeComponent();
    }

    public string Execute()
    {
      string result = "";
      if (this.ShowDialog() == DialogResult.OK)
      {
        result = txtSearch.Text;
      }
      return result;
    }
  }
}