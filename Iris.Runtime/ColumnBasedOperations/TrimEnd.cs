using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.Data;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Iris.Interfaces;
using System.ComponentModel;

namespace Iris.DataOperations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Trim End")]
  public class TrimEnd : ColumnBasedOperation
  {
    public TrimEnd(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }


    private int len;
    [DisplayName("Tamanho"), Category("Sub-String"), Description("Tamanho máximo da nova coluna.")]
    public int Len
    {
      get { return len; }
      set
      {
        if (len != value)
        {
          len = value;
          Reset();
        }
      }
    }

    private bool fullCommit;
    [DisplayName("Edição completa"), Category("Coluna"), Description("Ativar edição completa deixa o registro pronto para ser enviado ao banco, mas consome muito mais tempo.")]
    public bool FullCommit
    {
      get { return fullCommit; }
      set { fullCommit = value; }
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      DataTable table = Entrada.Table;

      if (string.IsNullOrEmpty(ColumnName))
        throw new Exception("A propriedade Coluna Resultante não foi atribuída");

      if (Column == null)
        throw new Exception("A Coluna Base não foi atribuída");

      if (Len == 0)
        throw new Exception("A Quantidade de caracteres não pode ser 0");


      if (table.Columns.Contains(ColumnName))
      {
        dColumn = table.Columns[ColumnName];
      }
      else
      {
        dColumn = new DataColumn(ColumnName, typeof(String));
        table.Columns.Add(dColumn);
      }

      for (int i = 0; i < table.Rows.Count; i++)
      {
        DataRow row = table.Rows[i];
        if (!Convert.IsDBNull(row[Column]))
        {
          row.BeginEdit();
          string value = Convert.ToString(row[Column]);
          if (value.Length > Len)
            row[dColumn] = value.Remove(Len);    
          else
            row[dColumn] = value;
          if (fullCommit)
            row.EndEdit();
        }
      }



      return (IEntity)Entrada;
    }
  }
}
