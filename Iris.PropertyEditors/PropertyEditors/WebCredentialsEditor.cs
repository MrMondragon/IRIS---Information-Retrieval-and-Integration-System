using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;
using System.Net;
using Iris.PropertyEditors.PropertyEditors.Dialogs;
using Databridge.Interfaces.BaseEditors;
using Iris.Runtime.NetworkOperations;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class WebCredentialsEditor : BaseDialogEditor<INetworkOperation>
  {
    protected override object GetValue(INetworkOperation Instance)
    {
      CredentialsEditorDialog dlg = new CredentialsEditorDialog();
      if (Instance.WebCredentials != null)
      {
        dlg.User = Instance.WebCredentials.UserName;
        dlg.Domain = Instance.WebCredentials.Domain;
      }
      if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        if((!string.IsNullOrEmpty(dlg.User)) && (!string.IsNullOrEmpty(dlg.Password)))
          Instance.WebCredentials = new NetworkCredential(dlg.User, dlg.Password, dlg.Domain);
        else
          Instance.WebCredentials = null;
      }

      return Instance.WebCredentials;
    }
  }
}
