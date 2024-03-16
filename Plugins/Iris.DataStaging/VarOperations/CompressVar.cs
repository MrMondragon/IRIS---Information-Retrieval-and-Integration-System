using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using Databridge.Engine.Compression;

namespace Iris.Runtime.Model.Operations.VarOperations
{
  [Serializable]
  [OperationCategory("Opera��es de Vari�vel", "Compactar Vari�vel")]
  public class CompressVar: BaseCompressionOperation
  {
    public CompressVar(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    
    }

    protected override IEntity doExecute()
    {
      base.doExecute();
      saida.RawValue = Compressor.CompressObject(entrada.RawValue, Password);
      return saida;
    }
  }
}
