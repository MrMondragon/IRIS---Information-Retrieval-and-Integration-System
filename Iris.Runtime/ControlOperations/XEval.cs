using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;
using System.Drawing.Design;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.DisignSuport;
using Iris.Interfaces;
using Databridge.Engine.Parsers;
using Databridge.Engine;
using Databridge.Interfaces;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  [OperationCategory("Opera��es de Controle", "Express�o (XEval)")]
  public class XEval : ControlOperation, IScriptedObject
  {
    public XEval(Structure _structure, string _name)
      : base(_structure, _name)
    {
      SetOutputs("Sa�da");
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      ExecutionContext context = Structure.GetContext();

      Object value = XEvalParser.GetParser().Parse(Xpresion, context);
      ScalarVar var;
      IOperation oper = GetOutput("Sa�da");

      if ((oper != null) && (oper is ScalarVar))
      {
        var = ((ScalarVar)oper);
        var.RawValue = value;
        return var;
      }
      else
      {
       return null;
      }
    }

    private string xpresion;
    [Editor(typeof(ScriptEditor), typeof(UITypeEditor))]
    [DisplayName("Express�o")]
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

    IExecutionContext IScriptedObject.Context
    {
      get { return Structure.GetContext(); }
    }


    #endregion
  }
}
