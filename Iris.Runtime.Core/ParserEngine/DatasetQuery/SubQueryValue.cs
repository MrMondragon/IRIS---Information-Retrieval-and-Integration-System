namespace DatasetQuery
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class SubQueryValue : Value
    {
        public SubQueryValue(SelectStm query)
        {
            this.SelectQuery = query;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.SelectQuery.Accept(visitor);
        }

        public override void CalculateRow(DataRow row)
        {
            throw new NotSupportedException();
        }

        public override object KeepRow(DataRow row)
        {
            if (this.subQueryValue == null)
            {
                this.subQueryValue = RuntimeHelpers.GetObjectValue(Utilities.ComputeScalar(row.Table.DataSet, this.SelectQuery));
            }
            return this.subQueryValue;
        }


        public override bool IsSubQuery
        {
            get
            {
                return true;
            }
        }


        public SelectStm SelectQuery;
        internal object subQueryValue;
    }
}

