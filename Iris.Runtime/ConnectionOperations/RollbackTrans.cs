using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.ConnectionOperations
{
  [Serializable]
  [OperationCategory("Operações de Conexão", "Rollback Transaction")]
  public class RollbackTrans : ConnectionOperation
  {
    public RollbackTrans(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    protected override IEntity doExecute()
    {
      Connection.RollbackTransaction();
      return null;
    }
  }
}
