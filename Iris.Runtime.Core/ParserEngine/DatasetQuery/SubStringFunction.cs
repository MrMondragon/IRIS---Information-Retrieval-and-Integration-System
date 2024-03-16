namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class SubStringFunction : BaseFunction
    {
        private void CheckParamLength(int actual, int expected)
        {
            if (actual < expected)
            {
                throw new DataException(string.Format("The Substring function requires {0} arguments.", expected));
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
            string text1 = StringType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[0]), typeof(string), 0));
            string text2 = StringType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[1]), typeof(int), 0));
            if ((DoubleType.FromString(text2) > 0) && (DoubleType.FromString(text2) <= text1.Length))
            {
                text2 = StringType.FromDouble(DoubleType.FromString(text2) - 1);
                if (pars.Length == 2)
                {
                    return text1.Substring(IntegerType.FromString(text2));
                }
                if (pars.Length != 3)
                {
                    throw new DataException(string.Format("The Substring function does not take {0} arguments.", pars.Length));
                }
                if (pars[2] == DBNull.Value)
                {
                    return obj2;
                }
                int num1 = IntegerType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[2]), typeof(int), 0));
                if (num1 <= 0)
                {
                    return string.Empty;
                }
                if (num1 >= text1.Length)
                {
                    return text1;
                }
                if ((DoubleType.FromString(text2) + num1) <= text1.Length)
                {
                    return text1.Substring(IntegerType.FromString(text2), num1);
                }
                return DBNull.Value;
            }
            return string.Empty;
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

