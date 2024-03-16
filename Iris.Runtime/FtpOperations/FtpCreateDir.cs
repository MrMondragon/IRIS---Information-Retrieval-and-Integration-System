using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;

namespace Iris.Runtime.Model.Operations.FtpOperations
{
  [Serializable]
  [OperationCategory("Opera��es de FTP", "Cria Diret�rio")]
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
        bool dirExists = Client.DirectoryExists(Dir);
        if (!dirExists)
        {
          Client.MakeDir(Dir);
          Structure.AddToLog("Diret�rio " + Dir + " criado no endere�o " + Server, this);
        }
        else
          Structure.AddToLog("Diret�rio " + Dir + " j� existente no endere�o " + Server, this);

      }
      finally
      {
        base.doExecute();
      }
      return null;
    }
  }
}
