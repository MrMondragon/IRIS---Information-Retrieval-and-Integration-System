using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Data;
using Iris.Runtime.Model.Operations.Control;
using Iris.Runtime.Core.Connections;
using Iris.PropertyEditors;
using System.Drawing.Design;
using Iris.Runtime.Model.Operations.ResultSetOperations;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces.Interfaces;
using Iris.PropertyEditors.PropertyEditors;

namespace Iris.Runtime.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Copy Table")]
  public class CopyTable : ResultSetOperation, ICopyTable
  {
    public CopyTable(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
      SetOutputs("Saída");
    }

    public string Filter { get; set; }

    [Editor(typeof(CopyTableColumnListEditor), typeof(UITypeEditor))]
    [DisplayName("Colunas Entrada"), Category("Expressão"), Description("Colunas da tabela Entrada a serem incluídas no RS gerado")]
    public List<string> ColunasEntrada { get; set; }

    protected override IEntity doExecute()
    {
      ResultSet source = GetInput(0) as ResultSet;

      if (source == null)
        throw new Exception("Não existe ResultSet de entrada");

      ResultSet dest = GetOutput(0) as ResultSet; ;

      if (dest == null)
        throw new Exception("Não existe ResultSet de saída");


      if (dest.Table != null)
        dest.Table.Clear();

      dest.InMemory = true;
      DataTable destTable = new DataTable(source.Table.TableName);
      if (ColunasEntrada == null)
      {
        try
        {
          destTable = source.Table.Clone();
        }
        catch
        {
          for (int i = 0; i < source.Table.Columns.Count; i++)
          {
            DataColumn col = source.Table.Columns[i];
            destTable.Columns.Add(col.ColumnName, col.DataType);
          }
        }
      }
      else
      {
        foreach (string colName in ColunasEntrada)
        {
          DataColumn col = source.Table.Columns[colName];
          destTable.Columns.Add(col.ColumnName, col.DataType);
        }
      }

      destTable.TableName = dest.Name;
      dest.Table = destTable;

      if (string.IsNullOrEmpty(Filter))
        Filter = source.Filter;
      dest.Table.BeginLoadData();

      DataView tmp = new DataView(source.Table, Filter, source.Sort, DataViewRowState.CurrentRows);

      for (int i = 0; i < tmp.Count; i++)
      {
        DataRow newRow = dest.Table.NewRow();
        DataRow row = tmp[i].Row;

        foreach (DataColumn col in dest.Table.Columns)
        {
          newRow[col] = row[col.ColumnName];
        }
        dest.Table.LoadDataRow(newRow.ItemArray, false);
      }



      dest.Table.EndLoadData();
      return null;

    }

  }
}
