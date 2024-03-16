using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Core.Expressions;
using Runner;
using System.Windows.Forms;

namespace Iris.Runtime.Model.BaseObjects
{
  public static class ExpressionEvaluator
  {
    public static bool Evaluate(Structure aStructure, string expression)
    {
      string code = aStructure.GetBaseAccessorCode();
      code += @"

      public class DynExpressionEvaluator: BaseAccessor
      {
        public DynExpressionEvaluator(Structure aStructure): base(aStructure)
        {
        }

        public bool Evaluate()
        {
          return " + expression + @";
        }
      }";

      code = aStructure.InsertInNamespace(code);

      string assemblyName = (typeof (ExpressionEvaluator)).Assembly.Location;

      List<string> assemblies = new List<string>();
      assemblies.Add(assemblyName);

      bool result = (bool)CodeRunner.RunInSeparateDomain(assemblies, code, "Iris.Runtime.Model.BaseObjects.DynExpressionEvaluator", new object[] { aStructure }, "Evaluate", null);
      return result;
    }

    public static int Evaluate(Structure aStructure, string[] expressions)
    {
      string code = aStructure.GetBaseAccessorCode();
      code += @"

      public class DynExpressionEvaluator: BaseAccessor
      {
        public DynExpressionEvaluator(Structure aStructure): base(aStructure)
        {
        }

        public int Evaluate()
        {
        ";


      for (int i = 0; i < expressions.Length; i++)
      {
        code += "\r if(" + expressions[i] + @")
                  return " + i.ToString()+";\r";
      }
      
      code+=@" return -1;
        }
      }";

      code = aStructure.InsertInNamespace(code);

      string assemblyName = (typeof(ExpressionEvaluator)).Assembly.Location;

      List<string> assemblies = new List<string>();
      assemblies.Add(assemblyName);

      int result = (int)CodeRunner.RunInSeparateDomain(assemblies, code, "Iris.Runtime.Model.BaseObjects.DynExpressionEvaluator", new object[] { aStructure }, "Evaluate", null);
      return result;
    }

  }
}
