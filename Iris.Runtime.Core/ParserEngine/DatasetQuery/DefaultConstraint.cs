namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class DefaultConstraint : ColumnConstraintType
    {
        public DefaultConstraint(Expression Value)
        {
            this.DefaultValue = Value;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.DefaultValue.Accept(visitor);
        }

        public override void CreateOnColumn(DataColumn dc)
        {
            try
            {
                object obj1 = RuntimeHelpers.GetObjectValue(this.DefaultValue.KeepRow(null));
                if (!(dc.DataType is object) && (obj1.GetType().IsArray != dc.DataType.IsArray))
                {
                    throw new DataException(string.Format("Column '{0}' binary default value is incompatible with data type.", dc.ColumnName));
                }
                dc.DefaultValue = RuntimeHelpers.GetObjectValue(DataType.ConvertValue(RuntimeHelpers.GetObjectValue(obj1), dc.DataType, dc.MaxLength));
            }
            catch (OverflowException exception2)
            {
                ProjectData.SetProjectError(exception2);
                OverflowException exception1 = exception2;
                throw new DataException(exception1.Message, exception1);
            }
            if ((dc.DefaultValue == DBNull.Value) && !dc.AllowDBNull)
            {
                throw new DataException(string.Format("Column '{0}' does not allow nulls.", dc.ColumnName));
            }
        }

        public override void CreateOnTable(DataTable dt)
        {
            throw new NotImplementedException();
        }


        internal Expression DefaultValue;
    }
}

