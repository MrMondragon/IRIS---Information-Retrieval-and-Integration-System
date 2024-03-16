using System;
using System.Collections.Generic;
using System.Data;

namespace Iris.Runtime.NetworkOperations
{
  public interface IParameterMapping
  {
    List<IParameterMapping> ChildMappings { get; set; }
    string ParamName { get; set; }
    Type ParamType { get; set; }
    string SourceField { get; set; }
    string ToString();
    Func<DataRow, object> Lambda { get; }
  }
}
