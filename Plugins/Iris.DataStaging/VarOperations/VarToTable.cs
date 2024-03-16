using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;
using System.Data;

namespace Iris.Runtime.Model.Operations.VarOperations
{
  [Serializable]
  [OperationCategory("Operações de Variável", "Variável para Tabela")]
  public class VarToTable: BaseVarOperation
  {
    public VarToTable(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
    }

    protected override IEntity doExecute()
    {
      ScalarVar entrada = GetInput(0) as ScalarVar;
      ResultSet saida = GetOutput(0) as ResultSet;

      if (entrada == null)
        throw new Exception("Entrada inválida");

      if (saida == null)
        throw new Exception("Saída inválida");

      saida.Table = entrada.RawValue as DataTable;

      return saida;
    }
  }
}
