using System;
using System.Collections.Generic;
using Iris.Interfaces;
namespace Iris.Runtime.ResultSetOperations
{
  public interface ISpTransport
  {
    List<KeyValuePair<string, string>> Corresp { get; set; }
    List<string> ParamNames { get; set; }
    IResultSet Entrada { get; }
    string SpName { get; set; }
  }
}
