using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using CRMFramework2011;

namespace Iris.Dynamics2011
{
  public static class DataViewExtensions
  {
    public static List<DynamicEntityProxy> ToProxyList(this DataView view, string entityName, DataViewRowState rowState)
    {
      DataView internalView = new DataView(view.Table, view.RowFilter, "", rowState);
      return internalView.Cast<DataRowView>().Select(x => x.ToProxy(entityName)).ToList();
    }

    public static DynamicEntityProxy ToProxy(this DataRowView row, string entityName)
    {
      return new DynamicEntityProxy(entityName, row.Row);
    }


  }
}
