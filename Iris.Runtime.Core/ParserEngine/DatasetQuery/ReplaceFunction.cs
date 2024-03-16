namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    internal class ReplaceFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            object obj2 = DBNull.Value;
            object obj3 = RuntimeHelpers.GetObjectValue(pars[0]);
            object obj4 = RuntimeHelpers.GetObjectValue(pars[1]);
            object obj5 = RuntimeHelpers.GetObjectValue(pars[2]);
            if (((obj3 != DBNull.Value) && (obj4 != DBNull.Value)) && (obj5 != DBNull.Value))
            {
                string text1 = StringType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(obj3), typeof(string), 0));
                string text2 = StringType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(obj4), typeof(string), 0));
                string text3 = StringType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(obj5), typeof(string), 0));
                obj2 = text1.Replace(text2, text3);
            }
            return obj2;
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

