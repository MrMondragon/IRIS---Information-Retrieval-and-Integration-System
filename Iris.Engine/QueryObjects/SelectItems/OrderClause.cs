using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Engine.QueryObjects.SelectItems
{
  public class OrderClause : Iris.Engine.QueryObjects.StatementPart
  {
    public bool Desc
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public List<string> Items
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
