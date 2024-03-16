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
using System.Drawing;
using Iris.Runtime.Properties;

namespace Iris.DataGenerator
{
  [Serializable]
  [OperationCategory("Geradores de Dados", "Date Rule")]
  public class DateRule : BaseValueRule
  {
    public DateRule(Structure structure, string name)
      : base(structure, name)
    {
      SetOutputs("Saída");
    }

    private int startYear;
    [DisplayName("Ano Inicial")]
    public int StartYear
    {
      get { return startYear; }
      set { startYear = value; }
    }

    private int endYear;
    [DisplayName("Ano Final")]
    public int EndYear
    {
      get { return endYear; }
      set { endYear = value; }
    }

    [NonSerialized]
    private Random rnd;

    protected override Iris.Interfaces.IEntity doExecute()
    {
      if (rnd == null)
        rnd = new Random();

      int year = rnd.Next(startYear, endYear);
      int month = rnd.Next(12) + 1;
      int day = rnd.Next(DateTime.DaysInMonth(year, month)) + 1;

      value = new DateTime(year, month, day);

      return FieldValue;
    }

    public static Bitmap GetIcon()
    {
      return Resources.DateTime;
    }
  }
}
