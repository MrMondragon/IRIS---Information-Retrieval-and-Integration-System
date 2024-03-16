namespace DatasetQuery
{
    using System;

    internal class ArgListOpt : ScriptNode
    {
        public ArgListOpt(string Rest, ArgumentList List)
        {
            this.Restriction = Rest;
            this.ArgList = List;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.ArgList.Accept(visitor);
        }


        internal ArgumentList ArgList;
        internal string Restriction;
    }
}

