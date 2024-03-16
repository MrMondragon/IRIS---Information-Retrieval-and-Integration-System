using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.ComponentModel;
using Iris.Runtime.Model.PropertyEditors;
using System.Drawing.Design;
using System.Data;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Copia Coluna")]
  public class CopyColumn : ColumnBasedOperation
  {
    public CopyColumn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    [Browsable(false)]
    public override string ColumnName
    {
      get
      {
        return base.ColumnName;
      }
      set
      {
        base.ColumnName = value;
      }
    }

    private bool fullCommit;
    [DisplayName("Edição completa"), Category("Coluna"), Description("Ativar edição completa deixa o registro pronto para ser enviado ao banco, mas consome muito mais tempo.")]
    public bool FullCommit
    {
      get { return fullCommit; }
      set { fullCommit = value; }
    }


    private String destColumn;
    [Editor(typeof(CBOColumnSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Coluna Desitno"), Category("Expressão")]
    public String DestColumn
    {
      get { return destColumn; }
      set
      {
        if (destColumn != value)
        {
          destColumn = value;
          Reset();
        }
      }
    }

    [Browsable(false)]
    public override IEntity EntityValue
    {
      get
      {
        if (GetInput(0) != null)
          return (IEntity)Entrada;
        else
          return null;        
      }
    }

    protected override IEntity doExecute()
    {
      if (!Entrada.Table.Columns.Contains(DestColumn))
      {
        Entrada.Table.Columns.Add(DestColumn, Entrada.Table.Columns[Column].DataType);
      }

      int destIdx = Entrada.Table.Columns.IndexOf(DestColumn);
      int sourceIdx = Entrada.Table.Columns.IndexOf(Column);

      foreach (DataRow row in Entrada.Table.Rows)
      {
        row.BeginEdit();
        row[destIdx] = row[sourceIdx];
        if (fullCommit)
          row.EndEdit();
      }

      return (IEntity)Entrada;
    }
  }
}
