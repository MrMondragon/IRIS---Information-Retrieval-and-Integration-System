namespace DatasetQuery
{
    using System;
    using System.Runtime.CompilerServices;

    internal class IsNullFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(pars[0]);
            if (obj2 == DBNull.Value)
            {
                obj2 = RuntimeHelpers.GetObjectValue(pars[1]);
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

