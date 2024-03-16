using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using Databridge.Engine;
using Databridge.Engine.Parsers;

namespace Iris.Runtime.Model.Operations.FtpOperations
{
  [Serializable]
  [OperationCategory("Operações de FTP", "Renomeia Arquivos")]
  public class FtpRenameFiles : BaseMaskedFtpOperation
  {
    public FtpRenameFiles(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    private string renameMask;
    [DisplayName("Máscara de renomeação"), Category("Arquivo")]
    public string RenameMask
    {
      get { return renameMask; }
      set { renameMask = value; }
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
            string fileName = files[i];

            string[] fileParts = fileName.Split('.');
            string[] maskParts = RenameMask.Split('.');

            fileName = "";

            for (int j = 0; j < maskParts.Length; j++)
            {
              if (fileParts.Length > j)
                fileName += maskParts[j].Replace("*", fileParts[j]);
              else
                fileName += maskParts[j];
              fileName += ".";
            }
            fileName = fileName.TrimEnd('.');
            string localDir = Dir;
            if (!string.IsNullOrEmpty(localDir))
              localDir += "/";

            Client.Rename(localDir+ files[i], fileName);
            Structure.AddToLog(String.Format("Arquivo {0} renomeado para {1} no diretório {2}", files[i], fileName, Dir), this);

            ct++;
          }
        }
      }
      finally
      {
        Structure.AddToLog(String.Format("{0} Arquivos renomeados", ct), this);
        base.doExecute();
      }
      return null;
    }
  }
}
