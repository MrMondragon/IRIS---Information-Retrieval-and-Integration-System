namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class InsertSelectStm : SQLStatement
    {
        public InsertSelectStm(string Identifier, IdList ColumnList, UnionList Query)
        {
            this.Name = Identifier.Replace("[", "").Replace("]", "");
            this.ColList = ColumnList;
            this.Union = Query;
            if (this.ColList != null)
            {
                this.ColList.CheckForDuplicates();
            }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.ColList.Accept(visitor);
            this.Union.Accept(visitor);
        }

        public override DataView Execute(DataSet ds)
        {
            return this.BuildResult(StringType.FromInteger(this.ExecuteNonQuery(ds)));
        }

        public override int ExecuteNonQuery(DataSet ds)
        {
            int[] numArray1;
            DataTable table1 = ds.Tables[this.Name];
            if (table1 == null)
            {
                throw new DataException("Invalid table name '" + this.Name + "'.");
            }
            DataView view1 = this.Union.Execute(ds);
            int num3 = 0;
            int num1 = 0;
            if (this.ColList == null)
            {
                numArray1 = new int[(table1.Columns.Count - 1) + 1];
                int num6 = table1.Columns.Count - 1;
                for (num3 = 0; num3 <= num6; num3++)
                {
                    if (StringType.StrCmp(table1.Columns[num3].Expression, string.Empty, false) == 0)
                    {
                        numArray1[num3] = num3;
                        num1++;
                    }
                }
                if (view1.Table.Columns.Count != num1)
                {
                    throw new DataException("The number of supplied values does not match the table definition.");
                }
                numArray1 = new int[(num1 - 1) + 1];
            }
            else
            {
                if (view1.Table.Columns.Count != this.ColList.List.Count)
                {
                    throw new DataException("The number of supplied values does not match the number of columns.");
                }
                numArray1 = new int[(this.ColList.List.Count - 1) + 1];
                foreach (IdItem item1 in this.ColList.List)
                {
                    DataColumn column1 = Utilities.GetColumn(table1.Columns, item1.Expression.ColumnName);
                    if (column1 == null)
                    {
                        throw new DataException(string.Format("Invalid column name '{0}'.", item1.Expression.ColumnName));
                    }
                    if (StringType.StrCmp(column1.Expression, string.Empty, false) != 0)
                    {
                        throw new DataException(string.Format("Column '{0}' cannot be modified because it is a computed column.", column1.ColumnName));
                    }
                    numArray1[num3] = column1.Ordinal;
                    num3++;
                }
            }
            num1 = view1.Count;
            foreach (DataRowView view2 in view1)
            {
                DataRow row1 = table1.NewRow();
                num3 = 0;
                foreach (int num4 in numArray1)
                {
                    object obj1 = RuntimeHelpers.GetObjectValue(view2.Row[num3]);
                    if (row1.Table.Columns[num4].DataType != obj1.GetType())
                    {
                        obj1 = RuntimeHelpers.GetObjectValue(DataType.ConvertValue(RuntimeHelpers.GetObjectValue(obj1), row1.Table.Columns[num4].DataType, 0));
                    }
                    row1[num4] = RuntimeHelpers.GetObjectValue(obj1);
                    num3++;
                }
                table1.Rows.Add(row1);
            }
            return num1;
        }


        internal IdList ColList;
        internal string Name;
        internal UnionList Union;
    }
}

