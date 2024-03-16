namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class InsertValuesStm : SQLStatement
    {
        public InsertValuesStm(string Identifier)
        {
            this.Name = Identifier.Replace("[", "").Replace("]", "");
            this.ColList = null;
            this.ValList = null;
        }

        public InsertValuesStm(string Identifier, IdList ColumnList, InsertValueList ValueList)
        {
            this.Name = Identifier.Replace("[", "").Replace("]", "");
            this.ColList = ColumnList;
            this.ValList = ValueList;
            if (this.ColList != null)
            {
                if (this.ColList.List.Count != this.ValList.List.Count)
                {
                    throw new DataException("The number of supplied columns does not match the number of values.");
                }
                this.ColList.CheckForDuplicates();
            }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            if (this.ColList != null)
            {
                this.ColList.Accept(visitor);
            }
            if (this.ValList != null)
            {
                this.ValList.Accept(visitor);
            }
        }

        public override DataView Execute(DataSet ds)
        {
            return this.BuildResult(StringType.FromInteger(this.ExecuteNonQuery(ds)));
        }

        public override int ExecuteNonQuery(DataSet ds)
        {
            DataRow row1;
            DataTable table1 = ds.Tables[this.Name];
            if (table1 == null)
            {
                throw new DataException("Invalid table name '" + this.Name + "'.");
            }
            try
            {
                row1 = table1.NewRow();
            }
            catch (Exception exception3)
            {
                ProjectData.SetProjectError(exception3);
                Exception exception1 = exception3;
                throw new DataException(exception1.Message, exception1);
            }
            if (this.ValList != null)
            {
                ArrayList list1 = new ArrayList();
                DataColumn column1 = null;
                if (this.ColList == null)
                {
                    IEnumerator enumerator2=null;
                    int num2 = 0;
                    try
                    {
                        enumerator2 = table1.Columns.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            column1 = (DataColumn) enumerator2.Current;
                            if (StringType.StrCmp(column1.Expression, string.Empty, false) == 0)
                            {
                                list1.Add(column1.ColumnName);
                                num2++;
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable)
                        {
                            ((IDisposable) enumerator2).Dispose();
                        }
                    }
                    if (this.ValList.List.Count != num2)
                    {
                        throw new DataException("The number of supplied values does not match the table definition.");
                    }
                }
                else
                {
                    try
                    {
                        foreach (IdItem item1 in this.ColList.List)
                        {
                            list1.Add(item1.Expression.ColumnName);
                        }
                    }
                    finally
                    {
                        IEnumerator enumerator1=null;
                        if (enumerator1 is IDisposable)
                        {
                            ((IDisposable) enumerator1).Dispose();
                        }
                    }
                }
                int num4 = list1.Count - 1;
                for (int num3 = 0; num3 <= num4; num3++)
                {
                    string text1 = StringType.FromObject(list1[num3]);
                    column1 = Utilities.GetColumn(table1.Columns, text1);
                    if (column1 == null)
                    {
                        throw new DataException(string.Format("Invalid column name '{0}'.", text1));
                    }
                    if (StringType.StrCmp(column1.Expression, string.Empty, false) != 0)
                    {
                        throw new DataException(string.Format("Column '{0}' cannot be modified because it is a computed column.", column1.ColumnName));
                    }
                    Expression expression1 = ((InsertValue) this.ValList.List[num3]).Expr;
                    if (expression1 == null)
                    {
                        row1[column1.Ordinal] = RuntimeHelpers.GetObjectValue(column1.DefaultValue);
                    }
                    else
                    {
                        object obj1 = RuntimeHelpers.GetObjectValue(expression1.KeepRow(null));
                        if (column1.DataType != obj1.GetType())
                        {
                            obj1 = RuntimeHelpers.GetObjectValue(DataType.ConvertValue(RuntimeHelpers.GetObjectValue(obj1), column1.DataType, 0));
                        }
                        row1[column1.Ordinal] = RuntimeHelpers.GetObjectValue(obj1);
                    }
                }
            }
            try
            {
                table1.Rows.Add(row1);
            }
            catch (Exception exception4)
            {
                ProjectData.SetProjectError(exception4);
                Exception exception2 = exception4;
                throw new DataException(exception2.Message, exception2);
            }
            return 1;
        }


        internal IdList ColList;
        internal string Name;
        internal InsertValueList ValList;
    }
}

