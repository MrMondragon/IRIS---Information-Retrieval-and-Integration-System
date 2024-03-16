namespace DatasetQuery
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class IsNullPredicate : Predicate
    {
        public IsNullPredicate(Expression Left, bool UseNot)
        {
            this.LeftExpression = Left;
            this.NotApplied = UseNot;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.LeftExpression.Accept(visitor);
        }

        public override object KeepRow(DataRow row)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(this.LeftExpression.KeepRow(row));
            bool flag1 = obj2 == DBNull.Value;
            if (this.NotApplied)
            {
                flag1 = !flag1;
            }
            return flag1;
        }


        public override object IsNull
        {
            get
            {
                return true;
            }
        }


        internal Expression LeftExpression;
        internal bool NotApplied;
    }
}

