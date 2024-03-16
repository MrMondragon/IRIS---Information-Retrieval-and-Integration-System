using System;
using System.Collections.Generic;
using System.Text;
using goldparser;

namespace Iris.Engine
{
  public class ParserException: Exception
  {
    private TerminalToken token;
    public TerminalToken Token
    {
      get { return token; }
    }

    public ParserException(string message, TerminalToken aToken)
      : base(message)
    {
      token = aToken;
    }

  }
}
