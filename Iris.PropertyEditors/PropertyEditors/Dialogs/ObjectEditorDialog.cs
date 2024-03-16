using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.Dialogs
{
  public partial class ObjectEditorDialog : BaseDialog
  {
    public ObjectEditorDialog()
    {
      InitializeComponent();
    }

    public object Value
    {
      get { return objectEditorControl1.Value; }
      set { objectEditorControl1.Value = value;}
    }
  }
}