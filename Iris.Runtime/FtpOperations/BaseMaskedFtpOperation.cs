using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using System.ComponentModel;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.FtpOperations
{
  [Serializable]
  public abstract class BaseMaskedFtpOperation : BaseFtpOperation
  {
    public BaseMaskedFtpOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Folder", "M�scara");
      Mask = "*.*";
    }

    private string mask;
    [DisplayName("M�scara"), Category("Arquivo"), Description("M�scara de busca dos arquivos")]
    public virtual string Mask
    {
      get
      {
        IOperation oper = GetInput(1);
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
