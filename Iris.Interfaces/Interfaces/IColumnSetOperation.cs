using System;
namespace Iris.Runtime.ResultSetOperations
{
  public interface IColumnSetOperation
  {
    System.Collections.Generic.List<System.Data.DataColumn> Columnset { get; set; }
    System.Data.DataTable Table { get; }
  }
}
