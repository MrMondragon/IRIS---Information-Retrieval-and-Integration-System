using System;
namespace Iris.Plugins.Treinamento
{
  interface IGUIDColumn
  {
    bool AcceptChanges { get; set; }
    string CaracteresMascara { get; set; }
    string Column { get; set; }
    bool FullCommit { get; set; }
  }
}
