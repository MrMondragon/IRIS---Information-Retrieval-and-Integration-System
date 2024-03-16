using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Runtime.Model.PropertyEditors.Interfaces
{
  /// <summary>
  /// Interface para operações de input ou output dinâmicos
  /// </summary>
  public interface IDynamicIOOperation
  {
    event EventHandler BeforeRefreshIO;
    event EventHandler AfterRefreshIO;
    void RefreshIO();
  }
}
