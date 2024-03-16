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

namespace Iris.DataOperations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Aggregate")]
  public class Aggregate : RelationBasedOperation
  {

    public Aggregate(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Detalhe");
    }

    [Browsable(true)]
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

    private AggregateType function;
    [DisplayName("Função"), Category("Expressão"), Description("Função de agregação")]
    public AggregateType Function
    {
      get { return function; }
      set { function = value; }
    }

    private string aggregateColumn;
    [Editor(typeof(LookupColumnSelectorEditor), typeof(UITypeEditor))]
    [DisplayName("Coluna"), Category("Expressão"), Description("Função de agregação")]
    public string AggregateColumn
    {
      get { return aggregateColumn; }
      set { aggregateColumn = value; }
    }

    //invertidos porque a direção da relação é diferente nesta operação

    public override IResultSet Entrada
    {
      get
      {
        return base.MasterRS;
      }
    }

    public override IResultSet MasterRS
    {
      get
      {
        return base.Entrada;
      }
    }

    protected override IEntity doExecute()
    {
      DataTable table = MasterRS.Table;
      if ((dColumn == null) || (!table.Columns.Contains(ColumnName)))
      {
        if (string.IsNullOrEmpty(ColumnName))
          throw new Exception("A propriedade Coluna Resultante não foi atribuída");

        DataTable detail = Entrada.Table;
        DataTable master = MasterRS.Table;

        string rName = RefreshRelation(master, detail);

        string expression = string.Format("{0}(Child({1}).{2})", Convert.ToString(Function), rName, AggregateColumn);

        if (table.Columns.Contains(ColumnName))
        {
          dColumn = table.Columns[ColumnName];
          dColumn.Expression = expression;
        }
        else
        {
          dColumn = new DataColumn(ColumnName, typeof(String), expression);
          table.Columns.Add(dColumn);
        }
      }

      return (IEntity)Entrada;
    }
    public override void Reset()
    {
      if(dColumn != null)
        dColumn.Expression = "";
      base.Reset();      
    }
  }
}
