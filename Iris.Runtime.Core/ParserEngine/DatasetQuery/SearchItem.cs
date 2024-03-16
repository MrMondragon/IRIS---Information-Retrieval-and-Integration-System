namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal class SearchItem : ScriptNode
    {
        public SearchItem(bool UseNot, DatasetQuery.Predicate Pred, string alias, [Optional] string Op /* = "" */)
        {
            this.NotApplied = UseNot;
            this.Predicate = Pred;
            this.AliasName = alias;
            this.Operation = Op.ToUpper();
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.Predicate.Accept(visitor);
        }

        public void CalculateRow(DataRow row)
        {
            throw new NotSupportedException();
        }

        public object KeepRow(DataRow row)
        {
            object obj1 = RuntimeHelpers.GetObjectValue(this.Predicate.KeepRow(row));
            if (this.NotApplied)
            {
                obj1 = ObjectType.NotObj(obj1);
            }
            return obj1;
        }


        internal string AliasName;
        internal bool NotApplied;
        internal string Operation;
        internal DatasetQuery.Predicate Predicate;
    }
}

