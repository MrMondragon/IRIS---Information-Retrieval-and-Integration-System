using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.Operations;
using Iris.Interfaces;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using System.Data;
using Iris.Runtime.Model.DisignSuport;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing;
using Iris.Runtime.Properties;

namespace Iris.DataGenerator
{
  [Serializable]
  [OperationCategory("Geradores de Dados", "List Lookup Rule")]
  public class ListLookup : BaseValueRule, Iris.DataGenerator.IListLookup
  {
    public ListLookup(Structure structure, string name)
      : base(structure, name)
    {
      values = new List<string>();
      SetOutputs("Saída");
    }

    private List<string> values;
    [Editor(typeof(ListLookupValuesEditor), typeof(UITypeEditor))]
    public List<string> Values
    {
      get { return values; }
      set { values = value; }
    }



    [NonSerialized]
    private Random rnd;

    protected override Iris.Interfaces.IEntity doExecute()
    {
      if (rnd == null)
        rnd = new Random();

      int idx = rnd.Next(Values.Count);

      value = Values[idx];

      return FieldValue;
    }

    public static Bitmap GetIcon()
    {
      return Resources.ListLookup;
    }
  }
}
