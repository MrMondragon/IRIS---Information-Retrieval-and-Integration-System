using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.Data;
using System.ComponentModel;

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Reject Table")]
  public class RejectTable : ResultSetOperation
  {
    public RejectTable(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      RejectAll = true;
    }

    private bool rejectAll;
    [DisplayName("Rejeitar tudo"), Category("Reject Table")]
    public bool RejectAll
    {
      get { return rejectAll; }
      set
      {
        rejectAll = value;
        rejectDelete = true;
        rejectInsert = true;
        rejectUpdate = true;
      }
    }

    private bool rejectInsert;
    [DisplayName("Rejeitar inserções"), Category("Reject Table")]
    public bool RejectInsert
    {
      get { return rejectInsert; }
      set
      {
        rejectInsert = value;
        CheckRejectAll();
      }
    }

    private bool rejectDelete;
    [DisplayName("Rejeitar exclusões"), Category("Reject Table")]
    public bool RejectDelete
    {
      get { return rejectDelete; }
      set
      {
        rejectDelete = value;
        CheckRejectAll();
      }
    }

    private bool rejectUpdate;
    [DisplayName("Rejeitar atualizações"), Category("Reject Table")]
    public bool RejectUpdate
    {
      get { return rejectUpdate; }
      set
      {
        rejectUpdate = value;
        CheckRejectAll();
      }
    }

    private void CheckRejectAll()
    {
      if (RejectDelete && RejectInsert && RejectUpdate)
        RejectAll = true;
      else
        rejectAll = false;
    }


    protected override IEntity doExecute()
    {
      if (Entrada.Table != null)
      {
        DataTable table = Entrada.Table;
        if (RejectAll)
          table.RejectChanges();
        else
        {
          int ctInsert = 0;
          int ctDelete = 0;
          int ctUpdate = 0;

          for (int i = 0; i < table.Rows.Count; i++)
          {
            DataRow row = table.Rows[i];
            if (RejectDelete && (row.RowState == DataRowState.Deleted))
            {
              row.RejectChanges();
              ctDelete++;
            }
            if (RejectUpdate && (row.RowState == DataRowState.Modified))
            {
              row.RejectChanges();
              ctUpdate++;
            }
            if (RejectInsert && (row.RowState == DataRowState.Added))
            {
              row.RejectChanges();
              ctInsert++;
            }
          }

          Structure.AddToLog(String.Format("{0} Inserts rejeitados, {1} Updates rejeitados e {2} Deletes rejeitados", ctInsert, ctUpdate, ctDelete), this);
        }

      }
      return (IEntity)Entrada;
    }
  }
}
