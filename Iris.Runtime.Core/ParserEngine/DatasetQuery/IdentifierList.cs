namespace DatasetQuery
{
    using System;
    using System.Collections;

    internal class IdentifierList
    {
        public IdentifierList(string item)
        {
            this.List = new ArrayList();
            this.List.Add(item.Replace("[", "").Replace("]", ""));
        }

        public void Add(string item)
        {
            this.List.Add(item.Replace("[", "").Replace("]", ""));
        }


        internal ArrayList List;
    }
}

