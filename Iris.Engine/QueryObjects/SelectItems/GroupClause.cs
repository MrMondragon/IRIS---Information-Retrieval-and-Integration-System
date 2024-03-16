using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Engine.QueryObjects.Expressions;

namespace Iris.Engine.QueryObjects.SelectItems
{
  public class GroupClause : Iris.Engine.QueryObjects.StatementPart
  {
    public bool All
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public List<CompositeIdentifier> Items
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
