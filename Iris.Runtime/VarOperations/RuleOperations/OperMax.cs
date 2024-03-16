using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.RuleOperations
{
  [Serializable]
  [OperationCategory("Funções e Operadores", "Max")]
  public class OperMax : BaseFunctionRuleOperation
  {
    public OperMax(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    public override bool Distinct
    {
      get
      {
        return false;
      }
    }

    protected override string GetFunction()
    {
      return "Max";
    }
  }
}
