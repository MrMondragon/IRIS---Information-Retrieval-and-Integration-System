using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Engine.QueryObjects.Expressions
{
  public class SearchList : BaseExpression
  {
    public bool Not
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

    public EnginePredicate Predicate
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
