using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.ConnectionOperations
{
  [Serializable]
  [OperationCategory("Operações de Conexão", "Close Connection")]
  public class CloseConnection : ConnectionOperation
  {
    public CloseConnection(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    protected override IEntity doExecute()
    {
      Connection.Close();
      return null;
    }
  }
}
