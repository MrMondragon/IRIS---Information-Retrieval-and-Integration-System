using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.VarOperations
{
  [Serializable]
  public abstract class BaseCompressionOperation: BaseVarOperation
  {
    public BaseCompressionOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Password");
    }

    private string password;

    public string Password
    {
      get 
      {
        if (GetInput(1) != null)
        {
          ScalarVar passVar = GetInput(1).EntityValue as ScalarVar;
          if (passVar == null)
            throw new Exception("Input de password inválido");

          return Convert.ToString(passVar.RawValue);
        }
        else
          return password; 
      }
      set { password = value; }
    }

    protected ScalarVar entrada;
    protected ScalarVar saida;

    protected override IEntity doExecute()
    {
      entrada = GetInput(0) as ScalarVar;
      saida = GetOutput(0) as ScalarVar;

      if (entrada == null)
        throw new Exception("Entrada inválida");

      if (saida == null)
        throw new Exception("Saída inválida");

     

      return null;
    }
  }
}
