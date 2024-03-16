using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.FtpOperations
{
  [Serializable]
  [OperationCategory("Operações de FTP", "Deleta Arquivos")]
  public class FtpDeleteFiles : BaseMaskedFtpOperation
  {
    public FtpDeleteFiles(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
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
            Client.DeleteFile(files[i]);
            ct++;
          }
        }
      }
      finally
      {
        Structure.AddToLog(String.Format("{0} Arquivos deletados", ct), this);
        base.doExecute();
      }
      return null;
    }
  }
}
