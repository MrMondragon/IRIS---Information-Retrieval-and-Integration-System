using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.VarOperations;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;

namespace Iris.WebOperations
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Cache Configs")]
  public class StoreWsConfig: BaseWebServiceOperation
  {
    public StoreWsConfig(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs(new string[]{});
      SetOutputs("Saída");
    }

    public override string WsdlLocation
    {
      get
      {
        return base.WsdlLocation;
      }
      set
      {
        wsdlLocation = value;
      }
    }

    protected override IEntity doExecute()
    {
      IScalarVar saida;
      if ((saida = GetOutput(0) as IScalarVar) != null)
      {
        WsConfigs config = new WsConfigs(this);
        saida.RawValue = config;
      }

      return (IEntity) saida;
     
    }
  }
}
