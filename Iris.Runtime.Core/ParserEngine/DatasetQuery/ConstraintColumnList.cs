namespace DatasetQuery
{
    using System;
    using System.Collections;

    internal class ConstraintColumnList
    {
        public ConstraintColumnList(ConstraintColumn item)
        {
            this.List = new ArrayList();
            this.List.Add(item);
        }

        public void Add(ConstraintColumn item)
        {
            this.List.Add(item);
        }


        internal ArrayList List;
    }
}

