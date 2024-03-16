namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class IndexOfFunction : BaseFunction
    {
        private void CheckParamLength(int actual, int expected)
        {
            if (actual < expected)
            {
                throw new DataException(string.Format("The CHARINDEX function requires {0} arguments.", expected));
            }
        }

        public override object Execute(object[] pars)
        {
            this.CheckParamLength(pars.Length, 2);
            object obj2 = DBNull.Value;
            if ((pars[0] == DBNull.Value) || (pars[1] == DBNull.Value))
            {
                return obj2;
            }
            string text2 = StringType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[0]), typeof(string), 0));
            string text1 = StringType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[1]), typeof(string), 0));
            if (pars.Length == 2)
            {
                return (text1.IndexOf(text2) + 1);
            }
            if ((pars.Length < 3) || (pars[2] == DBNull.Value))
            {
                return obj2;
            }
            int num1 = IntegerType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[2]), typeof(int), 0));
            if (num1 < 1)
            {
                num1 = 1;
            }
            if (num1 <= text1.Length)
            {
                num1--;
                if (pars.Length != 3)
                {
                    throw new DataException(string.Format("The CHARINDEX function does not take {0} arguments.", pars.Length));
                }
                return (text1.IndexOf(text2, num1) + 1);
            }
            return 0;
        }


        public override int ParameterCount
        {
            get
            {
                return -1;
            }
        }

    }
}

