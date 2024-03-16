using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Entities;
using Iris.PropertyEditors;
using Iris.Interfaces;
using System.Drawing.Design;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.PropertyEditors;
using System.Data;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de Colunas", "Lookup")]
  public class Lookup : RelationBasedOperation, Iris.Runtime.Model.Operations.ColumnBasedOperations.ILookup
  {

    public Lookup(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada", "Lookup");
    }


    protected override IEntity doExecute()
    {
      DataTable lookupTable = MasterRS.Table;
      DataTable table = Entrada.Table;

      string rName = RefreshRelation(lookupTable, table);

      List<DataColumn> colsToRemove = new List<DataColumn>();

      foreach (DataColumn col in table.Columns)
      {
        if (col.ExtendedProperties.ContainsKey("Operation") && col.ExtendedProperties["Operation"].ToString() == this.Name)
        {
          string fieldName = col.ColumnName.Substring(4);
          if (!LookupFields.Contains(fieldName))
            colsToRemove.Add(col);
        }
      }

      foreach (DataColumn col in colsToRemove)
      {
        table.Columns.Remove(col.ColumnName);
      }

      //Cria campos e expressões
      foreach (string fieldName in LookupFields)
      {
        string expression = "Parent(" + rName + ")." + fieldName;
        string colName = "lkp_" + fieldName;
        DataColumn col;
        if (!table.Columns.Contains(colName))
        {
          col = new DataColumn("lkp_" + fieldName, lookupTable.Columns[fieldName].DataType, expression);
          table.Columns.Add(col);
        }
        else
        {
          col = table.Columns[colName];
          col.Expression = expression;
        }
        col.ExtendedProperties["Operation"] = this.Name;
      }
      return (IEntity)Entrada;
    }   
 

    private List<string> lookupFields;
    [Editor(typeof(LookupFieldsEditor), typeof(UITypeEditor))]
    [DisplayName("Lookup Fields"), Category("Expressão")]
    public List<string> LookupFields
    {
      get { return lookupFields; }
      set
      {
        if (lookupFields != value)
        {
          lookupFields = value;
        }
      }
    }



  }
}
