using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Databridge.Interfaces.BaseEditors;
using Iris.Runtime.ResultSetOperations;
using Iris.PropertyEditors.PropertyEditors.Dialogs;
using System.Windows.Forms;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class SpParamsEditor: BaseDialogEditor<ISpTransport>
  {
    protected override object GetValue(ISpTransport Instance)
    {
      StringListEditorDialog dlg = new StringListEditorDialog();
      dlg.SetStringList(Instance.ParamNames);
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        Instance.ParamNames = dlg.GetStringList();
      }

      return Instance.ParamNames;
    }
  }
}
