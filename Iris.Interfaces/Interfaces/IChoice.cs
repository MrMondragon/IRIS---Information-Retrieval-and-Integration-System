using System;
using System.Collections.Generic;
namespace Iris.Runtime.Model.Operations.ControlOperations
{
  public interface IChoice
  {
    Dictionary<string, string> Alternatives { get; set; }
    void RefreshIO();
  }
}
