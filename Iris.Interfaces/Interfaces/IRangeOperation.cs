using System;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using System.Collections.Generic;
namespace Iris.Runtime.ColumnBasedOperations
{
  public interface IRangeOperation : IColumnBasedOperation
  {
    Dictionary<decimal, string> Labels { get; set; }
    Dictionary<decimal, decimal> Ranges { get; set; }
  }
}
