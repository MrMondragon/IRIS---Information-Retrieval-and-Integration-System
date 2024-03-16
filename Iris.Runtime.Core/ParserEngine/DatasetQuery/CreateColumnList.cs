namespace DatasetQuery
{
    using System;
    using System.Collections;
    using System.Data;

    internal class CreateColumnList : ScriptNode
    {
        public CreateColumnList(CreateColumn item)
        {
            this.List = new ArrayList();
            this.TableList = new ArrayList();
            this.Add(item);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            try
            {
                foreach (CreateColumn column1 in this.List)
                {
                    column1.Accept(visitor);
                }
            }
            finally
            {
                IEnumerator enumerator2=null;
                if (enumerator2 is IDisposable)
                {
                    ((IDisposable) enumerator2).Dispose();
                }
            }
            foreach (CreateColumn column2 in this.TableList)
            {
                column2.Accept(visitor);
            }
        }

        public void Add(CreateColumn item)
        {
            if (item is ColumnTableConstraint)
            {
                this.TableList.Add(item);
            }
            else
            {
                this.List.Add(item);
            }
        }

        public void Create(DataTable dt)
        {
            try
            {
                foreach (CreateColumn column1 in this.List)
                {
                    column1.Create(dt);
                }
            }
            finally
            {
                IEnumerator enumerator2=null;
                if (enumerator2 is IDisposable)
                {
                    ((IDisposable) enumerator2).Dispose();
                }
            }
            foreach (CreateColumn column2 in this.TableList)
            {
                column2.Create(dt);
            }
        }


        internal ArrayList List;
        internal ArrayList TableList;
    }
}

