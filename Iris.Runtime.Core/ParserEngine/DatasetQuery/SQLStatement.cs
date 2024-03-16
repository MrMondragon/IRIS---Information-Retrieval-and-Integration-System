namespace DatasetQuery
{
    using System;
    using System.Data;

    internal abstract class SQLStatement : IEvaluatable, ScriptNode
    {
        public abstract void Accept(IVisitor visitor);
        public DataView BuildResult(string Count)
        {
            DataTable table1 = new DataTable("Result");
            table1.Columns.Add("RowsAffected", typeof(int));
            DataRow row1 = table1.NewRow();
            row1[0] = Count;
            table1.Rows.Add(row1);
            return new DataView(table1);
        }

        public abstract DataView Execute(DataSet dataset);
        public abstract int ExecuteNonQuery(DataSet dataset);
    }
}

