using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.FtpOperations
{
  [Serializable]
  [OperationCategory("Operações de FTP", "Troca diretório")]
  public class FtpChangeDir : BaseFtpOperation
  {
    public FtpChangeDir(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      try
      {
        Client.ChangeDir(Dir);
      }
      finally
      {
        base.doExecute();
      }
      return null;
    }
  }
}
