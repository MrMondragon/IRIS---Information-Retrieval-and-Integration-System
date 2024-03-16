using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using System.Net;
using System.ComponentModel;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing.Design;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.NetworkOperations
{
  [Serializable]
  public abstract class NetworkOperation : Operation
  {
    public NetworkOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }


  }
}
