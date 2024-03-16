using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;
using System.Net;
using Iris.PropertyEditors.PropertyEditors.Dialogs;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class CredentialsEditor : BaseDialogEditor<ICredentialOperation>
  {
    protected override object GetValue(ICredentialOperation Instance)
    {
      CredentialsEditorDialog dlg = new CredentialsEditorDialog();
      if (Instance.Credentials != null)
      {
        dlg.User = Instance.Credentials.UserName;
        dlg.Domain = Instance.Credentials.Domain;
      }
      if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        if((!string.IsNullOrEmpty(dlg.User)) && (!string.IsNullOrEmpty(dlg.Password)))
          Instance.Credentials = new NetworkCredential(dlg.User, dlg.Password, dlg.Domain);
        else
          Instance.Credentials = null;
      }

      return Instance.Credentials;
    }
  }
}
