using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Operations.Control;

namespace Iris.Runtime.Model.Operations.ControlOperations
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Garbage Collection")]
  public class GarbageCollection: ControlOperation
  {
    public GarbageCollection(Structure aStructure, string aName)
      : base(aStructure, aName)
    {      
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      GC.Collect();
      return null;
    }
  }
}
