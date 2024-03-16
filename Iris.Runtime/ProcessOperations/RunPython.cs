using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.ControlOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.Diagnostics;

namespace Iris.Runtime.ProcessOperations
{
  [Serializable]
  [OperationCategory("Operações de Processo", "Executar Python Script")]
  public class RunPython : RunProcess
  {
    public RunPython(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Script");
      SetOutputs("Processo");
      Environment = @"C:\Python27\python.exe";
    }

    public string Environment { get; set; }

    public override ProcessStartInfo ProcInfo
    {
      get
      {
        if ((procInfo != null) && (!string.IsNullOrEmpty(ProcName)))
        {
          procInfo = new ProcessStartInfo(Environment);
          procInfo.UseShellExecute = false;
          procInfo.RedirectStandardOutput = true;
          procInfo.Arguments = String.IsNullOrWhiteSpace(Arguments)?ProcName:$"{ProcName} {Arguments}";
          ProcVerb = procInfo.Verb;
        }

        return base.ProcInfo;
      }
    }

    protected override IEntity doExecute()
    {
      Process proc = Process.Start(ProcInfo);
      SetValue(0, proc);
      return null;
    }
  }
}
