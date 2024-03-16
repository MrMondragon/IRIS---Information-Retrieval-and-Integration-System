using System;
namespace Iris.Runtime.NetworkOperations
{
  public interface INetworkOperation
  {
    System.Net.NetworkCredential WebCredentials { get; set; }
  }
}
