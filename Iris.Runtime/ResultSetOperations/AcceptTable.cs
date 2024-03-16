using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Data;

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Accept Table")]
  public class AcceptTable : ResultSetOperation
  {
    public AcceptTable(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      AcceptAll = true;
    }

    private bool acceptAll;
    [DisplayName("Aceitar tudo"), Category("Accept Table")]
    public bool AcceptAll
    {
      get { return acceptAll; }
      set
      {
        acceptAll = value;
        acceptDelete = true;
        acceptInsert = true;
        acceptUpdate = true;
      }
    }

    private bool acceptInsert;
    [DisplayName("Aceitar inserções"), Category("Accept Table")]
    public bool AcceptInsert
    {
      get { return acceptInsert; }
      set
      {
        acceptInsert = value;
        CheckAcceptAll();
      }
    }

    private bool acceptDelete;
    [DisplayName("Aceitar exclusões"), Category("Accept Table")]
    public bool AcceptDelete
    {
      get { return acceptDelete; }
      set
      {
        acceptDelete = value;
        CheckAcceptAll();
      }
    }

    private bool acceptUpdate;
    [DisplayName("Aceitar atualizações"), Category("Accept Table")]
    public bool AcceptUpdate
    {
      get { return acceptUpdate; }
      set
      {
        acceptUpdate = value;
        CheckAcceptAll();
      }
    }

    private void CheckAcceptAll()
    {
      if (AcceptDelete && AcceptInsert && AcceptUpdate)
        AcceptAll = true;
      else
        acceptAll = false;
    }


    protected override IEntity doExecute()
    {
      if (Entrada.Table != null)
      {
        DataTable table = Entrada.Table;

        foreach (DataRow row in table.Rows)
        {
          row.EndEdit();
        }

        if (AcceptAll)
        {
          table.AcceptChanges();
        }
        else
        {
          int ctInsert = 0;
          int ctDelete = 0;
          int ctUpdate = 0;

          for (int i = 0; i < table.Rows.Count; i++)
          {
            DataRow row = table.Rows[i];         

            if (AcceptDelete && (row.RowState == DataRowState.Deleted))
            {
              row.AcceptChanges();
              ctDelete++;
            }
            if (AcceptUpdate && (row.RowState == DataRowState.Modified))
            {
              row.AcceptChanges();
              ctUpdate++;
            }
            if (AcceptInsert && (row.RowState == DataRowState.Added))
            {
              row.AcceptChanges();
              ctInsert++;
            }

          }

          Structure.AddToLog(String.Format("{0} Inserts aceitos, {1} Updates aceitos e {2} Deletes aceitos", ctInsert, ctUpdate, ctDelete), this);
        }

      }
      return (IEntity)Entrada;
    }
  }
}
