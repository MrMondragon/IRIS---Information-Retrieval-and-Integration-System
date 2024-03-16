using System;
using System.Collections.Generic;
using System.Text;
using Iris.Engine.QueryObjects.UpdateItems;
using Iris.Engine.QueryObjects.SelectItems;

namespace Iris.Engine.QueryObjects
{
  public class Update : Statement
  {
    public string TableName
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public List<SetItem> Set
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
  
    public override string GetText()
    {
      throw new NotImplementedException();
    }
  }
}
