using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.Runtime.Model.Operations.VarOperations
{
  [Serializable]
  public abstract class BaseVarOperation: Operation
  {
    public BaseVarOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Registro");
      SetOutputs("Saída");
    }
  }
}
