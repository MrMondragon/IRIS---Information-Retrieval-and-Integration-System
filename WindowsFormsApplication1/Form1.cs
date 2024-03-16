using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Iris.Runtime.Model.BaseObjects;
using System.IO;
using Iris.Runtime.Model.ClientObjects;
using Iris.Interfaces;

namespace Iris.PropertyEditors.PropertyEditors.Dialogs
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      IIrisRunnable dynStructure = null;

      try
      {

        string configFile = Path.ChangeExtension(Application.ExecutablePath, ".cfg");
        if (File.Exists(configFile))
        {
          using (StreamReader sr = new StreamReader(configFile, Encoding.Default))
          {
            string line = "";
            while (!string.IsNullOrEmpty((line = sr.ReadLine())))
            {
              if (line.Contains('='))
              {
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

        string logFile = Path.ChangeExtension(Application.ExecutablePath, "");
        DateTime dt = DateTime.Now;

        logFile = string.Format("{0}-{1}-{2}-{3} {4}-{5}.log", logFile, dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute);

        using (StreamWriter sw = new StreamWriter(logFile, false, Encoding.Default))
        {
          sw.WriteLine("LOG:");

          List<ILogItem> log = dynStructure.Structure.Log.GetEntries();
          foreach (ILogItem item in log)
          {
            sw.WriteLine(item.Text);
          }
        }


      }
      catch (Exception ex)
      {
        string logFile = Path.ChangeExtension(Application.ExecutablePath, "");
        DateTime dt = DateTime.Now;

        logFile = string.Format("Erro - {0}-{1}-{2}-{3} {4}-{5}.log", logFile, dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute);

        using (StreamWriter sw = new StreamWriter(logFile, false, Encoding.Default))
        {
          sw.WriteLine("Falha na execução do processo {0}.", dynStructure.Structure.ClassName);
          sw.WriteLine("Mensagem original:");
          sw.WriteLine("    - {0}", ex.Message);

          Exception inner = ex.InnerException;

          while (inner != null)
          {
            sw.WriteLine("    - {0}", inner.Message);
            inner = inner.InnerException;
          }

          sw.WriteLine("STACK TRACE:");
          string[] stack = ex.StackTrace.Split('\r');

          foreach (string stackItem in stack)
          {
            sw.WriteLine("         -" + stackItem.Trim());
          }

          sw.WriteLine("LOG:");

          List<ILogItem> log = dynStructure.Structure.Log.GetEntries();
          foreach (ILogItem item in log)
          {
            sw.WriteLine(item.Text);
          }


        }
      }

    }
  }
}
