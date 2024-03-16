namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class CaseValue : Value
    {
        public CaseValue(Expression CaseExpr, CaseWhenList List, Expression ElseExpr)
        {
            this.CaseExpression = CaseExpr;
            this.WhenList = List;
            this.ElseExpression = ElseExpr;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            if (this.CaseExpression != null)
            {
                this.CaseExpression.Accept(visitor);
            }
            this.WhenList.Accept(visitor);
            if (this.ElseExpression != null)
            {
                this.ElseExpression.Accept(visitor);
            }
        }

        public override void CalculateRow(DataRow row)
        {
            if (this.CaseExpression != null)
            {
                this.CaseExpression.CalculateRow(row);
            }
            foreach (CaseItem item1 in this.WhenList.List)
            {
                item1.Search.CalculateRow(row);
                item1.Result.CalculateRow(row);
            }
            if (this.ElseExpression != null)
            {
                this.ElseExpression.CalculateRow(row);
            }
        }

        public override object KeepRow(DataRow row)
        {
            object obj1;
            object obj3 = null;
            bool flag1 = false;
            if (this.CaseExpression != null)
            {
                object obj4 = RuntimeHelpers.GetObjectValue(this.CaseExpression.KeepRow(row));
                if (obj4 is string)
                {
                    obj4 = StringType.FromObject(obj4).Trim();
                }
                foreach (CaseItem item1 in this.WhenList.List)
                {
                    obj1 = RuntimeHelpers.GetObjectValue(item1.Search.KeepRow(row));
                    if (ObjectType.ObjTst(obj1, obj4, false) == 0)
                    {
                        obj3 = RuntimeHelpers.GetObjectValue(item1.Result.KeepRow(row));
                        flag1 = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (CaseItem item2 in this.WhenList.List)
                {
                    obj1 = RuntimeHelpers.GetObjectValue(item2.Search.KeepRow(row));
                    if ((obj1 != DBNull.Value) && (ObjectType.ObjTst(obj1, false, false) != 0))
                    {
                        if (ObjectType.ObjTst(obj1, true, false) == 0)
                        {
                            obj3 = RuntimeHelpers.GetObjectValue(item2.Result.KeepRow(row));
                            flag1 = true;
                            break;
                        }
                        throw new DataException("Internal Error: Unexpected result in CASE expression");
                    }
                }
            }
            if (!flag1 && (this.ElseExpression != null))
            {
                obj3 = RuntimeHelpers.GetObjectValue(this.ElseExpression.KeepRow(row));
            }
            return obj3;
        }


        public bool IsAggregate
        {
            get
            {
                bool flag1 = false;
                if ((this.ElseExpression != null) && this.ElseExpression.IsAggregate)
                {
                    throw new DataException("Invalid use of aggregate in CASE ELSE expression.");
                }
                if (this.CaseExpression != null)
                {
                    flag1 = this.CaseExpression.IsAggregate;
                }
                if (!flag1)
                {
                    foreach (CaseItem item1 in this.WhenList.List)
                    {
                        flag1 = item1.Search.IsAggregate || item1.Result.IsAggregate;
                        if (flag1)
                        {
                            return flag1;
                        }
                    }
                }
                return flag1;
            }
        }

        public override bool IsCase
        {
            get
            {
                return true;
            }
        }


        internal Expression CaseExpression;
        internal Expression ElseExpression;
        internal CaseWhenList WhenList;
    }
}

