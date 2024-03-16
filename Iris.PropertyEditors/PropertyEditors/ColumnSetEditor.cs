using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;
using Iris.PropertyEditors.Dialogs;
using System.Data;
using Databridge.Interfaces.BaseEditors;
using Iris.Runtime.ResultSetOperations;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class ColumnSetEditor : BaseDialogEditor<IColumnSetOperation>
  {
    protected override object GetValue(IColumnSetOperation Instance)
    {
      PKEditorDialog dlg = new PKEditorDialog();
      List<DataColumn> cs = dlg.Execute(Instance.Columnset, Instance.Table);
      if (cs != Instance.Columnset)
        Instance.Columnset = cs;

      return cs;
    }
  }
}
