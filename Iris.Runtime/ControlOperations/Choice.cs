using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.Control;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.Runtime.Model.PropertyEditors.Interfaces;
using Iris.Interfaces;
using Iris.PropertyEditors.PropertyEditors;
using Databridge.Engine.Parsers;

namespace Iris.Runtime.Model.Operations.ControlOperations
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Fluxo Alternativo")]
  public class Choice : ControlOperation, IDynamicIOOperation,IChoice
  {
    public Choice(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      alternatives = new Dictionary<string, string>();
    }

    private Dictionary<string, string> alternatives;
    [Editor(typeof(ChoiceEditor), typeof(UITypeEditor))]
    public Dictionary<string, string> Alternatives
    {
      get { return alternatives; }
      set { alternatives = value; }
    }

    public void RefreshIO()
    {
      if (BeforeRefreshIO != null)
        BeforeRefreshIO(this, new EventArgs());

      Dictionary<string, IOperation> oldOutputs = new Dictionary<string,IOperation>();
      List<string> list = new List<string>();
      foreach (KeyValuePair<string, string> alternative in alternatives)
      {
        list.Add(alternative.Key);
        oldOutputs[alternative.Key] = GetOutput(alternative.Key);        
      }
      SetOutputs(list.ToArray());

      for (int i = 0; i < OutputCount; i++)
      {
        if (!oldOutputs.ContainsKey(GetOutputName(i)))
          SetOutput(i,null);
        else
          SetOutput(i, oldOutputs[GetOutputName(i)]);
      }

      foreach (KeyValuePair<string,IOperation> output in oldOutputs)
      {
        SetOutput(output.Key, output.Value);
      }

      if (AfterRefreshIO != null)
        AfterRefreshIO(this, new EventArgs());
    }

    private int trueExp;

    protected override IEntity doExecute()
    {
      trueExp = -1;

      for (int i = 0; i < OutputCount; i++)
      {
        string expression = Alternatives[GetOutputName(i)];

        bool result = Convert.ToBoolean(XEvalParser.GetParser().Parse(expression, Structure.GetContext()));
        if (result)
        {
          if (trueExp == -1)
            trueExp = i;
          else
          {
            throw new Exception("Mais de uma expressão foi avaliada como verdadeira");
          }
        }
      }
      return null;
    }

    public override Operation OnSuccess
    {
      get
      {
        if ((trueExp == -1)||(GetOutput(trueExp) == null))
          return base.OnSuccess;
        else
          return (Operation)GetOutput(trueExp);
      }
      set
      {
        base.OnSuccess = (Operation)value;
      }
    }

    #region IDynamicIOOperation Members
    [field: NonSerialized()]
    public event EventHandler BeforeRefreshIO;
    [field: NonSerialized()]
    public event EventHandler AfterRefreshIO;
    #endregion
  }
}
