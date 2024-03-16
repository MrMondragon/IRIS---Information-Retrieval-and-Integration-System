namespace DatasetQuery
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal abstract class FunctionValue : Value
    {
        public FunctionValue(string Name, ArgumentList List, int ParamCount)
        {
            if ((ParamCount >= 0) && (List.List.Count < ParamCount))
            {
                throw new DataException(string.Format("The {0} function requires {1} arguments.", Name, ParamCount));
            }
            this.Name = Name.ToLower();
            this.ParamList = List;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.ParamList.Accept(visitor);
        }

        public override void CalculateRow(DataRow row)
        {
            this.ParamList.CalculateRow(row);
        }

        public abstract object Execute(DataRow row, object[] pars);
        public override object KeepRow(DataRow row)
        {
            object obj2;
            if (this is AggregateFunctionValue)
            {
                obj2 = RuntimeHelpers.GetObjectValue(this.Execute(row, null));
            }
            else
            {
                object[] objArray1 = this.ParamList.GetParameters(row);
                obj2 = RuntimeHelpers.GetObjectValue(this.Execute(row, objArray1));
            }
            if (obj2 == null)
            {
                obj2 = DBNull.Value;
            }
            return obj2;
        }


        public override bool IsFunction
        {
            get
            {
                return true;
            }
        }


        internal string Name;
        protected ArgumentList ParamList;
    }
}

