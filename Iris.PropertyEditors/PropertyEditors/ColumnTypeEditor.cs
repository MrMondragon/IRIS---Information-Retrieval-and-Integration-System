using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;
using Databridge.Interfaces.BaseEditors;

namespace Iris.Runtime.Model.PropertyEditors
{
  public class ColumnTypeEditor: BaseListEditor<string>
  {
    protected override List<string> GetItems(object obj)
    {
      string[] types = new string[] {"String","Int16","Int32","Int64","UInt16","UInt32","UInt64",
        "Byte","SByte","Decimal","Double","Single","DateTime","Boolean", "Guid", "TimeSpan"};

      
      return new List<string>(types);

    }

  }
}
