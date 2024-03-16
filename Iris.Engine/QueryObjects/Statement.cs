using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Engine.QueryObjects
{
  public abstract class Statement
  {
    public string Go
    {
      get
      {
        throw new System.NotImplementedException();
      }
      set
      {
      }
    }
  
    public abstract string GetText();
  }
}
