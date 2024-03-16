using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Clear Table")]
  public class ClearTable : ResultSetOperation
  {
    public ClearTable(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected override IEntity doExecute()
    {
      Entrada.Clear();
      Entrada.Table = null;

      if (Structure.CollectOnClear)
        GC.Collect();

      return (IEntity)Entrada;
    }
  }
}
