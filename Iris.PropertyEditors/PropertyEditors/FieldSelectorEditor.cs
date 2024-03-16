using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.PropertyEditors.Dialogs;
using Iris.PropertyEditors;
using System.Data;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Runtime.Model.PropertyEditors
{
  public class FieldSelectorEditor: BaseListEditor<String>
  {
    protected override List<String> GetItems(object obj)
    {
      FieldSelectionItem item = (FieldSelectionItem)obj;
      List<String> list = new List<string>();
      foreach (DataColumn col in item.table.Columns)
      {
        list.Add(col.ColumnName);
      }
      return list;
    }
  }
}
