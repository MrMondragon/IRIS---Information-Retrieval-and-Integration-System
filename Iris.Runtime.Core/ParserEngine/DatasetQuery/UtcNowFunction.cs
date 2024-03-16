namespace DatasetQuery
{
    using System;

    internal class UtcNowFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            return DateTime.UtcNow;
        }


        public override int ParameterCount
        {
            get
            {
                return 0;
            }
        }

    }
}

