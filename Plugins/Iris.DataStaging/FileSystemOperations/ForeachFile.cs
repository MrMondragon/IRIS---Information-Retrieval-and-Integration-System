using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Operations.Control;
using Iris.Runtime.Model.Entities;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.IO;
using Iris.Interfaces;

namespace Iris.Runtime.Model.Operations.ControlOperations
{
  [Serializable]
  [OperationCategory("Operações de Controle", "For Each File")]
  public class ForeachFile : Loop
  {
    public ForeachFile(Structure aStructure, string aName)
      : base(aStructure,aName)
    {
      SetInputs("Folder", "Máscara");
      SetOutputs("Loop", "Saída");
      Mask = "*.*";
    }

    private string folder;
    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    [DisplayName("Folder"), Category("Arquivo"), Description("A localização dos arquivos em disco")]
    public string Folder
    {
      get
      {
        if (GetInput(0) != null)
        {
          ScalarVar folderVar = GetInput(0).EntityValue as ScalarVar;
          if (folderVar == null)
            throw new Exception("Input de folder inválido");

          return Convert.ToString(folderVar.RawValue);
        }
        else
          return folder;
      }
      set { folder = value; }
    }

    private string mask;
    [DisplayName("Máscara"), Category("Arquivo"), Description("A máscara de busca dos arquivos. \r\nEx.: *.txt")]
    public string Mask
    {
      get
      {
        if (GetInput(1) != null)
        {
          ScalarVar maskVar = GetInput(1).EntityValue as ScalarVar;
          if (maskVar == null)
            throw new Exception("Input de máscara inválido");

          return Convert.ToString(maskVar.RawValue);
        }
        else
          return mask;
      }
      set { mask = value; }
    }

    protected override IEntity doExecute()
    {
      if (string.IsNullOrEmpty(Folder) || (!Directory.Exists(Folder)))
        throw new Exception("Folder não existente");

      if (string.IsNullOrEmpty(Mask))
        throw new Exception("Máscara inválida");

      ScalarVar saida = GetOutput(1) as ScalarVar;

      if (saida == null)
        throw new Exception("Saída inválida");

      string[] files = Directory.GetFiles(Folder, Mask);

      for (int i = 0; i < files.Length; i++)
      {
        saida.RawValue = files[i];

        Structure.AddToErrorLog(String.Format("Processando arquivo: {0}", files[i]), this);

        base.doExecute();
      }

      return null;
    }
  }
}
