namespace DatasetQuery
{
    using System;
    using System.Data;

    internal class RowGuidConstraint : ColumnConstraintType
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void CreateOnColumn(DataColumn dc)
        {
        }

        public override void CreateOnTable(DataTable dt)
        {
        }

    }
}

