namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class MaxAggregateFunction : AggregateFunctionValue
    {
        public MaxAggregateFunction(string Name, ArgumentList List) : base(Name, List)
        {
        }

        public override void CalculateAggregate(object Value)
        {
            if (base.Aggregate == null)
            {
                if (Information.IsNumeric(RuntimeHelpers.GetObjectValue(Value)))
                {
                    base.Aggregate = RuntimeHelpers.GetObjectValue(DataType.MinValue(Value.GetType()));
                }
                else
                {
                    if (!(Value is string))
                    {
                        throw new DataException("Max for data type '" + Value.GetType().ToString() + "' not implemented");
                    }
                    base.Aggregate = RuntimeHelpers.GetObjectValue(Value);
                }
            }
            if (ObjectType.ObjTst(Value, base.Aggregate, false) > 0)
            {
                base.Aggregate = RuntimeHelpers.GetObjectValue(Value);
            }
        }

        public override object Execute(DataRow row, object[] pars)
        {
            return base.Aggregate;
        }

    }
}

