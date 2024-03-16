using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Interfaces;
using System.IO;
using System.Windows.Forms;
using Iris.Runtime.Model.ClientObjects;
using System.Reflection;

namespace Iris.Runtime.Model.BaseObjects
{
  public abstract class BaseExecutableStructure
  {

    public abstract IIrisRunnable GetStructure();

    private void Initialize()
    {
      this.dynStructure = GetStructure();
      ((Structure)dynStructure.Structure).IsHandlingException = false;
      string runningPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      string pluginPath = Path.Combine(runningPath, "Plugins");

      List<string> asmKeys = dynStructure.Structure.Assemblies.Select(x => x.Key).ToList();
      for (int i = 0; i < asmKeys.Count; i++)
      {
        if (!dynStructure.Structure.Assemblies[asmKeys[i]].ToLower().Contains("microsoft.net"))
        {
          dynStructure.Structure.Assemblies[asmKeys[i]] = Path.Combine(runningPath, asmKeys[i]);
        }
      }

      ExecLogFileName = GetLogFileName(false);
      ExecLogFileName = ExecLogFileName.Replace(".log", "_EXEC.log");
      ProccessLog pl = new ProccessLog();
      this.dynStructure.Structure.Log = pl;
      pl.OnAddItem += OnLogItem;

      string configFile = Path.ChangeExtension(Application.ExecutablePath, ".cfg");

      if (File.Exists(configFile))
      {
        using (StreamReader sr = new StreamReader(configFile, Encoding.Default))
        {
          string line = "";
          while ((line = sr.ReadLine()) != null)
          {
            if ((line.Contains("=")) && (!line.StartsWith("!")))
            {
              line = line.Trim('"');
              int idx = line.IndexOf('=');
              if (idx > 0)
              {
                string key = line.Remove(idx);
                string value = line.Substring(idx + 1);

                dynStructure.Structure[key] = value;
              }
            }
          }
        }
      }

      string[] args = Environment.GetCommandLineArgs();

      foreach (string arg in args)
      {
        int idx = arg.IndexOf('=');
        if (idx > 0)
        {
          string key = arg.Remove(idx);
          string value = arg.Substring(idx + 1);

          dynStructure.Structure[key] = value;
        }
      }

    }

    public void Execute()
    {
      try
      {
        Initialize();
        dynStructure.Execute();
        LogSuccess();
      }
      catch (Exception ex)
      {
        LogException(ex);
      }

    }

    private void OnLogItem(object sender, LogEventArgs e)
    {
      using (StreamWriter sw = new StreamWriter(ExecLogFileName, true, Encoding.Default))
      {
        sw.WriteLine(e.Entry.ToString());
      }
    }

    private string ExecLogFileName;

    private IIrisRunnable dynStructure;

    private void LogException(Exception ex)
    {
      List<string> logLines = new List<string>();

      logLines.Add("Falha na execução da integração " + dynStructure.Structure.ClassName);
      logLines.Add("Mensagem original: ");

      while (ex != null)
      {
        logLines.Add("   " + ex.Message+";");
        ex = ex.InnerException;
      }
      Exception inner = ex.InnerException;
      while (inner != null)
      {
        logLines.Add("      - " + inner.Message);
        inner = inner.InnerException;
      }
      logLines.Add("");
      logLines.Add("");
      logLines.Add("Stack:");

      List<string> stack = ex.StackTrace.Split('\r').Select(x => x.Trim()).ToList();
      logLines.AddRange(stack);

      logLines.Add("");
      logLines.Add("");

      if ((dynStructure != null) && (dynStructure.Structure.Log != null))
      {
        IProccessLog log = dynStructure.Structure.Log;
        List<ILogItem> entries = log.GetEntries();
        List<string> strLines = entries.Select(x => x.Text).ToList();
        logLines.Add("Log de execução:");
        logLines.AddRange(strLines);
      }

      SaveLog(logLines, true);
    }

    private void LogSuccess()
    {
      IProccessLog log = dynStructure.Structure.Log;
      List<ILogItem> entries = log.GetEntries();

      List<string> logLines = entries.Select(x => x.Text).ToList();
      SaveLog(logLines, false);
    }

    private void SaveLog(List<string> logLines, bool error)
    {
      string fileName = GetLogFileName(error);

      using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default))
      {
        foreach (string item in logLines)
        {
          sw.WriteLine(item);
        }
      }

      if (File.Exists(ExecLogFileName))
        File.Delete(ExecLogFileName);
    }

    private string GetLogFileName(bool error)
    {
      string folderName = Application.StartupPath;
      folderName = Path.Combine(folderName, "Log");
      if (!Directory.Exists(folderName))
        Directory.CreateDirectory(folderName);


      DateTime dt = DateTime.Now;

      string prefix = Path.GetFileNameWithoutExtension(Application.ExecutablePath);

      if (dynStructure != null)
      {
        if (((dynStructure != null) && (dynStructure.Structure != null) &&
          (dynStructure.Structure.Log != null) && (dynStructure.Structure.Log.HasErrors())) || error)
          prefix = "ERRO - " + prefix;
      }

      string fileName = string.Format("{0} - {1}-{2}-{3} {4}-{5}.log", prefix,
        dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute);

      fileName = Path.Combine(folderName, fileName);
      return fileName;
    }
  }
}
