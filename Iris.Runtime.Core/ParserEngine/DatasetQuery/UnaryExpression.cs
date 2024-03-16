namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class UnaryExpression : ScriptNode
    {
        public UnaryExpression(DatasetQuery.Value v, string s)
        {
            this.Value = v;
            this.Sign = s;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.Value.Accept(visitor);
        }

        public void CalculateRow(DataRow row)
        {
            this.Value.CalculateRow(row);
        }

        public object KeepRow(DataRow row)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(this.Value.KeepRow(row));
            if (obj2 != DBNull.Value)
            {
                try
                {
                    if (StringType.StrCmp(this.Sign, "-", false) == 0)
                    {
                        return ObjectType.NegObj(obj2);
                    }
                    if (StringType.StrCmp(this.Sign, "~", false) != 0)
                    {
                        return obj2;
                    }
                    if ((obj2 is bool) && (ObjectType.ObjTst(obj2, true, false) == 0))
                    {
                        obj2 = 1;
                    }
                    obj2 = ObjectType.BitXorObj(obj2, -1);
                }
                catch (Exception exception2)
                {
                    ProjectData.SetProjectError(exception2);
                    Exception exception1 = exception2;
                    throw new DataException(exception1.Message);
                }
            }
            return obj2;
        }


        public string ColumnName
        {
            get
            {
                return this.Value.ColumnName;
            }
        }

        public bool IsAggregate
        {
            get
            {
                bool flag1=false;
                if (this.Value is AggregateFunctionValue)
                {
                    return true;
                }
                if (this.Value is ConvertValue)
                {
                    return ((ConvertValue) this.Value).Expression.IsAggregate;
                }
                if (this.Value is CaseValue)
                {
                    flag1 = ((CaseValue) this.Value).IsAggregate;
                }
                return flag1;
            }
        }

        public bool IsCase
        {
            get
            {
                return this.Value.IsCase;
            }
        }

        public bool IsColumnName
        {
            get
            {
                return this.Value.IsColumnName;
            }
        }

        public bool IsConstant
        {
            get
            {
                return this.Value.IsConstant;
            }
        }

        public bool IsConvert
        {
            get
            {
                return this.Value.IsConvert;
            }
        }

        public bool IsFunction
        {
            get
            {
                return this.Value.IsFunction;
            }
        }

        public bool IsSearchList
        {
            get
            {
                return this.Value.IsSearchList;
            }
        }

        public bool IsSubQuery
        {
            get
            {
                return this.Value.IsSubQuery;
            }
        }


        internal string Sign;
        internal DatasetQuery.Value Value;
    }
}

