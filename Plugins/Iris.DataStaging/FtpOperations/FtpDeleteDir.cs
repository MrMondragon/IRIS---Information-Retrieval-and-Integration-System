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
        Client.RemoveDir(Dir);
      }
      finally
      {
        base.doExecute();
      }
      return null;
    }
  }
}
