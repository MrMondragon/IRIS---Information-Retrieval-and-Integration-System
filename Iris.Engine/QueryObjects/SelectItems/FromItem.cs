using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Engine.QueryObjects.Expressions;

namespace Iris.Engine.QueryObjects.SelectItems
{
  public class FromItem : Iris.Engine.QueryObjects.StatementPart
  {
    public Iris.Engine.QueryObjects.SelectItems.JoinType? JoinType
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

    public SearchList OnClause
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
