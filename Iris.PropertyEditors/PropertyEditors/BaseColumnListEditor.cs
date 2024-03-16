using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;
using Iris.PropertyEditors.Dialogs;
using System.Data;
using Databridge.Interfaces.BaseEditors;
using Iris.FuzzyString;

namespace Iris.PropertyEditors
{
  public abstract class BaseColumnListEditor<T> : BaseDialogEditor<T>
  {
    protected override object GetValue(T Instance)
    {
      PKEditorDialog dlg = new PKEditorDialog();

      DataTable table = GetTable(Instance);

      List<DataColumn> columns = new List<DataColumn>();

      List<string> colNames = GetList(Instance);

      if((colNames != null)&&(colNames.Count > 0))
      {
        columns.AddRange(colNames.Select(x => table.Columns[x]));
      }

      columns = dlg.Execute(columns, table);

      List<string> colList = columns.Select(x => x.ColumnName).ToList();


      SetValue(Instance, colList);

      return colList;
    }

    protected abstract DataTable GetTable(T Instance);

    protected abstract void SetValue(T Instance, List<string> columNames);

    protected abstract List<string> GetList(T Instance);

    protected abstract string GetCaption();
  }

  
  
}
