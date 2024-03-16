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
        if (GetInput(0) == null)
          return startValue;
        else
        {
          if (GetInput(0) is IResultSet)
            return ((IResultSet)GetInput(0)).Table.Rows.Count;
          else
            return Convert.ToInt32(GetInput(0).Value);
        }
      }
      set { startValue = value; }
    }


    private int endValue;

    public int EndValue
    {
      get 
      {
        if (GetInput(1) == null)
          return endValue;
        else
        {
          if (GetInput(1) is IResultSet)
            return ((IResultSet)GetInput(1)).Table.Rows.Count;
          else
            return Convert.ToInt32(GetInput(1).Value);
        }
      }
      set { endValue = value; }
    }

    private int increment;
    public int Increment
    {
      get 
      {
        if (increment == 0)
          increment = 1;

        return increment; 
      }
      set { increment = value; }
    }

    protected override IEntity doExecute()
    {
      for (int i = StartValue; i < EndValue; i+=Increment)
      {
        if (GetInput(2) != null)
        {
          ((ScalarVar)GetInput(2)).RawValue = i;
        }

        base.doExecute();
      }
      return null;
    }
  }
}
