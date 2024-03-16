using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Engine.QueryObjects
{
  public class Truncate : Statement
  {
    public override string GetText()
    {
      return "Truncate Table " + TableName;
    }

    public string TableName { get; set; }
  }
}
