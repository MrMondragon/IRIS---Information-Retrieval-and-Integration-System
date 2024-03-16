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
using Databridge.Engine.Criptography.Generators;
using System.Drawing;
using Iris.Runtime.Properties;

namespace Iris.DataGenerator
{
  [Serializable]
  [OperationCategory("Geradores de Dados", "Number Rule")]
  public class NumberRule : BaseValueRule
  {
    public NumberRule(Structure structure, string name)
      : base(structure, name)
    {
      Length = 0;
      Min = 0;
      Max = 1000;
      SetOutputs("Saída");
    }


    private decimal min;
    [DisplayName("Mínimo"), Description("Valor mínimo"), Category("Rule")]
    public decimal Min
    {
      get { return min; }
      set { min = value; }
    }

    private decimal max;
    [DisplayName("Máximo"), Description("Valor máximo"), Category("Rule")]
    public decimal Max
    {
      get { return max; }
      set { max = value; }
    }

    private bool integer;
    [DisplayName("Inteiros"), Description("Indica se a regra deve retornar valores inteiros ou fracionários"), Category("Rule")]
    public bool Integer
    {
      get { return integer; }
      set { integer = value; }
    }

    private int length;
    [DisplayName("Tamanho"), Description("Se for diferente de 0, indica o tamanho para numeros de tamanho fixo."), Category("Rule")]
    public int Length
    {
      get { return length; }
      set { length = value; }
    }

    [NonSerialized]
    private Random rnd;

    protected override Iris.Interfaces.IEntity doExecute()
    {
      if (rnd == null)
        rnd = new Random();

      if (length == 0)
      {
        double baseValue = (double)Max - (double)Min;

        baseValue = baseValue * rnd.NextDouble();

        baseValue += (double)min;

        if (Integer)
          value = Convert.ToInt32(baseValue);
        else
          value = baseValue;
      }
      else
      {
        string vlSt = "";

        while (vlSt.Length < length)
          vlSt += rnd.Next(10).ToString();



        value = vlSt;
      }

      return FieldValue;

    }

    public static Bitmap GetIcon()
    {
      return Resources.Number;
    }
  }
}
