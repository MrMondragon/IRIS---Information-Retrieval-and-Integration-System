using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using Iris.Interfaces;
using System.Drawing.Design;
using Iris.Runtime.Model.PropertyEditors;
using System.Data;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  public abstract class ColumnBasedOperation : Operation, Iris.Runtime.Model.Operations.ColumnBasedOperations.IColumnBasedOperation
  {
    public ColumnBasedOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IResultSet Entrada
    {
      get
      {
        Operation input = GetInput("Entrada") as Operation;

        if (input == null)
          throw new Exception("Resultset de entrada não atribuído");
        else if (input is IResultSet)
          return (IResultSet)input;
        else
          return (IResultSet)input.EntityValue;
      }
    }

    [Browsable(false)]
    public override IEntity EntityValue
    {
      get
      {
        if (GetInput("Entrada") != null)
          return doExecute();
        else
          return null;
      }
    }

    private String column;
    [Editor(typeof(CBOColumnSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Coluna Base"), Category("Expressão")]
    public virtual String Column
    {
      get { return column; }
      set
      {
        if (column != value)
        {
          column = value;
        }
      }
    }

    private String columnName;
    [DisplayName("Coluna Resultante"), Category("Expressão"), Description("Nome da coluna que será criada a partir da operação")]
    public virtual String ColumnName
    {
      get { return columnName; }
      set
      {
        if (columnName != value)
        {
          if ((!String.IsNullOrEmpty(columnName)) && (Entrada != null) && (Entrada.Table.Columns.Contains(columnName)))
            Entrada.Table.Columns.Remove(columnName);

          columnName = value;
        }
      }
    }

    public override string Name
    {
      get
      {
        return base.Name;
      }
      set
      {
        if (GetInput("Entrada") != null)
        {
          DataTable table = Entrada.Table;
          foreach (DataColumn col in table.Columns)
          {
            if (col.ExtendedProperties.ContainsKey("Operation") && col.ExtendedProperties["Operation"].ToString() == base.Name)
              col.ExtendedProperties["Operation"] = value;
          }

        }
        base.Name = value;
      }
    }

    [NonSerialized]
    protected DataColumn dColumn;

    public override void Reset()
    {
      base.Reset();
      dColumn = null;
    }

  }
}
