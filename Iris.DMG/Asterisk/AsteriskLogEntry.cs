using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Iris.DMG.Asterisk
{
  public class AsteriskLogEntry : IComparable<AsteriskLogEntry>
  {
    public AsteriskLogEntry(string line, int id)
    {
      Line = line;
      line = ExtractEntryTime(line);
      if (!string.IsNullOrEmpty(line))
        line = ExtractLevel(line);
      if (!string.IsNullOrEmpty(line))
        line = ExtractModule(line);

      ProcessCommand(line);
      Id = id;

    }



    private void ProcessCommand(string line)
    {
      line = line.Trim(':', ' ', '-', '=');
      State = true;
      CommandLine = line;
      string commandName = ExtractFeature(ref line, @"^\w+ ").Trim();
      if (commandName == "Executing")
      {
        Command = commandName;
        string pattern = @"^\[\d+\@";
        string value = ExtractFeature(ref line, pattern).Trim('[', '@');
        Number = value;

        Discador = line.Remove(line.IndexOf(']'));
        line = line.Substring(line.IndexOf(' ') + 1);

        CommandLine = line.Replace("in new stack", "");
        Args = CommandLine.Remove(CommandLine.IndexOf('('));

      }
      else if (commandName == "Launched")
      {
        Command = commandName;
        Args = line;
      }
      else if (commandName == "Goto")
      {
        Command = commandName;
        string[] lineParts = line.Trim('(', ')').Split(',');
        if (lineParts[0].Contains("discador"))
        {
          Args = $"{lineParts[0]}:{lineParts[2]}";
        }
        else
        {
          Args = lineParts[0];
        }

        Number = lineParts[1];
        State = false;
      }
      else if (commandName == "Called")
      {
        Command = commandName;
        ArgsName = "Called";
        string[] lineParts = line.Trim('(', ')').Split('/');
        Number = lineParts[2];
        Args = Telefone;
      }
      else if (commandName == "User")
      {
        Command = "User";
        Args = line;
      }
      else if (CommandLine.Contains("is making progress"))
      {
        Command = "Making progress";
        Args = CommandLine.Substring(CommandLine.IndexOf("passing"));
      }
      else if (CommandLine.Contains("answered"))
      {
        Command = "Answered";
        Args = CommandLine.Substring(CommandLine.IndexOf("answered")).Replace("answered", "").Trim();
      }
      else if (CommandLine.Contains("circuit-busy"))
      {
        Command = "Circuit-Busy";
        Args = Command;
      }
      else if (CommandLine.Contains("Fail"))
      {
        Command = "Fail";
        Args = CommandLine;
      }
      else if (CommandLine.Contains("Nobody picked up"))
      {
        Command = "Nobody picked up";
        Args = CommandLine.Replace("Nobody picked up in ", "");
      }
      else if (CommandLine.Contains("Channel will hangup"))
      {
        Command = "Channel will hangup";
        Args = CommandLine.Replace("Channel will hangup at ", "");
      }

      else if (CommandLine.Contains("No such label"))
      {
        Command = "No such label";
        Args = CommandLine.Replace("No such label", "");
      }
      else if (CommandLine.Contains("Got SIP response"))
      {
        Command = "Got SIP response";
        Args = CommandLine.Replace("Got SIP response", "");
      }
      else if (CommandLine.Contains("Spawn"))
      {
        Command = "Spawn extension exited";
        string[] lineParts = line.Split(' ');

        Args = lineParts[5];
      }
      else if (CommandLine.Contains("Everyone") && CommandLine.Contains("congested"))
      {
        Command = "Congestion";
        Args = CommandLine;
      }
      else if (CommandLine.Contains("Accepting"))
      {
        Command = "Accepting";
        Args = line;
      }
      else if (commandName == "")
      {
        if (line.Contains("Playing"))
        {
          string[] lineParts = line.Split(' ');
          Command = lineParts[1];
          CommandLine = line;
          Args = lineParts[2].Trim('\'');
        }
        else if (line.Contains("AMD: Channel"))
        {
          Command = "AMD: Channel";
          Args = line.Substring(line.IndexOf('.') + 1).Trim();
        }
        else if (line.Contains("Script ") && line.Contains("completed"))
        {
          Command = "Script Completed";
          string[] lineParts = line.Split(' ');
          Args = lineParts[2];
          ArgsName = lineParts[3];

        }
        else
        {
          Command = line;
          State = false;
        }
      }
      else
      {
        Command = line;
        State = false;
      }


    }

    private string ExtractModule(string line)
    {
      line = line.Trim();

      string pattern = @"^\w+\.\w+";

      Module = ExtractFeature(ref line, pattern);

      return line;


    }

    private string ExtractLevel(string line)
    {
      Level = "";
      if (line.StartsWith("Asterisk") || (!Time.HasValue))
        return "";
      else
      {

        Level = ExtractFeature(ref line, @"^ \w+").Trim();



        if (!string.IsNullOrEmpty(Level))
        {

          LevelId = ExtractFeature(ref line, @"^\[\d+\]").Trim('[', ']');
          LevelBinaryId = ExtractFeature(ref line, @"^\[C\-\w+\]").Trim('[', ']');


        }

        return line;
      }


    }

    private string ExtractFeature(ref string line, string pattern)
    {

      Regex rx = new Regex(pattern);

      Match match = rx.Match(line);

      if (match.Success)
      {
        string value = match.Value;
        line = line.Substring(value.Length);
        return value;

      }
      else
        return "";

    }

    private string ExtractEntryTime(string line)
    {
      Time = null;

      string pattern = @"^\[\d{4}\-\d{2}-\d{2} \d{2}:\d{2}:\d{2}.\d{3}\]";
      string value = ExtractFeature(ref line, pattern);


      if (!String.IsNullOrEmpty(value))
      {
        string[] valueParts = value.Trim('[', ']', ' ').Split(' ');
        string[] dateParts = valueParts[0].Split('-');
        string[] timeParts = valueParts[1].Split(':', '.');

        DateTime dt = new DateTime(Convert.ToInt32(dateParts[0]), Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[2]),
          Convert.ToInt32(timeParts[0]), Convert.ToInt32(timeParts[1]), Convert.ToInt32(timeParts[2]), Convert.ToInt32(timeParts[3]));

        Time = dt;
      }
      return line;

    }

    public static DataTable GetTable(IEnumerable<AsteriskLogEntry> entries)
    {
      DataTable table = new DataTable("LogEntries");
      table.Columns.Add("State", typeof(bool));
      table.Columns.Add("Line", typeof(string));
      table.Columns.Add("Discador", typeof(string));
      table.Columns.Add("Telefone", typeof(string));
      table.Columns.Add("Number", typeof(string));
      table.Columns.Add("ArgsName", typeof(string));
      table.Columns.Add("Args", typeof(string));
      table.Columns.Add("CommandLine", typeof(string));
      table.Columns.Add("Command", typeof(string));
      table.Columns.Add("Module", typeof(string));
      table.Columns.Add("LevelBinaryId", typeof(string));
      table.Columns.Add("LevelId", typeof(string));
      table.Columns.Add("MessageLevel", typeof(string));
      table.Columns.Add("Id", typeof(int));
      table.Columns.Add("CmdId", typeof(int));
      table.Columns.Add("LogTime", typeof(DateTime));

      table.PrimaryKey = new DataColumn[] { table.Columns["LevelBinaryId"], table.Columns["CmdId"], };

      Dictionary<string, int> identificator = new Dictionary<string, int>();

      List<AsteriskLogEntry> list = entries.ToList();
      list.Sort();

      int lastId = 0;
      string lastType = "";
      table.BeginLoadData();
      for (int i = 0; i < list.Count; i++)
      {
        AsteriskLogEntry item = list[i];

        DataRow row = table.NewRow();

        if (string.IsNullOrEmpty(item.LevelBinaryId))
        {
          if (!lastType.StartsWith("System"))
            lastId++;

          item.LevelBinaryId = $"System{lastId}";

          lastType = item.LevelBinaryId;

        }




        string lbi = Convert.ToString(item.LevelBinaryId);
        int itemId = 0;

        if (identificator.ContainsKey(lbi))
          itemId = identificator[lbi] + 1;


        identificator[lbi] = itemId;


        row["State"] = item.State;
        row["Line"] = item.Line;
        row["Discador"] = item.Discador;
        row["Telefone"] = item.Telefone;
        row["Number"] = item.Number;
        row["ArgsName"] = item.ArgsName;
        row["Args"] = item.Args;
        row["CommandLine"] = item.CommandLine;
        row["Command"] = item.Command;
        row["Module"] = item.Module;
        row["LevelBinaryId"] = item.LevelBinaryId;
        row["LevelId"] = item.LevelId;
        row["MessageLevel"] = item.Level;
        row["Id"] = item.Id;
        row["CmdId"] = itemId;
        if (item.Time.HasValue)
          row["LogTime"] = item.Time;
        table.LoadDataRow(row.ItemArray, LoadOption.Upsert);
      }

      table.EndLoadData();

      return table;
    }

    public int CompareTo(AsteriskLogEntry other)
    {
      return Id.CompareTo(other.Id);
    }

    public override string ToString()
    {
      return CommandLine;
    }
    public DateTime? Time { get; set; }
    public int Id { get; set; }

    public string Level { get; set; }
    public string LevelId { get; set; }
    public string LevelBinaryId { get; set; }
    public string Module { get; set; }
    public string Command { get; set; }
    public string CommandLine { get; set; }
    public string Args { get; set; }
    public string ArgsName { get; set; }

    private string number;
    public string Number
    {
      get
      {
        return number;
      }
      set
      {
        number = value;

        if (number.Contains("55") && (number.Length > 12) && (number.IndexOf("55") < 6))
        {
          string tel = number.Substring(number.IndexOf("55") + 2);
          Telefone = $"({tel[0]}{tel[1]}){tel.Substring(2)}";
        }
        else if ((number.Length == 11) || (number.Length == 12))
        {
          string tel = number.TrimStart('0');
          Telefone = $"({tel[0]}{tel[1]}){tel.Substring(2)}";
        }
      }
    }

    public string Telefone { get; set; }
    public string Discador { get; set; }
    public string Line { get; set; }
    public bool State { get; set; }
  }
}
