using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.RuleOperations
{
  [Serializable]
  [OperationCategory("Fun��es e Operadores", ">=0")]
  public class OperGtEq0: BaseUnaryPredicate
  {
    public OperGtEq0(Structure aStructure, string aName)
      : base(aStructure, aName)
    { 
    }

    protected override string GetExpression()
    {
      return "&A >= 0";
    }
  }
}
