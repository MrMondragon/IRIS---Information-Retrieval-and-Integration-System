using System;
using System.Collections.Generic;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
namespace Iris.FuzzyString
{
  public interface IFuzzyMatchScore : IColumnBasedOperation
  {
    Iris.Interfaces.IResultSet Alvo { get; }

    List<string> ColunasEntrada { get; set; }
    List<string> ColunasAlvo { get; set; }

  }
}
