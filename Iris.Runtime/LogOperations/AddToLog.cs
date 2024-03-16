using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.DisignSuport;
using System.ComponentModel;
using Databridge.PropertyEditors;
using System.Drawing.Design;

namespace Iris.Runtime.LogOperations
{
  [Serializable]
  [OperationCategory("Operações de Log", "Add to Log")]
  public class AddToLog : BaseLogOperation
  {
    public AddToLog(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }


    protected override IEntity doExecute()
    {
      Structure.AddToLog(MergedMessage, this);
      return null;
    }
  }
}
