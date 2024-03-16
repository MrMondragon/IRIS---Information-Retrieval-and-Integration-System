namespace DatasetQuery
{
    using System;
    using System.Collections;

    internal class ColumnList : ScriptNode
    {
        public ColumnList(ColumnSource item)
        {
            this.List = new ArrayList();
            this.List.Insert(0, item);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (ColumnSource source1 in this.List)
            {
                source1.Accept(visitor);
            }
        }

        public void Add(ColumnSource item)
        {
            this.List.Insert(0, item);
        }

        public void Optimize()
        {
            try
            {
                foreach (ColumnSource source1 in this.List)
                {
                    if (source1.Expression != null)
                    {
                        Expression expression1 = source1.Expression;
                        if (expression1.IsColumnName)
                        {
                            source1.ColumnName = expression1.ColumnName;
                        }
                        expression1 = null;
                    }
                }
            }
            finally
            {
                IEnumerator enumerator1 = null;
                if (enumerator1 is IDisposable)
                {
                    ((IDisposable) enumerator1).Dispose();
                }
            }
        }


        internal ArrayList List;
    }
}

