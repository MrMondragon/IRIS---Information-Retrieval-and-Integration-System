using System;
using Iris.Interfaces;
namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  public interface IColumnBasedOperation
  {
    string Column { get; set; }
    string ColumnName { get; set; }
    IEntity EntityValue { get; }
    IResultSet Entrada { get; }
    string Name { get; set; }
  }
}
