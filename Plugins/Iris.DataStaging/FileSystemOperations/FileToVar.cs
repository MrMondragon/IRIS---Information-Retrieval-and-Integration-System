using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Entities;

namespace Iris.Runtime.Model.Operations.FileSystemOperations
{
  [Serializable]
  [OperationCategory("Operações de Arquivo", "Carrega Arquivo")]
  public class FileToVar : BaseFileSystemOperation
  {
    public FileToVar(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Filename");
      SetOutputs("Saída");
    }

    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    [DisplayName("Filename"), Category("Arquivo"), Description("Nome do arquivo a ser carregado")]
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

    protected override Iris.Interfaces.IEntity doExecute()
    {
      if(File.Exists(Filename1))
      {
        byte[] bytes = File.ReadAllBytes(Filename1);
        ScalarVar var = GetOutput(0) as ScalarVar;
        if (var != null)
        {
          var.RawValue = bytes;
          return var;
        }
      }
      return null;
    }
  }
}
