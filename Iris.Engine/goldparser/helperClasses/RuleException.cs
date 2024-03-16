using System;
using System.IO;
using System.Runtime.Serialization;
using goldparser.lalr;
using goldparser;
using commons;
namespace Iris.Engine
{
  [Serializable()]
  public class RuleException : System.Exception
  {

    public RuleException(string message)
      : base(message)
    {
    }

    public RuleException(string message,
                         Exception inner)
      : base(message, inner)
    {
    }

    protected RuleException(SerializationInfo info,
                            StreamingContext context)
      : base(info, context)
    {
    }

  }
}
