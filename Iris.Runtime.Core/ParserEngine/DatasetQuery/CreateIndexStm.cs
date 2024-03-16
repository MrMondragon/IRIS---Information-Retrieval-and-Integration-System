namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;

    internal class CreateIndexStm : SQLStatement
    {
        public CreateIndexStm(bool Unique, bool Clustered, string IndexIdentifier, string TableIdentifier, ConstraintColumnList List)
        {
            this.IsUnique = Unique;
            if (!this.IsUnique)
            {
                throw new NotSupportedException("Only UNIQUE constraints are supported.");
            }
            this.IsClustered = Clustered;
            if (this.IsClustered)
            {
                throw new NotSupportedException("CLUSTERED constraints are not supported.");
            }
            this.IndexName = IndexIdentifier.Replace("[", "").Replace("]", "");
            this.TableName = TableIdentifier.Replace("[", "").Replace("]", "");
            this.ColumnList = List;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override DataView Execute(DataSet ds)
        {
            return this.BuildResult(StringType.FromInteger(this.ExecuteNonQuery(ds)));
        }

        public override int ExecuteNonQuery(DataSet ds)
        {
            DataTable table1 = ds.Tables[this.TableName];
            if (table1 == null)
            {
                throw new DataException(string.Format("Invalid table name '{0}'.", this.TableName));
            }
            int num2 = 0;
            DataColumn[] columnArray1 = new DataColumn[(this.ColumnList.List.Count - 1) + 1];
            string[] textArray1 = new string[(this.ColumnList.List.Count - 1) + 1];
            try
            {
                foreach (ConstraintColumn column2 in this.ColumnList.List)
                {
                    string text1 = column2.Name;
                    DataColumn column1 = Utilities.GetColumn(table1.Columns, text1);
                    if (column1 == null)
                    {
                        throw new DataException(string.Format("Column '{0}' does not exist in the target table.", text1));
                    }
                    columnArray1[num2] = column1;
                    textArray1[num2] = column2.SortType;
                    num2++;
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
            try
            {
                table1.Constraints.Add(new UniqueConstraint(this.IndexName, columnArray1));
            }
            catch (Exception exception2)
            {
                ProjectData.SetProjectError(exception2);
                Exception exception1 = exception2;
                throw new DataException(exception1.Message, exception1);
            }
            return -1;
        }


        internal ConstraintColumnList ColumnList;
        internal string IndexName;
        internal bool IsClustered;
        internal bool IsUnique;
        internal string TableName;
    }
}

