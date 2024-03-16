namespace DatasetQuery
{
    using System;

    internal class IdItem : ScriptNode
    {
        public IdItem(DatasetQuery.Expression Expr, string alias)
        {
            this.Expression = Expr;
            this.AliasName = alias;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.Expression.Accept(visitor);
        }


        internal string AliasName;
        internal DatasetQuery.Expression Expression;
    }
}

