using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;

namespace Iris.RuleOperations
{
  [Serializable]
  public abstract class BaseRuleOperation: Operation
  {
    public BaseRuleOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Input A", "Input B");
    }

    protected abstract string GetExpression();

    protected Dictionary<string, object> XParams
    {
      get
      {
        Dictionary<string, object> pars = new Dictionary<string, object>();
        pars["A"] = GetValue(0);
        pars["B"] = GetValue(1);
        return pars;
      }
    }
  }
}
