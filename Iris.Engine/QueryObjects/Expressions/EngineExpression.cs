using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Engine.QueryObjects.Expressions
{
  public abstract class EngineExpression : EnginePredicate
  {
    public override string GetText()
    {
      throw new NotImplementedException();
    }
  }
}
