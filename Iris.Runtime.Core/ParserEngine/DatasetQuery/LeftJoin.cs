namespace DatasetQuery
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class LeftJoin : BaseJoin
    {
        public LeftJoin(BaseOperator left, string[] leftcols, BaseOperator right, string[] rightcols) : base(left, leftcols, right, rightcols)
        {
        }

        public override DataTable Execute()
        {
            DataTable table2 = base._left.Execute();
            DataView view1 = new DataView(base._right.Execute(), "", base._right.GetSort(base._rightcolumns), DataViewRowState.CurrentRows);
            object[] objArray1 = this.GetNullColumns(base._right.Table);
            if (table2.Rows.Count > 0)
            {
                base._table.BeginLoadData();
                foreach (DataRow row1 in table2.Rows)
                {
                    object[] objArray2 = new object[(base._leftordinals.Length - 1) + 1];
                    int num3 = base._leftordinals.Length - 1;
                    for (int num1 = 0; num1 <= num3; num1++)
                    {
                        objArray2[num1] = RuntimeHelpers.GetObjectValue(row1[base._leftordinals[num1]]);
                    }
                    DataRowView[] viewArray1 = view1.FindRows(objArray2);
                    if (viewArray1.Length > 0)
                    {
                        foreach (DataRowView view2 in viewArray1)
                        {
                            base._table.LoadDataRow(this.JoinArrays(row1.ItemArray, row1.ItemArray.Length, view2.Row.ItemArray, view2.Row.ItemArray.Length), true);
                        }
                    }
                    else
                    {
                        base._table.LoadDataRow(this.JoinArrays(row1.ItemArray, row1.ItemArray.Length, objArray1, objArray1.Length), true);
                    }
                }
                base._table.EndLoadData();
            }
            return base._table;
        }

    }
}

