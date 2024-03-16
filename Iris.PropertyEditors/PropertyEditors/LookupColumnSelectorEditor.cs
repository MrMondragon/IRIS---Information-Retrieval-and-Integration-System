using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;
using System.Data;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors
{

  public class LookupColumnSelectorEditor: BaseListEditor<String>
  {
    protected override List<string> GetItems(object obj)
    {
      DataTable table = ((IRelationBasedOperation)obj).Entrada.Table;
      List<String> list = new List<string>();
      foreach (DataColumn dc in table.Columns)
      {
        list.Add(dc.ColumnName);        
      }
      return list;
    }
  }
}

