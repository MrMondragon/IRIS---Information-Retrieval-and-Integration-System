using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Interfaces
{
  /// <summary>
  /// Interface para opera��es e classes que utilizam refer�ncias a assemblies
  /// e precisam de editor de propriedade
  /// </summary>
  public interface IAssemblyUser
  {
    Dictionary<string, string> Assemblies { get;set; }
  }
}
