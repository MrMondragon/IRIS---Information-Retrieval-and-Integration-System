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
    public virtual IResultSet Entrada
    {
      get
      {
        if (GetInput("Entrada") != null)
        {
          IResultSet input = GetInput("Entrada").EntityValue as IResultSet;
          return input;
        }
        else
          return null;
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


    //Propriedades de mapeamento para melhorar a legibilidade do codigo das classes derivadas mantendo 
    //compatibilidade retroativa com todos os projetos ja criados
    [Browsable(false)]
    public String ColunaBase
    {
      get
      {
        return Column;
      }
      set
      {
        Column = ColunaBase;
      }
    }

    [Browsable(false)]
    public String ColunaResultante
    {
      get
      {
        return ColumnName;
      }
      set
      {
        ColumnName = ColunaResultante;
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
