namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class BetweenPredicate : Predicate
    {
        public BetweenPredicate(Expression Expr, bool UseNot, Expression Left, Expression Right)
        {
            this.LeftExpression = Expr;
            this.LeftBetween = Left;
            this.RightBetween = Right;
            this.NotApplied = UseNot;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.LeftExpression.Accept(visitor);
            this.LeftBetween.Accept(visitor);
            this.RightBetween.Accept(visitor);
        }

        public override object KeepRow(DataRow row)
        {
            object obj3 = RuntimeHelpers.GetObjectValue(this.LeftExpression.KeepRow(row));
            object obj2 = RuntimeHelpers.GetObjectValue(this.LeftBetween.KeepRow(row));
            object obj4 = RuntimeHelpers.GetObjectValue(this.RightBetween.KeepRow(row));
            bool flag1 = false;
            if (!(obj3 is DBNull))
            {
                flag1 = BooleanType.FromObject(ObjectType.BitAndObj(ObjectType.ObjTst(obj3, obj2, false) >= 0, ObjectType.ObjTst(obj3, obj4, false) <= 0));
            }
            if (this.NotApplied)
            {
                flag1 = !flag1;
            }
            return flag1;
        }


        public override object IsBetween
        {
            get
            {
                return true;
            }
        }


        internal Expression LeftBetween;
        internal Expression LeftExpression;
        internal bool NotApplied;
        internal Expression RightBetween;
    }
}

