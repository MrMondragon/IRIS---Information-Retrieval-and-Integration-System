namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class Comparisons : Predicate
    {
        public Comparisons(Expression Left, string Op, Expression Right)
        {
            this.LeftExpression = Left;
            this.Operation = Op;
            this.RightExpression = Right;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.LeftExpression.Accept(visitor);
            if (this.RightExpression != null)
            {
                this.RightExpression.Accept(visitor);
            }
        }

        public override void CalculateRow(DataRow row)
        {
            this.LeftExpression.CalculateRow(row);
            if (this.RightExpression != null)
            {
                this.RightExpression.CalculateRow(row);
            }
        }

        public override object KeepRow(DataRow row)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(this.LeftExpression.KeepRow(row));
            if (this.RightExpression != null)
            {
                object obj3 = RuntimeHelpers.GetObjectValue(this.RightExpression.KeepRow(row));
                if ((obj2 != DBNull.Value) && (obj3.GetType() != obj2.GetType()))
                {
                    if (Information.IsNumeric(RuntimeHelpers.GetObjectValue(obj3)) && (obj2 is string))
                    {
                        obj2 = RuntimeHelpers.GetObjectValue(DataType.ConvertValue(RuntimeHelpers.GetObjectValue(obj2), obj3.GetType(), 0));
                    }
                    else
                    {
                        obj3 = RuntimeHelpers.GetObjectValue(DataType.ConvertValue(RuntimeHelpers.GetObjectValue(obj3), obj2.GetType(), 0));
                    }
                }
                bool flag1 = obj2 == DBNull.Value;
                bool flag2 = obj3 == DBNull.Value;
                if (!flag1 && !flag2)
                {
                    string text1 = this.Operation;
                    if (StringType.StrCmp(text1, "=", false) != 0)
                    {
                        if (StringType.StrCmp(text1, "<=", false) != 0)
                        {
                            if (StringType.StrCmp(text1, ">=", false) != 0)
                            {
                                if ((StringType.StrCmp(text1, "<>", false) != 0) && (StringType.StrCmp(text1, "!=", false) != 0))
                                {
                                    if (StringType.StrCmp(text1, "<", false) != 0)
                                    {
                                        if (StringType.StrCmp(text1, ">", false) != 0)
                                        {
                                            throw new NotSupportedException();
                                        }
                                        return RuntimeHelpers.GetObjectValue(ObjectType.ObjTst(obj2, obj3, false) > 0);
                                    }
                                    return RuntimeHelpers.GetObjectValue(ObjectType.ObjTst(obj2, obj3, false) < 0);
                                }
                                return !obj2.Equals(RuntimeHelpers.GetObjectValue(obj3));
                            }
                            return RuntimeHelpers.GetObjectValue(ObjectType.ObjTst(obj2, obj3, false) >= 0);
                        }
                        return RuntimeHelpers.GetObjectValue(ObjectType.ObjTst(obj2, obj3, false) <= 0);
                    }
                    return obj2.Equals(RuntimeHelpers.GetObjectValue(obj3));
                }
                return false;
            }
            return obj2;
        }


        public override bool IsAggregate
        {
            get
            {
                return (this.LeftExpression.IsAggregate || ((this.RightExpression != null) && this.RightExpression.IsAggregate));
            }
        }

        public override object IsComparison
        {
            get
            {
                return (StringType.StrCmp(this.Operation, "", false) != 0);
            }
        }

        public override object IsExpression
        {
            get
            {
                return (this.RightExpression == null);
            }
        }


        internal Expression LeftExpression;
        internal string Operation;
        internal Expression RightExpression;
    }
}

