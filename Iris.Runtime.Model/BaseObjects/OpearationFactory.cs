using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Iris.Runtime.Model.BaseObjects
{
  public static class OpearationFactory
  {
    public static Operation CreateOperation(Type opType, Structure _structure, string _name)
    {
      Assembly assembly = opType.Assembly;
      Operation operation = (Operation)assembly.CreateInstance(opType.ToString(), false, BindingFlags.Default,
                                null, new object[] { _structure, _name }, null, null);

      return operation;
    }

  }
}
