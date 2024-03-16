using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.FtpOperations
{
  [Serializable]
  [OperationCategory("Operações de FTP", "Deleta Diretório")]
  public class FtpDeleteDir : BaseFtpOperation
  {
    public FtpDeleteDir(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }


    protected override Iris.Interfaces.IEntity doExecute()
    {
      try
      {
        if (Client.DirectoryExists(Dir))
        {
          Client.RemoveDir(Dir);
          Structure.AddToLog("Diretório " + Dir + " removido no endereço " + Server, this);
        }
        else
          Structure.AddToLog("Diretório " + Dir + " não existente no endereço " + Server, this);

      }
      finally
      {
        base.doExecute();
      }
      return null;
    }
  }
}
