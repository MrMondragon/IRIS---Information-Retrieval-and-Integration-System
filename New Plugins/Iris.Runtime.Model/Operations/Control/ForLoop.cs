using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Model.DisignSuport;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  [OperationCategory("Operações de Controle", "For Loop")]
  public class ForLoop : Loop
  {
    public ForLoop(Structure aStructure, string aName)
      : base(aStructure,aName)
    {
      SetInputs("Início", "Final","LoopVar");
    }

    private int startValue;

    public int StartValue
    {
      get 
      {
        if (Inputs[0] == null)
          return startValue;
        else
        {
          if (Inputs[0] is ResultSet)
            return ((ResultSet)Inputs[0]).Table.Rows.Count;
          else
            return Convert.ToInt32(Inputs[0].Value);
        }
      }
      set { startValue = value; }
    }


    private int endValue;

    public int EndValue
    {
      get 
      {
        if (Inputs[1] == null)
          return endValue;
        else
        {
          if (Inputs[1] is ResultSet)
            return ((ResultSet)Inputs[1]).Table.Rows.Count;
          else
            return Convert.ToInt32(Inputs[1].Value);
        }
      }
      set { endValue = value; }
    }

    private int increment;
    public int Increment
    {
      get { return increment; }
      set { increment = value; }
    }

    protected override IEntity doExecute()
    {
      for (int i = StartValue; i < EndValue; i+=Increment)
      {
        if (Inputs[2] != null)
        {
          ((ScalarVar)Inputs[2]).InternalValue = i;
        }

        LoopOper.Execute();
      }
      return base.doExecute();
    }
  }
}
