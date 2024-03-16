namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class Expression : ScriptNode
    {
        public Expression(Expression Left, string Op, UnaryExpression Right)
        {
            this.LeftExpression = Left;
            this.Operation = Op;
            this.RightExpression = Right;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            if (this.LeftExpression != null)
            {
                this.LeftExpression.Accept(visitor);
            }
            this.RightExpression.Accept(visitor);
        }

        public void CalculateRow(DataRow row)
        {
            this.RightExpression.CalculateRow(row);
            if (this.LeftExpression != null)
            {
                this.LeftExpression.CalculateRow(row);
            }
        }

        public Type GuessType()
        {
            if (this.LeftExpression == null)
            {
                if (this.RightExpression.IsConstant)
                {
                    Value value1 = this.RightExpression.Value;
                    if (value1 is Int64Value)
                    {
                        return typeof(long);
                    }
                    if (value1 is Int32Value)
                    {
                        return typeof(int);
                    }
                    if (value1 is Int16Value)
                    {
                        return typeof(short);
                    }
                    if (value1 is ByteValue)
                    {
                        return typeof(byte);
                    }
                    if (value1 is DecimalValue)
                    {
                        return typeof(decimal);
                    }
                    if (value1 is RealValue)
                    {
                        return typeof(float);
                    }
                    if (value1 is FloatValue)
                    {
                        return typeof(double);
                    }
                    if (value1 is StringValue)
                    {
                        return typeof(string);
                    }
                    return typeof(string);
                }
                if (this.RightExpression.IsAggregate)
                {
                    return typeof(decimal);
                }
                return typeof(object);
            }
            return typeof(string);
        }

        public object KeepRow(DataRow row)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(this.RightExpression.KeepRow(row));
            if ((obj2 != DBNull.Value) && (this.LeftExpression != null))
            {
                object obj3 = RuntimeHelpers.GetObjectValue(this.LeftExpression.KeepRow(row));
                if (obj3 == DBNull.Value)
                {
                    return RuntimeHelpers.GetObjectValue(obj3);
                }
                try
                {
                    string text1 = this.Operation;
                    if (StringType.StrCmp(text1, "+", false) == 0)
                    {
                        if (obj2 is DateTime)
                        {
                            return DateType.FromObject(obj2).AddDays(DoubleType.FromObject(obj3));
                        }
                        return ObjectType.AddObj(obj3, obj2);
                    }
                    if (StringType.StrCmp(text1, "-", false) == 0)
                    {
                        if (obj2 is DateTime)
                        {
                            return DateType.FromObject(obj2).AddDays(DoubleType.FromObject(ObjectType.NegObj(obj3)));
                        }
                        return ObjectType.SubObj(obj3, obj2);
                    }
                    if (StringType.StrCmp(text1, "*", false) == 0)
                    {
                        return ObjectType.MulObj(obj3, obj2);
                    }
                    if (StringType.StrCmp(text1, "/", false) == 0)
                    {
                        return ObjectType.DivObj(obj3, obj2);
                    }
                    if (StringType.StrCmp(text1, "&", false) == 0)
                    {
                        return ObjectType.BitAndObj(obj3, obj2);
                    }
                    if (StringType.StrCmp(text1, "|", false) == 0)
                    {
                        return ObjectType.BitOrObj(obj3, obj2);
                    }
                    if (StringType.StrCmp(text1, "^", false) == 0)
                    {
                        return ObjectType.BitXorObj(obj3, obj2);
                    }
                    if (StringType.StrCmp(text1, "%", false) != 0)
                    {
                        throw new NotSupportedException();
                    }
                    obj2 = ObjectType.ModObj(obj3, obj2);
                }
                catch (NotSupportedException exception3)
                {
                    ProjectData.SetProjectError(exception3);
                    NotSupportedException exception1 = exception3;
                    throw;
                }
                catch (Exception exception4)
                {
                    ProjectData.SetProjectError(exception4);
                    Exception exception2 = exception4;
                    throw new DataException(string.Format("Invalid operator '{0}' for data type {1}.", this.Operation, obj2.GetType().ToString()));
                }
            }
            return obj2;
        }


        public string ColumnName
        {
            get
            {
                return this.RightExpression.ColumnName;
            }
        }

        public bool IsAggregate
        {
            get
            {
                bool flag1 = false;
                if (this.LeftExpression != null)
                {
                    flag1 = this.LeftExpression.IsAggregate;
                }
                if (!flag1 && !this.RightExpression.IsAggregate)
                {
                    return false;
                }
                return true;
            }
        }

        public bool IsCase
        {
            get
            {
                if ((this.LeftExpression == null) && this.RightExpression.IsCase)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsColumnName
        {
            get
            {
                if ((this.LeftExpression == null) && this.RightExpression.IsColumnName)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsConstant
        {
            get
            {
                if ((this.LeftExpression == null) && this.RightExpression.IsConstant)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsConvert
        {
            get
            {
                if ((this.LeftExpression == null) && this.RightExpression.IsConvert)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsFunction
        {
            get
            {
                if ((this.LeftExpression == null) && this.RightExpression.IsFunction)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsSearchList
        {
            get
            {
                if ((this.LeftExpression == null) && this.RightExpression.IsSearchList)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsSubQuery
        {
            get
            {
                if ((this.LeftExpression == null) && this.RightExpression.IsSubQuery)
                {
                    return true;
                }
                return false;
            }
        }


        internal Expression LeftExpression;
        internal string Operation;
        internal UnaryExpression RightExpression;
    }
}

