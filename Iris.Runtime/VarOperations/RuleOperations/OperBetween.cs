using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Databridge.Engine;
using Databridge.Engine.Parsers;

namespace Iris.RuleOperations
{
  [Serializable]
  [OperationCategory("Funções e Operadores", "Between")]
  public class OperBetween: BasePredicateRuleOperation
  {
    public OperBetween(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Valor", "Input A", "Input B", "Result");
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      Dictionary<string, object> pars = XParams;
      pars["C"] = GetValue(2);
      string expression = GetExpression();

      ExecutionContext context = Structure.GetContext();
      context.Parameters = pars;

      bool result = Convert.ToBoolean(XEvalParser.GetParser().Parse(expression, context));
      ExecResult(result); 
      SetValue(3, result);
      return null;
    }

    protected override string GetExpression()
    {
      return "&A BETWEN &B AND &C";
    }
  }
}


