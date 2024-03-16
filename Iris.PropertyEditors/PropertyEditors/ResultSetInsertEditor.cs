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

  public class ResultSetInsertEditor : BaseDialogEditor<IResultSet>
  {
    protected override object GetValue(IResultSet Instance)
    {
      ScriptEditorDialog dlg = new ScriptEditorDialog();
      dlg.Script = Instance.InsertCommand;

      if (dlg.ShowDialog() == DialogResult.OK)
      {
        Instance.InsertCommand = dlg.Script;
      }
      return Instance.InsertCommand;
    }
  }
}
