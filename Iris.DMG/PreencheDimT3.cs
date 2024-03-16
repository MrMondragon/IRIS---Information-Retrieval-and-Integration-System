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
  [OperationCategory("DMG", "PreencheDimT3")]
  public class PreencheDimT3 : BaseDimensionOperation
  {

    public PreencheDimT3(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }


    protected override void ProcessDimension(mtd_dwh_Dimensoes dim)
    {
      if (TestaTipoDimensao(dim) == 3)
      {
        string nome = dim.mtd_con_Conceitos.Conceito;
        string id = dim.mtd_con_Conceitos.Conceito_Id;

        string tableName = string.Format("dwh_dim{0}_{1}", id, nome);

        StringBuilder script = new StringBuilder();

        string sql = script.ToString().Trim().TrimEnd(',');

        // ExecuteScript(sql);
        Structure.AddToLog(string.Format("Dimensão [{0}] preenchida", dim.Dimensao), this);
      }
    }
  }
}
