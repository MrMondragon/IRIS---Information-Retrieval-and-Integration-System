using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.Operations;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using System.Data;
using Iris.Runtime.Model.DisignSuport;
using System.Drawing;
using Iris.Runtime.Properties;

namespace Iris.DataGenerator
{
  [Serializable]
  [OperationCategory("Geradores de Dados", "Table Based Generator")]
  public class TableBasedGenerator : BaseRowGenerator
  {
    public TableBasedGenerator(Structure structure, string name)
      : base(structure, name)
    {
      SetInputs("Ref.");
      SetOutputs("Saída");
    }

    protected override void GetInstanceInputs(List<string> fieldList)
    {
      fieldList.Add("Ref.");
    }

    protected override int GetRowCount()
    {
      return ((ResultSet)GetValue("Ref.")).Table.Rows.Count;
    }

    public static Bitmap GetIcon()
    {
      return Resources.TabGen;
    }
    
  }
}
