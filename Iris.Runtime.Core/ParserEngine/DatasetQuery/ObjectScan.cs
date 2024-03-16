namespace DatasetQuery
{
    using System;
    using System.Data;
    using System.Diagnostics;

    internal class ObjectScan : BaseOperator
    {
        public ObjectScan(string name, IObjectSource ts)
        {
            base._table = ts.ToTable();
            base._table.TableName = name;
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

