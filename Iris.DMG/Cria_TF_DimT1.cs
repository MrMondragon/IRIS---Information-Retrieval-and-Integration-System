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
using Databridge.Engine.Extensions;

namespace Iris.DMG
{
  [Serializable]
  [OperationCategory("DMG", "Cria_TF_DimT1")]
  public class Cria_TF_DimT1 : BaseMetadataOperation
  {
    public Cria_TF_DimT1(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }


    protected override IEntity doExecute()
    {
      foreach (mtd_dwh_Tabfatos tabFato in MetaModel.mtd_dwh_Tabfatos)
      {
        StringBuilder script = new StringBuilder();
        string tableName = GetNomeTabFato(tabFato);
        script.AppendLine("Alter Table {0} ", tableName);
        script.AppendLine("Add ");
        int ct = 0;

        foreach (mtd_dwh_Dimensoes dim in tabFato.mtd_dwh_Dimensoes)
        {
          if (TestaTipoDimensao(dim) == 1)
          {
            ct += 1;
            script.AppendLine("{0} int null,", dim.Dimensao_Id );
          }
        }

        if (ct > 0)
          ExecuteScript(script.ToString().Trim().TrimEnd(','));

      }

      return null;
    }


  }
}