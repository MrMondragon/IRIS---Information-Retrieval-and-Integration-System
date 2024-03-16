using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Databridge.Engine.Parsers;
using Databridge.Engine;

namespace Iris.RuleOperations
{
  [Serializable]
  public abstract class BasePredicateRuleOperation: BaseRuleOperation
  {
    public BasePredicateRuleOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetOutputs("True", "False", "Result");
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      string expression = GetExpression();
      ExecutionContext context = Structure.GetContext();
      context.Parameters = XParams;

      bool result = Convert.ToBoolean( XEvalParser.GetParser().Parse(expression, context));
      ExecResult(result);
      SetValue(2, result);
      return null;
    }

    protected void ExecResult(bool result)
    {
      if (result)
      {
        if (GetOutput(0) != null)
          ExecuteObj((Operation)GetOutput(0));          
      }
      else
      {
        if (GetOutput(1) != null)
          ExecuteObj((Operation)GetOutput(1));
      }

      
    }
  }
}
