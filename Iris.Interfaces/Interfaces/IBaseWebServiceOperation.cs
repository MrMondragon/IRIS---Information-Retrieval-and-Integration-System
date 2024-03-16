using System;
namespace Iris.Runtime.NetworkOperations
{
  public interface IBaseWebServiceOperation
  {
    System.Net.NetworkCredential Credentials { get; set; }
    System.Net.NetworkCredential WebCredentials { get; set; }
    System.Reflection.MethodInfo Method { get; set; }
    System.Reflection.MethodInfo[] MethodList { get; }
    int Port { get; set; }
    string ProxyServer { get; set; }
    bool UseDefaultCredentials { get; set; }
    bool UseWebProxy { get; set; }
    string WsdlLocation { get; set; }

    Type GetRemoteType(string typeName);
  }
}
