using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.DatasetOperations
{
  [Serializable]
  [OperationCategory("Operações de Dataset", "Enable Constraints")]
  public class EnableConstraints : DataSetOperation
  {

    public EnableConstraints(Structure _structure, string _name)
      : base(_structure, _name)
    {

    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      Dataset.EnforceConstraints = true;
      Structure.AddToLog("Constraints habilitadas no dataset", this);
      return null;
    }

    public override string OperationType
    {
      get { return "Enable Constraints"; }
    }
  }
}
