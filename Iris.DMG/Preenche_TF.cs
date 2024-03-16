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
  [OperationCategory("DMG", "Preenche_TF")]
  public class Preenche_TF
    : BaseMetadataOperation
  {
    public Preenche_TF(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }


    protected override IEntity doExecute()
    {
      foreach (mtd_dwh_Tabfatos tabFato in MetaModel.mtd_dwh_Tabfatos)
      {
        StringBuilder script = new StringBuilder();
        string tableName = string.Format("dwh_tbf{0}", tabFato.Tabfato);

        IEnumerable<string> conceitos = tabFato.mtd_dwh_Dimensoes.Select(x=> x.Conceito_Id).Distinct();

        IEnumerable<int> fontesId = MetaModel.mtd_fnt_Fontes_x_Conceitos.Where(x => conceitos.Contains(x.Conceito_Id)).Select(y => y.Fonte_Id);

        IEnumerable<mtd_fnt_Fontes> fontes = MetaModel.mtd_fnt_Fontes.Where(x => fontesId.Contains(x.Fonte_Id));

        List<string> chaves = GetChavesTabFato(tabFato);
        string chavesScript =  string.Join(", ", chaves.ToArray()).Trim().TrimStart(',');;

        script.AppendLine("insert into [{0}] ", tableName);

        string camposTbf = chavesScript;
                
        foreach (mtd_dwhTipoTabfato_Campos campo in tabFato.mtd_dwhTipoTabfato.mtd_dwhTipoTabfato_Campos)
        {
            camposTbf+= ", "+campo.Campo;         
        }

        script.AppendLine("({0})", camposTbf);


        mtd_fnt_Fontes fonte = fontes.First(); //quando tiver mais de uma, precisa ver como vai ser o relacionamento

        string valoresTbf = chavesScript;
        foreach (mtd_dwhTipoTabfato_Campos campo in tabFato.mtd_dwhTipoTabfato.mtd_dwhTipoTabfato_Campos)
        {
          valoresTbf += ", ";
          valoresTbf += !(string.IsNullOrWhiteSpace(campo.Valor_Default)) ? campo.Valor_Default : "NULL";
        }

        string fonteNome = GetNomeFonte(fonte);

        script.AppendLine("Select {0} from {1}", valoresTbf, fonteNome);


        ExecuteScript(script.ToString());
      }

      return null;
    }

  
  }
}
