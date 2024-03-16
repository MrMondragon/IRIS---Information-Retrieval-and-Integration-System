using System.IO;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.FileSystemOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iris.Runtime.FileSystemOperations
{
  [Serializable]
  [OperationCategory("Operações de Arquivo", "Arquivo Existe?")]
  public class FileExists : BaseFileSystemOperation
  {

    public FileExists(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Filename");
      SetOutputs("True", "False");
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



    protected override Interfaces.IEntity doExecute()
    {
      IOperation opTrue = GetOutput("True");
      IOperation opFalse = GetOutput("False");

      bool exists = File.Exists(Filename1);
      if (exists)
        opTrue.Execute();
      else
      {
        if (opFalse != null)
          opFalse.Execute();
      }

      return null;
    }
  }
}
