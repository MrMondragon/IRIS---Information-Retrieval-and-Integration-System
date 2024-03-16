using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Interfaces
{
  public static class TypeExtender
  {
    public static bool IsPrimitiveType(this Type type)
    {
      TypeCode tc = Type.GetTypeCode(type);
      return (tc != TypeCode.Object) && (tc != TypeCode.DBNull) && (tc != TypeCode.Empty);
    }

  }
}
