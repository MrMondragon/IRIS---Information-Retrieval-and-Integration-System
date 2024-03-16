using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.RuleOperations
{
  [Serializable]
  [OperationCategory("Funções e Operadores", "<=0")]
  public class OperLgtEq0 : BaseUnaryPredicate
  {
    public OperLgtEq0(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected override string GetExpression()
    {
      return "&A <= 0";
    }
  }
}
