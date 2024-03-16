using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;

namespace Iris.Runtime.Model.Operations.VarOperations
{
  [Serializable]
  [OperationCategory("Opera��es de Vari�vel", "Dataset para Vari�vel")]
  public class DatasetToVar: BaseVarOperation
  {
    public DatasetToVar(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs(new string[] { });
    }

    protected override IEntity doExecute()
    {
      ScalarVar saida = GetOutput(0) as ScalarVar;

      if (saida == null)
        throw new Exception("Sa�da inv�lida");

      saida.RawValue = Structure.Dataset;

      return saida;
    }
  }
}
