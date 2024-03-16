using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Operations;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Entities;

namespace Iris.RuleOperations
{
  [Serializable]
  [OperationCategory("Funções e Operadores", "Case")]
  public class OperCase : DynamicLinkOperation
  {

    public OperCase(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
    }

    protected override void doRefreshIO()
    {
      ScalarVar var = GetInput(0) as ScalarVar;
      if (var != null)
      {
        string[] newOutputs = new string[var.ValidValues.Count];
        for (int i = 0; i < var.ValidValues.Count; i++)
        {
          newOutputs[i] = var.ValidValues[i];
        }
        SetOutputs(newOutputs);
      }
      else
        SetOutputs(new string[0]);
    }

    protected override IEntity doExecute()
    {
      ScalarVar var = GetInput(0) as ScalarVar;
      if (var != null)
      {
        string stValue;
        if (!Convert.IsDBNull(var.RawValue))
          stValue = Convert.ToString(var.RawValue);
        else
          stValue = "";


        for (int i = 0; i < var.ValidValues.Count; i++)
        {
          if (stValue == var.ValidValues[i])
          {
            Operation oper = (Operation)GetOutput(i);
            this.ExecuteObj(oper);
            break;
          }
        }

        return null;
      }
      else
        throw new Exception("Variável de entrada inválida");
    }

    public override void SetInput(int idx, IOperation input)
    {
      IOperation oldInput = GetInput(idx);

      base.SetInput(idx, input);

      if ((idx == 0) && (oldInput != input))
      {
        RefreshIO();
      }
    }
  }
}
