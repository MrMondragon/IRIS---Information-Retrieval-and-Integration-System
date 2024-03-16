using System;
using System.Reflection;
namespace Iris.Runtime.Model.Operations.NetworkOperations
{
  public interface IInvokeWebService
  {
    MethodInfo Method { get; set; }
    MethodInfo[] MethodList { get; }
    string WsdlLocation { get; set; }
  }
}
