namespace DatasetQuery
{
    using System;
    using System.Collections;
    using System.Data;

    internal class ExpressionList : ScriptNode
    {
        public ExpressionList(Expression item)
        {
            this.List = new ArrayList();
            this.List.Insert(0, item);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (Expression expression1 in this.List)
            {
                expression1.Accept(visitor);
            }
        }

        public void Add(Expression item)
        {
            this.List.Insert(0, item);
        }

        public object KeepRow(DataRow row)
        {
            throw new NotSupportedException();
        }


        internal ArrayList List;
    }
}

