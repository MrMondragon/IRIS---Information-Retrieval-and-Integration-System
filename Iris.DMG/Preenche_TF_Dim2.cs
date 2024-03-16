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
  [OperationCategory("DMG", "Preenche_TF_Dim2")]
  public class Preenche_TF_Dim2 : BaseDimensionOperation
  {
    public Preenche_TF_Dim2(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected override void ProcessDimension(mtd_dwh_Dimensoes dim)
    {
      if (TestaTipoDimensao(dim) == 2)
      {
        if (TestaTipoDimensao(dim) == 2)
        {
          StringBuilder script = new StringBuilder();

          string nome = dim.mtd_con_Conceitos.Conceito;
          string id = dim.mtd_con_Conceitos.Conceito_Id;

          string tableName = string.Format("dwh_tbf{0}", id, nome);

          mtd_dwh_Tabfatos tabFato = dim.mtd_dwh_Tabfatos.First();

          List<string> chaves = GetChavesTabFato(tabFato);

          string tabFatoNome = GetNomeTabFato(tabFato);
          string select = string.Format("Select * from [{0}]", tabFatoNome);
          DataTable tbfTable = Connection.ExecQuery(select, Structure.GetContext());


          string keyFields = string.Join(", ", chaves);
          keyFields += string.Format("x{0}", id);


          script.AppendLine("Insert into {0} ({1}) values", tableName, keyFields);



          IEnumerable<mtd_fnt_Fontes_x_Conceitos> fontes = dim.mtd_con_Conceitos.mtd_fnt_Fontes_x_Conceitos;


          foreach (mtd_fnt_Fontes_x_Conceitos fonte in fontes)
          {
            script.AppendLine("select distinct {0}, {1} from {2} where {1} is not null ", chaves, fonte.Campo, fonte.mtd_fnt_Fontes_Campos.mtd_fnt_Fontes.Fonte);
            string scriptStr = script.ToString();
            scriptStr = scriptStr.Remove(scriptStr.LastIndexOf("Union")).Trim();

            DataTable result = Connection.ExecQuery(scriptStr, Structure.GetContext());


            foreach (DataRow row in result.Rows)
            {
              string campoFonte = result.Columns[1].ColumnName;
              string valorFonte = Convert.ToString(row[1]);

              script.AppendLine("({0}, {1})", row[0], fonte.mtd_fnt_Fontes_Campos.mtd_fnt_Fontes.GetValorDominio(campoFonte, valorFonte));
            }
          }

          string sql = script.ToString().Trim().TrimEnd(',');
          ExecuteScript(sql);


        }
      }
    }

  }
}
