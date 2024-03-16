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
  [OperationCategory("Geradores de Dados", "Constant Rule")]
  public class ConstantRule : BaseValueRule
  {
    public ConstantRule(Structure structure, string name)
      : base(structure, name)
    {
      SetInputs("Entrada");
      SetOutputs("Saída");
    }

    private string valor;
    [DisplayName("Valor"), Description("Valor da constante retornada pela regra"), Category("Rule")]
    public string Valor
    {
      get 
      {
        if (GetInput("Entrada") != null)
          return Convert.ToString(GetInput("Entrada").Value);
        else
          return valor; 
      }
      set { valor = value; }
    }

    protected override IEntity doExecute()
    {
      this.value = Valor;
      return FieldValue;
    }

    public static Bitmap GetIcon()
    {
      return Resources.Const;
    }
  }
}
