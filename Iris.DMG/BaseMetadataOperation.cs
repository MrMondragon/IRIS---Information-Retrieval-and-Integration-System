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
  [OperationCategory("DMG", "Dimensões")]
  public abstract class BaseMetadataOperation : Operation
  {
    public BaseMetadataOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }


    private static MetaModel metaModel;
    public MetaModel MetaModel
    {
      get
      {
        if (metaModel == null)
        {
          metaModel = new MetaModel(Connection.Connection);
        }
        return metaModel;
      }
    }

    private DynConnection connection;
    /// <summary>
    /// Gets the connection.
    /// </summary>
    /// <value>The connection.</value>
    [Editor(typeof(ConnectionSelectorEditor), typeof(UITypeEditor))]
    public DynConnection Connection
    {
      get
      {
        if (connection == null)
        {
          if (Structure.Connections.Count != 0)
          {
            connection = Structure.Connections[0];
          }
        }
        return connection;
      }
      set { connection = value; }
    }

    protected int TestaTipoDimensao(mtd_dwh_Dimensoes dim)
    {
      if (tiposDimensao == null)
      {
        tiposDimensao = new Dictionary<mtd_dwh_Dimensoes, int>();
        foreach (mtd_dwh_Dimensoes item in MetaModel.mtd_dwh_Dimensoes)
        {
          tiposDimensao[item] = item.mtd_con_Conceitos.mtd_fnt_Fontes_x_Conceitos.First().mtd_fnt_Fontes_Campos.Campo_Tipo_Cod.Value;
        }
      }
      return tiposDimensao[dim];
    }
    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private Dictionary<mtd_dwh_Dimensoes, int> tiposDimensao;

    protected mtd_dwh_Dimensoes GetDimensionFromId(string id)
    {
      if (dimensoes == null)
      {
        dimensoes = MetaModel.mtd_dwh_Dimensoes.ToDictionary(x => x.Dimensao_Id);
      }
      return dimensoes[id];
    }
    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private Dictionary<string, mtd_dwh_Dimensoes> dimensoes;

    protected string[] GetCamposFonte(mtd_dwh_Dimensoes dim)
    {
      if (camposFonte == null)
      {
        camposFonte = new Dictionary<mtd_dwh_Dimensoes, string[]>();
        foreach (mtd_dwh_Dimensoes item in MetaModel.mtd_dwh_Dimensoes)
        {
          camposFonte[item] = item.mtd_con_Conceitos.mtd_fnt_Fontes_x_Conceitos.Select(x => x.mtd_fnt_Fontes_Campos.Campo).ToArray();
        }

      }
      return camposFonte[dim];

    }

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private Dictionary<mtd_dwh_Dimensoes, string[]> camposFonte;

    protected string GetSqlType(string tipoMtd, int? tamanho)
    {
      tipoMtd = tipoMtd.ToLower();
      string tipo = tipoMtd;

      switch (tipoMtd)
      {
        case "string":
          {
            tipo = "varchar";
            if (tamanho.HasValue)
              tipo += "(" + tamanho.ToString() + ")";
            else
              tipo += "(50)";
          }
          break;
        case "integer":
          tipo = "int";
          break;
        case "decimal":
          {
            tipo = "decimal";
            if (tamanho.HasValue)
              tipo = string.Format("{0}({1},{2})", tipo, tamanho.Value * 2, tamanho.Value);
          }
          break;
      }


      return tipo;
    }

    protected void ExecuteScript(string sql)
    {
      DbCommand cmd = connection.Connection.CreateCommand();
      cmd.CommandText = sql;
      cmd.ExecuteNonQuery();
    }

    protected List<string> GetChavesTabFato(mtd_dwh_Tabfatos tabFato)
    {
      List<string> chaves = new List<string>();

      foreach (mtd_dwh_Dimensoes dim in tabFato.mtd_dwh_Dimensoes)
      {
        foreach (mtd_fnt_Fontes_x_Conceitos fxcs in dim.mtd_con_Conceitos.mtd_fnt_Fontes_x_Conceitos)
        {
          chaves.AddRange(MetaModel.mtd_fnt_Fontes_Campos.Where(x => (x.Fonte_Id == fxcs.Fonte_Id) && (x.Campo_Tipo_Cod == 99) && (!chaves.Contains(x.Campo))).Select(y => y.Campo));
        }
      }
      return chaves;
    }


    protected string GetNomeTabFato(mtd_dwh_Tabfatos tabFato)
    {
      string tableName = string.Format("dwh_tbf{0}", tabFato.Tabfato);
      return tableName;
    }

    protected string GetNomeFonte(mtd_fnt_Fontes fonte)
    {
      string fonteNome = string.Format("fntFonte_{0}_{1}", fonte.Fonte_Id, fonte.Fonte);
      return fonteNome;
    }

    public override void Reset()
    {
      base.Reset();
      metaModel = null;
    }
  }
}
