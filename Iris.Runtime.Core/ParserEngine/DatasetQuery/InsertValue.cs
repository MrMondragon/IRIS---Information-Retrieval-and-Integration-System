namespace DatasetQuery
{
    using System;
    using System.Data;

    internal class InsertValue : ScriptNode
    {
        public InsertValue()
        {
            this.Expr = null;
        }

        public InsertValue(Expression item)
        {
            this.Expr = item;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            if (this.Expr != null)
            {
                this.Expr.Accept(visitor);
            }
        }

        public BaseOperator Evaluate(DataSet ds)
        {
            throw new NotImplementedException();
        }


        internal Expression Expr;
    }
}

