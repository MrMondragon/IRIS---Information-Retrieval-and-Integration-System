using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;

namespace Iris.Runtime.LogOperations
{
  [Serializable]
  [OperationCategory("Operações de Log", "Add to Error Log")]
  public class AddToErrorLog : BaseLogOperation
  {
    public AddToErrorLog(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected override IEntity doExecute()
    {
      Structure.AddToErrorLog(MergedMessage, this);
      return null;
    }

  }
}
