namespace DatasetQuery
{
    using System;

    internal class NewGuidFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            return Guid.NewGuid();
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

