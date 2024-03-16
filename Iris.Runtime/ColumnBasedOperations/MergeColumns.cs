using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.PropertyEditors.PropertyEditors;
using System.Data;
using Iris.Runtime.Model.Entities;
namespace Iris.Runtime.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "MergeColumns")]
  public class MergeColumns : ColumnBasedOperation
  {
    public MergeColumns(Structure aStructure, string aName) : base(aStructure, aName)
    {
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

    [Category("Expression"), Description("Lista de colunas separadas por ; em ordem de prioridade da esquerda pra direita")]
    public string ColumnList { get; set; }

    protected override IEntity doExecute()
    {
      ResultSet entrada = (ResultSet)Entrada;
      if (entrada == null)
        throw new Exception("Resultset de entrada não atribuído");

      if (string.IsNullOrWhiteSpace(ColunaResultante))
        throw new Exception("Coluna resultante não atribuída");
      if (string.IsNullOrWhiteSpace(ColumnList))
        throw new Exception("Lista não atribuída");

      String[] colList = ColumnList.Split(';');

      if (!entrada.Table.Columns.Contains(ColunaResultante))
        entrada.Table.Columns.Add(ColunaResultante, entrada.Table.Columns[colList[0]].DataType);

      DataView view = entrada.View;

      foreach (DataRowView row in view)
      {
        for (int i = 0; i < colList.Length; i++)
        {
          row[ColunaResultante] = row[colList[i]];
          string value = Convert.ToString(row[ColunaResultante]);

          if (!string.IsNullOrWhiteSpace(value))
            break;
        }
      }


      return null;
    }
  }
}
