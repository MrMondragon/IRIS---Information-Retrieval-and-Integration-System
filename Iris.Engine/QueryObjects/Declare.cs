using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Engine.QueryObjects.DeclareItems;

namespace Iris.Engine.QueryObjects
{
  public class Declare : Statement
  {
    public System.Collections.Generic.List<VariableDeclaration> Items
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
