namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class SumAggregateFunction : AggregateFunctionValue
    {
        public SumAggregateFunction(string Name, ArgumentList List) : base(Name, List)
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
            return base.Aggregate;
        }

    }
}

