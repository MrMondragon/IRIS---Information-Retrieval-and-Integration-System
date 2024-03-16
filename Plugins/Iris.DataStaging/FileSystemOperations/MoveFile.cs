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
  [OperationCategory("Operações de Arquivo", "Move Arquivo")]
  public class MoveFile : BaseMaskedFileOperation
  {
    public MoveFile(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Origem", "Destino");
      
    }

    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Origem"), Category("Arquivo"), Description("Local onde se encontram os arquivos a serem movidos")]
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
    [DisplayName("Destino"), Category("Destino"), Description("Local para onde os arquivos serão movidos")]
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

    protected override Iris.Interfaces.IEntity doExecute()
    {
      string[] fileNames = Directory.GetFiles(Filename1, Mask);
      int ct = 0;
      try
      {
        for (int i = 0; i < fileNames.Length; i++)
        {
          string fileName = fileNames[i].Substring(fileNames[i].LastIndexOf('\\'));
          fileName = Filename2 + fileName;


           
          ct++;
        }
      }
      finally
      {
        Structure.AddToLog(String.Format("{0} Arquivos movidos", ct), this);
      }
      return null;
    }
  }
}
