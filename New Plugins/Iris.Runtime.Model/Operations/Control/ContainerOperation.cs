///////////////////////////////////////////////////////////
//  ContainerOperation.cs
//  Implementation of the Class ContainerOperation
//  Generated by Enterprise Architect
//  Created on:      23-Jan-2007 21:51:46
//  Original author: Marcelo
///////////////////////////////////////////////////////////



using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Connections;
using System;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  public class ContainerOperation : ControlOperation
  {

    public ContainerOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      container = new Structure();
      container.Log = this.Structure.Log;
    }

    private Structure container;

    public Structure Container
    {
      get { return container; }
      set { container = value; }
    }

    protected override IEntity doExecute()
    {
      return container.Execute(false);
    }
  }//end ContainerOperation

}//end namespace ControlOperations