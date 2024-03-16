namespace DatasetQuery
{
    using System;

    internal class ConstraintColumn
    {
        public ConstraintColumn(string Identifier, string SortType)
        {
            this.Name = Identifier.Replace("[", "").Replace("]", "");
            this.SortType = SortType;
        }


        internal string Name;
        internal string SortType;
    }
}

