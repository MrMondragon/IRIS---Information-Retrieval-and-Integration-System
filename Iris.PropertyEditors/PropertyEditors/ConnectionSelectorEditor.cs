using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;
using Databridge.Interfaces.BaseEditors;
using Databridge.Interfaces;

namespace Iris.PropertyEditors
{
  public class ConnectionSelectorEditor : BaseListEditor<IDataConnection>
  {
    protected override List<IDataConnection> GetItems(object obj)
    {
      return new List<IDataConnection>(((IOperation)obj).Structure.Connections);
    }
  }
}
