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
  [OperationCategory("DMG", "Cria_TF_DimT2")]
  public class Cria_TF_DimT2 : BaseDimensionOperation
  {
    public Cria_TF_DimT2(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected override void ProcessDimension(mtd_dwh_Dimensoes dim)
    {
      if (TestaTipoDimensao(dim) == 2)
      {
        StringBuilder script = new StringBuilder();

        string nome = dim.mtd_con_Conceitos.Conceito;
        string id = dim.mtd_con_Conceitos.Conceito_Id;

        string tableName = string.Format("dwh_tbf{0}", id, nome);

        if (Connection.TableExists(tableName))
        {
          script.AppendLine("Drop table " + tableName);
          script.AppendLine();
        }
        mtd_dwh_Tabfatos tabFato = dim.mtd_dwh_Tabfatos.First();

        List<string> chaves = GetChavesTabFato(tabFato);

        script.AppendLine("CREATE TABLE [{0}](", tableName);
        for (int i = 0; i < chaves.Count; i++)
        {
          script.AppendLine("[{0}] int NOT NULL,", chaves[i]);
        }
        script.AppendLine(String.Format("[x{0}] int NOT NULL,", id));

        script.AppendLine(string.Format(" CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED ", tableName));
        script.AppendLine(string.Format("([x{0}] ASC, ", id));
        for (int i = 0; i < chaves.Count; i++)
        {
          script.AppendLine("[{1}] ASC,", chaves[i]);
        }
        
        string sql = script.ToString().Trim().TrimEnd(',') + "))";

        ExecuteScript(sql);
        Structure.AddToLog(string.Format("Tabela fato da Dimensão [{0}] criada", dim.Dimensao), this);
      }
    }
  }
}
