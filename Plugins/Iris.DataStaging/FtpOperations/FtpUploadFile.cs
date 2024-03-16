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
  [OperationCategory("Operações de FTP", "Upload de Arquivos")]
  public class FtpUploadFiles : BaseTwoFolderedFtpOperation
  {
    public FtpUploadFiles(Structure aStructure, string aName)
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

    protected override Iris.Interfaces.IEntity doExecute()
    {
      int ct = 0; 
      try
      {
        Client.ChangeDir(Destino);
        string[] files = Directory.GetFiles(Dir, Mask);
        for (int i = 0; i < files.Length; i++)
        {
          Client.Upload(files[i]);
          ct++;         
        }
      }
      finally
      {
        Structure.AddToLog(String.Format("{0} Arquivos enviados", ct), this);
        base.doExecute();
      }
      return null;
    }
  }
}
