using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Iris.PropertyEditors.Dialogs;
using Iris.Interfaces;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors
{
  public class ScalarVarValueEditor: BaseDialogEditor<IScalarVar>
  {
    protected override object GetValue(IScalarVar Instance)
    {
      ObjectEditorDialog dlg = new ObjectEditorDialog();
      dlg.Value = Instance.RawValue;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        Instance.RawValue = dlg.Value;       
      }
      return Instance.RawValue;
    }
  }
}
