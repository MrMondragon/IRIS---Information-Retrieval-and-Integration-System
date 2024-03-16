namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class IdentifierValue : Value
    {
        public IdentifierValue(string Name)
        {
            this.Ordinal = -1;
            this.Identifier = Name;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void CalculateRow(DataRow row)
        {
        }

        public override object KeepRow(DataRow row)
        {
            object obj2 = DBNull.Value;
            if (row == null)
            {
                return obj2;
            }
            if (this.Ordinal == -1)
            {
                DataColumn column1 = null;
                if (row != null)
                {
                    column1 = Utilities.GetColumn(row.Table.Columns, this.Identifier);
                }
                if (column1 == null)
                {
                    throw new DataException("Invalid column name '" + this.Identifier + "'");
                }
                this.Ordinal = column1.Ordinal;
            }
            obj2 = RuntimeHelpers.GetObjectValue(row[this.Ordinal]);
            if (!(obj2 is bool))
            {
                return obj2;
            }
            if (BooleanType.FromObject(obj2))
            {
                return 1;
            }
            return 0;
        }


        public override string ColumnName
        {
            get
            {
                return this.Identifier;
            }
        }

        public override bool IsColumnName
        {
            get
            {
                return true;
            }
        }


        internal string Identifier;
        internal int Ordinal;
    }
}

