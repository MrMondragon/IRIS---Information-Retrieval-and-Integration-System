namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class NullConstraint : ColumnConstraintType
    {
        public NullConstraint(bool Allow)
        {
            this.AllowNulls = Allow;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void CreateOnColumn(DataColumn dc)
        {
            try
            {
                dc.AllowDBNull = this.AllowNulls;
            }
            catch (OverflowException exception2)
            {
                ProjectData.SetProjectError(exception2);
                OverflowException exception1 = exception2;
                throw new DataException(exception1.Message, exception1);
            }
        }

        public override void CreateOnTable(DataTable dt)
        {
            throw new NotImplementedException();
        }


        internal bool AllowNulls;
    }
}

