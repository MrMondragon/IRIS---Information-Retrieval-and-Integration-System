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
using System.Drawing;
using Iris.Runtime.Properties;

namespace Iris.DataGenerator
{
  [Serializable]
  [OperationCategory("Geradores de Dados", "Serial Rule")]
  public class SerialRule : BaseValueRule
  {
    public SerialRule(Structure structure, string name)
      : base(structure, name)
    {
      SetInputs("Início");
      initialized = false;
      SetOutputs("Saída");
    }

    private int start;
    [DisplayName("Início"), Description("Valor de início da numeração"), Category("Rule")]
    public int Start
    {
      get
      {
        if (GetInput("Início") != null)
          return Convert.ToInt32(GetInput("Início").Value);
        else
          return start;

        
      }
      set 
      {
        if (value != start)
        {
          start = value;
          Reset();
        }
      }
    }

    [NonSerialized]
    private bool initialized;

    public override void Reset()
    {
      initialized = false;
      base.Reset();
    }

    protected override IEntity doExecute()
    {
      if (!initialized)
      {
        value = Start;
        initialized = true;
      }
      else
      {
        int valueInt = Convert.ToInt32(value);
        value = valueInt + 1;
      }

      return FieldValue;
    }

    public static Bitmap GetIcon()
    {
      return Resources.Serial;
    }
  }
}
