using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using Iris.Runtime.Model.DisignSuport;
using Databridge.Engine;
using Databridge.Engine.Parsers;

namespace Iris.Runtime.Model.Operations.FileSystemOperations
{
  [Serializable]
  [OperationCategory("Operações de Arquivo", "Renomeia Arquivo")]
  public class RenameFile : BaseMaskedFileOperation
  {
    public RenameFile(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Folder");
    }

    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Folder"), Category("Arquivo"), Description("Local onde se encontram os arquivos a serem renomeados")]
    public override string Filename1
    {
      get
      {
        return base.Filename1;
      }
      set
      {
        base.Filename1 = value;
      }
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Filename2
    {
      get
      {
        return base.Filename2;
      }
      set
      {
        base.Filename2 = value;
      }
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
      string[] fileNames = Directory.GetFiles(Filename1, Mask);
      Dictionary<string, object> parameters = new Dictionary<string, object>();
      for (int i = 0; i < fileNames.Length; i++)
      {
        string fileName = fileNames[i].Substring(fileNames[i].LastIndexOf('\\')+1);

        parameters["filename"] = fileName;
        parameters["index"] = i;

        ExecutionContext context = Structure.GetContext();
        context.Parameters = parameters;

        fileName = Convert.ToString(XEvalParser.GetParser().Parse(renameMask, context));

        fileName = Filename1 +"\\"+ fileName;

        if (File.Exists(fileName))
          File.Delete(fileName);

        File.Move(fileNames[i], fileName);
      }
      Structure.AddToLog(String.Format("{0} Arquivos renomeados", fileNames.Length), this);

      return null;
    }
  }
}
