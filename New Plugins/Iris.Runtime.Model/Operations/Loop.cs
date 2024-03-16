using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Connections;
using Iris.Interfaces;
using System.ComponentModel;

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

    [Browsable(false)]
    public Operation LoopOper
    {
      get { return GetOutput(0) as Operation; }
    }

    protected override IEntity doExecute()
    {
      ExecuteObj(LoopOper);
      if (Structure.inStep)
        LoopOper.Execute();

      return null;
    }
  }
}
