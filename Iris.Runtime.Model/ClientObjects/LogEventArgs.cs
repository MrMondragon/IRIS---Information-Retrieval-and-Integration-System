using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Runtime.Model.ClientObjects
{
  public class LogEventArgs: EventArgs
  {
    public LogEventArgs(string entry, bool error)
    {
      Entry = entry;
      Error = error;
    }

    public string Entry { get; set; }
    public bool Error { get; set; }

  }
}
