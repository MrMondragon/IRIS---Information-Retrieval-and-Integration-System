using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Entities;
using System.Data;

namespace Iris.Runtime.Model.Operations.DatasetOperations
{
  [Serializable]
  [OperationCategory("Operações de Dataset", "Clear Dataset")]
  public class ClearDataset : DataSetOperation
  {
    public ClearDataset(Structure _structure, string _name)
      : base(_structure, _name)
    {

    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      Structure.ClearDataset();
      Structure.AddToLog("Dataset limpo", this);

      return null;
    }

    
  }
}
