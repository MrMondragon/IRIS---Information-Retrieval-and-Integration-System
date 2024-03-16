using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors.Dialogs;
using Iris.Interfaces;
using Databridge.Interfaces.BaseEditors;
using Databridge.Interfaces;

namespace Iris.PropertyEditors
{
  public class ScriptEditor : BaseDialogEditor<IScriptedObject>
  {
    protected override object GetValue(IScriptedObject Instance)
    {
      ScriptEditorDialog dlg = new ScriptEditorDialog();      
      dlg.SelectedObject = Instance;
      dlg.language = Instance.Language;
      dlg.Script = Instance.Script;
      dlg.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      dlg.syntaxControl1.Structure = ((IOperation)Instance).Structure;
        

      if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        Instance.Script = dlg.Script;
      }
      return Instance.Script;
    }
  }
}
