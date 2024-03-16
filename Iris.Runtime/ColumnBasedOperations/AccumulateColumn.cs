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
  [OperationCategory("Transformações", "Accumulate")]
  public class AccumulateColumn : ColumnBasedOperation
  {
    public AccumulateColumn(Structure aStructure, string aName) : base(aStructure, aName)
    {
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
        entrada.Table.Columns.Add(ColunaResultante, entrada.Table.Columns[ColunaBase].DataType);
      }

      int value = 0;

      for (int i = 0; i < view.Count; i++)
      {
        value += Convert.ToInt32(view[i][ColunaBase]);
        view[i][ColunaResultante] = value;
      }

      return null;
    }
  }
}
