using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Designer.PluginEngine
{
  [AttributeUsage(AttributeTargets.Class)]
  public class FactoryCreationMethod: Attribute
  {
    public string MethodName { get; private set; }
    public FactoryCreationMethod(string methodName)
    {
      MethodName = methodName;
    }
  }
}
