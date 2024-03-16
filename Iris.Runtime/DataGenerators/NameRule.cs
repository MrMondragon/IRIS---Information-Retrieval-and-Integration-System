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
  [OperationCategory("Geradores de Dados", "Name Rule")]
  public class NameRule : BaseValueRule
  {
    public NameRule(Structure structure, string name)
      : base(structure, name)
    {
      SetOutputs("Nome", "Sexo");
      maxLength = 0;
    }

    private int maxLength;
    [DisplayName("Tamanho Máximo"), Category("Rule"), Description("Tamanho máximo admitido pelo campo que será alimentado por esta regra. 0 para ilimitado")]
    [DefaultValue(0)]
    public int MaxLength
    {
      get { return maxLength; }
      set { maxLength = value; }
    }


    [NonSerialized]
    private Random rnd;

    protected override Iris.Interfaces.IEntity doExecute()
    {
      if (rnd == null)
        rnd = new Random();

      int sexIdx = rnd.Next(10) % 2;
      
      
      string nome;

      if (sexIdx == 1)
      {
        SetValue("Sexo", "M");
        int nameIdx = rnd.Next(NameParts.mNames.Length);
        nome = NameParts.mNames[nameIdx];
      }
      else
      {
        SetValue("Sexo", "F");
        int nameIdx = rnd.Next(NameParts.fNames.Length);
        nome = NameParts.fNames[nameIdx];
      }

      int sNameCount = rnd.Next(4)+1;

      for (int i = 0; i < sNameCount; i++)
      {
        int idx = rnd.Next(NameParts.sNames.Length);

        if((maxLength == 0) || ((nome.Length + NameParts.sNames[idx].Length) <= maxLength))
          nome += " " + NameParts.sNames[idx];
      }

      SetValue("Nome", nome);

      return FieldValue;
    }

    public static Bitmap GetIcon()
    {
      return Resources.Name;
    }


  }
}
