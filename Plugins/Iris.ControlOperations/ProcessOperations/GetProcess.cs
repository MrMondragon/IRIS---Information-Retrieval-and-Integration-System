using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.Control;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.Diagnostics;
using Iris.Runtime.Model.Entities;
using System.ComponentModel;

namespace Iris.ControlOperations.ProcessOperations
{
  [Serializable]
  [OperationCategory("Operações de Processo", "Buscar Processo")]
  public class GetProcess: ControlOperation
  {
    public GetProcess(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Nome");
      SetOutputs("Saída");
    }

    private string procName;
    [DisplayName("Processo"), Category("Processo"), Description("Nome do processo desejado")]
    public string ProcName
    {
      get 
      {
        if (GetInput(0) != null)
        {
          ScalarVar var = GetInput(0).EntityValue as ScalarVar;
          procName = Convert.ToString(var.RawValue);
        }
        return procName; 
      }
      set { procName = value; }
    }

    private string machineName;
    [DisplayName("Máquina"), Category("Processo"), Description("Nome da máquina da rede onde o processo está sendo executado")]
    public string MachineName
    {
      get { return machineName; }
      set { machineName = value; }
    }

    protected override IEntity doExecute()
    {
      Process[] processes;
      if(string.IsNullOrEmpty(MachineName))
        processes = Process.GetProcessesByName(ProcName);
      else
        processes = Process.GetProcessesByName(ProcName, MachineName);

      ScalarVar var = GetOutput(0) as ScalarVar;
      if (processes.Length > 0)
      {
        if (var != null)
        {
          var.RawValue = processes[0];
        }
      }
      return (IEntity)var;
    }
  }
}
