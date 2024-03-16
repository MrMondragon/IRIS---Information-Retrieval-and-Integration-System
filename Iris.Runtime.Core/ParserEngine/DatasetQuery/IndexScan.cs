namespace DatasetQuery
{
    using System;
    using System.Data;
    using System.Diagnostics;

    internal class IndexScan : BaseOperator
    {
        public IndexScan(DataTable table, string filter, string sort)
        {
            base._table = table;
        }

        public override DataTable Execute()
        {
            if (base._table.Rows.Count == 0)
            {
                Trace.WriteLine(string.Format("Table {0} is empty", base._table.TableName));
            }
            return base._table;
        }

    }
}

