using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;
using System.Data;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Databridge.Interfaces.BaseEditors;
using Iris.FuzzyString;

namespace Iris.Runtime.Model.PropertyEditors
{
  public class FuzzyColumnSelectorEditor: BaseListEditor<String>
  {
    protected override List<string> GetItems(object obj)
    {
      if (((IFuzzyMatchScore)obj).Alvo == null)
        throw new Exception("Resultset de fonte de comparação não atribuído");

      DataTable table = ((IFuzzyMatchScore)obj).Alvo.Table;
      List<String> list = new List<string>();
      foreach (DataColumn dc in table.Columns)
      {
        list.Add(dc.ColumnName);        
      }
      return list;
    }
  }
}
