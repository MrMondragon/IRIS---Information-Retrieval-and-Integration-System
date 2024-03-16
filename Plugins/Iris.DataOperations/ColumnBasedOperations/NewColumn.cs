using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.ComponentModel;
using System.Data;
using Iris.PropertyEditors;
using System.Drawing.Design;
using Iris.Runtime.Model.PropertyEditors;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Operações de Colunas", "Criar Colunas")]
  public class NewColumn : ColumnBasedOperation
  {
    public NewColumn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      columns = new List<Coluna>();
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

    private List<Coluna> columns;
    [DisplayName("Colunas"), Category("Colunas"), Description("Lista de Colunas que serão incluídas no resultset de entrada")]
    public List<Coluna> Columns
    {
      get 
      {
        return columns; 
      }
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
      DataTable table = Entrada.Table;

      List<DataColumn> colsToRemove = new List<DataColumn>();

      foreach (DataColumn coluna in table.Columns)
      {
        if(coluna.ExtendedProperties.ContainsKey("Operation") && Convert.ToString(coluna.ExtendedProperties["Operation"]) == this.Name)
        {
          if (!ColumnExists(coluna.Caption))
            colsToRemove.Add(coluna);
        }
      }

      foreach (DataColumn col in colsToRemove)
      {
        table.Columns.Remove(col);
      }

      foreach (Coluna coluna in Columns)
      {
        if (!table.Columns.Contains(coluna.ColumnName))
        {
          dColumn = coluna.CreateColumn();
          dColumn.ExtendedProperties["Operation"] = this.Name;
          table.Columns.Add(dColumn);
        }
        else
        {
          if (!String.IsNullOrEmpty(coluna.Expression))
          {
            table.Columns[coluna.ColumnName].Expression = coluna.Expression;
          }
        }
      }

      return (IEntity)Entrada; 
    }

    private bool ColumnExists(string colCaption)
    {
      foreach (Coluna col in Columns)
      {
        if (col.Caption == colCaption)
          return true;
      }

      return false;
    }
  }

 
}
