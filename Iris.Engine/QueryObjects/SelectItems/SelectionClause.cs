using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Engine.QueryObjects.Expressions;

namespace Iris.Engine.QueryObjects.SelectItems
{
  public class SelectionClause : Iris.Engine.QueryObjects.StatementPart
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

    public bool Distinct
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public int Top
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public bool TopPercent
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public List<CompositeIdentifier> Columns
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
