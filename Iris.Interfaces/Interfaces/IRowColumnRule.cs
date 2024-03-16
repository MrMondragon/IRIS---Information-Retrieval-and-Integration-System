using System;
using Iris.Interfaces;
namespace Iris.DataGenerator
{
  public interface IRowColumnRule
  {
    string ColumnName { get; set; }
    IResultSet Entrada { get; }
  }
}
