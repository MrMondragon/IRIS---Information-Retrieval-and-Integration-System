using System;
using System.Collections.Generic;
using Iris.Interfaces;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Iris.Runtime.Core;
namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  public interface ITransport
  {
    bool Clear { get; set; }
    List<KeyValuePair<string, string>> Corresp { get; set; }    
    bool FillDest { get; set; }
    bool FillOrig { get; set; }
    IResultSet Saida { get; }
    IResultSet Entrada { get; }
    bool SaveDest { get; set; }
  }
}
