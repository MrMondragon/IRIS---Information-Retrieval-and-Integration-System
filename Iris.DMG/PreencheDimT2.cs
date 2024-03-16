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
  [OperationCategory("DMG", "PreencheDimT2")]
  public class PreencheDimT2 : BaseDimensionOperation
  {

    public PreencheDimT2(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }


    protected override void ProcessDimension(mtd_dwh_Dimensoes dim)
    {
      if (TestaTipoDimensao(dim) == 2)
      {
        string nome = dim.mtd_con_Conceitos.Conceito;
        string id = dim.mtd_con_Conceitos.Conceito_Id;

        string tableName = string.Format("dwh_dim{0}_{1}", id, nome);

        StringBuilder script = new StringBuilder();
        script.AppendLine(string.Format("insert into {0} ([x{1}],[x{1}_Conceito],[x{1}_Descricao],[x{1}_Grupo],[x{1}_SubGrupo],[x{1}_Valor_Rotulo],[x{1}_Valor_Abreviacao],[x{1}_Nome]) values", tableName, id));

        string conceito = dim.mtd_con_Conceitos.Conceito;
        string descricao = dim.mtd_con_Conceitos.Conceito_Descricao;
        string grupo = dim.mtd_con_Conceitos.mtd_con_SubgrupoConceito.mtd_con_GrupoConceito.Grupo;
        string subGrupo = dim.mtd_con_Conceitos.mtd_con_SubgrupoConceito.Subgrupo;

        foreach (mtd_con_Conceitos_Dominios item in dim.mtd_con_Conceitos.mtd_con_Conceitos_Dominios)
        {
          mtd_con_Conceitos_Dominios cdr = item;

          script.AppendLine(string.Format("({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}'), ", cdr.Dominio_Valor, conceito, descricao,
            grupo, subGrupo, cdr.Dominio_Rotulo, cdr.Dominio_Abreviacao, cdr.mtd_con_Conceitos.Conceito_Nome));
        }

        string sql = script.ToString().Trim().TrimEnd(',');

        ExecuteScript(sql);
        Structure.AddToLog(string.Format("Dimensão [{0}] preenchida", dim.Dimensao), this);
      }
    }
  }
}
