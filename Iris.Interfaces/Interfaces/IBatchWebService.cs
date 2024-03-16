using System;
using Iris.Interfaces;
using System.Reflection;
using System.Collections.Generic;

namespace Iris.Runtime.NetworkOperations
{
  public interface IBatchWebService
  {
    IResultSet Entrada { get; }
    MethodInfo Method { get; set; }
    List<IParameterMapping> ParameterMappings { get; set; }
    string ResultColumn { get; set; }
  }
}
