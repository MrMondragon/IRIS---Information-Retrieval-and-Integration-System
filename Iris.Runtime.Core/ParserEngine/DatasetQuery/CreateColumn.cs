namespace DatasetQuery
{
    using System;
    using System.Data;

    internal abstract class CreateColumn : ScriptNode
    {
        public abstract void Accept(IVisitor visitor);
        public abstract void Create(DataTable dt);
    }
}

