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
  [OperationCategory("DMG", "CriaDimT1")]
  public class CriaDimT1 : BaseDimensionOperation
  {

    public CriaDimT1(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    protected override void ProcessDimension(mtd_dwh_Dimensoes dim)
    {
      if(TestaTipoDimensao(dim)==1)
      {
        StringBuilder script = new StringBuilder();

        string nome = dim.mtd_con_Conceitos.Conceito;
        string id = dim.mtd_con_Conceitos.Conceito_Id;

        string tableName = string.Format("dwh_dim{0}_{1}", id, nome);

        if (Connection.TableExists(tableName))
        {
          script.AppendLine("Drop table " + tableName);
          script.AppendLine();
        }

        string[] linhasScript = new string[dim.mtd_dwhTipoDimensao.mtd_dwhTipoDimensao_Campos.Count()];

        foreach (mtd_dwhTipoDimensao_Campos item in dim.mtd_dwhTipoDimensao.mtd_dwhTipoDimensao_Campos)
        {

          int idx = item.Ordem - 1;
          string tipo = GetSqlType(item.Tipo, item.Tamanho);
          string scriptLine = string.Format("[x{0}_{1}]{2} NULL,", id, item.Campo, tipo);
          linhasScript[idx] = scriptLine;
        }


        script.AppendLine(String.Format("CREATE TABLE [{0}](", tableName));
        script.AppendLine(String.Format("[x{0}] int NOT NULL,", id));
        for (int i = 0; i < linhasScript.Length; i++)
        {
          script.AppendLine(linhasScript[i]);
        }
        script.AppendLine(String.Format("[x{0}_{1}] int NULL,", id, nome));

        script.AppendLine(string.Format(" CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED ", tableName));
        script.AppendLine(string.Format("([x{0}] ASC))", id));

        string sql = script.ToString();

        ExecuteScript(sql);
        Structure.AddToLog(string.Format("Dimensão [{0}] criada", dim.Dimensao), this);
      }
    }
  }
}
