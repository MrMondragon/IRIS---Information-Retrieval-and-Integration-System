namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    internal class PowerFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(pars[0]);
            object obj3 = RuntimeHelpers.GetObjectValue(pars[1]);
            if ((obj2 != DBNull.Value) && (obj3 != DBNull.Value))
            {
                obj2 = Math.Pow(DoubleType.FromObject(obj2), DoubleType.FromObject(obj3));
            }
            return obj2;
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

