using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.FtpOperations
{
  [Serializable]
  [OperationCategory("Operações de FTP", "Cria Diretório")]
  public class FtpCreateDir : BaseFtpOperation
  {
    public FtpCreateDir(Structure aStructure, string aName)
      : base(aStructure, aName)
    { 
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      try
      {
        Client.ChangeDir(Dir);
      }
      catch
      {
        Client.MakeDir(Dir);
      }
      finally
      {
        base.doExecute();
      }
      return null;
    }
  }
}
