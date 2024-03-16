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
        string[] files = Client.GetFileList(Dir, Mask);
        for (int i = 0; i < files.Length; i++)
        {
          if (!string.IsNullOrEmpty(files[i].Trim()))
          {
            string localDir = Dir;
            if (!string.IsNullOrEmpty(localDir))
              localDir += "/";

            Client.Delete(localDir+files[i]);
            Structure.AddToLog(String.Format("Arquivo {0} deletado ", files[i]), this);

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
