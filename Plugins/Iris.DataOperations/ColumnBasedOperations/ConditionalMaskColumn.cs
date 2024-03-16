using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using Iris.Interfaces;
using System.Data;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using System.Drawing.Design;
using Databridge.PropertyEditors;


namespace Iris.DataOperations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Operações de Colunas", "Conditional Mask")]
  public class ConditionalMaskColumn : ColumnBasedOperation
  {
    public ConditionalMaskColumn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
      masks = new  List<MaskItem>();
    }

    private List<MaskItem> masks;
    [Editor(typeof(GenericListEditor<MaskItem>), typeof(UITypeEditor))]
    [DisplayName("Masks"), Category("Expressão")]
    public List<MaskItem> Masks
    {
      get 
      {
        return masks;
      }
      set 
      { 
        masks = value; 
      }
    }

    private bool fullCommit;
    [DisplayName("Edição completa"), Category("Coluna"), Description("Ativar edição completa deixa o registro pronto para ser enviado ao banco, mas consome muito mais tempo.")]
    public bool FullCommit
    {
      get { return fullCommit; }
      set { fullCommit = value; }
    }


    protected override Iris.Interfaces.IEntity doExecute()
    {
      DataTable table = Entrada.Table;

      if (string.IsNullOrEmpty(ColumnName))
        throw new Exception("A propriedade Coluna Resultante não foi atribuída");

      if (Column == null)
        throw new Exception("A Coluna Base não foi atribuída");

      if (!table.Columns.Contains(ColumnName))
        table.Columns.Add(ColumnName);

      for (int i = 0; i < table.Rows.Count; i++)
      {
        DataRow row = table.Rows[i];
        row.BeginEdit();

        int value = Convert.ToInt32(row[Column]);
        string formatedValue = Convert.ToString(value);
        int len = formatedValue.Length;

        Dictionary<int, string> maskDictionary = masks.ToDictionary(x => x.Length, x => x.Mask);

        if (maskDictionary.ContainsKey(len))
        {
          string mask = maskDictionary[len];
          string formatStr = string.Format("{{0}}:{0}", mask);
          formatedValue = string.Format(formatStr, value);
        }

        row[ColumnName] = formatedValue;

        if (FullCommit)
          row.EndEdit();
      }

      return (IEntity)Entrada;
    }
  }

  [Serializable]
  public class MaskItem
  {
    public int Length { get; set; }
    public string Mask { get; set; }

    public override string ToString()
    {
      return string.Format("{0}:{1}", Length, Mask);
    }
  }
}
