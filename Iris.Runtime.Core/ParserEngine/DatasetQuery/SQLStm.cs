namespace DatasetQuery
{
    using System;
    using System.Data;

    internal class SQLStm : SQLStatement
    {
        public SQLStm(SQLStatement item)
        {
            this.SQL = item;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.SQL.Accept(visitor);
        }

        public override DataView Execute(DataSet dataset)
        {
            return this.SQL.Execute(dataset);
        }

        public override int ExecuteNonQuery(DataSet dataset)
        {
            return this.SQL.ExecuteNonQuery(dataset);
        }


        internal SQLStatement SQL;
    }
}

