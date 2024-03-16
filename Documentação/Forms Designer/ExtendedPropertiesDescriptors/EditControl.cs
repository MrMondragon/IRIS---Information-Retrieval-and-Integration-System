using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
  public partial class EditControl : UserControl
  {
    public EditControl()
    {
      InitializeComponent();
    }

    private DataColumn column;

    public DataColumn Column
    {
      get { return column; }
      set 
      {
        if (column != value)
        {
          column = value;

          if (column.MaxLength == -1)
          {
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right;
          }
          else
            this.Width = column.MaxLength * 5;

          if (this.Width >= this.Parent.Width)
            this.Width = this.Parent.Width - 5;

          label1.Text = column.Caption;
        }
      }
    }

    
  }
}
