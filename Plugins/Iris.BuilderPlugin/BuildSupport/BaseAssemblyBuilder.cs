using System;
using System.Collections.Generic;
using System.Text;
using Iris.Designer.PluginSupport;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Iris.Runtime.Model.BaseObjects;
using System.IO;

namespace Iris.Designer.BuildSupport
{
  public abstract class BaseAssemblyBuilder : BaseToolbarPlugin
  {
    public BaseAssemblyBuilder()
    {
      this.saveDllDialog = new System.Windows.Forms.SaveFileDialog();
      this.saveDllDialog.Title = "Compilação";
    }

    private SaveFileDialog saveDllDialog;

    internal string BuildAssembly(BuildType type)
    {
      Structure.DisableConnections();
      try
      {

        Structure.ClearDataset();
        //Structure.EnableConnections();

        string typeStr = "";
        string outputPath;


        switch (type)
        {
          case BuildType.Assembly:
            saveDllDialog.Filter = "Assemblies|*.dll";
            saveDllDialog.DefaultExt = "dll";
            typeStr = "Assembly";
            break;
          case BuildType.Executable:
            saveDllDialog.Filter = "Executáveis|*.exe";
            saveDllDialog.DefaultExt = "exe";
            typeStr = "Executável";
            break;
          case BuildType.WebService:
            saveDllDialog.Filter = "WebServices|*.asmx";
            saveDllDialog.DefaultExt = "asmx";
            typeStr = "Web Service";
            break;
          case BuildType.Plugin:
            saveDllDialog.Filter = "Assemblies|*.dll";
            saveDllDialog.DefaultExt = "dll";
            typeStr = "Plugin";
            break;
          default:
            break;
        }

        saveDllDialog.Title = "Compilação de " + typeStr;

        saveDllDialog.FileName = Path.ChangeExtension(this.Designer.FileName, saveDllDialog.DefaultExt);

        if (string.IsNullOrEmpty(saveDllDialog.FileName))
          saveDllDialog.FileName = Structure.ClassName;
        if (saveDllDialog.ShowDialog() == DialogResult.OK)
          outputPath = saveDllDialog.FileName;
        else
          return "";


        CompilerResults results = null;
        switch (type)
        {
          case BuildType.Assembly:
            results = StructureBuilder.CompileAssembly(outputPath, (Structure)Structure);
            break;
          case BuildType.Executable:
            results = StructureBuilder.CompileExecutable(outputPath, (Structure)Structure);
            break;
          case BuildType.WebService:
            results = StructureBuilder.CompileWebService(outputPath, (Structure)Structure);
            break;
          case BuildType.Plugin:
            results = StructureBuilder.CompilePlugin(outputPath, (Structure)Structure);
            break;
        }

        Designer.ClearLog();
        if (results.Errors.HasErrors)
        {
          for (int i = 0; i < results.Errors.Count; i++)
          {
            Designer.AddToErrorLog(Convert.ToString(results.Errors[i]), null);
          }
        }
        else
        {
          for (int i = 0; i < results.Output.Count; i++)
          {
            Designer.AddToLog(results.Output[i], null);
          }
          Designer.AddToLog(typeStr + " compilado em:" + outputPath, null);
          return outputPath;
        }
        return "";
      }
      finally
      {
        Structure.EnableConnections();
      }
    }

  }
}
