namespace DatasetQuery
{
    using System;

    internal class CaseItem : ScriptNode
    {
        public CaseItem(SearchList Search, Expression Result)
        {
            this.Search = Search;
            this.Result = Result;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.Search.Accept(visitor);
            this.Result.Accept(visitor);
        }


        internal Expression Result;
        internal SearchList Search;
    }
}

