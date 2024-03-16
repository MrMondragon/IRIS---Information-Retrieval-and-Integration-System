namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using System;
    using System.Runtime.CompilerServices;

    internal class IsNumericFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            if (Information.IsNumeric(RuntimeHelpers.GetObjectValue(pars[0])))
            {
                return 1;
            }
            return 0;
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

