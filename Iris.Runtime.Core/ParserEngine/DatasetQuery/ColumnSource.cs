namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class ColumnSource : ScriptNode
    {
        public ColumnSource(DatasetQuery.Expression Expr, string Alias)
        {
            this.AliasName = Alias.Replace("'", "").Replace("[", "").Replace("]", "");
            this.Expression = Expr;
            this.ColumnName = this.AliasName;
            this.Ordinal = -1;
        }

        public ColumnSource(string Name, DatasetQuery.Expression Expr)
        {
            this.AliasName = Name.Replace("'", "").Replace("[", "").Replace("]", "");
            this.Expression = Expr;
            this.ColumnName = this.AliasName;
            this.Ordinal = -1;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            if (this.Expression != null)
            {
                this.Expression.Accept(visitor);
            }
        }

        public DataColumn GetDataColumn(DataTable input)
        {
            DataColumn column1;
            DataColumn column3;
            if ((this.Expression == null) || this.Expression.IsColumnName)
            {
                if (input == null)
                {
                    throw new DataException(string.Format("Invalid column name '{0}'.", this.ColumnName));
                }
                column1 = Utilities.GetColumn(input.Columns, this.ColumnName);
                if (column1 == null)
                {
                    throw new DataException(string.Format("Invalid column name '{0}'.", this.ColumnName));
                }
                this.Ordinal = (short) column1.Ordinal;
                column3 = Utilities.CloneColumn(column1);
                this.TypeKnown = true;
                return column3;
            }
            if (this.Expression.IsCase)
            {
                return new DataColumn(this.ColumnName, this.Expression.GuessType());
            }
            if (this.Expression.IsConstant)
            {
                return new DataColumn(this.ColumnName, this.Expression.GuessType());
            }
            if (this.Expression.IsConvert)
            {
                ConvertValue value1 = (ConvertValue) this.Expression.RightExpression.Value;
                column3 = new DataColumn(this.ColumnName, value1.NewDataType.DotNetType);
                this.TypeKnown = true;
                return column3;
            }
            if (this.Expression.IsFunction)
            {
                return new DataColumn(this.ColumnName, this.Expression.GuessType());
            }
            if (this.Expression.IsSearchList)
            {
                return new DataColumn(this.ColumnName, this.Expression.GuessType());
            }
            if (this.Expression.IsSubQuery)
            {
                return new DataColumn(this.ColumnName, this.Expression.GuessType());
            }
            if (StringType.StrCmp(this.ColumnName, "", false) == 0)
            {
                throw new DataException("Internal error: unexpected column case");
            }
            if ((input == null) || (StringType.StrCmp(this.Expression.Operation, "", false) != 0))
            {
                return new DataColumn(this.ColumnName, this.Expression.GuessType());
            }
            column1 = input.Columns[this.ColumnName];
            if (column1 == null)
            {
                throw new DataException(string.Format("Invalid column name '{0}'.", this.ColumnName));
            }
            this.Ordinal = (short) column1.Ordinal;
            column3 = Utilities.CloneColumn(column1);
            this.TypeKnown = true;
            return column3;
        }

        public object ProcessValue(DataRow row)
        {
            if (!this.Expression.IsCase)
            {
                if (!this.Expression.IsColumnName)
                {
                    if (!this.Expression.IsConstant)
                    {
                        if (!this.Expression.IsConvert)
                        {
                            if (!this.Expression.IsFunction)
                            {
                                if (!this.Expression.IsSearchList)
                                {
                                    if (this.Expression.IsSubQuery)
                                    {
                                        throw new NotSupportedException();
                                    }
                                    if (StringType.StrCmp(this.ColumnName, "", false) == 0)
                                    {
                                        throw new DataException("Internal Error: unexpected column case");
                                    }
                                    if (StringType.StrCmp(this.Expression.Operation, "", false) == 0)
                                    {
                                        throw new NotSupportedException();
                                    }
                                    return RuntimeHelpers.GetObjectValue(this.Expression.KeepRow(row));
                                }
                                return RuntimeHelpers.GetObjectValue(this.Expression.KeepRow(row));
                            }
                            return RuntimeHelpers.GetObjectValue(this.Expression.KeepRow(row));
                        }
                        return RuntimeHelpers.GetObjectValue(this.Expression.RightExpression.Value.KeepRow(row));
                    }
                    return RuntimeHelpers.GetObjectValue(this.Expression.KeepRow(row));
                }
                return RuntimeHelpers.GetObjectValue(row[this.Ordinal]);
            }
            return RuntimeHelpers.GetObjectValue(this.Expression.KeepRow(row));
        }


        internal string AliasName;
        internal string ColumnName;
        internal short Count;
        internal DatasetQuery.Expression Expression;
        internal short Ordinal;
        internal bool TypeKnown;
    }
}

