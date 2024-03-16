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
  [OperationCategory("Operações de Colunas", "Coluna GUID")]
  public class GUIDColumn : ColumnBasedOperation
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
    public string CaracteresMascara { get; set; }
    public bool AcceptChanges { get; set; }

    protected override IEntity doExecute()
    {
      ResultSet rs = (ResultSet)Entrada;
      DataTable table = rs.Table;
      DataColumn column;
      DataColumn colunaBase = table.Columns[Column];

      if (table.Columns.Contains(ColumnName))
        column = table.Columns[ColumnName];
      else
      {
        column = new DataColumn(ColumnName);
        table.Columns.Add(column);
      }

      int idx = table.Columns.IndexOf(column);

      char[] caracteres = CaracteresMascara.ToCharArray();

      foreach (DataRow row in table.Rows)
      {
        if (!Convert.IsDBNull(row[colunaBase]))
        {
          row.BeginEdit();

          string valor = Convert.ToString(row[colunaBase]);

          foreach (char item in caracteres)
          {
            valor = valor.Replace(item.ToString(), "");
          }

          row[column] = valor;

          row.EndEdit();
        }
      }
      if (AcceptChanges)
        table.AcceptChanges();
      return null;
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
