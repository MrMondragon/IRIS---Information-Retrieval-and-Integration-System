namespace DatasetQuery
{
    using System;
    using System.Collections;
    using System.Data;

    internal class CrossJoin : BaseJoin
    {
        public CrossJoin(BaseOperator left, BaseOperator right) : base(left, new string[] { "" }, right, new string[] { "" })
        {
        }

        public override DataTable Execute()
        {
            DataTable table2 = base._left.Execute();
            DataTable table3 = base._right.Execute();
            base._table.BeginLoadData();
            foreach (DataRow row1 in table2.Rows)
            {
                object[] objArray1 = row1.ItemArray;
                try
                {
                    foreach (DataRow row2 in table3.Rows)
                    {
                        base._table.LoadDataRow(this.JoinArrays(objArray1, objArray1.Length, row2.ItemArray, row2.ItemArray.Length), true);
                    }
                    continue;
                }
                finally
                {
                    IEnumerator enumerator1 = null;
                    if (enumerator1 is IDisposable)
                    {
                        ((IDisposable) enumerator1).Dispose();
                    }
                }
            }
            base._table.EndLoadData();
            return base._table;
        }

    }
}

