using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using Iris.Runtime.Model.DisignSuport;
using Databridge.Engine;
using Databridge.Engine.Parsers;
using Iris.Runtime.Model.Operations.FileSystemOperations;
using Iris.Interfaces;
using System.Reflection;

namespace Iris.Runtime.FileSystemOperations
{
  [Serializable]
  [OperationCategory("Operações de Arquivo", "Caminho de Inicialização")]
  public class StartupPath : BaseFileSystemOperation
  {
    public StartupPath(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs(new string[] { });
      SetOutputs("Path");
    }

    protected override IEntity doExecute()
    {
      string codeBase = Assembly.GetExecutingAssembly().CodeBase;
      UriBuilder uri = new UriBuilder(codeBase);
      string path = Uri.UnescapeDataString(uri.Path);
      SetValue("Path", Path.GetDirectoryName(path));
      return null;
    }
  }
}
