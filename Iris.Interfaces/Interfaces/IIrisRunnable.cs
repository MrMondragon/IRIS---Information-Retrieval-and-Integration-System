using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;

namespace Iris.Interfaces
{
  public interface IIrisRunnable
  {
    Object Execute();
    IStructure Structure
    {
      get;
    }

  }
}
