using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.Operations;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using System.Data;
using Iris.Runtime.Model.DisignSuport;
using System.ComponentModel;


namespace Iris.DataGenerator
{
  [Serializable]
  public abstract class BaseValueRule : Operation
  {
    public BaseValueRule(Structure structure, string name)
      : base(structure, name)
    {
    }

    [NonSerializedAttribute]
    protected object value;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ScalarVar FieldValue
    {
      get
      {
        ScalarVar sv = new ScalarVar(null, null);
        sv.RawValue = value;
        return sv;
      }
    }

    public override IEntity EntityValue
    {
      get
      {
        return FieldValue;
      }
    }

  }
}
