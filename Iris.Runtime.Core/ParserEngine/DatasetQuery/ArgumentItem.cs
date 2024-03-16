namespace DatasetQuery
{
    using System;

    internal class ArgumentItem : ScriptNode
    {
        public ArgumentItem(bool All)
        {
            this.Star = All;
        }

        public ArgumentItem(DatasetQuery.Expression Expr, string alias)
        {
            this.Expression = Expr;
            this.AliasName = alias;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            if (this.Expression != null)
            {
                this.Expression.Accept(visitor);
            }
        }


        internal string AliasName;
        internal DatasetQuery.Expression Expression;
        internal bool Star;
    }
}

