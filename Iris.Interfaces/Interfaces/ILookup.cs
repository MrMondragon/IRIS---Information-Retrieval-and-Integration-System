using System;
using System.Collections.Generic;
namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  public interface ILookup: IRelationBasedOperation
  {
    List<string> LookupFields { get; set; }
  }
}
