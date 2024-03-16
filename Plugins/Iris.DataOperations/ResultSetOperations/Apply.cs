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

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Apply")]
  public class Apply : ResultSetOperation
  {
    public Apply(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
      UseBulkInsert = true;
      BatchSize = 20000;
      TimeOut = 30;
    }

    private bool useBulkInsert;
    [Category("BulkInsert"), DisplayName("Utilizar Bulk Insert"), Description("Habilita inserção em lote para conexões MS SQL Server")]
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
    [Category("BulkInsert"), DisplayName("Tamanho do Lote"), Description("Tamanho do lote de registros para inserção em lotes")]
    public int BatchSize
    {
      get { return batchSize; }
      set { batchSize = value; }
    }

    private int timeOut;
    [Category("BulkInsert"), DisplayName("Time Out"), Description("Tempo em segundos para o Time-out da operação")]
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
           

      if (UseBulkInsert)
      {
        DataRow[] rows = source.Table.Select("", "", DataViewRowState.Added);
        string tableName = source.MainTableName;

        if((source.Connection != null) && (source.Connection.Connection is SqlConnection))
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
        Structure.AddToLog(String.Format("  {0} registros excluídos", rows.Length), this);
      }
      else
      {
        source.Apply(source.Table.Select());
      }

      return (IEntity)source;
    }
  }
}
