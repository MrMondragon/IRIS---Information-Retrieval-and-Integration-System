using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model.Entities.Schemas;
using Iris.Runtime.Model.Operations.FileSystemOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace Iris.Runtime.FileSystemOperations
{
  [Serializable]
  [OperationCategory("Operações de Arquivo", "Quebrador de Arquivos")]
  public class FileSplitter : BaseMaskedFileOperation
  {
    public FileSplitter(Structure aStructure, string aName) : base(aStructure, aName)
    {
      LineLimit = 100000;
      TextEncoding = TextEncoding.UTF8;
    }

    [Browsable(false)]
    public override string Filename1 { get => base.Filename1; set => base.Filename1 = value; }
    [Browsable(false)]
    public override string Filename2 { get => base.Filename2; set => base.Filename2 = value; }
    public int LineLimit { get; set; }

    public bool MultiThread { get; set; }

    private string origem;
    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Origem"), Category("Arquivo")]
    public string Origem
    {
      get
      {
        if (GetInput("Origem") != null)
        {
          ScalarVar folderVar = GetInput("Origem").EntityValue as ScalarVar;
          if (folderVar == null)
            throw new Exception("Input de origem inválido");

          return Convert.ToString(folderVar.RawValue);
        }
        else
          return origem;
      }
      set { origem = value; }
    }

    private string destino;
    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Destino"), Category("Arquivo")]
    public string Destino
    {
      get
      {
        if (GetInput("Destino") != null)
        {
          ScalarVar folderVar = GetInput("Destino").EntityValue as ScalarVar;
          if (folderVar == null)
            throw new Exception("Input de destino inválido");

          return Convert.ToString(folderVar.RawValue);
        }
        else
          return destino;
      }
      set { destino = value; }
    }

    protected override IEntity doExecute()
    {
      string[] fileNames = Directory.GetFiles(Origem, Mask);

      if (MultiThread)
      {
        Parallel.ForEach(fileNames, file => { SplitFile(file); });
      }
      else
      {
        foreach (string file in fileNames)
        {
          SplitFile(file);
        }
      }
      return null;
    }

    private void SplitFile(string fileName)
    {
      int lineCounter = 0;
      int fileCounter = 1;
      string fName = Path.GetFileNameWithoutExtension(fileName);
      string fExtension = Path.GetExtension(fileName).Trim('.');
      using (StreamReader sr = new StreamReader(fileName, Encoding))
      {
        string line = "";
        while ((line = sr.ReadLine()) != null)
        {
          lineCounter++;
          if (lineCounter >= LineLimit)
          {
            fileCounter++;
            lineCounter = 0;
          }
          using (StreamWriter sw = new StreamWriter(Path.Combine(Destino, $"{fName}_{fileCounter}.{fExtension}"), true))
          {
            sw.WriteLine(line);
          }

        }
      }
    }



    private TextEncoding? textEncoding;

    public TextEncoding TextEncoding
    {
      get
      {
        if (textEncoding == null)
          return TextEncoding.Default;
        else
          return textEncoding.Value;
      }
      set { textEncoding = value; }
    }

    [Browsable(false)]
    public Encoding Encoding
    {
      get
      {
        switch (TextEncoding)
        {
          case TextEncoding.Default:
            return Encoding.Default;
          case TextEncoding.ASCII:
            return Encoding.ASCII;
          case TextEncoding.BigEndianUnicode:
            return Encoding.BigEndianUnicode;
          case TextEncoding.Unicode:
            return Encoding.Unicode;
          case TextEncoding.UTF32:
            return Encoding.UTF32;
          case TextEncoding.UTF7:
            return Encoding.UTF7;
          case TextEncoding.UTF8:
            return Encoding.UTF8;
          default:
            return Encoding.Default;
        }
      }
    }


  }
}
