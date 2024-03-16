using System;
namespace Iris.Runtime.Core
{
  public interface IKeyValueItem
  {
    string Chave { get; set; }
    string ToString();
    string Valor { get; set; }
  }
}
