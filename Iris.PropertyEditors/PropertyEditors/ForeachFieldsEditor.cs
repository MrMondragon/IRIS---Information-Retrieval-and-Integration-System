using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Operations.ControlOperations;
using Iris.Designer;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class ForeachFieldsEditor: BaseDialogEditor<IForEachLoop>
  {
    protected override object GetValue(IForEachLoop Instance)
    {
      FieldsDialog dlg = new FieldsDialog();
      if (dlg.Execute(Instance.Table, Instance.Fields, false) == System.Windows.Forms.DialogResult.OK)
      {
        Instance.Fields = dlg.CamposSelecionados;
      }
      return Instance.Fields;
    }
  }
}
