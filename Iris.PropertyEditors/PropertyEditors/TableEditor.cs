using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;
using Iris.Runtime.Model.PropertyEditors.Dialogs;
using Iris.Interfaces;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Runtime.Model.PropertyEditors
{
  public class TableEditor: BaseDialogEditor<IResultSet>
  {
    protected override object GetValue(IResultSet Instance)
    {
      TableEditorDialog dlg = new TableEditorDialog();
      if (Instance.HasView())
        dlg.DataSource = Instance.View;
      else
        dlg.DataSource = Instance.Table;

      dlg.Show();

      return Instance.Table;
    }
  }
}
