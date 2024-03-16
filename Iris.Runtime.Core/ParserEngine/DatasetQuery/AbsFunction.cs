namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    internal class AbsFunction : BaseFunction
    {
        public override object Execute(object[] pars)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(pars[0]);
            if (obj2 == DBNull.Value)
            {
                return obj2;
            }
            switch (((IConvertible) obj2).GetTypeCode())
            {
                case TypeCode.SByte:
                    return Math.Abs((sbyte) obj2);

                case TypeCode.Int16:
                    return Math.Abs(ShortType.FromObject(obj2));

                case TypeCode.Int32:
                    return Math.Abs(IntegerType.FromObject(obj2));

                case TypeCode.Int64:
                    return Math.Abs(LongType.FromObject(obj2));

                case TypeCode.Single:
                    return Math.Abs(SingleType.FromObject(obj2));

                case TypeCode.Double:
                    return Math.Abs(DoubleType.FromObject(obj2));

                case TypeCode.Decimal:
                    return Math.Abs(DecimalType.FromObject(obj2));
            }
            double num1 = DoubleType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(obj2), typeof(double), 0));
            return Math.Abs(num1);
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

