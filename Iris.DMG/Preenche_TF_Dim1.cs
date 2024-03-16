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
using Databridge.Engine.Data;

namespace Iris.DMG
{
  [Serializable]
  [OperationCategory("DMG", "Preenche_TF_Dim1")] 
  public class Preenche_TF_Dim1 : BaseMetadataOperation
  {
    public Preenche_TF_Dim1(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      UpdateBatchSize = 5000;
    }

    protected override IEntity doExecute()
    {

      mtd_fnt_Fontes fonte = MetaModel.mtd_fnt_Fontes.First();
      string fonteName = GetNomeFonte(fonte);

      DataTable fntTable = Connection.ExecQuery(string.Format("Select * from {0}", fonteName), Structure.GetContext());

      foreach (mtd_dwh_Tabfatos tabFato in MetaModel.mtd_dwh_Tabfatos)
      {
        string tableName = GetNomeTabFato(tabFato);
        string select = string.Format("Select * from [{0}]", tableName);
        DataTable tbfTable = Connection.ExecQuery(select, Structure.GetContext());

        Dictionary<int, DataRow> dFonte = fntTable.Rows.Cast<DataRow>().ToDictionary(x => Convert.ToInt32(x[fntTable.PrimaryKey[0]]));

        foreach (DataRow row in tbfTable.Rows)
        {
          ProcessTbfRow(row, dFonte, fonte);
        }

        DataTable tmp = tbfTable.Clone();
        BaseResultSet rs = new BaseResultSet();
        rs.Table = tmp;
        rs.Sql = select;

        DbDataAdapter adapter = Connection.GetAdapter(rs, select, ref tmp, Structure.GetContext());
        adapter.UpdateBatchSize = UpdateBatchSize;
        adapter.Update(tbfTable);

      }
      return null;
    }

    public int UpdateBatchSize { get; set; }

    private void ProcessTbfRow(DataRow row, Dictionary<int, DataRow> dFonte, mtd_fnt_Fontes fonte)
    {

      int keyFilter = Convert.ToInt32(row[row.Table.PrimaryKey[0]]);
     

      foreach (DataColumn col in row.Table.Columns)
      {
        if (col.ColumnName.StartsWith("x"))
        {
          mtd_dwh_Dimensoes dim = GetDimensionFromId(col.ColumnName);
         
          if(TestaTipoDimensao(dim)==1)
          {
            string campoFonte = GetCamposFonte(dim)[0];
            string valorFonte = Convert.ToString(dFonte[keyFilter][campoFonte]);
            if (String.IsNullOrWhiteSpace(valorFonte))
            {
              row[col] = DBNull.Value;
            }
            else
            {
              row[col] = fonte.GetValorDominio(campoFonte, valorFonte);
            }
          }
        }
        
      }
    }



  }
}
