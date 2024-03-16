namespace DatasetQuery
{
    using System;
    using System.Data;

    internal class NullValue : Value
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void CalculateRow(DataRow row)
        {
        }

        public override object KeepRow(DataRow row)
        {
            return DBNull.Value;
        }


        public override bool IsConstant
        {
            get
            {
                return true;
            }
        }

    }
}

