using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Iris.DMG.Asterisk
{
  public class AsteriskLogEntry: IComparable<AsteriskLogEntry>
  {
    public AsteriskLogEntry(string line, int id)
    {
      line = ExtractEntryTime(line);
      if (!string.IsNullOrEmpty(line))
        line = ExtractLevel(line);
      if (!string.IsNullOrEmpty(line))
        line = ExtractModule(line);

      ProcessCommand(line);

    }

    private void ProcessCommand(string line)
    {
      line = line.Trim(':', ' ', '-', '=');
      string commandName = ExtractFeature(ref line, @"^\w+ ").Trim();
      if (commandName == "Executing")
      {
        Command = commandName;
        string pattern = @"^\[\d+\@";
        string value = ExtractFeature(ref line, pattern).Trim('[', '@');
        Number = value;

        Discador = line.Remove(line.IndexOf(']'));
        line = line.Substring(line.IndexOf(' ') + 1);

        Opper = line.Replace("in new stack", "");
        OpperName = Opper.Remove(Opper.IndexOf('('));

      }
      else if(commandName == "Launched")
      {
        Command = commandName;
        Opper = line;
      }
      else if (commandName == "Goto")
      {
        Command = commandName;
        string[] lineParts = line.Trim('(', ')').Split(',');
        if (lineParts[0].Contains("discador"))
        {
          Discador = $"{lineParts[0]}:{lineParts[2]}";
        }
        else
        {
          OpperName = lineParts[0];
        }

        Number = lineParts[1];

      }
      else if (commandName == "Called")
      {
        Command = commandName;
        Opper = line;
        string[] lineParts = line.Trim('(', ')').Split('/');
        Number = lineParts[2];


      }
      else if (commandName == "")
      {
        if (line.Contains("Playing"))
        {
          string[] lineParts = line.Split(' ');
          Command = lineParts[1];
          Opper = line;
          OpperName = lineParts[2].Trim('\'');

        }
        else
          Command = line;
      }
      else
      {
        Command = line;
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

    public int CompareTo(AsteriskLogEntry other)
    {
      return Id.CompareTo(other.Id);
    }

    public DateTime? Time { get; set; }
    public int Id { get; set; }

    public string Level { get; set; }
    public string LevelId { get; set; }
    public string LevelBinaryId { get; set; }
    public string Module { get; set; }
    public string Command { get; set; }
    public string Opper { get; set; }
    public string OpperName { get; set; }
    public string Number { get; set; }
    public string Discador { get; set; }
  }
}
