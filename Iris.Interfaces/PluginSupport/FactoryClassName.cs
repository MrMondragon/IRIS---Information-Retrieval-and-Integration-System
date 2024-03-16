using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Designer.PluginEngine
{
  [AttributeUsage(AttributeTargets.Class)]
  public class FactoryClass: Attribute
  {
    public FactoryClass(string className, string methodName)
    {
      Name = className;
      MethodName = methodName; 
    }
    public string Name { get; set; }
    public string MethodName { get; set; }
  }
}
