namespace DatasetQuery
{
    using System;
    using System.Data;

    internal class CountAggregateFunction : AggregateFunctionValue
    {
        public CountAggregateFunction(string Name, ArgumentList List) : base(Name, List)
        {
        }

        public override void CalculateAggregate(object Value)
        {
        }

        public override object Execute(DataRow row, object[] pars)
        {
            return base.Count;
        }

    }
}

