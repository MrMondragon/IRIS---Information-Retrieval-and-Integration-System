using System;
using System.Linq;
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
using Databridge.Engine.Criptography;
using Databridge.Engine.Extensions;

namespace Iris.Runtime.ColumnBasedOperations
{
  [Serializable]
  [OperationCategory("Transformações", "AlphaSeq")]
  public class AlphaSeq : ColumnBasedOperation
  {
    public AlphaSeq(Structure aStructure, string aName) : base(aStructure, aName)
    {
    }

    [Browsable(false)]
    public override string ColumnName
    {
      get
      {
        return base.ColumnName;
      }

      set
      {
        base.ColumnName = value;
      }
    }

    [Category("Expression")]
    public string Prefix { get; set; }
    [Category("Expression")]
    public int Size { get; set; }
    private string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    protected override IEntity doExecute()
    {
      ResultSet entrada = (ResultSet)Entrada;
      if (entrada == null)
        throw new Exception("Resultset de entrada não atribuído");

      if (string.IsNullOrWhiteSpace(ColunaBase))
        throw new Exception("Coluna base não atribuída");

      List<string> colValues = entrada.Table.Rows.Cast<DataRow>().Select(x => Convert.ToString(x[ColunaBase])).Where(y=> !string.IsNullOrWhiteSpace(y)).ToList();

      int startValue = 0;

      if(colValues.Any(x=> !string.IsNullOrEmpty(x)))
      {
        startValue = colValues.Select(x => Cube.StringToInt(Cube.InvertString(x.Substring(Prefix.Length)), alpha)).Max() + 1;
      }

      DataRow[] rows = entrada.Table.Select(entrada.Filter, entrada.Sort, DataViewRowState.CurrentRows);

      

      for (int i = 0; i < rows.Length; i++)
      {
        DataRow row = rows[i];

        string value = Convert.ToString(row[ColunaBase]);
        if(string.IsNullOrWhiteSpace(value))
        {
          value = Prefix+Cube.InvertString(Cube.IntToString(startValue, alpha)).PadLeft(Size, 'A');
          row[ColunaBase] = value;
          startValue++;
        }
      }

      return null;
    }
  }
}
