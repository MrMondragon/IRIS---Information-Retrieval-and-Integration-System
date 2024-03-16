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
  [OperationCategory("Transformações", "Conditional Mask")]
  public class ConditionalMaskColumn : ColumnBasedOperation
  {
    public ConditionalMaskColumn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada");
      masks = new List<MaskItem>();
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

    private string elseMask;

    public string ElseMask
    {
      get { return elseMask; }
      set { elseMask = value; }
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

        Int64 value = Convert.ToInt64(row[Column]);
        string formatedValue = Convert.ToString(value);
        int len = formatedValue.Length;

        Dictionary<int, string> maskDictionary = masks.ToDictionary(x => x.Length, x => x.Mask);

        string formatStr;

        if (maskDictionary.ContainsKey(len))
        {
          string mask = maskDictionary[len];
          formatStr = string.Format("{{0:{0}}}", mask);
          formatedValue = string.Format(formatStr, value);
        }
        else if (!string.IsNullOrEmpty(elseMask))
        {
          int digits = elseMask.ToCharArray().Where(x => (x == '#') || (x == '0')).Count();
          formatStr = string.Format("{{0:{0}}}", elseMask);
          if (digits <= formatedValue.Length)
          {
            Int64 firstPart = Convert.ToInt64(formatedValue.Remove(digits));
            Int64 secondPart = Convert.ToInt64(formatedValue.Substring(digits));
            formatedValue = string.Format(formatStr, firstPart) + secondPart;
          }
          else
            formatedValue = string.Format(formatStr, value);

        }



        row[ColumnName] = formatedValue;

        if (FullCommit)
          row.EndEdit();
      }

      return (IEntity)Entrada;
    }
  }


}
