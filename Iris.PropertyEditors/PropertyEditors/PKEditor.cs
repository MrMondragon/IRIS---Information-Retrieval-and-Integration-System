using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;
using Iris.PropertyEditors.Dialogs;
using System.Data;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors
{
  public class PKEditor: BaseDialogEditor<IResultSet>
  {
    protected override object GetValue(IResultSet Instance)
    {
      PKEditorDialog dlg = new PKEditorDialog();
      Instance.Table.PrimaryKey = Instance.PrimaryKey.ToArray();
      List<DataColumn> pk = dlg.Execute(Instance.Table);
      if (pk != Instance.PrimaryKey)
        Instance.PrimaryKey = pk;

      return pk;
    }
  }
}
