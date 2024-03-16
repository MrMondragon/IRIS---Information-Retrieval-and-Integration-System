using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;
using System.Data;
using Iris.Runtime.Model.Operations.VarOperations;

namespace Iris.Runtime.VarOperations
{
  [Serializable]
  [OperationCategory("Operações de Objeto", "Apply Bindings")]
  public class VarToProp : BaseVarOperation
  {
    public VarToProp(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Entrada");
    }

    protected override IEntity doExecute()
    {
      ScalarVar entrada = GetInput(0) as ScalarVar;
      entrada.ApplyBindings();
      return null;
    }
  }
}
