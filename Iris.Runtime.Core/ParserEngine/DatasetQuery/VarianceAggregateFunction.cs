namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class VarianceAggregateFunction : AggregateFunctionValue
    {
        public VarianceAggregateFunction(string Name, ArgumentList List) : base(Name, List)
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
            return ObjectType.DivObj(ObjectType.SubObj(this.SumSqr, ObjectType.DivObj(ObjectType.MulObj(base.Aggregate, base.Aggregate), base.Count)), base.Count - 1);
        }


        private double SumSqr;
    }
}

