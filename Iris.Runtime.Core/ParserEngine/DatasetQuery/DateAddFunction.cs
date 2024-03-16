namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class DateAddFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            object obj2 = DBNull.Value;
            string text1 = StringType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[0]), typeof(string), 0));
            int num1 = IntegerType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[1]), typeof(int), 0));
            if (pars[2] == DBNull.Value)
            {
                return obj2;
            }
            DateTime time1 = DateType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[2]), typeof(DateTime), 0));
            string text2 = text1.ToLower();
            if (((StringType.StrCmp(text2, "yy", false) == 0) || (StringType.StrCmp(text2, "yyyy", false) == 0)) || (StringType.StrCmp(text2, "year", false) == 0))
            {
                return DateAndTime.DateAdd(DateInterval.Year, (double) num1, time1);
            }
            if (((StringType.StrCmp(text2, "qq", false) == 0) || (StringType.StrCmp(text2, "q", false) == 0)) || (StringType.StrCmp(text2, "quarter", false) == 0))
            {
                return DateAndTime.DateAdd(DateInterval.Quarter, (double) num1, time1);
            }
            if (((StringType.StrCmp(text2, "mm", false) == 0) || (StringType.StrCmp(text2, "m", false) == 0)) || (StringType.StrCmp(text2, "month", false) == 0))
            {
                return DateAndTime.DateAdd(DateInterval.Month, (double) num1, time1);
            }
            if (((StringType.StrCmp(text2, "dy", false) == 0) || (StringType.StrCmp(text2, "y", false) == 0)) || (StringType.StrCmp(text2, "dayofyear", false) == 0))
            {
                return DateAndTime.DateAdd(DateInterval.DayOfYear, (double) num1, time1);
            }
            if (((StringType.StrCmp(text2, "dd", false) == 0) || (StringType.StrCmp(text2, "d", false) == 0)) || (StringType.StrCmp(text2, "day", false) == 0))
            {
                return DateAndTime.DateAdd(DateInterval.Day, (double) num1, time1);
            }
            if (((StringType.StrCmp(text2, "wk", false) == 0) || (StringType.StrCmp(text2, "ww", false) == 0)) || (StringType.StrCmp(text2, "week", false) == 0))
            {
                return DateAndTime.DateAdd(DateInterval.WeekOfYear, (double) num1, time1);
            }
            if ((StringType.StrCmp(text2, "hh", false) == 0) || (StringType.StrCmp(text2, "hour", false) == 0))
            {
                return DateAndTime.DateAdd(DateInterval.Hour, (double) num1, time1);
            }
            if (((StringType.StrCmp(text2, "mi", false) == 0) || (StringType.StrCmp(text2, "n", false) == 0)) || (StringType.StrCmp(text2, "minute", false) == 0))
            {
                return DateAndTime.DateAdd(DateInterval.Minute, (double) num1, time1);
            }
            if (((StringType.StrCmp(text2, "ss", false) == 0) || (StringType.StrCmp(text2, "s", false) == 0)) || (StringType.StrCmp(text2, "second", false) == 0))
            {
                return DateAndTime.DateAdd(DateInterval.Second, (double) num1, time1);
            }
            if ((StringType.StrCmp(text2, "ms", false) != 0) && (StringType.StrCmp(text2, "millisecond", false) != 0))
            {
                throw new DataException(string.Format("'{0}' is not a recognized dateadd option.", text1));
            }
            return time1.AddMilliseconds((double) num1);
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

