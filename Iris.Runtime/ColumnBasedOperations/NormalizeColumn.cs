using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.ComponentModel;
using Iris.Runtime.Model.PropertyEditors;
using Databridge.Engine.Extensions;
using System.Drawing.Design;
using System.Data;
using System.Linq;

namespace Iris.Runtime.Model.Operations.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "Normaliza Coluna")]
  public class NormalizeColumn : ColumnBasedOperation
  {
    public NormalizeColumn(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    [DisplayName("Alteração de Case"), Category("Expressão")]
    public CaseChange ChangeCase { get; set; }

    public bool KeepSpaces{ get; set; }

    protected override IEntity doExecute()
    {
      if (Entrada == null)
        throw new Exception("Resultset de origem não atribuído!");
      if (string.IsNullOrEmpty(Column))
        throw new Exception("Coluna base não atribuída");
      if (string.IsNullOrEmpty(ColumnName))
        throw new Exception("Coluna resultante não atribuída");

      if (!Entrada.Table.Columns.Contains(ColumnName))
      {
        Entrada.Table.Columns.Add(ColumnName);
      }

      foreach (DataRow row in Entrada.Table.Rows)
      {
        if(KeepSpaces)
          row[ColumnName] = Convert.ToString(row[Column]).ChangeCase(ChangeCase);
        else
          row[ColumnName] = Convert.ToString(row[Column]).NormalizeText(ChangeCase);
      }

      return null;

    }





  }


}
