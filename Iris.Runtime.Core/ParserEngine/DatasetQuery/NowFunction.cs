namespace DatasetQuery
{
    using System;

    internal class NowFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            return DateTime.Now;
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

