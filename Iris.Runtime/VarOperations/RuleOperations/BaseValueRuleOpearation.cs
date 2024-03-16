using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Databridge.Engine;
using Databridge.Engine.Parsers;

namespace Iris.RuleOperations
{
  [Serializable]
  public abstract class BaseValueRuleOpearation : BaseRuleOperation
  {
    public BaseValueRuleOpearation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetOutputs("Saída");
    }

    protected override IEntity doExecute()
    {
      string expression = GetExpression();

      ExecutionContext context = Structure.GetContext();
      context.Parameters = XParams;

      object result = XEvalParser.GetParser().Parse(expression, context);
      SetValue(0, result);
      return null;
    }
  }
}
