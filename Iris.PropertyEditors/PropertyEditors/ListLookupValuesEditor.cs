using System;
using System.Collections.Generic;
using System.Text;
using Iris.DataGenerator;
using Iris.PropertyEditors.PropertyEditors.Dialogs;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class ListLookupValuesEditor : BaseDialogEditor<IListLookup>
  {
    protected override object GetValue(IListLookup Instance)
    {
      StringListEditorDialog dlg = new StringListEditorDialog();
      dlg.SetStringList(Instance.Values);
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        Instance.Values = dlg.GetStringList();
      }

      return Instance.Values;
    }
  }
}
