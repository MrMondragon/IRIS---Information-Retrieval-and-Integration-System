using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Iris.PropertyEditors.Dialogs
{
  public partial class BaseDialog : Form
  {
    public BaseDialog()
    {
      InitializeComponent();

      if(Application.OpenForms.Count > 0)
        this.Icon = Application.OpenForms[0].Icon;
      
    }
  }
}