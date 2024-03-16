using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.FtpOperations
{
  [Serializable]
  [OperationCategory("Opera��es de FTP", "Deleta Diret�rio")]
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
          Structure.AddToLog("Diret�rio " + Dir + " removido no endere�o " + Server, this);
        }
        else
          Structure.AddToLog("Diret�rio " + Dir + " n�o existente no endere�o " + Server, this);

      }
      finally
      {
        base.doExecute();
      }
      return null;
    }
  }
}
