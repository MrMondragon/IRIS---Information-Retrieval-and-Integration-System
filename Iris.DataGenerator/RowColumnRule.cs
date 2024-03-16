using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.Operations;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using System.Data;
using Iris.Runtime.Model.DisignSuport;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.PropertyEditors.PropertyEditors;

namespace Iris.DataGenerator
{
  [Serializable]
  [OperationCategory("Geradores de Dados", "RowColumn Rule")]
  public class RowColumnRule : BaseValueRule, Iris.DataGenerator.IRowColumnRule
  {
    public RowColumnRule(Structure structure, string name)
      : base(structure, name)
    {
      SetInputs("Entrada", "RowNum");
    }


    private String columnName;
    [DisplayName("Coluna"), Category("Rule"), Description("Nome da coluna que será utilizada pela regra")]
    [Editor(typeof(RCRColumnSelector), typeof(UITypeEditor))]
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

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual IResultSet Entrada
    {
      get
      {
        ResultSet input = GetInput("Entrada").EntityValue as ResultSet;


        return input;


      }
    }

    /*
     Retorna o valor de um campo determinado em um registro específico de uma tabela
     */

    protected override Iris.Interfaces.IEntity doExecute()
    {
      int idx = Convert.ToInt32(GetValue("RowNum"));
      DataTable table = Entrada.Table;

      this.value = table.Rows[idx][columnName];

      return FieldValue;
    }
  }
}
