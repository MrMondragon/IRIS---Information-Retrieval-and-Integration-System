using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Engine.QueryObjects.Expressions;
using Iris.Engine.QueryObjects.SelectItems;

namespace Iris.Engine.QueryObjects
{
  public class Insert : Statement
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

    public bool DefaultValues
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public List<EngineExpression> Items
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public Union Query
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
