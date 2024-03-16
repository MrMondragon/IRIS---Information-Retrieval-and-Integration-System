using System;
using System.Collections.Generic;
using Iris.Interfaces;
using Iris.Runtime.Core;
namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  public interface IRelationBasedOperation: IColumnBasedOperation
  {
    void Delete();
    List<KeyValuePair<string, string>> FieldMap { get; set;}
    IResultSet MasterRS { get; }
  }
}
