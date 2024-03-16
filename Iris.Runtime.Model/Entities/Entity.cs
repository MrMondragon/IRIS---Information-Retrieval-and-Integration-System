using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Core.Connections;
using System.ComponentModel;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Entities
{
  [Serializable]
  public abstract class Entity : Operation, IEntity
  {
    public Entity(string aName, Structure aStructure)
      : base(aStructure,  aName)
    { 
    }

    [Browsable(false)]
    public override bool BreakPoint
    {
      get
      {
        return base.BreakPoint;
      }
      set
      {
        base.BreakPoint = value;
      }
    }

    [Browsable(false)]
    public override bool IgnoreFailure
    {
      get
      {
        return base.IgnoreFailure;
      }
      set
      {
        base.IgnoreFailure = value;
      }
    }

    [Browsable(false)]
    public override IEntity EntityValue
    {
      get { return this; }
    }

    [Browsable(false)]
    public override ExecutionStatus Status
    {
      get
      {
        return ExecutionStatus.Entity;
      }
      set
      {
      }
    }

    [Browsable(false)]
    public override bool ExternalParam
    {
      get
      {
        return base.ExternalParam;
      }
      set
      {
        base.ExternalParam = value;
      }
    }


    [Browsable(false), Description("Tipo de dado do valor da Variável")]
    public override Type DataType
    {
      get
      {
        return base.DataType;
      }
      set
      {
        base.DataType = value;
      }
    }
  }
}
