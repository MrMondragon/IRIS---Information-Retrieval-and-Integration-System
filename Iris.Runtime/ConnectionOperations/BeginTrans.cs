using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.ConnectionOperations
{
  [Serializable]
  [OperationCategory("Operações de Conexão", "Begin Transaction")]
  public class BeginTrans : ConnectionOperation
  {    public BeginTrans(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    protected override IEntity doExecute()
    {
      Connection.StartTransaction();
      return null;
    }
  }
}
