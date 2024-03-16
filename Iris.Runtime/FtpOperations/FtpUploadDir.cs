using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.IO;

namespace Iris.Runtime.Model.Operations.FtpOperations
{
  [Serializable]
  [OperationCategory("Operações de FTP", "Upload de Diretório")]
  public class FtpUploadDir : BaseTwoFolderedFtpOperation
  {
    public FtpUploadDir(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    public override string Dir
    {
      get
      {
        return base.Dir;
      }
      set
      {
        base.Dir = value;
      }
    }

    private bool recursive;

    public bool Recursive
    {
      get { return recursive; }
      set { recursive = value; }
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      try
      {
        //Client.ChangeDir(Destino);
        //Client.UploadDirectory(Dir, recursive, Mask);
      }
      finally
      {
        base.doExecute();
      }
      return null;
    }
  }
}
