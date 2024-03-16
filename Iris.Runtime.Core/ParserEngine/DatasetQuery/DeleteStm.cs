namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class DeleteStm : SQLStatement
    {
        public DeleteStm(string Identifier, SearchList WhereClause)
        {
            this.Name = Identifier.Replace("[", "").Replace("]", "");
            this.WhereStm = WhereClause;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            if (this.WhereStm != null)
            {
                this.WhereStm.Accept(visitor);
            }
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
                throw new DataException("Invalid table name '" + this.Name + "'.");
            }
            int num1 = 0;
            if (this.WhereStm == null)
            {
                num1 = table1.Rows.Count;
                table1.Rows.Clear();
                return num1;
            }
            foreach (DataRow row1 in table1.Select())
            {
                if (BooleanType.FromObject(this.WhereStm.KeepRow(row1)))
                {
                    row1.Delete();
                    num1++;
                }
            }
            return num1;
        }


        internal string Name;
        internal SearchList WhereStm;
    }
}

