namespace DatasetQuery
{
    using System;
    using System.Data;

    internal class ExistsPredicate : Predicate
    {
        public ExistsPredicate(UnionList Query)
        {
            this.SelectQuery = Query;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.SelectQuery.Accept(visitor);
        }

        public override object KeepRow(DataRow row)
        {
            bool flag1 = false;
            if (row != null)
            {
                flag1 = Utilities.Exists(row.Table.DataSet, this.SelectQuery);
            }
            return flag1;
        }


        public override object IsExists
        {
            get
            {
                return true;
            }
        }


        internal UnionList SelectQuery;
    }
}

