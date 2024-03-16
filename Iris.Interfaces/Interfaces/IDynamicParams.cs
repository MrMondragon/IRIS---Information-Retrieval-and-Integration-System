using System;
using System.Collections.Generic;
using Iris.Runtime.Core.Conexao;

namespace Iris.Interfaces
{
  public interface IDynamicParams
  {
    Dictionary<string, string> AssemblyRefs { get; set; }
    void LoadConnectionSettings(IDynConnection connection);
    void SaveConnectionSettings(IDynConnection connection);
    object this[string paramName] { get; set; }
    bool ContainsParam(string paramName);
  }
}
