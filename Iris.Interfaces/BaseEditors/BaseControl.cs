using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Iris.PropertyEditors.Controls
{
  public partial class BaseControl : UserControl
  {
    public BaseControl()
    {
      InitializeComponent();
    }

    protected void OnPropertyChanged()
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new EventArgs());
    }

    public event EventHandler PropertyChanged;

  }
}
