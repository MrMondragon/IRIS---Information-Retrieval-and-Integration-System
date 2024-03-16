using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Interfaces
{
  public interface ILoggable
  {
    IProccessLog Log
    {
      get;
      set;
    }
  }
}
