using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Core.PropertyEditors.Interfaces;
using Iris.PropertyEditors;
using System.Drawing.Design;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Expressão (XEval)")]
  public class XEval : ControlOperation, IScriptedObject
  {
    public XEval(Structure _structure, string _name)
      : base(_structure, _name)
    {
      SetOutputs("Saída");
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      Object value = Structure.XevalPrarser.Parse(Xpresion);
      ScalarVar var;
      if ((Outputs[0] != null) && (Outputs[0] is ScalarVar))
      {
        var = ((ScalarVar)Outputs[0]);
      }
      else
      {
        var = Structure.CreateVar("Var_" + Name, true);
      }
      var.InternalValue = value;
      return var;
    }

    private string xpresion;
    [Editor(typeof(ScriptEditor), typeof(UITypeEditor))]
    [DisplayName("Expressão")]
    public string Xpresion
    {
      get { return xpresion; }
      set { xpresion = value; }
    }

    #region IScriptedObject Members
    [Browsable(false)]
    public string Script
    {
      get
      {
        return Xpresion;
      }
      set
      {
        Xpresion = value;
      }
    }

    [Browsable(false)]
    public string Language
    {
      get { return "SQL"; }
    }

    #endregion
  }
}
