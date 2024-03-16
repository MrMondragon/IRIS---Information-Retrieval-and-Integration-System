namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class StdDevAggregateFunction : AggregateFunctionValue
    {
        public StdDevAggregateFunction(string Name, ArgumentList List) : base(Name, List)
        {
        }

        public override void CalculateAggregate(object Value)
        {
            if (base.Aggregate == null)
            {
                base.Aggregate = 0;
                this.SumSqr = 0;
            }
            base.Aggregate = ObjectType.AddObj(base.Aggregate, Value);
            this.SumSqr = DoubleType.FromObject(ObjectType.AddObj(this.SumSqr, ObjectType.MulObj(Value, Value)));
        }

        public override object Execute(DataRow row, object[] pars)
        {
            return Math.Sqrt(DoubleType.FromObject(ObjectType.DivObj(ObjectType.SubObj(base.Count * this.SumSqr, ObjectType.MulObj(base.Aggregate, base.Aggregate)), base.Count * (base.Count - 1))));
        }


        private double SumSqr;
    }
}

