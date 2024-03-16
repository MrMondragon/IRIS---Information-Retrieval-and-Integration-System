using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Connections;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  public abstract class Loop : ControlOperation
  {
    public Loop(Structure aStructure,  string aName)
      : base(aStructure,aName)
    {
      SetOutputs("Loop");
    }

    public Operation LoopOper
    {
      get { return (Operation)outputs[0]; }
      set { outputs[0] = (Operation)value; }
    }

    protected override IEntity doExecute()
    {
      return LoopOper.EntityValue;
    }
  }
}
