namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using System;
    using System.Runtime.CompilerServices;

    internal class IsDateFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            return Information.IsDate(RuntimeHelpers.GetObjectValue(pars[0]));
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

