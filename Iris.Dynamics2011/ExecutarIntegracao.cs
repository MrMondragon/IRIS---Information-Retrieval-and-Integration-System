using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.Operations.ResultSetOperations;
using Iris.Interfaces;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Data;
using Iris.Dynamics2011;
using System.Threading.Tasks;
using Iris.Runtime.Model.Entities;
using Databridge.Engine.Data;

namespace PUC.IRIS.Operations
{
  [Serializable]
  [OperationCategory("Operações de Clientes", "PUC Executar Integração")]
  public class ExecutarIntegracao : ResultSetOperation
  {
    public string Organization { get; set; }

    public string EntityName { get; set; }

    public bool InsertOnly { get; set; }

    public ExecutarIntegracao(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      this.SetInputs("Origem", "OrigemTabela", "Configs");
      this.SetOutputs("Destino");
    }

    public bool LogDifferences { get; set; }


    protected override IEntity doExecute()
    {
      //validações
      if (string.IsNullOrEmpty(this.EntityName))
        throw new ApplicationException("EntityName não foi definido");
      Structure.AddToLog("Entidade definida: " + EntityName, this);

      if (string.IsNullOrEmpty(this.Organization))
        throw new ApplicationException("Organization não foi definido");
      Structure.AddToLog("Organização definida: " + Organization, this);

      IOperation opOrigem = this.GetInput("Origem");
      IResultSet origem = opOrigem.EntityValue as IResultSet;
      if (origem == null)
        throw new ApplicationException("Origem não foi definido ou não é um IResultSet");

      Structure.AddToLog("Origem definido", this);

      // Alteração para pegar a tabela com filtro
      DataTable tblOrigem = origem.View.ToTable();

      if (origem.PrimaryKey.Count() == 0)
        throw new ApplicationException("Defina a chave primária (chave de negócio) para a Origem");

      /// Avaliar em acesso remoto se isso pode ser o ponto
      /// A chave é passada de uma coluna pra outra
      /// 
      DataColumn[] pk = tblOrigem.Columns
        .Cast<DataColumn>()
        .Where(col =>
          origem.PrimaryKey.Any(colOrigem => colOrigem.ColumnName == col.ColumnName))
        .ToArray();
      tblOrigem.PrimaryKey = pk;


      Structure.AddToLog("Chave Primaria definida", this);

      IOperation opOrigemTabela = this.GetInput("OrigemTabela");
      IResultSet origemTabela = opOrigemTabela.EntityValue as IResultSet;

      ((BaseResultSet)origemTabela).TimeOut = 90;

      if (origemTabela == null)
        throw new ApplicationException("OrigemTabela não foi definido ou não é um IResultSet");
      DataTable tblOrigemTabela = origemTabela.Table;

      if (tblOrigemTabela.PrimaryKey.Count() == 0)
        throw new ApplicationException("Defina a chave primária (chave de negócio) para a OrigemTabela");

      Structure.AddToLog("Tabela Origem definido", this);

      IOperation opDestino = this.GetOutput("Destino");
      IResultSet destino = opDestino.EntityValue as IResultSet;
      if (destino == null)
        throw new ApplicationException("Destino não foi definido ou não é um IResultSet");
      DataTable tblDestino = destino.Table;

      // Remove coluna versionnumber
      if (tblDestino.Columns.Contains("versionnumber"))
      {
        UniqueConstraint constraint = null;
        foreach (UniqueConstraint con in tblDestino.Constraints)
        {
          if (con.Columns.Count() == 1)
          {
            foreach (DataColumn col in con.Columns)
            {
              if (col.ColumnName.ToLower() == "versionnumber")
              {
                constraint = con;
              }
            }
          }
        }
        if (constraint != null)
          tblDestino.Constraints.Remove(constraint);
        tblDestino.Columns.Remove("versionnumber");
      }

      Structure.AddToLog("Destino definido", this);

      // Remove colunas desnecessarias

      List<string> corresp = new List<string>();

      List<string> origColumns = tblOrigem.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
      List<string> destColumns = tblDestino.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();

      foreach (string item in destColumns)
      {
        if (!item.ToLower().Equals(this.EntityName.ToLower() + "id"))
        {
          if (!tblOrigem.Columns.Contains(item))
          {
            tblDestino.Columns.Remove(item);
          }
        }
      }

      Structure.AddToLog("Regra de Negocio atualização GUIDCRM", this);
      Structure.AddToLog("1 - Vinculo registros GuidCRM", this);
      //AtualizacaoGuidCrm(opOrigem, opDestino, origem, destino);
      AtualizacaoGuidCrm(tblOrigem, tblDestino);

      Structure.AddToLog("1 - Fim Vinculo registros GuidCRM", this);
      Structure.AddToLog("Fim da Regra de Negocio atualização GUIDCRM", this);

      Structure.AddToLog("1 - Vinculo registros PK", this);
      AtualizacaoPk(tblOrigem, tblDestino);
      Structure.AddToLog("1 - Fim Vinculo registros PK", this);

      Structure.AddToLog("1 - Vincular registros a serem desativados", this);

      //criar um dicionario ou lista de ids
      //aí, mermão, se funcionar, ta tudo errado
      if (!this.InsertOnly)
      {
        Dictionary<string, DataRow> ids = tblDestino.Select(EntityName + "id is not null").Cast<DataRow>().ToDictionary(x => Convert.ToString(x[EntityName + "id"]));
        DataRow[] rows = tblOrigem.Select("ind_operacao = 'D'");

        foreach (DataRow deleteRow in rows)
        {
          string id = Convert.ToString(deleteRow["guid_crm"]);
          if (ids.ContainsKey(id))
          {
            ids[id].Delete();
          }
        }
      }

      Structure.AddToLog("1 - Fim Vincular registros a serem desativados", this);

      #region Passo 2 - Salvamento no CRM
      Structure.AddToLog("Começo do Passo 2 - Salvamento no CRM", this);

      //envia as inclusões/atualizações para o CRM
      CRM2011Updater crmUpdate = new CRM2011Updater(this.Structure, "crmUpdateDestino");
      crmUpdate.UseSettingsInstaller = true;
      crmUpdate.RemoveUnchanged = true;
      crmUpdate.EntityName = this.EntityName;
      crmUpdate.ResultColumn = string.Format("{0}id_new", this.EntityName);
      crmUpdate.Organization = this.Organization;
      crmUpdate.ApplyNulls = true;
      crmUpdate.ApplyInserts = true;
      crmUpdate.ApplyUpdates = !InsertOnly;
      crmUpdate.ApplyDeletes = !InsertOnly;
      crmUpdate.LogicalExclusion = !InsertOnly;
      crmUpdate.TreatDateTimeAsDate = true;
      crmUpdate.FloatPrecision = 2;
      crmUpdate.BatchSize = BatchSize;
      crmUpdate.MaxErrors = 9;
      crmUpdate.SetInput("Entrada", opDestino);
      crmUpdate.SetInput("Configs", this.GetInput("Configs"));
      crmUpdate.LogDifferences = this.LogDifferences;
      crmUpdate.Execute();

      Structure.AddToLog("Fim do Passo 2 - Salvamento no CRM", this);

      #endregion Passo 2 - Salvamento no CRM
      if (crmUpdate.Status == ExecutionStatus.Failure)
      {
        this.Status = ExecutionStatus.Failure;
        //throw new ApplicationException("Falha no processo de atualização do CRM.");
      }

      #region Passo 3 - Vincula registro de atualização retorno
      Structure.AddToLog("Começo do Passo 3 - Vincula registro de atualização retorno", this);

      //atualiza retorno
      bool containsId = false;
      containsId = tblDestino.Columns.Contains(string.Format("{0}id", this.EntityName));

      foreach (DataRow rowOrigem in tblOrigem.Rows)
      {
        //procura pela chave de negócio
        string businessKeyOrigemTabela = GetBusinessKey(rowOrigem);

        DataRow rowDestino = tblDestino.Rows.Find(businessKeyOrigemTabela);
        DataRow rowOrigemTabela = tblOrigemTabela.Rows.Find(businessKeyOrigemTabela);

        if ((rowDestino != null) && (rowOrigemTabela != null))
        {
          object entityId = null;
          DataRowVersion version = rowDestino.RowState == DataRowState.Deleted ? DataRowVersion.Original : DataRowVersion.Default;

          if (containsId)
          {
            entityId = rowDestino[string.Format("{0}id", this.EntityName), version];
          }

          rowOrigemTabela["dat_execucao_crm"] = DateTime.Now;

          if (rowDestino.RowState == DataRowState.Deleted)
            continue;

          if (string.IsNullOrEmpty(Convert.ToString(entityId)))
            continue;

          if ((containsId) && (Convert.ToString(rowOrigemTabela["guid_crm"]) != Convert.ToString(entityId)))
          {
            rowOrigemTabela["guid_crm"] = entityId;
          }
        }
        else if ((rowDestino == null) && (rowOrigemTabela != null) && (Convert.ToString(rowOrigem["ind_operacao"]) == "D"))
        {
          rowOrigemTabela["dat_execucao_crm"] = DateTime.Now;
        }
      }
      Structure.AddToLog("Fim do Passo 3 - Vincula registro de atualização retorno", this);
      #endregion Passo 3 - Vincula registro de atualização retorno

      #region Passo 4 - Atualiza Retorno
      Structure.AddToLog("Começo do Passo 4 - Atualiza Retorno", this);
      Apply save = new Apply(this.Structure, "saveOrigemTabela");
      save.BatchSize = BatchSize;
      save.TimeOut = 90000;
      save.SetInput("Entrada", opOrigemTabela);
      save.Execute();
      Structure.AddToLog("Fim do Passo 4 - Atualiza Retorno", this);
      #endregion Passo 4 - Atualiza Retorno
      return destino as IEntity;
    }

