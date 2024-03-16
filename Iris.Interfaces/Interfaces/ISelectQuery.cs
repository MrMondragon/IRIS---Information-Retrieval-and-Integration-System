using System;
namespace Iris.Runtime.Core.ParserEngine.ParserObjects
{
  public interface ISelectQuery
  {
    void Clear();
    string GetMainTableName();

  }
}
