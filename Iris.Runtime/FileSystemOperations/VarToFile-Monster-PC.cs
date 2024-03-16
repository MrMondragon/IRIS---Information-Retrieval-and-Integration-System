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
    [OperationCategory("Operações de Arquivo", "Grava Arquivo")]
  public class VarToFile : BaseFileSystemOperation
  {
    public VarToFile(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Filename", "Entrada");
    }

    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    [DisplayName("Filename"), Category("Arquivo"), Description("Nome do arquivo a ser gravado")]
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
      ScalarVar var = GetInput(1) as ScalarVar;
      if (var != null)
      {
        byte[] bytes = var.RawValue as byte[];
        if (bytes != null)
        {
          File.WriteAllBytes(Filename1, bytes);
          return var;
        }
      }
      return null;
    }
  }
}
