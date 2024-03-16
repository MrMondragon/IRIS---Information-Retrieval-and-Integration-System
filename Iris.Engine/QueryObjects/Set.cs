using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Engine.QueryObjects.UpdateItems;

namespace Iris.Engine.QueryObjects
{
  public class Set : Statement
  {
    public SetItem Item
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
