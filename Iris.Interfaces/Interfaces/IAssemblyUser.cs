using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Interfaces
{
  /// <summary>
  /// Interface para operações e classes que utilizam referências a assemblies
  /// e precisam de editor de propriedade
  /// </summary>
  public interface IAssemblyUser
  {
    Dictionary<string, string> Assemblies { get;set; }
  }
}
