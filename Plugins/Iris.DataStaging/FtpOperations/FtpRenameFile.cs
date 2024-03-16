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
    [DisplayName("Máscara de renomeação"), Category("Arquivo"), Description("Máscara de renomeação dos arquivos. Utilize as variáveis &filename para acessar o nome atual e &index para acessar o número do arquivo no processo.")]
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
        Client.ChangeDir(Dir);
        string[] files = Client.GetFileList(Mask);
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        for (int i = 0; i < files.Length; i++)
        {
          if (!string.IsNullOrEmpty(files[i].Trim()))
          {
            parameters["filename"] = files[i];
            parameters["index"] = i;

            ExecutionContext context = Structure.GetContext();
            context.Parameters = parameters;            

            string fileName = Convert.ToString(XEvalParser.GetParser().Parse(renameMask, context));
            Client.RenameFile(files[i],fileName,true);
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
