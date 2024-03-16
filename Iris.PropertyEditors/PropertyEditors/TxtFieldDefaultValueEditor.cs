using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Entities.Txt;
using Iris.PropertyEditors.Dialogs;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class TxtFieldDefaultValueEditor: BaseDialogEditor<ITextField>
  {
    protected override object GetValue(ITextField Instance)
    {
      ObjectEditorDialog dlg = new ObjectEditorDialog();
      dlg.Value = Instance.DefaultValue;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        Instance.DefaultValue = dlg.Value;       
      }
      return Instance.DefaultValue;
    }
  }
}
