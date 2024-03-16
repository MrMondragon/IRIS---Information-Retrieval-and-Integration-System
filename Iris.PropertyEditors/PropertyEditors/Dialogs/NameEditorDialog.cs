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
  public partial class NameEditorDialog : BaseDialog
  {
    public NameEditorDialog()
    {
      InitializeComponent();
    }

    public string Nome
    {
      get { return tbNome.Text; }
      set { tbNome.Text = value; }
    }

  }
}