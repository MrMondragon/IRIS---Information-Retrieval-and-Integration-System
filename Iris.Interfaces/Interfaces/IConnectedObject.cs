using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Core.Conexao;
namespace Iris.Interfaces
{
  public interface  IConnectedObject
  {
    IDynConnection Connection { get;set; }
  }
} 
