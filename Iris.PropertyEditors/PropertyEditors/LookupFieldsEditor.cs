using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;
using System.Data;
using Iris.Runtime.Model.PropertyEditors.Dialogs;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Runtime.Model.PropertyEditors
{
  public class LookupFieldsEditor: BaseDialogEditor<ILookup>
  {
    protected override object GetValue(ILookup Instance)
    {
      if (Instance.MasterRS == null)
        throw new Exception("Resultset de lookup não atribuído");

      DataTable table = Instance.MasterRS.Table;

      if(table == null)
        throw new Exception("Resultset de lookup não possui uma tabela");

      FieldSelectorDialog dlg = new FieldSelectorDialog();
      List<string> list = dlg.Execute(table, Instance.LookupFields);
      if (list != null)
      {
        Instance.LookupFields = list;
      }

      return Instance.LookupFields;
    }
  }
}
