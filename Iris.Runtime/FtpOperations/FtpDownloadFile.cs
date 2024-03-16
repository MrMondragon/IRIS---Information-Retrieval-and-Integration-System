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
        string[] files = Client.GetFileList(Dir, Mask);
        if (files != null)
        {
          for (int i = 0; i < files.Length; i++)
          {
            if (!string.IsNullOrEmpty(files[i].Trim()))
            {
              string filename = files[i];
              string localDir = Dir;
              if (!string.IsNullOrEmpty(localDir))
                localDir += "/";
              filename = Path.Combine(Destino ,filename);
              Client.Download(localDir+files[i], filename);
              Structure.AddToLog(String.Format("Arquivos {0} baixado", filename), this);
              ct++;
            }
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
