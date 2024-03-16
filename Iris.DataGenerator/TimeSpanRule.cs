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
  [OperationCategory("Geradores de Dados", "TimeSpan Rule")]
  public class TimeSpanRule : BaseValueRule
  {
    public TimeSpanRule(Structure structure, string name)
      : base(structure, name)
    {
      minDate = DateTime.Today.AddMonths(-1);
      maxDate = DateTime.Today.AddMonths(1);
      SetOutputs("Início", "Fim");

    }

    private DateTime minDate;

    public DateTime MinDate
    {
      get { return minDate; }
      set { minDate = value; }
    }

    private DateTime maxDate;

    public DateTime MaxDate
    {
      get { return maxDate; }
      set { maxDate = value; }
    }

    [NonSerialized]
    private Random rnd;


    protected override Iris.Interfaces.IEntity doExecute()
    {
      if (rnd == null)
        rnd = new Random();

      long start = MinDate.Ticks;
      long end = MaxDate.Ticks;

      long baseSpan = end - start;

      int span = rnd.Next(Convert.ToInt32(baseSpan))/2;
      int startTick = rnd.Next(Convert.ToInt32(baseSpan));

      start += startTick;
      

      DateTime startDate = new DateTime(startTick);
      if (startDate > maxDate)
        startDate = maxDate.AddDays(-1);

      end = startDate.Ticks + span;

      DateTime endDate = new DateTime(end);

      SetValue("Início", startDate);

      if (endDate <= maxDate)
        SetValue("Fim", endDate);
      else
        SetValue("Fim", null);

      this.value = startDate;

      return FieldValue;
    }

    public static Bitmap GetIcon()
    {
      return Resources.TimeStamp;
    }
  }
}
