using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.NetworkOperations;
using Databridge.Interfaces.BaseEditors;
using Iris.PropertyEditors.PropertyEditors.Dialogs;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class ParameterMappingEditor: BaseDialogEditor<IBatchWebService>
  {
    protected override object GetValue(IBatchWebService Instance)
    {
      ParameterMappingEditorDialog dlg = new ParameterMappingEditorDialog();

      dlg.ParameterMappings = Instance.ParameterMappings;
      dlg.InitializeFields(Instance.Entrada.Table);

      if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        Instance.ParameterMappings = dlg.ParameterMappings;
      }

      return Instance.ParameterMappings;
    }
  }
}
