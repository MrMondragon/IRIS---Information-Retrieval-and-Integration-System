namespace DatasetQuery
{
    using System;

    internal class TopStm : ScriptNode
    {
        public TopStm(int rows, bool Percent)
        {
            this.MaxRows = rows;
            this.AsPercent = Percent;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }


        internal bool AsPercent;
        internal int MaxRows;
    }
}

