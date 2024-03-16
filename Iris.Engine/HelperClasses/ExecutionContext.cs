using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Iris.Engine
{
  public class ExecutionContext
  {
    public DataSet Dataset { get; set; }
    public Dictionary<string, object> Variables { get; set; }
    public Dictionary<string, object> Parameters { get; set; }
    public Dictionary<string, object> Objects { get; set; }
  }
}
