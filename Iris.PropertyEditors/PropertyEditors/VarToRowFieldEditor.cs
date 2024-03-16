using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Operations.VarOperations;
using System.Data;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class VarToRowFieldEditor : BaseListEditor<string>
  {
    protected override List<string> GetItems(object obj)
    {
      IVarToRow vtr = (IVarToRow)obj;
      List<String> list = new List<string>();
      if ((vtr != null) && (vtr.Saida != null) && (vtr.Saida.Table != null))
      {
        foreach (DataColumn col in vtr.Saida.Table.Columns)
        {
          list.Add(col.ColumnName);
        }
      }

      return list;
    }
  }
}
