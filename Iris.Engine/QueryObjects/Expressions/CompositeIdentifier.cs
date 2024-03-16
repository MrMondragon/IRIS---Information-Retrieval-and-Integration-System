using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Engine.QueryObjects.Expressions;

namespace Iris.Engine.QueryObjects.Expressions
{
  public class CompositeIdentifier : Iris.Engine.QueryObjects.StatementPart
  {
    public string Identifier
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public string Alias
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public EngineExpression Expression
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
