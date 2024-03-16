namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class LikePredicate : Predicate
    {
        public LikePredicate(Expression Left, bool UseNot, Expression Right)
        {
            this.LeftExpression = Left;
            this.RightExpression = Right;
            this.NotApplied = UseNot;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.LeftExpression.Accept(visitor);
            this.RightExpression.Accept(visitor);
        }

        public override object KeepRow(DataRow row)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(this.LeftExpression.KeepRow(row));
            if (obj2 == DBNull.Value)
            {
                return false;
            }
            string text1 = StringType.FromObject(this.RightExpression.KeepRow(row));
            bool flag1 = ObjectType.LikeObj(LateBinding.LateGet(obj2, null, "ToUpper", new object[0], null, null), text1.Replace("%", "*").ToUpper(), CompareMethod.Binary);
            if (this.NotApplied)
            {
                flag1 = !flag1;
            }
            return flag1;
        }


        public override object IsLike
        {
            get
            {
                return true;
            }
        }


        internal Expression LeftExpression;
        internal bool NotApplied;
        internal Expression RightExpression;
    }
}

