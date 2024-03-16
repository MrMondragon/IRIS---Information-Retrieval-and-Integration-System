namespace DatasetQuery
{
    using System;
    using System.Data;

    internal abstract class Value : ScriptNode
    {
        public abstract void Accept(IVisitor visitor);
        public abstract void CalculateRow(DataRow row);
        public abstract object KeepRow(DataRow row);

        public virtual string ColumnName
        {
            get
            {
                return "";
            }
        }

        public virtual bool IsCase
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsColumnName
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsConstant
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsConvert
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsFunction
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsSearchList
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsSubQuery
        {
            get
            {
                return false;
            }
        }

    }
}

