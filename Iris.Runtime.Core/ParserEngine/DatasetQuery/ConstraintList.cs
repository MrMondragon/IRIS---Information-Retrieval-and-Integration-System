namespace DatasetQuery
{
    using System;
    using System.Collections;

    internal class ConstraintList
    {
        public ConstraintList(ColumnConstraintType item)
        {
            this.List = new ArrayList();
            this.List.Add(item);
        }

        public void Add(ColumnConstraintType item)
        {
            this.List.Add(item);
        }


        internal ArrayList List;
    }
}

