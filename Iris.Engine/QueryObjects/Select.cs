using System;
using System.Collections.Generic;
using System.Text;
using Iris.Engine.QueryObjects.SelectItems;

namespace Iris.Engine.QueryObjects
{
  public class Select : Statement
  {

    public string Into
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public FromClause From
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public WhereClause Where
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public SelectionClause Selection
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public GroupClause GroupBy
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public HavingClause Having
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public OrderClause OredBy
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
