namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    internal class ChrWFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(pars[0]);
            if (obj2 != DBNull.Value)
            {
                obj2 = Strings.ChrW(IntegerType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(obj2), typeof(int), 0)));
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

    }
}

