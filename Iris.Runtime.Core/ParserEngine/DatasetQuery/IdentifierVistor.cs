namespace DatasetQuery
{
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;

    internal class IdentifierVistor : IVisitor
    {
        public IdentifierVistor()
        {
            this.List = new ArrayList();
        }

        public void Visit(object obj)
        {
            if (obj is IdentifierValue)
            {
                this.List.Add(RuntimeHelpers.GetObjectValue(obj));
            }
        }


        public ArrayList List;
    }
}

