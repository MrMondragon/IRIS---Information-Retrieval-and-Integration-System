using System;
using System.Collections.Generic;
using System.Text;
using Iris.Engine.QueryObjects.SelectItems;

namespace Iris.Engine.QueryObjects
{
  public class Delete : Statement
  {
    public bool UseFrom
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

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
