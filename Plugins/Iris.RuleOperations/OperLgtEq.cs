using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.RuleOperations
{
  [Serializable]
  [OperationCategory("Fun��es e Operadores", "<=")]
  public class OperLgtEq : BasePredicateRuleOperation
  {
    public OperLgtEq(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected override string GetExpression()
    {
      return "&A <= &B";
    }
  }
}