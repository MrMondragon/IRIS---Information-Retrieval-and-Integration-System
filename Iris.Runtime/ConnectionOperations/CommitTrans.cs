using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.ConnectionOperations
{
  [Serializable]
  [OperationCategory("Operações de Conexão", "Commit Transaction")]
  public class CommitTrans : ConnectionOperation
  {
    public CommitTrans(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    protected override IEntity doExecute()
    {
      Connection.CommitTransaction();
      return null;
    }
  }
}