    private static void DeleteRow(Dictionary<string, DataRow> ids, DataRow deleteRow)
    {
      string id = Convert.ToString(deleteRow["guid_crm"]);
      if (ids.ContainsKey(id))
      {
        ids[id].Delete();
      }
    }

    public int BatchSize { get; set; }

    private void AtualizacaoGuidCrm(IOperation origem, IOperation destino, IResultSet resorigem, IResultSet resdestino)
    {
      List<KeyValuePair<string, string>> corresp = new List<KeyValuePair<string, string>>();

      Dictionary<string, string> origColumns = resorigem.Table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToDictionary(y => y.ToLower(), z => z);
      Dictionary<string, string> destColumns = resdestino.Table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToDictionary(y => y.ToLower(), z => z);


      foreach (KeyValuePair<string, string> item in origColumns)
      {
        if (item.Key == "guid_crm")
        {
          corresp.Add(new KeyValuePair<string, string>(item.Value, this.EntityName.ToLower() + "id"));
        }
        else if (destColumns.ContainsKey(item.Key))
        {
          corresp.Add(new KeyValuePair<string, string>(item.Value, destColumns[item.Key]));
        }
      }

      Transport trans = new Transport(this.Structure, "transporteGuidCRM");
      trans.Corresp = corresp;
      trans.SetInput("Entrada", origem);
      trans.SetOutput("Saída", destino);

      trans.Execute();
    }

