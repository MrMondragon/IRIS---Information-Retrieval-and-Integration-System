namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class IdentityConstraint : ColumnConstraintType
    {
        public IdentityConstraint()
        {
            this.Seed = 1;
            this.Increment = 1;
        }

        public IdentityConstraint(object Seed, object Increment)
        {
            this.Seed = RuntimeHelpers.GetObjectValue(Seed);
            this.Increment = RuntimeHelpers.GetObjectValue(Increment);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void CreateOnColumn(DataColumn dc)
        {
            string text1 = dc.DataType.Name;
            if (((StringType.StrCmp(text1, "Byte", false) != 0) && (StringType.StrCmp(text1, "Int16", false) != 0)) && ((StringType.StrCmp(text1, "Int32", false) != 0) && (StringType.StrCmp(text1, "Int64", false) != 0)))
            {
                throw new DataException("Identity column must be a numeric data type.");
            }
            if (this.Seed == DBNull.Value)
            {
                throw new DataException(string.Format("Identity column {0} seed is invalid.", dc.ColumnName));
            }
            if (this.Increment == DBNull.Value)
            {
                throw new DataException(string.Format("Identity column {0} increment is invalid.", dc.ColumnName));
            }
            try
            {
                dc.AutoIncrementSeed = LongType.FromObject(this.Seed);
                dc.AutoIncrementStep = LongType.FromObject(this.Increment);
                dc.AutoIncrement = true;
            }
            catch (Exception exception2)
            {
                ProjectData.SetProjectError(exception2);
                Exception exception1 = exception2;
                throw new DataException(exception1.Message, exception1);
            }
        }

        public override void CreateOnTable(DataTable dt)
        {
            throw new NotImplementedException();
        }


        internal object Increment;
        internal object Seed;
    }
}

