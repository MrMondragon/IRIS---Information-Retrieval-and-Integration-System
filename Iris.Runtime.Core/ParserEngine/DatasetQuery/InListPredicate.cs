namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class InListPredicate : Predicate
    {
        public InListPredicate(Expression Left, bool UseNot, ExpressionList ExprList)
        {
            this.LeftExpression = Left;
            this.NotApplied = UseNot;
            this.List = ExprList;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.LeftExpression.Accept(visitor);
            this.List.Accept(visitor);
        }

        public override object KeepRow(DataRow row)
        {
            object obj1 = false;
            object obj2 = RuntimeHelpers.GetObjectValue(this.LeftExpression.KeepRow(row));
            if (obj2 != DBNull.Value)
            {
                foreach (Expression expression1 in this.List.List)
                {
                    if (ObjectType.ObjTst(expression1.KeepRow(null), obj2, false) == 0)
                    {
                        obj1 = true;
                        break;
                    }
                }
                if (this.NotApplied)
                {
                    obj1 = ObjectType.NotObj(obj1);
                }
            }
            return obj1;
        }


        public override object IsInLst
        {
            get
            {
                return true;
            }
        }


        internal Expression LeftExpression;
        internal ExpressionList List;
        internal bool NotApplied;
    }
}

