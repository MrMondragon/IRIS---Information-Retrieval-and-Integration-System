namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class RandFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            object obj2 = DBNull.Value;
            switch (pars.Length)
            {
                case 0:
                    return VBMath.Rnd();

                case 1:
                    if (pars[0] != DBNull.Value)
                    {
                        obj2 = VBMath.Rnd(SingleType.FromObject(pars[0]));
                    }
                    return obj2;
            }
            throw new DataException("The rand function requires 0 to 1 arguments.");
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

