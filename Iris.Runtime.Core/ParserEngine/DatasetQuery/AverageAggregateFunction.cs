namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class AverageAggregateFunction : AggregateFunctionValue
    {
        public AverageAggregateFunction(string Name, ArgumentList List) : base(Name, List)
        {
        }

        public override void CalculateAggregate(object Value)
        {
            if (base.Aggregate == null)
            {
                base.Aggregate = 0;
            }
            base.Aggregate = ObjectType.AddObj(base.Aggregate, Value);
        }

        public override object Execute(DataRow row, object[] pars)
        {
            if (base.Aggregate == null)
            {
                return RuntimeHelpers.GetObjectValue(base.Aggregate);
            }
            return ObjectType.DivObj(base.Aggregate, base.Count);
        }

    }
}

