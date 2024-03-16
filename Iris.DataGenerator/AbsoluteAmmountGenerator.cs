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
  [OperationCategory("Geradores de Dados", "Absolute Generator")]
  public class AbsoluteAmmountGenerator : BaseRowGenerator
  {
    public AbsoluteAmmountGenerator(Structure structure, string name)
      : base(structure, name)
    {
      SetInputs("Qtde");     
    }

    private int ammount;
    [DisplayName("Quantidade"), Description("Quantidade de registros que serão gerados")]
    public int Ammount
    {
      get 
      {
        if (GetInput("Qtde") != null)
          return Convert.ToInt32(GetInput("Qtde").Value);
        else
          return ammount; 
      }
      set { ammount = value; }
    }

    protected override void GetInstanceInputs(List<string> fieldList)
    {
      fieldList.Add("Qtde"); 
    }

    protected override int GetRowCount()
    {
      return Ammount;
    }

    public static Bitmap GetIcon()
    {
      return Resources.AbsGen;
    }
  }
}
