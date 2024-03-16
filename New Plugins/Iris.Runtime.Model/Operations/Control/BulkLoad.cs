using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using System.Data.SqlClient;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Model.DisignSuport;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  [OperationCategory("Operações de Controle", "Bulk Load")]
  public class BulkLoad : ControlOperation
  {
    public BulkLoad(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
    }

    private DynConnection connection;

    public DynConnection Connection
    {
      get { return connection; }
      set { connection = value; }
    }

    private string destinationTable;

    public string DestinationTable
    {
      get { return destinationTable; }
      set { destinationTable = value; }
    }

    private int batchSize;

    public int BatchSize
    {
      get { return batchSize; }
      set { batchSize = value; }
    }

    private int timeout;

    public int Timeout
    {
      get { return timeout; }
      set { timeout = value; }
    }

    protected override IEntity doExecute()
    {
      SqlBulkCopy bulk = new SqlBulkCopy((SqlConnection)Connection.Connection);
      bulk.DestinationTableName = DestinationTable;
      bulk.BatchSize = BatchSize;
      bulk.BulkCopyTimeout = Timeout;
      ResultSet rs = (ResultSet) Inputs[0].EntityValue;
      bulk.WriteToServer(rs.Table.Select());
      return null;
    }
  }
}
