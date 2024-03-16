namespace DatasetQuery
{
    using System;
    using System.Data;

    internal class AssignValue : ScriptNode
    {
        public AssignValue(string Identifier, InsertValue item)
        {
            this.Name = Identifier.Replace("[", "").Replace("]", "");
            this.Value = item;
            this.Ordinal = -1;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            if (this.Value != null)
            {
                this.Value.Accept(visitor);
            }
        }

        public BaseOperator Evaluate(DataSet ds)
        {
            throw new NotImplementedException();
        }


        internal string Name;
        internal int Ordinal;
        internal InsertValue Value;
    }
}

