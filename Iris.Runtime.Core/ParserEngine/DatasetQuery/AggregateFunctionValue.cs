namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal abstract class AggregateFunctionValue : FunctionValue
    {
        public AggregateFunctionValue(string Name, ArgumentList ArgList) : base(Name, ArgList, 1)
        {
            this.AggArgument = (ArgumentItem) ArgList.List[0];
            if ((this.AggArgument.Expression != null) && (this.AggArgument.Expression.IsSubQuery || this.AggArgument.Expression.IsAggregate))
            {
                throw new DataException("Cannot perform an aggregate function on an expression containing an aggregate or a subquery.");
            }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.AggArgument.Accept(visitor);
        }

        public abstract void CalculateAggregate(object Value);
        public override void CalculateRow(DataRow row)
        {
            if (row == null)
            {
                this.Aggregate = null;
                this.Count = 0;
            }
            else
            {
                object obj1 = null;
                if (this.AggArgument != null)
                {
                    if (!this.AggArgument.Star)
                    {
                        obj1 = RuntimeHelpers.GetObjectValue(this.AggArgument.Expression.KeepRow(row));
                    }
                    if (obj1 != DBNull.Value)
                    {
                        if (obj1 is string)
                        {
                            obj1 = StringType.FromObject(obj1).Trim();
                        }
                        this.CalculateAggregate(RuntimeHelpers.GetObjectValue(obj1));
                        this.Count++;
                    }
                }
            }
        }


        public bool IsAggregate
        {
            get
            {
                return true;
            }
        }


        protected ArgumentItem AggArgument;
        protected object Aggregate;
        protected int Count;
    }
}

