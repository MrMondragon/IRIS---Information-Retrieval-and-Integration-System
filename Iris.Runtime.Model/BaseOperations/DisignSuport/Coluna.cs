using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.PropertyEditors;
using System.Drawing.Design;
using System.Data;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  /// <summary>
  /// Classe interna utilizada para representar as
  /// propriedades das colunas que serão criaras
  /// </summary>
  [Serializable]
  public class Coluna : IColuna
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
      if (DataType == typeof(DateTime))
        column.DateTimeMode = DateTimeMode;
      column.DefaultValue = DefaultValue;
      column.MaxLength = MaxLength;
      column.Unique = Unique;
      column.Expression = Expression;
      return column;
    }

    private string expression;

    public string Expression
    {
      get { return expression; }
      set { expression = value; }
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
        if (string.IsNullOrEmpty(caption))
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
