using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;
using Iris.PropertyEditors.PropertyEditors.Dialogs;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class ScalarValidValuesEditor: BaseDialogEditor<IScalarVar>
  {
    protected override object GetValue(IScalarVar Instance)
    {
      StringListEditorDialog dlg = new StringListEditorDialog();
      dlg.SetStringList(Instance.ValidValues);
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        Instance.ValidValues = dlg.GetStringList();
      }

      return Instance.ValidValues;
    }
  }
}
