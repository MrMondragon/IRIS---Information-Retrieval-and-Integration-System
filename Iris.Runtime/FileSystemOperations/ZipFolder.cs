using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.FileSystemOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Databridge.Engine.Extensions;

namespace Iris.Runtime.FileSystemOperations
{
  [Serializable]
  [OperationCategory("Operações de Arquivo", "Zip Folder")]
  public class ZipFolder : BaseFileSystemOperation
  {
    public ZipFolder(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Path");
    }

    protected override IEntity doExecute()
    {
      string path = Convert.ToString(GetValue("Path"));
      string outpath = path.TrimEnd('\\') + ".zip";

      ZipFile.CreateFromDirectory(path, outpath);
      Structure.AddToLog($"Arquivo {outpath} criado com sucesso", this);
      return null;
    }
  }
}

