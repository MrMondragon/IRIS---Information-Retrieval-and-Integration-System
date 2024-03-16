using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.FtpOperations
{
  [Serializable]
  public abstract class BaseTwoFolderedFtpOperation : BaseMaskedFtpOperation
  {
    public BaseTwoFolderedFtpOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Folder", "Máscara", "Destino");
      Mask = "*.*";
    }

    private string destino;
    [DisplayName("Destino"), Category("Arquivo"), Description("O caminho de destino dos arquivos")]
    public virtual string Destino
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
          return destino;
      }
      set { destino = value; }
    }

  }
}
