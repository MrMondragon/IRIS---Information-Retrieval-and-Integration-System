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
  [OperationCategory("DMG", "CriaTabFato")]
  public class CriaTabFato : BaseMetadataOperation
  {
    public CriaTabFato(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }


    protected override IEntity doExecute()
    {
      foreach (mtd_dwh_Tabfatos tabFato in MetaModel.mtd_dwh_Tabfatos)
      {
        StringBuilder script = new StringBuilder();
        string tableName = GetNomeTabFato(tabFato);

        if (Connection.TableExists(tableName))
        {
          script.AppendLine("Drop table {0}", tableName);
          script.AppendLine();
        }

        List<string> chaves = GetChavesTabFato(tabFato);

        script.AppendLine("CREATE TABLE [{0}](", tableName);
        for (int i = 0; i < chaves.Count; i++)
        {
          script.AppendLine("[{0}] int NOT NULL,", chaves[i]);
        }
        foreach(mtd_dwhTipoTabfato_Campos campo in tabFato.mtd_dwhTipoTabfato.mtd_dwhTipoTabfato_Campos)
        {
          string tipo = GetSqlType(campo.Tipo, campo.Tamanho);
          script.AppendLine("	[{0}] {1} NULL,", campo.Campo, tipo);
        }
        script.AppendLine("CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED (", tableName);
        for (int i = 0; i < chaves.Count; i++)
        {
          script.AppendLine("[{0}] ASC,", chaves[i]);
        }

        string sql = script.ToString().Trim().TrimEnd(',') + "))";

        ExecuteScript(sql);

        Structure.AddToLog(string.Format("TabelaFato [{0}] criada", tableName), this);
      }

      return null;
    }




  }
}
