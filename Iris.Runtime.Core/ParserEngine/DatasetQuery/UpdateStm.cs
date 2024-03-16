namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class UpdateStm : SQLStatement
    {
        public UpdateStm(string Identifier, AssignList SetList, SearchList WhereClause)
        {
            this.Name = Identifier.Replace("[", "").Replace("]", "");
            this.List = SetList;
            this.WhereStm = WhereClause;
            this.List.CheckForDuplicates();
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            if (this.List != null)
            {
                this.List.Accept(visitor);
            }
            if (this.WhereStm != null)
            {
                this.WhereStm.Accept(visitor);
            }
        }

        public override DataView Execute(DataSet ds)
        {
            return this.BuildResult(StringType.FromInteger(this.ExecuteNonQuery(ds)));
        }

        public override int ExecuteNonQuery(DataSet ds)
        {
            DataTable table1 = ds.Tables[this.Name];
            if (table1 == null)
            {
                throw new DataException("Invalid table name '" + this.Name + "'.");
            }
            int[] numArray1 = new int[(this.List.List.Count - 1) + 1];
            int num3 = 0;
            foreach (AssignValue value1 in this.List.List)
            {
                DataColumn column1 = Utilities.GetColumn(table1.Columns, value1.Name);
                if (column1 == null)
                {
                    throw new DataException(string.Format("Invalid column name '{0}'.", value1.Name));
                }
                if (StringType.StrCmp(column1.Expression, string.Empty, false) != 0)
                {
                    throw new DataException(string.Format("Column '{0}' cannot be modified because it is a computed column.", column1.ColumnName));
                }
                numArray1[num3] = column1.Ordinal;
                num3++;
            }
            int num1 = 0;
            foreach (DataRow row1 in table1.Rows)
            {
                if (BooleanType.FromObject(BooleanType.FromObject(this.WhereStm == null) || BooleanType.FromObject(this.WhereStm.KeepRow(row1))))
                {
                    foreach (AssignValue value2 in this.List.List)
                    {
                        if (value2.Ordinal == -1)
                        {
                            DataColumn column2 = Utilities.GetColumn(table1.Columns, value2.Name);
                            if (column2 == null)
                            {
                                throw new DataException(string.Format("Invalid column name '{0}'.", value2.Name));
                            }
                            value2.Ordinal = column2.Ordinal;
                        }
                        if (value2.Value.Expr != null)
                        {
                            object obj1 = RuntimeHelpers.GetObjectValue(value2.Value.Expr.KeepRow(row1));
                            if (row1.Table.Columns[value2.Ordinal].DataType != obj1.GetType())
                            {
                                obj1 = RuntimeHelpers.GetObjectValue(DataType.ConvertValue(RuntimeHelpers.GetObjectValue(obj1), row1.Table.Columns[value2.Ordinal].DataType, 0));
                            }
                            row1[value2.Ordinal] = RuntimeHelpers.GetObjectValue(obj1);
                        }
                        else
                        {
                            row1[value2.Ordinal] = RuntimeHelpers.GetObjectValue(row1.Table.Columns[value2.Ordinal].DefaultValue);
                        }
                    }
                    num1++;
                }
            }
            return num1;
        }


        internal AssignList List;
        internal string Name;
        internal SearchList WhereStm;
    }
}

