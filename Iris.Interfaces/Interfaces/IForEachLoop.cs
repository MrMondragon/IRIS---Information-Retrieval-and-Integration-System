using System;
using System.Collections.Generic;
using System.Data;
namespace Iris.Runtime.Model.Operations.ControlOperations
{
  public interface IForEachLoop
  {
    List<string> Fields { get; set; }
    DataTable Table { get;}
  }
}
