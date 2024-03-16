using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Iris.DMG.Asterisk;
using System.Data;

namespace AsteriskTestProject.Asterisk
{
  public class AsteriskLoader
  {
    public AsteriskLoader(string path)
    {
      string[] files = Directory.GetFiles(path);

      Dictionary<int, string> logFiles = new Dictionary<int, string>();
      foreach (string file in files)
      {
        string ext = Path.GetExtension(file).Trim('.');
        int value = 0;
        if (Int32.TryParse(ext, out value))
        {
          logFiles[value] = file;
        }
      }
      Entries = new List<AsteriskLogEntry>();

      int max = logFiles.Keys.Max();
      int min = logFiles.Keys.Min();

      while (max > min)
      {
        if (logFiles.ContainsKey(max))
          LoadFile(logFiles[max]);
        max--;
      }

      //Calls = new List<AsteriskCall>();
      //IEnumerable<string> ids = Entries.Where(x => !string.IsNullOrWhiteSpace(x.LevelBinaryId)).Select(y => y.LevelBinaryId).Distinct();
      //foreach (string id in ids)
      //{
      //  IEnumerable<AsteriskLogEntry> callEntries = Entries.Where(x => x.LevelBinaryId == id);
      //  if (callEntries.Where(x => !String.IsNullOrEmpty(x.Telefone)).Count() != 0)
      //    Calls.Add(new AsteriskCall(callEntries));
      //}




    }

    public DataTable GetEntryTable()
    {
      return AsteriskLogEntry.GetTable(Entries);
    }

    private void LoadFile(string fileName)
    {
      using (StreamReader sr = new StreamReader(fileName))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          Entries.Add(new AsteriskLogEntry(line, Entries.Count + 1));
        }
      }
    }

    public List<AsteriskLogEntry> Entries { get; set; }
    public List<AsteriskCall> Calls { get; set; }
  }
}
