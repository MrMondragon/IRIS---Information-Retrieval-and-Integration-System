using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Databridge.Engine.Compression;

namespace Iris.Runtime.Model.Operations.VarOperations
{
  [Serializable]
  [OperationCategory("Operações de Objeto", "Descompactar Variável")]
  public class UncompressVar : BaseCompressionOperation
  {
    public UncompressVar(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    
    }

    protected override IEntity doExecute()
    {
      base.doExecute();
      saida.RawValue = Compressor.DecompressObjetc<Object>(entrada.RawValue as byte[] , Password);
      return saida;
    }
  }
}
