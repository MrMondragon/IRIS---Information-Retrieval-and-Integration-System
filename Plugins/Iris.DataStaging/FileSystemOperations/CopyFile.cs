using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.IO;

namespace Iris.Runtime.Model.Operations.FileSystemOperations
{
  [Serializable]
  [OperationCategory("Operações de Arquivo", "Copia Arquivo")]
  public class CopyFile : BaseMaskedFileOperation
  {
    public CopyFile(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Origem", "Destino");
      overwrite = true;
      
    }

    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Origem"), Category("Arquivo"), Description("Local onde se encontram os arquivos a serem copiados")]
    public override string Filename1
    {
      get
      {
        return base.Filename1;
      }
      set
      {
        base.Filename1 = value;
      }
    }

    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Destino"), Category("Destino"), Description("Local para onde os arquivos serão copiados")]
    public override string Filename2
    {
      get
      {
        return base.Filename2;
      }
      set
      {
        base.Filename2 = value;
      }
    }

    private bool overwrite;

    public bool Overwrite
    {
      get { return overwrite; }
      set { overwrite = value; }
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      string[] fileNames = Directory.GetFiles(Filename1, Mask);
      for (int i = 0; i < fileNames.Length; i++)
      {
        string fileName = fileNames[i].Substring(fileNames[i].LastIndexOf('\\'));
        fileName = Filename2 + fileName;
        File.Copy(fileNames[i], fileName, overwrite);
      }
      Structure.AddToLog(String.Format("{0} Arquivos copiados", fileNames.Length), this);
      return null;
    }
  }
}
