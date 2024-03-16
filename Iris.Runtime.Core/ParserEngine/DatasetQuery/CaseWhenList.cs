namespace DatasetQuery
{
    using System;
    using System.Collections;

    internal class CaseWhenList : ScriptNode
    {
        public CaseWhenList(CaseItem item)
        {
            this.List = new ArrayList();
            this.List.Insert(0, item);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (CaseItem item1 in this.List)
            {
                item1.Accept(visitor);
            }
        }

        public void Add(CaseItem item)
        {
            this.List.Insert(0, item);
        }


        internal ArrayList List;
    }
}

