using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;
using System.Data;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Iris.DataGenerator;
using Databridge.Interfaces.BaseEditors;


namespace Iris.PropertyEditors.PropertyEditors
{
  public class RCRColumnSelector : BaseListEditor<String>
  {
    protected override List<string> GetItems(object obj)
    {
      if (((IRowColumnRule)obj).Entrada == null)
        throw new Exception("Resultset de Entrada não atribuído");

      DataTable table = ((IRowColumnRule)obj).Entrada.Table;
      List<String> list = new List<string>();
      foreach (DataColumn dc in table.Columns)
      {
        list.Add(dc.ColumnName);
      }
      return list;
    }
  }
}
