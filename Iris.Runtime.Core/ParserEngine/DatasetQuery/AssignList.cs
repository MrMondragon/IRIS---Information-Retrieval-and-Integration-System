namespace DatasetQuery
{
    using System;
    using System.Collections;
    using System.Data;

    internal class AssignList : ScriptNode
    {
        public AssignList(AssignValue item)
        {
            this.List = new ArrayList();
            this.List.Insert(0, item);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (AssignValue value1 in this.List)
            {
                value1.Accept(visitor);
            }
        }

        public void Add(AssignValue item)
        {
            this.List.Insert(0, item);
        }

        public void CheckForDuplicates()
        {
            ArrayList list1 = new ArrayList();
            foreach (AssignValue value1 in this.List)
            {
                if (list1.Contains(value1.Name))
                {
                    throw new DataException(string.Format("Column name '{0}' appears more than once in the column list.", value1.Name));
                }
                list1.Add(value1.Name);
            }
        }

        public BaseOperator Evaluate(DataSet ds)
        {
            throw new NotImplementedException();
        }


        internal ArrayList List;
    }
}

