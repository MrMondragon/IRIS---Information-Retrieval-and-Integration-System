using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Iris.Runtime.ResultSetOperations;
using System.Drawing.Design;
using Iris.PropertyEditors.PropertyEditors;

namespace Iris.Runtime.Model.Operations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Deduplicate Table")]
  public class DeduplicateTable: ResultSetOperation, IColumnSetOperation
  {
    public DeduplicateTable(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      columnset = new List<string>();
    }

    private List<string> columnset;
    [Editor(typeof(ColumnSetEditor), typeof(UITypeEditor))]
    public List<DataColumn> Columnset
    {
      get 
      {
        IOperation input = GetInput("Entrada");

        if ((input == null)|| (Entrada == null) || (Entrada.Table == null))
        {
          List<DataColumn> cols = new List<DataColumn>();
          for (int i = 0; i < columnset.Count; i++)
          {
            cols.Add(new DataColumn(columnset[i]));
          }
          return cols;
        }
        else
        {
          List<DataColumn> cols = new List<DataColumn>();
          for (int i = 0; i < columnset.Count; i++)
          {
            if (Entrada.Table.Columns.Contains(columnset[i]))
              cols.Add(Entrada.Table.Columns[columnset[i]]);
            else
              cols.Add(new DataColumn(columnset[i]));

          }
          return cols;
        }
      }
      set
      {
        columnset = value.Select(x => x.ColumnName).ToList();
      }
    }

    protected override IEntity doExecute()
    {
      DataColumn[] colSet = Columnset.ToArray();
      DataTable auxTable = Table.Clone();
      auxTable.TableName = Table.TableName;
      List<string> unique = new List<string>();
      int count = Table.Rows.Count; 
      auxTable.BeginLoadData();
      for (int i = Table.Rows.Count-1; i >=0; i--)
      {
        string key = GetRowKey(Table.Rows[i], colSet);
       
        if (!unique.Contains(key))
        {
          auxTable.LoadDataRow(Table.Rows[i].ItemArray, LoadOption.Upsert);
          unique.Add(key);
        }

      }
      auxTable.EndLoadData();
      Entrada.Table = auxTable;
      int uniqueRows = auxTable.Rows.Count;

      Structure.AddToLog(String.Format("Quantidade original = {0}; Quantidade de únicos = {1}; Removidos: {2}", count,
        uniqueRows, count - uniqueRows), this);

      return null;
    }

    private string GetRowKey(DataRow row, DataColumn[] colSet)
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < colSet.Length; i++)
      {
        if (Convert.IsDBNull(row[colSet[i]]))
          sb.Append("null|");
        else
          sb.Append(Convert.ToString(row[colSet[i].ColumnName]) + "|");
      }

      return sb.ToString();
    }

    #region IColumnSetOperation Members


    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataTable Table
    {
      get 
      {
        if ((Entrada == null) || (Entrada.Table == null))
          return null;
        else
          return Entrada.Table;
      }
    }

    #endregion
  }
}
