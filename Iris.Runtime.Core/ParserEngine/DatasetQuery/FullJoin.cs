namespace DatasetQuery
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class FullJoin : BaseJoin
    {
        public FullJoin(BaseOperator left, string[] leftcols, BaseOperator right, string[] rightcols) : base(left, leftcols, right, rightcols)
        {
        }

        public override DataTable Execute()
        {
            DataView view1 = new DataView(base._left.Execute(), "", base._left.GetSort(base._leftcolumns), DataViewRowState.CurrentRows);
            DataTable table2 = base._right.Execute();
            object[] objArray1 = this.GetNullColumns(base._left.Table);
            base._table.BeginLoadData();
            foreach (DataRow row1 in table2.Rows)
            {
                bool flag1 = false;
                object[] objArray2 = new object[(base._rightordinals.Length - 1) + 1];
                int num5 = base._rightordinals.Length - 1;
                for (int num1 = 0; num1 <= num5; num1++)
                {
                    objArray2[num1] = RuntimeHelpers.GetObjectValue(row1[base._rightordinals[num1]]);
                    flag1 |= objArray2[num1] == DBNull.Value;
                }
                if (flag1)
                {
                    base._table.LoadDataRow(this.JoinArrays(objArray1, objArray1.Length, row1.ItemArray, row1.ItemArray.Length), true);
                }
                else
                {
                    DataRowView[] viewArray1 = view1.FindRows(objArray2);
                    if (viewArray1.Length > 0)
                    {
                        foreach (DataRowView view3 in viewArray1)
                        {
                            base._table.LoadDataRow(this.JoinArrays(view3.Row.ItemArray, view3.Row.ItemArray.Length, row1.ItemArray, row1.ItemArray.Length), true);
                        }
                        continue;
                    }
                    base._table.LoadDataRow(this.JoinArrays(objArray1, objArray1.Length, row1.ItemArray, row1.ItemArray.Length), true);
                }
            }
            DataView view2 = new DataView(table2, "", base._right.GetSort(base._rightcolumns), DataViewRowState.CurrentRows);
            objArray1 = this.GetNullColumns(base._right.Table);
            foreach (DataRow row2 in view1.Table.Rows)
            {
                bool flag2 = false;
                object[] objArray3 = new object[(base._leftordinals.Length - 1) + 1];
                int num3 = base._leftordinals.Length - 1;
                for (int num2 = 0; num2 <= num3; num2++)
                {
                    objArray3[num2] = RuntimeHelpers.GetObjectValue(row2[base._leftordinals[num2]]);
                    flag2 |= objArray3[num2] == DBNull.Value;
                }
                if (flag2)
                {
                    base._table.LoadDataRow(this.JoinArrays(row2.ItemArray, row2.ItemArray.Length, objArray1, objArray1.Length), true);
                }
                else
                {
                    DataRowView[] viewArray2 = view2.FindRows(objArray3);
                    if (viewArray2.Length <= 0)
                    {
                        base._table.LoadDataRow(this.JoinArrays(row2.ItemArray, row2.ItemArray.Length, objArray1, objArray1.Length), true);
                    }
                }
            }
            base._table.EndLoadData();
            return base._table;
        }

    }
}

