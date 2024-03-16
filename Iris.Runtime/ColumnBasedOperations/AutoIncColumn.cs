using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using System.Data;
using System.ComponentModel;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Coluna de Auto-Incremento")]
  public class AutoIncColumn : ColumnBasedOperation
  {
    public AutoIncColumn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Val. Inic");
      
      initialValue = 1;
    }

    private long initialValue;
    [DisplayName("Valor Inicial"), Category("Expressão")]
    public long InitialValue
    {
      get
      {
        IOperation oper = GetInput(1);
        if ((oper == null)||(Convert.IsDBNull(oper.EntityValue.Value)))
          return initialValue;
        else
          return Convert.ToInt64(oper.EntityValue.Value);
      }
      set { initialValue = value; }
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
      ResultSet rs = (ResultSet)Entrada;
      DataTable table = rs.Table;
      DataColumn column;

      if (table.Columns.Contains(ColumnName))
        column = table.Columns[ColumnName];
      else
      {
        column = new DataColumn(ColumnName, typeof(Int64));
        table.Columns.Add(column);
      }


      int idx = table.Columns.IndexOf(column);
      Int64 autoInc = 0;
      foreach (DataRow row in table.Rows)
      {
        row.BeginEdit();
        row[idx] = InitialValue + autoInc;
        autoInc++;
        row.EndEdit();
      }


      return (IEntity)Entrada;
    }

 
  }



}
