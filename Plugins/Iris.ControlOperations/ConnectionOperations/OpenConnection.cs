using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.ConnectionOperations
{
  [Serializable]
  [OperationCategory("Operações de Conexão", "Open Connection")]
  public class OpenConnection : ConnectionOperation
  {
    public OpenConnection(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    protected override IEntity doExecute()
    {
      Connection.Open();
      return null;
    }
  }
}
