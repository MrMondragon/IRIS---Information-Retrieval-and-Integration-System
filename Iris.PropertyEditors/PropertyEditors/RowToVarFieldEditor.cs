using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Operations.VarOperations;
using System.Data;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class RowToVarFieldEditor : BaseListEditor<string>
  {
    protected override List<string> GetItems(object obj)
    {
      IRowToVar rtv = (IRowToVar)obj;
      List<String> list = new List<string>();
      if ((rtv != null) && (rtv.Entrada != null) && (rtv.Entrada.Table != null))
      {
        foreach (DataColumn col in rtv.Entrada.Table.Columns)
        {
          list.Add(col.ColumnName);
        }
      }

      return list;
    }
  }
}
