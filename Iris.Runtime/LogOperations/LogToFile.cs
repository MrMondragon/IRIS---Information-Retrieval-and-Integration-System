using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.ClientObjects;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace Iris.Runtime.LogOperations
{
  [Serializable]
  [OperationCategory("Operações de Log", "Log to File")]
  public class LogToFile : Operation
  {
    public LogToFile(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Folder");
    }

    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Folder"), Category("Arquivo"), Description("Caminho para gravação do arquivo")]
    public string FolderName { get; set; }
 

    protected override Interfaces.IEntity doExecute()
    {
      IProccessLog log = Structure.Log;
      List<ILogItem> entries = log.GetEntries();

      string folderName = Convert.ToString(GetValue("Folder"));
      if (string.IsNullOrEmpty(folderName))
        folderName = FolderName;
      
      DateTime dt = DateTime.Now;

      string prefix = Structure.ClassName;

      if (prefix == "DynStructure")
        prefix = "Integração";

      if (log.HasErrors())
        prefix = "ERRO - " + prefix;

      string fileName = string.Format("{0} - {1}-{2}-{3} {4}-{5}.log", prefix,
        dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute);

      fileName = Path.Combine(folderName, fileName);

      using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default))
      {
        foreach (LogItem item in entries)
        {
          try
          {
            sw.WriteLine(item.Text);
          }
          catch(Exception ex)
          {
            sw.WriteLine(ex.Message);
          }
        }
      }

      return null;
    }
  }
}
