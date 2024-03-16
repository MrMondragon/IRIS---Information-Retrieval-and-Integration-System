using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.Control;
using Iris.Runtime.Model.BaseObjects;
using System.Diagnostics;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.ControlOperations
{
  [Serializable]
  [OperationCategory("Operações de Processo", "Parar Processo")]
  public class StopProcess : ControlOperation
  {
    public StopProcess(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Processo");
    }

    private bool killProcess;

    public bool KillProcess
    {
      get { return killProcess; }
      set { killProcess = value; }
    }

    protected override IEntity doExecute()
    {
      Process proc;
      if (GetInput(0)!= null)
      {
        proc = (Process)GetValue(0);
        if (KillProcess)
          proc.Kill();
        else
          proc.CloseMainWindow();
      }
      return null;
    }
  }
}
