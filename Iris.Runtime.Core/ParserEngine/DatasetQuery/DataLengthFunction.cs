namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using System;
    using System.Runtime.CompilerServices;

    internal class DataLengthFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(pars[0]);
            if (obj2 == DBNull.Value)
            {
                return obj2;
            }
            if (obj2.GetType().IsArray)
            {
                return ((Array) obj2).Length;
            }
            return Strings.Len(RuntimeHelpers.GetObjectValue(obj2));
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

