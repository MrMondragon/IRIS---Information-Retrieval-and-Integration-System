using System;
using System.Data;
namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  public interface IColuna
  {
    bool AllowDBNull { get; set; }
    bool AutoIncrement { get; set; }
    long AutoIncrementSeed { get; set; }
    long AutoIncrementStep { get; set; }
    string Caption { get; set; }
    string ColumnName { get; set; }
    DataColumn CreateColumn();
    Type DataType { get; set; }
    DataSetDateTime DateTimeMode { get; set; }
    object DefaultValue { get; set; }
    int MaxLength { get; set; }
    string ToString();
    bool Unique { get; set; }
  }
}
