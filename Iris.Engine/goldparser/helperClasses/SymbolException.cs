using System;
using System.IO;
using System.Runtime.Serialization;
using goldparser.lalr;
using goldparser;
using commons;

namespace Iris.Engine
{
  [Serializable()]
  public class SymbolException : System.Exception
  {
    public SymbolException(string message)
      : base(message)
    {
    }

    public SymbolException(string message,
        Exception inner)
      : base(message, inner)
    {
    }

    protected SymbolException(SerializationInfo info,
        StreamingContext context)
      : base(info, context)
    {
    }
  }
}