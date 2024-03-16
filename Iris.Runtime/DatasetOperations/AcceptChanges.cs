using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.DatasetOperations
{
  [Serializable]
  [OperationCategory("Operações de Dataset", "Accept Changes")]
  public class AcceptChanges: DataSetOperation
  {
    public AcceptChanges(Structure _structure, string _name)
      : base(_structure, _name)
    {

    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      Dataset.AcceptChanges();
      Structure.AddToLog("Alterações aceitas no dataset", this);
      return null;
    }


  }
}
