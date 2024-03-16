using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;
using System.Data;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Runtime.Model.PropertyEditors
{
  public class CBOColumnSelectorEditor: BaseListEditor<String>
  {
    protected override List<string> GetItems(object obj)
    {
      if (((IColumnBasedOperation)obj).Entrada == null)
        throw new Exception("Resultset de Entrada não atribuído");
        
      DataTable table = ((IColumnBasedOperation)obj).Entrada.Table;
      List<String> list = new List<string>();
      foreach (DataColumn dc in table.Columns)
      {
        list.Add(dc.ColumnName);        
      }
      return list;
    }
  }
}
