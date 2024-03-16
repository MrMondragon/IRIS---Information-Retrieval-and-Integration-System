using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Core.Connections;
using Iris.Runtime.Model.DisignSuport;
using Iris.Interfaces;
using Oracle.DataAccess.Client;

namespace Iris.Runtime.Model.Operations.Control
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Oracle Bulk Load")]
  public class OracleBulk : ControlOperation
  {
    public OracleBulk(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
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
      ResultSet rs = (ResultSet)GetInput(0).EntityValue;
      string tableName = rs.MainTableName;
      rs.Connection.Open();
      OracleBulkCopy bulk = new OracleBulkCopy((OracleConnection)rs.Connection.Connection);
      bulk.DestinationTableName = tableName;
      bulk.BatchSize = BatchSize;
      bulk.BulkCopyTimeout = Timeout;
      bulk.WriteToServer(rs.Table.Select());
      return null;
    }
  }
}
