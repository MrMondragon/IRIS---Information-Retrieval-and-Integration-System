using Iris.DMG.Asterisk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskTestProject.Asterisk
{
  public class AsteriskCall
  {
    public AsteriskCall(IEnumerable<AsteriskLogEntry> entries)
    {
      Entries = entries;
      
      Phone = entries.Where(x => !String.IsNullOrEmpty(x.Telefone)).FirstOrDefault().Telefone;
      StartTime = entries.Where(x => x.Time.HasValue).Select(y => y.Time.Value).Min();
      Duration = Convert.ToInt32((entries.Where(x => x.Time.HasValue).Select(y => y.Time.Value).Max() - StartTime).TotalSeconds);

      int maxStateId = entries.Where(x => x.State).Select(y => y.Id).Max();

      LastState = entries.Where(x => x.Id == maxStateId).Select(y => y.CommandLine).First();
      BinaryID = entries.First().LevelBinaryId;

      Id = entries.Select(x => x.LevelId).First();

    }

    public static DataTable GetTable(IEnumerable<AsteriskCall> calls)
    {
      DataTable table = new DataTable("Calls");
      table.Columns.Add("Id", typeof(string));
      table.Columns.Add("BinaryID", typeof(string));
      table.Columns.Add("LastState", typeof(string));
      table.Columns.Add("StartTime", typeof(DateTime));
      table.Columns.Add("Duration", typeof(int));
      table.Columns.Add("Phone", typeof(string));
      table.PrimaryKey = new DataColumn[] { table.Columns["Id"] };
      table.BeginLoadData();

      foreach (AsteriskCall call in calls)
      {
        DataRow row = table.NewRow();

        row["Id"] = call.Id;
        row["BinaryID"] = call.BinaryID;
        row["LastState"] = call.LastState;
        row["StartTime"] = call.StartTime;
        row["Duration"] = call.Duration;
        row["Phone"] = call.Phone;

        table.LoadDataRow(row.ItemArray, LoadOption.Upsert);
      }
      table.EndLoadData();

      return table;
    }

    public IEnumerable<AsteriskLogEntry> Entries { get; set; }

    public string Id { get; set; }
    public String BinaryID { get; set; }
    public String LastState { get; set; }
    public DateTime StartTime { get; set; }
    public String Phone { get; set; }
    public int Duration { get; set; }
  }
}
