using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.IO;
using System.Diagnostics;

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
        string fileDir = Dir;
        string localMask = Mask;

        if(string.IsNullOrEmpty(fileDir))
        {
          fileDir = Path.GetDirectoryName(Mask);
          localMask = Path.GetFileName(Mask);
        }


        string[] files = Directory.GetFiles(fileDir, localMask);
        for (int i = 0; i < files.Length; i++)
        {
          Stopwatch sw = new Stopwatch();
          sw.Start();
          string localDir = Destino;
          if (!string.IsNullOrEmpty(localDir))
            localDir += "/";


          string remoteFile = localDir+Path.GetFileName(files[i]);
          Client.Upload(remoteFile, files[i]);
          sw.Stop();

          Structure.AddToLog(String.Format("Arquivo {0} enviado em {1}", Path.GetFileName(files[i]), sw.Elapsed), this);
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
