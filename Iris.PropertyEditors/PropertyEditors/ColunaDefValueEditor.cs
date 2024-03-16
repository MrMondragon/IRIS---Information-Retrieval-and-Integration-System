using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Iris.PropertyEditors.Dialogs;
using Iris.PropertyEditors;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Runtime.Model.PropertyEditors
{
  public class ColunaDefValueEditor: BaseDialogEditor<IColuna>
  {
    protected override object GetValue(IColuna Instance)
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
