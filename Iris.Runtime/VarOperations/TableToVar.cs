using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.VarOperations
{
  [Serializable]
  [OperationCategory("Operações de Objeto", "Tabela para Variável")]
  public class TableToVar: BaseVarOperation
  {
    public TableToVar(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
    }

    protected override IEntity doExecute()
    {
      ResultSet entrada = GetInput(0) as ResultSet;
      ScalarVar saida = GetOutput(0) as ScalarVar;

      if (entrada == null)
        throw new Exception("Entrada inválida");

      if (saida == null)
        throw new Exception("Saída inválida");

      saida.RawValue = entrada.Table;

      return saida;
    }
  }
}
