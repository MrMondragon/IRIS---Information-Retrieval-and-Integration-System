using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Engine.QueryObjects
{
  public class Union : Iris.Engine.QueryObjects.Statement
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

    public Select SelectStatement
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }

    public Union UnionStatement
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
