using System;
using System.Collections.Generic;


namespace Iris.Interfaces
{
  public interface IDecode
  {
    string DefaultValue { get; set; }
    Dictionary<string, string> Items { get; set; }
  }
}
