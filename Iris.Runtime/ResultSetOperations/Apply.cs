using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using System.Data;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Expressions;
using System.Drawing;
using Iris.Runtime.Model.Properties;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Save")]
  public class Apply : ResultSetOperation
  {
    public Apply(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
      UseBulkInsert = false;
      BatchSize = 100;
      TimeOut = 30;
    }

    private bool useBulkInsert;
    [DisplayName("Utilizar Bulk Insert"), Description("Habilita inserção em lote para conexões MS SQL Server")]
    public bool UseBulkInsert
    {
      get { return useBulkInsert; }
      set { useBulkInsert = value; }
    }

    private bool keepIdentity;
    [DisplayName("Keep Identity"), Description("Indica se os valores de ID devem ser copiados da origem (true) ou atribuidos pelo destino (false)"), Category("BulkInsert")]
    public bool KeepIdentity
    {
      get { return keepIdentity; }
      set { keepIdentity = value; }
    }

    private int batchSize;
    [DisplayName("Tamanho do Lote"), Description("Tamanho do lote de registros para inserção em lotes")]
    public int BatchSize
    {
      get { return batchSize; }
      set { batchSize = value; }
    }

    private int timeOut;
    [DisplayName("Time Out"), Description("Tempo em segundos para o Time-out da operação")]
    public int TimeOut
    {
      get { return timeOut; }
      set { timeOut = value; }
    }

   

    protected override IEntity doExecute()
    {
      if (GetInput(0) == null)
        throw new Exception("Objeto de entrada não atribuído");

      if (!(GetInput(0).EntityValue is ResultSet))
        throw new Exception("Objeto de entrada não é um ResultSet");

      ResultSet source = (ResultSet)GetInput(0).EntityValue;
      source.UpdateBatchSize = BatchSize;

      if (UseBulkInsert)
      {
        DataRow[] rows = source.Table.Select("", "", DataViewRowState.Added);
        string tableName = source.MainTableName;

        if ((source.Connection != null) && (source.Connection.Connection is SqlConnection))
        {
          SqlConnection connection = source.Connection.Connection as SqlConnection;
          source.Connection.Open();

          SqlBulkCopyOptions options = SqlBulkCopyOptions.Default;
          if (KeepIdentity)
            options = SqlBulkCopyOptions.KeepIdentity;

          SqlBulkCopy bulk = new SqlBulkCopy(source.Connection.ConnectionString, options);

          bulk.DestinationTableName = tableName;
          bulk.BatchSize = BatchSize;
          bulk.BulkCopyTimeout = TimeOut;
          bulk.WriteToServer(rows);
        }

        Structure.AddToLog(String.Format("  {0} registros inseridos", rows.Length), this);

        rows = source.Table.Select("", "", DataViewRowState.Deleted);
        source.Apply(rows);
        Structure.AddToLog(String.Format("  {0} registros excluídos", rows.Length), this);

        rows = source.Table.Select("", "", DataViewRowState.ModifiedCurrent);
        source.Apply(rows);
        Structure.AddToLog(String.Format("  {0} registros atualizados", rows.Length), this);
      }
      else
      {

        int sourceBatchSize = source.UpdateBatchSize;
        int oldTimeOut = source.TimeOut;
        if ((source.TimeOut != this.TimeOut) && (this.TimeOut != 0))
        {
          source.TimeOut = this.TimeOut;
          Structure.AddToLog(string.Format("Quantidade de Registros por Lote do ResultSet {0} alterada para {1}", source.Name, this.BatchSize), this);
          Structure.AddToLog(string.Format("Timeout do ResultSet {0} alterado para {1}", source.Name, this.TimeOut), this);
        }
        try
        {

          if (BatchSize != 0)
            ApplyRows(source);
          else
            source.Apply(source.Table.Select());
        }
        finally
        {
          if (source.TimeOut != oldTimeOut)
          {
            source.UpdateBatchSize = sourceBatchSize;
            source.TimeOut = oldTimeOut;
            Structure.AddToLog(string.Format("Quantidade de Registros por Lote do ResultSet {0} restaurada para {1}", source.Name, sourceBatchSize), this);
            Structure.AddToLog(string.Format("Timeout do ResultSet {0} restaurado para {1}", source.Name, oldTimeOut), this);
          }
        }

      }

      return (IEntity)source;
    }


    private void ApplyRows(ResultSet source)
    {
      List<DataRow> rows = new List<DataRow>();
      rows.AddRange(source.Table.Select("", "", DataViewRowState.Added));
      rows.AddRange(source.Table.Select("", "", DataViewRowState.ModifiedCurrent));
      rows.AddRange(source.Table.Select("", "", DataViewRowState.Deleted));

      
      int localBatch = BatchSize;

      int batchCount = Convert.ToInt32(Math.Ceiling((decimal)rows.Count / batchSize));
      int counter = 1;

      Stopwatch sw = new Stopwatch();
      while (rows.Count > 0)
      {
        sw.Reset();
        sw.Start();

        if (localBatch > rows.Count)
          localBatch = rows.Count;

        List<DataRow> rowBatch = new List<DataRow>();
        for (int i = 0; i < localBatch; i++)
        {
          DataRow row = rows[0];
          rows.RemoveAt(0);

          if (row.RowState != DataRowState.Unchanged)
            rowBatch.Add(row);
          else
            localBatch--;
        }

        source.Apply(rowBatch.ToArray());
        sw.Stop();

        Structure.AddToLog(string.Format("Lote {0} de {1} -- {2} Registros processados -- Tempo: {3}", counter, batchCount, localBatch, sw.Elapsed), this);

        if (counter > batchCount)
        {
          Structure.AddToLog(string.Format("Registros não processados: {0}/{1}", localBatch, rows.Count), this);
          break;
        }
        Application.DoEvents();
        counter++;

        if (Structure.Stop)
        {
          Structure.ExecuteStop();
          break;
        }
      }
    }
  }
}
