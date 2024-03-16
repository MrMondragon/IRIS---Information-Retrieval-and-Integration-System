using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.PropertyEditors.PropertyEditors;
using System.Data;
using Iris.Runtime.Model.Entities;


namespace Iris.Runtime.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Treshold")]
  public class Treshold : ColumnBasedOperation
  {
    public Treshold(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetInputs("Entrada", "Treshold");
    }

    [Category("Expression"), Description("Valor de substituição para limite superior >")]
    public string ValueAbove { get; set; }
    [Category("Expression"), Description("Valor de substituição para limite inferior <=")]
    public string ValueBelow { get; set; }
    private decimal treshold;

    public decimal TresholdValue
    {
      get
      {
        object tValue = GetValue(1);
        if (tValue != null)
          return Convert.ToDecimal(tValue);
        else
          return treshold;
      }
      set { treshold = value; }
    }


    protected override IEntity doExecute()
    {
      ResultSet entrada = (ResultSet)Entrada;
      if (entrada == null)
        throw new Exception("Resultset de entrada não atribuído");

      if (string.IsNullOrWhiteSpace(ColunaResultante))
        throw new Exception("Coluna resultante não atribuída");
      if (string.IsNullOrWhiteSpace(ColunaBase))
        throw new Exception("Coluna base não atribuída");

      DataView view = entrada.View;

      if (view == null)
        throw new Exception("Resultset de entrada não preenchido");

      if (!entrada.Table.Columns.Contains(ColunaResultante))
      {
        entrada.Table.Columns.Add(ColunaResultante);
      }

      for (int i = 0; i < view.Count; i++)
      {

        decimal value = Convert.ToDecimal(view[i][ColunaBase]);
        if (value <= TresholdValue)
          view[i][ColunaResultante] = ValueBelow;
        else
          view[i][ColunaResultante] = ValueAbove;
      }

      return null;
    }
  }
}
