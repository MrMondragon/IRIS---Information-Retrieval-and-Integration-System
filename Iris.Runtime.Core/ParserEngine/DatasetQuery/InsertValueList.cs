namespace DatasetQuery
{
    using System;
    using System.Collections;
    using System.Data;

    internal class InsertValueList : ScriptNode
    {
        public InsertValueList(InsertValue item)
        {
            this.List = new ArrayList();
            this.List.Add(item);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (InsertValue value1 in this.List)
            {
                value1.Accept(visitor);
            }
        }

        public void Add(InsertValue item)
        {
            this.List.Add(item);
        }

        public BaseOperator Evaluate(DataSet ds)
        {
            throw new NotImplementedException();
        }


        internal ArrayList List;
    }
}

