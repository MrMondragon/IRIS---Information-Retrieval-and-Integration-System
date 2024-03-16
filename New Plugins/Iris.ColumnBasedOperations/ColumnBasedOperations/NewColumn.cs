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

  /// <summary>
  /// Classe interna utilizada para representar as
  /// propriedades das colunas que serão criaras
  /// </summary>
  [Serializable]
  public class Coluna : Iris.Runtime.Model.Operations.ColumnBasedOperations.IColuna
  {
    public Coluna()
    {
      DataType = typeof(String);
      AllowDBNull = true;
      MaxLength = -1;
      AutoIncrementStep = 1;
    }

    public override string ToString()
    {
      return Caption;
    }

    public DataColumn CreateColumn()
    {
      DataColumn column = new DataColumn(ColumnName, DataType);
      column.AllowDBNull = AllowDBNull;
      column.AutoIncrement = AutoIncrement;
      column.AutoIncrementSeed = AutoIncrementSeed;
      column.AutoIncrementStep = AutoIncrementStep;
      column.Caption = Caption;
      if(DataType == typeof(DateTime))
        column.DateTimeMode = DateTimeMode;
      column.DefaultValue = DefaultValue;
      column.MaxLength = MaxLength;
      column.Unique = Unique;
      return column;
    }


    private bool allowDBNull;
    [DefaultValue(true)]
    public bool AllowDBNull { get { return allowDBNull; } set { allowDBNull = value; } }

    private bool autoIncrement;
    [DefaultValue(false)]
    [RefreshProperties(RefreshProperties.All)]
    public bool AutoIncrement
    {
      get { return autoIncrement; }
      set { autoIncrement = value; }
    }

    
    private long autoIncrementSeed;
    [DefaultValue(0)]
    public long AutoIncrementSeed
    {
      get { return autoIncrementSeed; }
      set { autoIncrementSeed = value; }
    }
    
    public long autoIncrementStep;
    [DefaultValue(1)]
    public long AutoIncrementStep
    {
      get { return autoIncrementStep; }
      set { autoIncrementStep = value; }
    }

    private string caption;

    public string Caption
    {
      get 
      { 
        if(string.IsNullOrEmpty(caption))
          return ColumnName;
        else
          return caption; 
      }
      set { caption = value; }
    }

    private string columnName;
    [DefaultValue("")]
    [RefreshProperties(RefreshProperties.All)]
    public string ColumnName
    {
      get { return columnName; }
      set { columnName = value; }
    }

    
    private Type dataType;
    [RefreshProperties(RefreshProperties.All)]
    [Editor(typeof(TypeSelectorEditor), typeof(UITypeEditor))]
    public Type DataType
    {
      get { return dataType; }
      set { dataType = value; }
    }

    private DataSetDateTime dateTimeMode;
    [RefreshProperties(RefreshProperties.All)]
    public DataSetDateTime DateTimeMode
    {
      get { return dateTimeMode; }
      set { dateTimeMode = value; }
    }

    private object defaultValue;
    [Editor(typeof(ColunaDefValueEditor), typeof(UITypeEditor))]
    public object DefaultValue
    {
      get { return defaultValue; }
      set { defaultValue = value; }
    }

    private int maxLength;
    [DefaultValue(-1)]
    public int MaxLength
    {
      get { return maxLength; }
      set { maxLength = value; }
    }

    private bool unique;
    [DefaultValue(false)]
    public bool Unique
    {
      get { return unique; }
      set { unique = value; }
    }
  }
}
