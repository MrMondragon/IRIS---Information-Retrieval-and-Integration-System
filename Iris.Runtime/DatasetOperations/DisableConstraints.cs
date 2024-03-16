using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.DatasetOperations
{
  [Serializable]
  [OperationCategory("Operações de Dataset", "Disable Constraints")]
  public class DisableConstraints : DataSetOperation
  {

    public DisableConstraints(Structure _structure, string _name)
      : base(_structure, _name)
    {

    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      Dataset.EnforceConstraints = false;
      Structure.AddToLog("Constraints desabilitadas no dataset", this);
      return null;
    }

  }
}
