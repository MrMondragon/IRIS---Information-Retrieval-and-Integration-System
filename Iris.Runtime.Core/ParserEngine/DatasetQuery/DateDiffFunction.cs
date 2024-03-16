namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class DateDiffFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            object obj2 = DBNull.Value;
            string text1 = StringType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[0]), typeof(string), 0));
            if ((pars[1] == DBNull.Value) || (pars[2] == DBNull.Value))
            {
                return obj2;
            }
            DateTime time2 = DateType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[1]), typeof(DateTime), 0));
            DateTime time1 = DateType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[2]), typeof(DateTime), 0));
            string text2 = text1.ToLower();
            if (((StringType.StrCmp(text2, "yy", false) == 0) || (StringType.StrCmp(text2, "yyyy", false) == 0)) || (StringType.StrCmp(text2, "year", false) == 0))
            {
                return DateAndTime.DateDiff(DateInterval.Year, time2, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "qq", false) == 0) || (StringType.StrCmp(text2, "q", false) == 0)) || (StringType.StrCmp(text2, "quarter", false) == 0))
            {
                return DateAndTime.DateDiff(DateInterval.Quarter, time2, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "mm", false) == 0) || (StringType.StrCmp(text2, "m", false) == 0)) || (StringType.StrCmp(text2, "month", false) == 0))
            {
                return DateAndTime.DateDiff(DateInterval.Month, time2, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "dy", false) == 0) || (StringType.StrCmp(text2, "y", false) == 0)) || (StringType.StrCmp(text2, "dayofyear", false) == 0))
            {
                return DateAndTime.DateDiff(DateInterval.DayOfYear, time2, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "dd", false) == 0) || (StringType.StrCmp(text2, "d", false) == 0)) || (StringType.StrCmp(text2, "day", false) == 0))
            {
                return DateAndTime.DateDiff(DateInterval.Day, time2, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "wk", false) == 0) || (StringType.StrCmp(text2, "ww", false) == 0)) || (StringType.StrCmp(text2, "week", false) == 0))
            {
                return DateAndTime.DateDiff(DateInterval.WeekOfYear, time2, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if ((StringType.StrCmp(text2, "hh", false) == 0) || (StringType.StrCmp(text2, "hour", false) == 0))
            {
                return DateAndTime.DateDiff(DateInterval.Hour, time2, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "mi", false) == 0) || (StringType.StrCmp(text2, "n", false) == 0)) || (StringType.StrCmp(text2, "minute", false) == 0))
            {
                return DateAndTime.DateDiff(DateInterval.Minute, time2, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "ss", false) == 0) || (StringType.StrCmp(text2, "s", false) == 0)) || (StringType.StrCmp(text2, "second", false) == 0))
            {
                return DateAndTime.DateDiff(DateInterval.Second, time2, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if ((StringType.StrCmp(text2, "ms", false) != 0) && (StringType.StrCmp(text2, "millisecond", false) != 0))
            {
                throw new DataException(string.Format("'{0}' is not a recognized datediff option.", text1));
            }
            TimeSpan span1 = time2.Subtract(time1);
            return Math.Round(Conversion.Fix(span1.TotalMilliseconds));
        }


        public override int ParameterCount
        {
            get
            {
                return 3;
            }
        }

    }
}

