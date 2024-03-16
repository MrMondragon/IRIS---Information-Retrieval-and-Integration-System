using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Operations.ControlOperations;
using Iris.PropertyEditors.PropertyEditors.Dialogs;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class ChoiceEditor: BaseDialogEditor<IChoice>
  {
    protected override object GetValue(IChoice Instance)
    {
      ChoiceEditorDialog dlg = new ChoiceEditorDialog();
      Instance.Alternatives = dlg.Execute(Instance.Alternatives);
      Instance.RefreshIO();
      return Instance.Alternatives;
    }
  }
}
