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
  [OperationCategory("Operações de Arquivo", "Deleta Diretório")]
  public class DeleteDir : BaseFileSystemOperation
  {
    public DeleteDir(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Folder");
    }

    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Folder"), Category("Arquivo"), Description("O caminho do diretório a ser deletado")]
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
      if (Directory.Exists(Filename1))
      {
        Directory.Delete(Filename1, true);
        Structure.AddToLog("Diretório excluído: " + Filename1, this);
      }
      else
        Structure.AddToLog("Diretório não existe. Operação ignorada: " + Filename1, this);

      return null;
    }
  }
}
