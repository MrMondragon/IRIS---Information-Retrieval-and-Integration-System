namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;

    internal abstract class BaseJoin : BaseOperator
    {
        public BaseJoin(BaseOperator left, string[] leftcols, BaseOperator right, string[] rightcols)
        {
            this._left = left;
            this._leftcolumns = leftcols;
            this._leftordinals = new int[(leftcols.Length - 1) + 1];
            this._right = right;
            this._rightcolumns = rightcols;
            this._rightordinals = new int[(rightcols.Length - 1) + 1];
            if (!(this is CrossJoin))
            {
                int num2 = leftcols.Length - 1;
                for (int num1 = 0; num1 <= num2; num1++)
                {
                    DataColumn column1 = Utilities.GetColumn(this._left.Table.Columns, this._leftcolumns[num1]);
                    if (column1 == null)
                    {
                        column1 = this.GetColumn(this._right.Table.Columns, this._leftcolumns[num1]);
                        this._rightordinals[num1] = column1.Ordinal;
                        column1 = this.GetColumn(this._left.Table.Columns, this._rightcolumns[num1]);
                        this._leftordinals[num1] = column1.Ordinal;
                        string text1 = this._leftcolumns[num1];
                        this._leftcolumns[num1] = this._rightcolumns[num1];
                        this._rightcolumns[num1] = text1;
                    }
                    else
                    {
                        this._leftordinals[num1] = column1.Ordinal;
                        column1 = this.GetColumn(this._right.Table.Columns, this._rightcolumns[num1]);
                        this._rightordinals[num1] = column1.Ordinal;
                    }
                }
            }
            base._table = new DataTable();
            try
            {
                foreach (DataColumn column2 in this._left.Table.Columns)
                {
                    base._table.Columns.Add(Utilities.CloneColumn(column2));
                }
            }
            finally
            {
                IEnumerator enumerator2 = null;
                if (enumerator2 is IDisposable)
                {
                    ((IDisposable) enumerator2).Dispose();
                }
            }
            foreach (DataColumn column4 in this._right.Table.Columns)
            {
                DataColumn column3 = Utilities.CloneColumn(column4);
                column3.ColumnName = Utilities.AvoidDuplicateColumnName(base._table.Columns, column3.ColumnName);
                base._table.Columns.Add(column3);
            }
        }

        protected int CompareValues(object left, object right)
        {
            int num1 = 0;
            if (ObjectType.ObjTst(left, right, false) < 0)
            {
                return -1;
            }
            if (ObjectType.ObjTst(left, right, false) > 0)
            {
                return 1;
            }
            return num1;
        }

        public override DataTable Execute()
        {
            throw new NotSupportedException();
        }

        private DataColumn GetColumn(DataColumnCollection Columns, string Name)
        {
            DataColumn column1 = Utilities.GetColumn(Columns, Name);
            if (column1 == null)
            {
                throw new DataException(string.Format("Invalid column name '{0}'.", Name));
            }
            return column1;
        }

        protected DBNull[] GetNullColumns(DataTable dt)
        {
            DBNull[] nullArray2 = new DBNull[(dt.Columns.Count - 1) + 1];
            int num2 = dt.Columns.Count - 1;
            for (int num1 = 0; num1 <= num2; num1++)
            {
                nullArray2[num1] = DBNull.Value;
            }
            return nullArray2;
        }

        protected object[] JoinArrays(object[] left, int lcount, object[] right, int rcount)
        {
            object[] objArray1 = new object[((lcount + rcount) - 1) + 1];
            Array.Copy(left, 0, objArray1, 0, lcount);
            Array.Copy(right, 0, objArray1, lcount, rcount);
            return objArray1;
        }


        protected BaseOperator _left;
        protected string[] _leftcolumns;
        protected int[] _leftordinals;
        protected BaseOperator _right;
        protected string[] _rightcolumns;
        protected int[] _rightordinals;
    }
}

