using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Databridge.Licence;
using System.Windows.Forms;
using Iris.Runtime.Model.BaseObjects;
using System.IO;


namespace Iris.Designer.Loader
{
  internal static class LicensedPluginLoader
  {
    internal static List<string> GetLicensedPlugins(Structure structure)
    {
      Manager manager = new Manager();
       List<string> list = manager.LoadRegisteredPlugins();

       List<string> plugins = new List<string>();
       foreach (string item in list)
       {
         if (!string.IsNullOrEmpty(item))
         {
           string[] lineparts = item.Split('|');
           string fileName = Path.Combine(Application.StartupPath, lineparts[1]);
           if (lineparts[0] == "p")
             plugins.Add(fileName);
           else
           {
             structure.Assemblies[lineparts[1]] = fileName;
           }
         }
       }

       return plugins;
    }
  }
}
