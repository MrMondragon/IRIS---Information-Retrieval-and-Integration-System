namespace DatasetQuery
{
    using System;
    using System.Data;

    internal class FloatValue : DatasetQuery.Value
    {
        public FloatValue(double v)
        {
            this.Value = v;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void CalculateRow(DataRow row)
        {
        }

        public override object KeepRow(DataRow row)
        {
            return this.Value;
        }


        public override bool IsConstant
        {
            get
            {
                return true;
            }
        }


        public double Value;
    }
}

