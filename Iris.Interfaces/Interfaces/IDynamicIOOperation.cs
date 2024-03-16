using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Runtime.Model.PropertyEditors.Interfaces
{
  /// <summary>
  /// Interface para opera��es de input ou output din�micos
  /// </summary>
  public interface IDynamicIOOperation
  {
    event EventHandler BeforeRefreshIO;
    event EventHandler AfterRefreshIO;
    void RefreshIO();
  }
}
