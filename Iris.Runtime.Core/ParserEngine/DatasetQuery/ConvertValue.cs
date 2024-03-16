namespace DatasetQuery
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal class ConvertValue : Value
    {
        public ConvertValue(DataType type, DatasetQuery.Expression Expr, [Optional] int s /* = 0 */)
        {
            this.NewDataType = type;
            this.Expression = Expr;
            this.Style = s;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.Expression.Accept(visitor);
        }

        public override void CalculateRow(DataRow row)
        {
            this.Expression.CalculateRow(row);
        }

        public override object KeepRow(DataRow row)
        {
            return this.NewDataType.ConvertValue(RuntimeHelpers.GetObjectValue(this.Expression.KeepRow(row)));
        }


        public override bool IsConvert
        {
            get
            {
                return true;
            }
        }


        internal DatasetQuery.Expression Expression;
        internal DataType NewDataType;
        internal int Style;
    }
}

