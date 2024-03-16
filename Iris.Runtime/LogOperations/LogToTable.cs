using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.ClientObjects;
using System.ComponentModel;
using System.Data;

namespace Iris.Runtime.LogOperations
{
  [Serializable]
  [OperationCategory("Operações de Log", "Log to Table")]
  public class LogToTable: Operation
  {
    public LogToTable(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetOutputs("Saída");
    }

    [Browsable(false)]
    public IResultSet Saida
    {
      get
      {
        IOperation input = GetOutput("Saída");
        if (input == null)
          throw new Exception("Resultset de saída não atribuído");
        else
          return (IResultSet)input.EntityValue;
      }
    }

    public bool SingleDataRow { get; set; }

    protected override Interfaces.IEntity doExecute()
    {
      IProccessLog log = Structure.Log;
      List<ILogItem> entries = log.GetEntries();

      if (Saida.Table != null)
      {
        Structure.Dataset.Tables.Remove(Saida.Table);
        Saida.Table.Clear();
        Saida.Table.Dispose();
        Saida.Table = null;
      }

      DataTable table = new DataTable(Saida.Name);
      table.Columns.Add("Time", typeof(DateTime));
      table.Columns.Add("Entry", typeof(string));
      table.Columns.Add("Error", typeof(bool));
      Structure.Dataset.Tables.Add(table);

      table.BeginLoadData();

      if (!SingleDataRow)
      {
        for (int i = 0; i < entries.Count; i++)
        {
          table.LoadDataRow(entries[i].GetItemArray(), false);
        }
      }
      else
      {
        table.Columns.Add("ProcessName", typeof(string));

        DataRow dr = table.NewRow();
        dr["Time"] = entries[0].Time;
        dr["ProcessName"] = Structure.ClassName;

        bool error = false;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < entries.Count; i++)
        {
          error |= (bool)entries[i].Error;
          sb.AppendLine(entries[i].Text);
        }

        dr["Entry"] = sb.ToString();

        table.LoadDataRow(dr.ItemArray,LoadOption.OverwriteChanges);
      }

      table.EndLoadData();

      Saida.Table = table;

      return (IEntity) Saida;
    }
  }
}
