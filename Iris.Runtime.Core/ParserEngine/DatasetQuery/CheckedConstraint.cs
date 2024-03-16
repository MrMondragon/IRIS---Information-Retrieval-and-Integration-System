namespace DatasetQuery
{
    using System;
    using System.Data;

    internal class CheckedConstraint : ColumnConstraintType
    {
        public CheckedConstraint(SearchList Search)
        {
            this.Search = Search;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void CreateOnColumn(DataColumn dc)
        {
            throw new NotImplementedException();
        }

        public override void CreateOnTable(DataTable dt)
        {
            throw new NotImplementedException();
        }


        internal SearchList Search;
    }
}

