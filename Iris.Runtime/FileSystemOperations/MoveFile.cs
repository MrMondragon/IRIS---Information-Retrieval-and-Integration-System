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
  [OperationCategory("Operações de Arquivo", "Move Arquivo")]
  public class MoveFile : BaseMaskedFileOperation
  {
    public MoveFile(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Origem"), Category("Arquivo"), Description("Local onde se encontram os arquivos a serem movidos")]
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
    [DisplayName("Destino"), Category("Arquivo"), Description("Local para onde os arquivos serão movidos")]
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

    [DisplayName("Sobrescrever"), Category("Arquivo"), Description("Local para onde os arquivos serão movidos")]
    public bool Overwrite { get; set; }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      string localMask = Mask;
      if (Mask.Contains(@"\"))
        localMask = Path.GetFileName(Mask);

      string origem = Filename1;

      if (String.IsNullOrEmpty(origem))
        origem = Path.GetDirectoryName(Mask);



      string[] fileNames = Directory.GetFiles(origem, localMask);
      int ct = 0;
      try
      {
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

            if (File.Exists(fileName))
            {
              if (Overwrite)
                File.Delete(fileName);
              else
                continue;
            }

            File.Move(fileNames[i], fileName);

            ct++;
          }
          catch (Exception ex)
          {
            throw new Exception(String.Format("Falha na movimentação de arquivos. Origem: {0}; Destino: {1}; Mensagem Original: {2}",
              fileNames[i], fileName, ex.Message), ex);
          }
        }
      }
      finally
      {
        Structure.AddToLog(String.Format("{0} Arquivos movidos", ct), this);
      }
      return null;
    }
  }
}
