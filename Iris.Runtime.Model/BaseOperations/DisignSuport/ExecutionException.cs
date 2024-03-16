using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Runtime.Model.DisignSuport
{
  public class ExecutionException: Exception
  {
    public ExecutionException(string message)
      : base(message)
    {

    }
  }
}
