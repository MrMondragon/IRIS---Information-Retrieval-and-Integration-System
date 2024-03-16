using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.IO;

namespace Iris.Runtime.Model.Operations.FileSystemOperations
{
  [Serializable]
  [OperationCategory("Operações de Arquivo", "Copia Arquivo")]
  public class CopyFile : BaseMaskedFileOperation
  {
    public CopyFile(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      overwrite = true;
    }

    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Origem"), Category("Arquivo"), Description("Local onde se encontram os arquivos a serem copiados")]
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

    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Destino"), Category("Destino"), Description("Local para onde os arquivos serão copiados")]
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

    private bool overwrite;

    public bool Overwrite
    {
      get { return overwrite; }
      set { overwrite = value; }
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      string[] fileNames = Directory.GetFiles(Filename1, Mask);
      for (int i = 0; i < fileNames.Length; i++)
      {
        string fileName = Filename2;
        try
        {
          if (Directory.Exists(Filename2))
          {
            fileName = Path.GetFileName(fileNames[i]);
            fileName = Path.Combine(Filename2, fileName);
          }

          File.Copy(fileNames[i], fileName, overwrite);
        }
        catch (Exception ex)
        {
          throw new Exception(String.Format("Falha na cópia de arquivos. Origem: {0}; Destino: {1}; Mensagem Original: {2}",
            fileNames[i], fileName, ex.Message), ex);
        }
      }
      Structure.AddToLog(String.Format("{0} Arquivos copiados", fileNames.Length), this);
      return null;
    }
  }
}
