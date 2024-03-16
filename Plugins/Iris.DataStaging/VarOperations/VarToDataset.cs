using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using System.Data;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.VarOperations
{
  [Serializable]
  [OperationCategory("Operações de Variável", "Variável para Dataset")]
  public class VarToDataset: BaseVarOperation
  {
    public VarToDataset(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
      SetOutputs(new string[] { });
    }

    protected override IEntity doExecute()
    {
      ScalarVar entrada = GetInput(0) as ScalarVar;

      if (entrada == null)
        throw new Exception("Entrada inválida");

      Structure.Dataset = entrada.RawValue as DataSet;

      return null;
    }
  }
}
