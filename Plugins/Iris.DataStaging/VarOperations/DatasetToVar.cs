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
  [OperationCategory("Operações de Variável", "Dataset para Variável")]
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
        throw new Exception("Saída inválida");

      saida.RawValue = Structure.Dataset;

      return saida;
    }
  }
}
