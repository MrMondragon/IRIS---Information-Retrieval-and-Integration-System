using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors;
using Databridge.Interfaces;

namespace Iris.PropertyEditors.Dialogs
{
  public partial class ConnectionEditorDialog : BaseDialog
  {
    public ConnectionEditorDialog()
    {
      InitializeComponent();
    }

    public IDataConnection Connection
    {
      get { return connectionEditorControl.Connection; }
      set { connectionEditorControl.Connection = value; }
    }

  }
}

