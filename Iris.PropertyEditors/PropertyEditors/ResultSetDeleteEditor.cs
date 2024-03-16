using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;
using Iris.PropertyEditors.Dialogs;
using System.Windows.Forms;
using Iris.Interfaces;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Runtime.Model.PropertyEditors
{

  public class ResultSetDeleteEditor : BaseDialogEditor<IResultSet>
  {
    protected override object GetValue(IResultSet Instance)
    {
      ScriptEditorDialog dlg = new ScriptEditorDialog();
      dlg.Script = Instance.DeleteCommand;

      if (dlg.ShowDialog() == DialogResult.OK)
      {
        Instance.DeleteCommand = dlg.Script;
      }
      return Instance.DeleteCommand;
    }
  }
}
