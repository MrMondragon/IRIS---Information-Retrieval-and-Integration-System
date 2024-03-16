namespace DatasetQuery
{
    using System;
    using System.Data;

    internal class SearchValue : Value
    {
        public SearchValue(DatasetQuery.SearchList Search)
        {
            this.SearchList = Search;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.SearchList.Accept(visitor);
        }

        public override void CalculateRow(DataRow row)
        {
            this.SearchList.CalculateRow(row);
        }

        public override object KeepRow(DataRow row)
        {
            return this.SearchList.KeepRow(row);
        }


        public override bool IsSearchList
        {
            get
            {
                return true;
            }
        }


        public DatasetQuery.SearchList SearchList;
    }
}

