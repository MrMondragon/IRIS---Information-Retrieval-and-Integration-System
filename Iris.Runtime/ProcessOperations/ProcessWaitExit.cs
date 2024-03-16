using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iris.Runtime.Model.BaseObjects;
using System.Diagnostics;
using Iris.Interfaces;

namespace Iris.Runtime.ProcessOperations
{
  [Serializable]
  [OperationCategory("Operações de Processo", "Aguardar Conclusão")]
  public class ProcessWaitExit : ControlOperation
  {
    public ProcessWaitExit(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Processo");
      SetOutputs("Proc Output");

    }

    protected override IEntity doExecute()
    {
      Process proc = GetValue("Processo") as Process;
      if (proc == null)
        throw new Exception("Processo de entrada não atribuído ou inválido");

      proc.WaitForExit();
      string procOutput = proc.StandardOutput.ReadToEnd();

      string[] procLines = procOutput.Split('\r').Select(x => x.Trim()).Where(y => !string.IsNullOrWhiteSpace(y)).ToArray();

      foreach (string line in procLines)
      {
        Structure.AddToLog(line, this);
      }

      SetValue(0, procOutput);
      return null;
    }
  }
}