    private void AtualizacaoGuidCrm(DataTable tblOrigem, DataTable tblDestino)
    {
      DataColumn[] oldPk = tblDestino.PrimaryKey;
      tblDestino.PrimaryKey = new DataColumn[] { tblDestino.Columns[EntityName + "id"] };

      DataView viewOrig = new DataView(tblOrigem);
      viewOrig.RowFilter = "guid_crm IS NOT NULL AND ind_operacao <> 'D'";

      DataTable tableOrig = viewOrig.ToTable();
      tableOrig.PrimaryKey = new DataColumn[] { tableOrig.Columns["guid_crm"] };

      tblDestino.Merge(tableOrig, false, MissingSchemaAction.Ignore);

      tblDestino.PrimaryKey = oldPk;
    }

    private void AtualizacaoPk(DataTable tblOrigem, DataTable tblDestino)
    {
      DataView viewOrig = new DataView(tblOrigem);
      viewOrig.RowFilter = "guid_crm IS NULL AND ind_operacao <> 'D'";

      DataTable tableOrig = viewOrig.ToTable();
      tableOrig.PrimaryKey = new DataColumn[] { tableOrig.Columns[tblOrigem.PrimaryKey[0].ColumnName] };

      tblDestino.Merge(tableOrig, false, MissingSchemaAction.Ignore);
    }

    private string GetBusinessKey(DataRow row)
    {
      string businessKey = string.Empty;

      DataRowVersion version = row.RowState == DataRowState.Deleted ? DataRowVersion.Original : DataRowVersion.Default;

      foreach (DataColumn pk in row.Table.PrimaryKey)
        businessKey += Convert.ToString(row[pk, version]);

      return businessKey;
    }

    private void AtualizaRegistro(DataRow rowOrigem, DataRow rowDestino)
    {
      if (rowDestino.Table.Columns.Contains("PK"))
        rowDestino.Table.Columns["PK"].ReadOnly = false;
      foreach (DataColumn col in rowOrigem.Table.Columns)
      {
        if (rowDestino.Table.Columns.Contains(col.ColumnName))
        {
          //if (Convert.ToString(rowDestino[col.ColumnName]) != Convert.ToString(rowOrigem[col.ColumnName]))
          rowDestino[col.ColumnName] = rowOrigem[col.ColumnName];
        }
      }
    }

    [Browsable(false)]
    public new IResultSet Entrada
    {
      get
      {
        IOperation input = base.GetInput("Origem");
        if (input == null)
        {
          throw new Exception("Resultset de origem não atribuído");
        }
        IResultSet entityValue = (IResultSet)input.EntityValue;
        return entityValue;
      }
    }
  }

  public enum Operacao
  {
    Insert = 'I',
    Update = 'U',
    Delete = 'D'
  }
}
