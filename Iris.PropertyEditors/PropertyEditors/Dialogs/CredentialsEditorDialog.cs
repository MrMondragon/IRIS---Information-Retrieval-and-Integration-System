using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors.Dialogs
{
  public partial class CredentialsEditorDialog : BaseDialog
  {
    public CredentialsEditorDialog()
    {
      InitializeComponent();
    }

    public string User
    {
      get
      {
        return txtUser.Text;
      }
      set
      {
        txtUser.Text = value;
      }
    }

    public string Domain
    {
      get
      {
        return txtDomain.Text;
      }
      set
      {
        txtDomain.Text = value;
      }
    }

    public string Password
    {
      get
      {
        return txtPassword.Text;
      }
    }
  }
}