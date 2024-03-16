using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.DataGenerator;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Drawing;
using Iris.Runtime.Properties;

namespace Iris.Runtime.DataGenerators
{
  [Serializable]
  [OperationCategory("Geradores de Dados", "Masked Number Rule")]
  public class MaskedNumberRule : BaseValueRule
  {
    public MaskedNumberRule(Structure structure, string name)
      : base(structure, name)
    {
      SetOutputs("Saída");
      mask = "######";
    }

    private string mask;
    [DisplayName("Mask"), Description("Máscara de formatação. Use # para números."), Category("Rule")]
    public string Mask
    {
      get { return mask; }
      set { mask = value; }
    }

    [NonSerialized]
    private Random rnd;

    protected override Iris.Interfaces.IEntity doExecute()
    {
      if (rnd == null)
        rnd = new Random();

      StringBuilder builder = new StringBuilder();

      if (string.IsNullOrEmpty(Mask))
        throw new Exception("Máscara inválida ou não informada");

      for (int i = 0; i < Mask.Length; i++)
      {
        if (mask[i] == '#')
        {
          int x = rnd.Next(10);
          builder.Append(x);
        }
        else
          builder.Append(Mask[i]);
      }

      value = builder.ToString();

      return FieldValue;
    }

    public static Bitmap GetIcon()
    {
      return Resources.MaskedNumberRule;
    }
  }
}
