using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.FileSystemOperations
{
  [Serializable]
  public abstract class BaseMaskedFileOperation : BaseFileSystemOperation
  {
    public BaseMaskedFileOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Filename 1", "Filename 2", "Máscara");
      Mask = "*.*";
    }


    private string mask;
    [DisplayName("Máscara"), Category("Arquivo"), Description("Máscara de busca dos arquivos")]
    public virtual string Mask
    {
      get
      {
        IOperation oper = GetInput(2);
        if (oper != null)
        {
          ScalarVar var = oper.EntityValue as ScalarVar;
          if (var != null)
            return Convert.ToString(var.RawValue);
          else
            return string.Empty;
        }
        else
          return mask;
      }
      set { mask = value; }
    }

  }
}
