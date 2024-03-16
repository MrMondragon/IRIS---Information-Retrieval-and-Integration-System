namespace DatasetQuery
{
    using System;
    using System.Collections;

    internal class IdentifierInGroupByVistor : IVisitor
    {
        public IdentifierInGroupByVistor()
        {
            this.List = new ArrayList();
        }

        public void Visit(object obj)
        {
            if (obj is IdentifierValue)
            {
                this.List.Add(((IdentifierValue) obj).Identifier);
            }
        }


        public ArrayList List;
    }
}

