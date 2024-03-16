using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.RuleOperations
{
  [Serializable]
  [OperationCategory("Funções e Operadores", "OR")]
  public class OperOr : BasePredicateRuleOperation
  {
    public OperOr(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected override string GetExpression()
    {
      return "&A OR &B";
    }
  }
}
