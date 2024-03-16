using System;
using System.Collections.Generic;
using System.Text;

namespace IrisVwgControls
{
  public class CallBackEventArgs: EventArgs
  {
    public CallBackEventArgs(string _eventArgument)
    {
      EventArgument = _eventArgument;
    }

    private string eventArgument;

    public string EventArgument
    {
      get { return eventArgument; }
      set { eventArgument = value; }
    }

    private string result;

    public string Result
    {
      get { return result; }
      set { result = value; }
    }
  }
}
