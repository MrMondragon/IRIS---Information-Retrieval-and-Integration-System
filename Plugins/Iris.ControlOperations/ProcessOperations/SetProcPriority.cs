using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Operations.Control;
using Iris.Interfaces;
using System.Diagnostics;
using System.ComponentModel;
using Iris.Runtime.Model.Entities;

namespace Iris.ControlOperations.ProcessOperations
{
  [Serializable]
  [OperationCategory("Operações de Processo", "Alterar Prioridade de Processo")]
  public class SetProcPriority : ControlOperation
  {
    public SetProcPriority(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Processo");
      SetOutputs("Saída");
    }

    private ProcessPriorityClass priority;
    [DisplayName("Prioridade"), Category("Processo"), Description("Prioridade de execução do processo")]
    public ProcessPriorityClass Priority
    {
      get { return priority; }
      set { priority = value; }
    }

    protected override IEntity doExecute()
    {
      Process proc;
      if (GetInput(0) != null)
      {
        proc = (Process)GetValue(0);
        proc.PriorityClass = Priority;
        if (GetOutput(0) != null)
        {
          ScalarVar var = GetOutput(0) as ScalarVar;
          if (var != null)
          {
            var.RawValue = proc;
          }
        }
      }
      return (IEntity)GetOutput(0);
    }
  }
}
