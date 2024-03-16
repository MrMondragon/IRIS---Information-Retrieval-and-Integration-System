using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Operations.NetworkOperations;
using System.Reflection;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class WSMethodEditor : BaseListEditor<MethodInfo>
  {
    protected override List<MethodInfo> GetItems(object obj)
    {
      IInvokeWebService instance = (IInvokeWebService)obj;
      List<MethodInfo> result = new List<MethodInfo>();
      if (instance.MethodList != null)
      {
        for (int i = 0; i < instance.MethodList.Length; i++)
        {
          result.Add(instance.MethodList[i]);
        }
      }
      return result;
    }
  }
}
