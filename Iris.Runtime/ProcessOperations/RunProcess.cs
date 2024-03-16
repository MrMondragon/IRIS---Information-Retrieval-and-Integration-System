using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.Control;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using Iris.ControlOperations.ProcessOperations;
using Iris.PropertyEditors.PropertyEditors;

namespace Iris.Runtime.Model.Operations.ControlOperations
{
  [Serializable]
  [OperationCategory("Operações de Processo", "Executar Processo")]
  public class RunProcess : ControlOperation, IRunProcess
  {
    public RunProcess(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Nome", "Processo");
      SetOutputs("Saída");
    }

    private string procName;
    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    [DisplayName("Arquivo"), Category("Processo"), Description("A localização do executável em disco")]
    public string ProcName
    {
      get
      {
        IOperation oper = GetInput(0);
        if (oper != null)
          return Convert.ToString(oper.EntityValue.Value);
        else
          return procName;
      }
      set
      {
        if (value != procName)
        {
          procName = value;
          procInfo = null;
        }
      }
    }

    private string arguments;
    [DisplayName("Argumentos"), Category("Processo"), Description("Argumentos de linha de comando passados para o processo")]
    public string Arguments
    {
      get
      {
        return arguments;
      }
      set { arguments = value; }
    }

    private ProcessWindowStyle windowStyle;
    [DisplayName("Window Style"), Category("Processo"), Description("Estilo da janela principal criada para o processo")]
    public ProcessWindowStyle WindowStyle
    {
      get { return windowStyle; }
      set { windowStyle = value; }
    }

    [NonSerialized]
    protected ProcessStartInfo procInfo;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual ProcessStartInfo ProcInfo
    {
      get
      {
        if ((procInfo != null)&&(!string.IsNullOrEmpty(ProcName)))
        {
          procInfo = new ProcessStartInfo(ProcName);
          procInfo.UseShellExecute = false;
          procInfo.RedirectStandardOutput = true;
          ProcVerb =procInfo.Verb;
        }

        return procInfo;
      }
    }

    public override void Reset()
    {
      procInfo = null;
      base.Reset();
    }

    private string procVerb;
    [Editor(typeof(VerbSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Verb"), Category("Processo"), Description("Ação de inicialização do processo.")]
    public string ProcVerb
    {
      get
      {
        if ((ProcInfo != null) && (string.IsNullOrEmpty(procVerb)) && (ProcInfo.Verbs.Length > 0))
          procVerb = ProcInfo.Verbs[0];
        return procVerb;
      }
      set { procVerb = value; }
    }

    protected override IEntity doExecute()
    {
      Process proc;
      if (GetInput(1) == null)
      {
        ProcInfo.Arguments = Arguments;
        ProcInfo.WindowStyle = WindowStyle;
        ProcInfo.Verb = ProcVerb;
        proc = Process.Start(ProcInfo);
      }
      else
      {
        proc = (Process)GetValue(1);
        proc.Start();
      }

      SetValue(0, proc);

      return null;
    }
  }
}
