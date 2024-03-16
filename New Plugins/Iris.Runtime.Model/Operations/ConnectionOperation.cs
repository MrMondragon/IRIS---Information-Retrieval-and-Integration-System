using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Operations.Control;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using Iris.PropertyEditors;
using System.Drawing.Design;
using Iris.Runtime.Core.Connections;

namespace Iris.Runtime.Model.Operations.ConnectionOperations
{
  [Serializable]
  public abstract class ConnectionOperation : Operation
  {
    public ConnectionOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    private DynConnection connection;
    /// <summary>
    /// Gets the connection.
    /// </summary>
    /// <value>The connection.</value>
    [Editor(typeof(ConnectionSelectorEditor), typeof(UITypeEditor))]
    public DynConnection Connection
    {
      get { return connection;  }
      set { connection = value; }
    }

  }
}
