using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace Iris.Runtime.Model.Operations.VarOperations
{
  [Serializable]
  public abstract class BaseIOVarOperation : BaseVarOperation
  {
    public BaseIOVarOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected int fileNameIdx;

    private string fileName;
    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    [DisplayName("File Name"), Category("Arquivo"), Description("A localização do arquivo em disco")]
    public string Filename
    {
      get
      {
        if (GetInput(fileNameIdx) != null)
        {
          ScalarVar fileVar = GetInput(fileNameIdx).EntityValue as ScalarVar;
          if (fileVar == null)
            throw new Exception("Input de file name inválido");

          return Convert.ToString(fileVar.RawValue);
        }
        else
          return fileName;
      }
      set { fileName = value; }
    }
  }
}
