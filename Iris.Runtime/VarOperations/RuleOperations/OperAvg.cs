using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.RuleOperations
{
  [Serializable]
  [OperationCategory("Funções e Operadores", "Avg")]
  public class OperAvg: BaseFunctionRuleOperation
  {
    public OperAvg(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected override string GetFunction()
    {
      return "Avg";
    }
  }
}


