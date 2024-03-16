namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class DatePartFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            object obj2 = DBNull.Value;
            string text1 = StringType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[0]), typeof(string), 0));
            if (pars[1] == DBNull.Value)
            {
                return obj2;
            }
            DateTime time1 = DateType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[1]), typeof(DateTime), 0));
            string text2 = text1.ToLower();
            if (((StringType.StrCmp(text2, "yy", false) == 0) || (StringType.StrCmp(text2, "yyyy", false) == 0)) || (StringType.StrCmp(text2, "year", false) == 0))
            {
                return DateAndTime.DatePart(DateInterval.Year, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "qq", false) == 0) || (StringType.StrCmp(text2, "q", false) == 0)) || (StringType.StrCmp(text2, "quarter", false) == 0))
            {
                return DateAndTime.DatePart(DateInterval.Quarter, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "mm", false) == 0) || (StringType.StrCmp(text2, "m", false) == 0)) || (StringType.StrCmp(text2, "month", false) == 0))
            {
                return DateAndTime.DatePart(DateInterval.Month, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "dy", false) == 0) || (StringType.StrCmp(text2, "y", false) == 0)) || (StringType.StrCmp(text2, "dayofyear", false) == 0))
            {
                return DateAndTime.DatePart(DateInterval.DayOfYear, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "dd", false) == 0) || (StringType.StrCmp(text2, "d", false) == 0)) || (StringType.StrCmp(text2, "day", false) == 0))
            {
                return DateAndTime.DatePart(DateInterval.Day, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "wk", false) == 0) || (StringType.StrCmp(text2, "ww", false) == 0)) || (StringType.StrCmp(text2, "week", false) == 0))
            {
                return DateAndTime.DatePart(DateInterval.WeekOfYear, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if ((StringType.StrCmp(text2, "dw", false) == 0) || (StringType.StrCmp(text2, "weekday", false) == 0))
            {
                return DateAndTime.DatePart(DateInterval.Weekday, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if ((StringType.StrCmp(text2, "hh", false) == 0) || (StringType.StrCmp(text2, "hour", false) == 0))
            {
                return DateAndTime.DatePart(DateInterval.Hour, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "mi", false) == 0) || (StringType.StrCmp(text2, "n", false) == 0)) || (StringType.StrCmp(text2, "minute", false) == 0))
            {
                return DateAndTime.DatePart(DateInterval.Minute, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if (((StringType.StrCmp(text2, "ss", false) == 0) || (StringType.StrCmp(text2, "s", false) == 0)) || (StringType.StrCmp(text2, "second", false) == 0))
            {
                return DateAndTime.DatePart(DateInterval.Second, time1, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
            }
            if ((StringType.StrCmp(text2, "ms", false) != 0) && (StringType.StrCmp(text2, "millisecond", false) != 0))
            {
                throw new DataException(string.Format("'{0}' is not a recognized datepart option.", text1));
            }
            return time1.Millisecond;
        }


        public override int ParameterCount
        {
            get
            {
                return 2;
            }
        }

    }
}

