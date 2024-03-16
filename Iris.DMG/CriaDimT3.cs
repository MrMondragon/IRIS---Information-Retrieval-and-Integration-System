using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.ClientObjects;
using Iris.Runtime.Model.Entities;
using System.Data;
using System.Threading.Tasks;
using Databridge.Interfaces;
using System.ComponentModel;
using Iris.PropertyEditors;
using Iris.Runtime.Core.Connections;
using System.Drawing.Design;
using System.Data.Common;
using Iris.DMG.Model;

namespace Iris.DMG
{
  [Serializable]
  [OperationCategory("DMG", "CriaDimT3")]
  public class CriaDimT3 : BaseDimensionOperation
  {

    public CriaDimT3(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    protected override void ProcessDimension(mtd_dwh_Dimensoes dim)
    {
      if (TestaTipoDimensao(dim) == 3)
      {
        StringBuilder script = new StringBuilder();


        string sql = script.ToString();
        //ExecuteScript(sql);
        Structure.AddToLog(string.Format("Dimensão [{0}] criada", dim.Dimensao), this);
      }
    }
  }
}
