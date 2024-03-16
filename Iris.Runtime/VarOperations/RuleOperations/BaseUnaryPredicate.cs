using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.RuleOperations
{
  [Serializable]
  public abstract class BaseUnaryPredicate : BasePredicateRuleOperation
  {
    public BaseUnaryPredicate(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Input A");
    }
  }
}
