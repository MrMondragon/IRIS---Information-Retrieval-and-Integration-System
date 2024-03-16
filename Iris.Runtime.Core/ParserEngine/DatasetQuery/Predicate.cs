namespace DatasetQuery
{
    using System;
    using System.Data;

    internal abstract class Predicate : ScriptNode
    {
        public abstract void Accept(IVisitor visitor);
        public virtual void CalculateRow(DataRow row)
        {
            throw new NotSupportedException();
        }

        public abstract object KeepRow(DataRow row);

        public virtual bool IsAggregate
        {
            get
            {
                return false;
            }
        }

        public virtual object IsBetween
        {
            get
            {
                return false;
            }
        }

        public virtual object IsComparison
        {
            get
            {
                return false;
            }
        }

        public virtual object IsExists
        {
            get
            {
                return false;
            }
        }

        public virtual object IsExpression
        {
            get
            {
                return false;
            }
        }

        public virtual object IsInLst
        {
            get
            {
                return false;
            }
        }

        public virtual object IsInQuery
        {
            get
            {
                return false;
            }
        }

        public virtual object IsLike
        {
            get
            {
                return false;
            }
        }

        public virtual object IsNull
        {
            get
            {
                return false;
            }
        }

    }
}

