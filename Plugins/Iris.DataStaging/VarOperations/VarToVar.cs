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
  [OperationCategory("Opera��es de Vari�vel", "Vari�vel para Vari�vel")]
  public class VarToVar: BaseVarOperation
  {
    public VarToVar(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected override IEntity doExecute()
    {
      ScalarVar entrada = GetInput(0) as ScalarVar;
      ScalarVar saida = GetOutput(0) as ScalarVar;

      if (entrada == null)
        throw new Exception("Entrada inv�lida");

      if (saida == null)
        throw new Exception("Sa�da inv�lida");

      saida.RawValue = entrada.RawValue;

      return saida;
    }
  }
}
