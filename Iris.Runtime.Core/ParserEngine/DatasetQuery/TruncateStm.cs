namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class TruncateStm : SQLStatement
    {
        public TruncateStm(string Identifier)
        {
            this.Name = Identifier.Replace("[", "").Replace("]", "");
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override DataView Execute(DataSet ds)
        {
            return this.BuildResult(StringType.FromInteger(this.ExecuteNonQuery(ds)));
        }

        public override int ExecuteNonQuery(DataSet ds)
        {
            DataTable table1 = ds.Tables[this.Name];
            if (table1 == null)
            {
                throw new DataException("Invalid table name '" + this.Name + "'");
            }
            int num1 = table1.Rows.Count;
            table1.Clear();
            return num1;
        }


        internal string Name;
    }
}

