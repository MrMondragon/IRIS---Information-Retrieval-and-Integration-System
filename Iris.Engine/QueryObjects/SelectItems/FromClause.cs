using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Engine.QueryObjects.SelectItems
{
  public class FromClause : Iris.Engine.QueryObjects.StatementPart
  {
    public List<FromItem> Items
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
