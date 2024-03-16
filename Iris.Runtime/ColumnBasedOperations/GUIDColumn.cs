using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using System.Data;
using System.ComponentModel;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Coluna GUID")]
  public class GUIDColumn: ColumnBasedOperation
  {
    public GUIDColumn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
    }

    [Browsable(false)]
    public override string Column
    {
      get
      {
        return base.Column;
      }
      set
      {
        base.Column = value;
      }
    }

    protected override IEntity doExecute()
    {
      ResultSet rs = (ResultSet)Entrada;
      DataTable table = rs.Table;
      DataColumn column;

      if (table.Columns.Contains(ColumnName))
        column = table.Columns[ColumnName];
      else
      {
        column = new DataColumn(ColumnName, typeof(Guid));
        table.Columns.Add(column);
      }

      int idx = table.Columns.IndexOf(column);
      foreach (DataRow row in table.Rows)
      {
        row.BeginEdit();
        row[idx] = Guid.NewGuid();
        if (FullCommit)
          row.EndEdit();
      }
      return (IEntity)Entrada;
    }

    private bool fullCommit;
    [DisplayName("Edição completa"), Category("Coluna"), Description("Ativar edição completa deixa o registro pronto para ser enviado ao banco, mas consome muito mais tempo.")]
    public bool FullCommit
    {
      get { return fullCommit; }
      set { fullCommit = value; }
    }

  }
}
