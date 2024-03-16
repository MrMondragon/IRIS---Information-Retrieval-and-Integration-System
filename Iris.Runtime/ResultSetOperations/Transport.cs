using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.Data;
using Iris.Runtime.Model.DisignSuport;
using System.ComponentModel;
using Iris.Runtime.Model.Entities;
using System.Drawing.Design;
using Iris.PropertyEditors;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Iris.Runtime.Core;
using Iris.Runtime.Core.Expressions;
using System.Data.SqlClient;
using System.Data.Common;

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Transporte de Dados")]
  public class Transport : ResultSetOperation, ITransport
  {
    public Transport(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetOutputs("Saída");
      DetailedLog = true;
      BatchSize = 20000;
      TimeOut = 30;
      UseBulkInsert = false;
    }

    /// <summary>
    /// Variável interna que armazena a correspondência de campos.
    /// O tipo não corresponde ao da propriedade para não quebrar os modelos anteriores
    /// </summary>

    private List<KeyValuePair<string, string>> corresp;

    [Editor(typeof(TransportFieldMapEditor), typeof(UITypeEditor))]
    [DisplayName("Correspondências"), Category("Transporte")]
    public virtual List<KeyValuePair<string, string>> Corresp
    {
      get
      {
        return corresp;
      }
      set
      {
        corresp = value;
      }
    }

    [DisplayName("Mapeamento Automatico"), Category("Transporte")]
    public bool AutoMapping { get; set; }

    private bool clear;
    [DisplayName("Limpar Destino"), Category("Transporte")]
    public bool Clear
    {
      get { return clear; }
      set { clear = value; }
    }

    private bool fillOrig;
    [DisplayName("Carregar Origem"), Category("Transporte")]
    public bool FillOrig
    {
      get { return fillOrig; }
      set { fillOrig = value; }
    }

    private bool fillDest;
    [DisplayName("Carregar Destino"), Category("Transporte")]
    public bool FillDest
    {
      get { return fillDest; }
      set { fillDest = value; }
    }

    private bool detailedLog;
    [DisplayName("Log Detalhado"), Category("Transporte")]
    public bool DetailedLog
    {
      get { return detailedLog; }
      set { detailedLog = value; }
    }

    private bool saveDest;
    [DisplayName("Gravar Destino"), Category("Transporte")]
    public bool SaveDest
    {
      get { return saveDest; }
      set { saveDest = value; }
    }

    private bool keepIdentity;
    [DisplayName("Keep Identity"), Description("Indica se os valores de ID devem ser copiados da origem (true) ou atribuidos pelo destino (false)"), Category("Bulk")]
    public bool KeepIdentity
    {
      get { return keepIdentity; }
      set { keepIdentity = value; }
    }

    private bool useBulkInsert;
    [DisplayName("Bulk Insert"), Description("Faz a carga diretamente para o banco, sem passar pela memória"), Category("Bulk")]
    public bool UseBulkInsert
    {
      get { return useBulkInsert; }
      set { useBulkInsert = value; }
    }

    private int timeOut;
    [Category("Bulk"), DisplayName("Time Out"), Description("Tempo em segundos para o Time-out da operação")]
    public int TimeOut
    {
      get { return timeOut; }
      set { timeOut = value; }
    }

    private int batchSize;
    [DisplayName("Batch Size"), Description("Determina o tamanho dos lotes de dados a serem enviados ao banco por transação, quando a opção Bulk Insert está habilitada"), Category("Bulk")]
    public int BatchSize
    {
      get { return batchSize; }
      set { batchSize = value; }
    }

    protected override IEntity doExecute()
    {
      IOperation opSource = GetInput(0);

      if (opSource == null)
        throw new Exception("Não existe ResultSet de entrada");
      
      if (!(opSource.EntityValue is ResultSet))
        throw new Exception("Objeto de entrada não é um ResultSet");

      IOperation opDest = GetOutput(0);

      if (opDest == null)
        throw new Exception("Não existe ResultSet de saída");

      if (!(opDest.EntityValue is ResultSet))
        throw new Exception("Objeto de saída não é um ResultSet");

      ResultSet source = (ResultSet)opSource.EntityValue;
      ResultSet dest = (ResultSet)opDest.EntityValue;

      if (Clear)
        dest.Clear();

      if (AutoMapping)
      {
        corresp = new List<KeyValuePair<string, string>>();

        Dictionary<string,string> origColumns = source.Table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToDictionary(y=> y.ToLower(), z=> z);
        Dictionary<string, string> destColumns = dest.Table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToDictionary(y => y.ToLower(), z => z);


        foreach (KeyValuePair<string,string> item in origColumns)
        {
          if (destColumns.ContainsKey(item.Key))
          {
            corresp.Add(new KeyValuePair<string, string>(item.Value, destColumns[item.Key]));
          }
        }

      }

      if (Corresp == null)
        throw new Exception("Não foi criada a correspondência dos campos");


      DataRow[] rows;

     

      if ((UseBulkInsert) && (dest.Connection.Connection is SqlConnection))
      {
        SqlBulkCopyOptions options = SqlBulkCopyOptions.Default;
        if (KeepIdentity)
          options = SqlBulkCopyOptions.KeepIdentity;

        SqlBulkCopy bulk = new SqlBulkCopy(dest.Connection.ConnectionString, options);

        bulk.DestinationTableName = dest.GetTableName();
        bulk.BatchSize = BatchSize;
        bulk.NotifyAfter = BatchSize;
        bulk.BulkCopyTimeout = TimeOut;
        bulk.SqlRowsCopied += OnSqlRowsCopied;
        rowsTransfered = 0;
        foreach (KeyValuePair<string, string> item in Corresp)
        {
          bulk.ColumnMappings.Add(item.Key, item.Value);
        }

        IDataReader reader = source.GetDataReader();
        try
        {
          source.Connection.Open();
          dest.Connection.Open();
          bulk.WriteToServer(reader);
        }
        finally
        {
          reader.Close();
          source.Connection.CloseAllClones();
        }


        Structure.AddToLog(String.Format("{0} registros transferidos", rowsTransfered), this);
      }
      else
      {
        if (FillOrig)
          source.Fill();

        if (FillDest)
          dest.Fill();

        if (!string.IsNullOrEmpty(source.View.RowFilter))
          rows = source.Table.Select(source.View.RowFilter);
        else
          rows = source.Table.Select();


        if (Clear)
          dest.Clear();

        dest.Table.BeginLoadData();

        int rowCounter = 0;

        foreach (DataRow row in rows)
        {
          DataRow newRow = dest.Table.NewRow();
          foreach (KeyValuePair<string, string> fm in Corresp)
          {
            object obj = row[fm.Key];
            newRow[fm.Value] = row[fm.Key];
          }
          dest.Table.LoadDataRow(newRow.ItemArray, LoadOption.Upsert);
          rowCounter++;
        }

        dest.Table.EndLoadData();

        if (DetailedLog)
        {
          DataView view = new DataView(dest.Table);
            view.RowStateFilter = DataViewRowState.Added;

          int newRows = view.Count;

          view.RowStateFilter = DataViewRowState.Deleted;

          int deletedRows = view.Count;

          view.RowStateFilter = DataViewRowState.ModifiedCurrent;

          int modifiedRows = view.Count;

          view.Table = null;
          view.Dispose();

          Structure.AddToLog(String.Format("{0} novos registros, {1} registros excluídos e {2} registros alterados.", newRows, deletedRows, modifiedRows), this);
        }

        Structure.AddToLog(String.Format("Total: {0} registros transferidos.", rowCounter), this);

        if (SaveDest)
          dest.Apply(dest.Table.Select());
      }

      return (IEntity)dest;
    }

    [NonSerialized]
    private long rowsTransfered;

    private void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
    {
      rowsTransfered = e.RowsCopied;
    }


    [Browsable(false)]
    public override IEntity EntityValue
    {
      get
      {
        return (IEntity)Saida;
      }
    }

    [Browsable(false)]
    public IResultSet Saida
    {
      get 
      {
        IOperation output = GetOutput(0);
        if (output == null)
          throw new Exception("Resultset de saída não atribuído");
        else
          return (IResultSet)output.EntityValue;
      }
    }
  }
}
