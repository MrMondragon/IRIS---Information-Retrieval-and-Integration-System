using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model;
using Iris.Runtime.Model.BaseObjects;
using System;
using Iris.Runtime.Model.Operations.Control;
using System.ComponentModel;
using Iris.Interfaces;
namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  public abstract class ResultSetOperation : Operation
  {
    public ResultSetOperation(Structure aStructure, string aName)
      : base(aStructure,  aName)
    {
      SetInputs("Entrada");
    }

    [Browsable(false)]
    public IResultSet Entrada
    {
      get
      {
        IOperation input = GetInput("Entrada");
        if (input == null)
          throw new Exception("Resultset de entrada não atribuído");
        else
          return (IResultSet)input.EntityValue;
      }
    }

    public override IEntity EntityValue
    {
      get
      {
        return (IEntity)GetInput(0).EntityValue;
      }
    }
  }
}