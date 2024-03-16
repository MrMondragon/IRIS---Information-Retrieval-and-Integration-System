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
using System.ComponentModel;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing.Design;
using System.Drawing;
using Iris.Runtime.Properties;

namespace Iris.DataGenerator
{
  [Serializable]
  [OperationCategory("Geradores de Dados", "Lookup Rule")]
  public class LookupRule : BaseValueRule, IRowColumnRule
  {
    public LookupRule(Structure structure, string name)
      : base(structure, name)
    {
      SetInputs("Entrada");
      SetOutputs("Saída");
      position = 0;
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual IResultSet Entrada
    {
      get
      {
        ResultSet input = GetInput("Entrada").EntityValue as ResultSet;
        return input;
      }
    }

    public override void Reset()
    {
      base.Reset();
      position = 0;
    }

    [NonSerialized]
    private int position;

    [Category("Rule"), Description("Determina se serão utilizados valores aleatórios ou ordenados na busca")]
    public bool Randomize { get; set; }

    private String columnName;
    [DisplayName("Coluna"), Category("Rule"), Description("Nome da coluna que será utilizada pela regra")]
    [Editor(typeof(RCRColumnSelector), typeof(UITypeEditor))]
    public virtual String ColumnName
    {
      get { return columnName; }
      set
      {
        if (columnName != value)
        {
          if ((!String.IsNullOrEmpty(columnName)) && (Entrada != null) && (Entrada.Table.Columns.Contains(columnName)))
            Entrada.Table.Columns.Remove(columnName);

          columnName = value;
        }
      }
    }

    [NonSerialized]
    private Random rnd;

    protected override Iris.Interfaces.IEntity doExecute()
    {
      if (Randomize)
      {
        if (rnd == null)
          rnd = new Random();

        int maxValue = Entrada.Table.Rows.Count;
        value = Entrada.Table.Rows[rnd.Next(maxValue)][ColumnName];
      }
      else
      {
        value = Entrada.Table.Rows[position][ColumnName];
        position++;
      }

      return FieldValue;       
    }

    public static Bitmap GetIcon()
    {
      return Resources.Lookup;
    }
  }
}
