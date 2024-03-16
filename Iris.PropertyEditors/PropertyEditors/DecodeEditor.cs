using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Databridge.Interfaces.BaseEditors;
using Iris.Interfaces;
using Iris.PropertyEditors.PropertyEditors.Dialogs;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class DecodeEditor: BaseDialogEditor<IDecode>
  {
    protected override object GetValue(IDecode Instance)
    {
      DecodeEditorDialog dlg = new DecodeEditorDialog();
      if (Instance is IColumnAlias)
        dlg.HideDefault();
      dlg.Items = Instance.Items;
      dlg.DefaultValue = Instance.DefaultValue;

      if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        Instance.Items = dlg.Items;
        Instance.DefaultValue = dlg.DefaultValue;
      }

      return Instance.Items;
    }
  }
}
