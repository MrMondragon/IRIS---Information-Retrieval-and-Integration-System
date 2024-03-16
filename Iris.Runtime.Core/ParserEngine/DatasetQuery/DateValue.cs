namespace DatasetQuery
{
    using System;
    using System.Data;

    internal class DateValue : DatasetQuery.Value
    {
        public DateValue(DateTime v)
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


        public DateTime Value;
    }
}

