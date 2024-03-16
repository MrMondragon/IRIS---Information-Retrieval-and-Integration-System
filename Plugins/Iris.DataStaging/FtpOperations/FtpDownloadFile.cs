using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace Iris.Runtime.Model.Operations.FtpOperations
{
  [Serializable]
  [OperationCategory("Operações de FTP", "Download de Arquivos")]
  public class FtpDownloadFiles : BaseTwoFolderedFtpOperation
  {
    public FtpDownloadFiles(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    public override string Destino
    {
      get
      {
        return base.Destino;
      }
      set
      {
        base.Destino = value;
      }
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      int ct = 0;
      try
      {
        Client.ChangeDir(Dir);
        string[] files = Client.GetFileList(Mask);
        for (int i = 0; i < files.Length; i++)
        {
          if (!string.IsNullOrEmpty(files[i].Trim()))
          {
            string filename = files[i];
            filename = Destino +"\\"+ filename;
            Client.Download(files[i], filename);
            ct++;
          }
        }       
      }
      finally
      {
        Structure.AddToLog(String.Format("{0} Arquivos baixados", ct), this);
        base.doExecute();
      }
      return null;
    }
  }
}
