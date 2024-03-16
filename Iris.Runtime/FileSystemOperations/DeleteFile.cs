using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.FileSystemOperations
{
  [Serializable]
  [OperationCategory("Operações de Arquivo", "Deleta Arquivo")]
  public class DeleteFile : BaseMaskedFileOperation
  {
    public DeleteFile(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Folder");
    }

    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Folder"), Category("Arquivo"), Description("Local onde se encontram os arquivos a serem deletados")]
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

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
      for (int i = 0; i < fileNames.Length; i++)
      {
        File.Delete(fileNames[i]);
      }
      Structure.AddToLog(String.Format("{0} Arquivos excluídos", fileNames.Length), this);

      return null;
    }
  }
}
