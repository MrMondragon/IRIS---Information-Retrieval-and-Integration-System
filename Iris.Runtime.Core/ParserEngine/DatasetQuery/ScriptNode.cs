namespace DatasetQuery
{
    using System;

    internal interface ScriptNode
    {
        void Accept(IVisitor visitor);
    }
}

