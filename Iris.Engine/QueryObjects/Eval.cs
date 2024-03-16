using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Engine.QueryObjects.Expressions;

namespace Iris.Engine.QueryObjects
{
  class Eval : Statement
  {
    public BaseExpression Expression
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }
  
    public override string GetText()
    {
      throw new NotImplementedException();
    }
  }
}
