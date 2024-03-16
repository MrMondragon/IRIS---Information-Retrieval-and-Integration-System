namespace DatasetQuery
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class RightJoin : BaseJoin
    {
        public RightJoin(BaseOperator left, string[] leftcols, BaseOperator right, string[] rightcols) : base(left, leftcols, right, rightcols)
        {
        }

        public override DataTable Execute()
        {
            DataView view1 = new DataView(base._left.Execute(), "", base._left.GetSort(base._leftcolumns), DataViewRowState.CurrentRows);
            DataTable table2 = base._right.Execute();
            object[] objArray1 = this.GetNullColumns(base._left.Table);
            if (table2.Rows.Count > 0)
            {
                base._table.BeginLoadData();
                foreach (DataRow row1 in table2.Rows)
                {
                    object[] objArray2 = new object[(base._rightordinals.Length - 1) + 1];
                    int num3 = base._rightordinals.Length - 1;
                    for (int num1 = 0; num1 <= num3; num1++)
                    {
                        objArray2[num1] = RuntimeHelpers.GetObjectValue(row1[base._rightordinals[num1]]);
                    }
                    DataRowView[] viewArray1 = view1.FindRows(objArray2);
                    if (viewArray1.Length > 0)
                    {
                        foreach (DataRowView view2 in viewArray1)
                        {
                            base._table.LoadDataRow(this.JoinArrays(view2.Row.ItemArray, view2.Row.ItemArray.Length, row1.ItemArray, row1.ItemArray.Length), true);
                        }
                    }
                    else
                    {
                        base._table.LoadDataRow(this.JoinArrays(objArray1, objArray1.Length, row1.ItemArray, row1.ItemArray.Length), true);
                    }
                }
                base._table.EndLoadData();
            }
            return base._table;
        }

    }
}

