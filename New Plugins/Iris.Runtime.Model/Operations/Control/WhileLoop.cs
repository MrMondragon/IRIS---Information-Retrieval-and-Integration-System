using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  public class WhileLoop : Loop
  {
    public WhileLoop(Structure aStructure,  string aName)
      : base(aStructure, aName)
    {

    }

  }
}
