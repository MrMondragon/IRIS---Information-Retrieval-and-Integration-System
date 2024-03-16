namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    internal class Date1Function : BaseFunction
    {
        public Date1Function(string name)
        {
            this.Part = name;
        }

        public override object Execute(object[] pars)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(pars[0]);
            if (obj2 != DBNull.Value)
            {
                DateTime time1 = DateType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(obj2), typeof(DateTime), 0));
                string text1 = this.Part;
                if (StringType.StrCmp(text1, "year", false) == 0)
                {
                    return time1.Year;
                }
                if (StringType.StrCmp(text1, "month", false) == 0)
                {
                    return time1.Month;
                }
                if (StringType.StrCmp(text1, "day", false) == 0)
                {
                    return time1.Day;
                }
                if (StringType.StrCmp(text1, "hour", false) == 0)
                {
                    return time1.Hour;
                }
                if (StringType.StrCmp(text1, "minute", false) == 0)
                {
                    return time1.Minute;
                }
                if (StringType.StrCmp(text1, "second", false) == 0)
                {
                    return time1.Second;
                }
                if (StringType.StrCmp(text1, "millisecond", false) == 0)
                {
                    return time1.Millisecond;
                }
                if (StringType.StrCmp(text1, "dayofyear", false) == 0)
                {
                    return time1.DayOfYear;
                }
                if (StringType.StrCmp(text1, "dayofweek", false) == 0)
                {
                    return time1.DayOfWeek;
                }
                if (StringType.StrCmp(text1, "timeofday", false) == 0)
                {
                    obj2 = time1.TimeOfDay;
                }
            }
            return obj2;
        }


        public override int ParameterCount
        {
            get
            {
                return 1;
            }
        }


        private string Part;
    }
}

