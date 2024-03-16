using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.DatasetOperations
{
  [Serializable]
  [OperationCategory("Opera��es de Dataset", "Reject Changes")]
  public class RejectChanges : DataSetOperation
  {

    public RejectChanges(Structure _structure, string _name)
      : base(_structure, _name)
    {

    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      Dataset.RejectChanges();
      Structure.AddToLog("Altera��es recusadas no dataset", this);
      return null;
    }

  
  }
}
