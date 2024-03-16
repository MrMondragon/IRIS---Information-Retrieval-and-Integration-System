namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;

    internal class PrimaryUniqueConstraint : ColumnConstraintType
    {
        public PrimaryUniqueConstraint(bool PrimaryKey, bool Clustered, ConstraintColumnList ConstraintList)
        {
            this.IsPrimaryKey = PrimaryKey;
            this.IsClustered = Clustered;
            this.List = ConstraintList;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void CreateOnColumn(DataColumn dc)
        {
            if (this.List == null)
            {
                try
                {
                    if (this.IsPrimaryKey)
                    {
                        if (dc.AllowDBNull)
                        {
                            throw new DataException(string.Format("Cannot define PRIMARY KEY constraint on nullable column '{0}'.", dc.ColumnName));
                        }
                        dc.Table.Constraints.Add(new UniqueConstraint(this.Name, dc, true));
                        return;
                    }
                    dc.Unique = true;
                    return;
                }
                catch (Exception exception2)
                {
                    ProjectData.SetProjectError(exception2);
                    Exception exception1 = exception2;
                    throw new DataException(exception1.Message, exception1);
                }
            }
            this.CreateOnTable(dc.Table);
        }

        public override void CreateOnTable(DataTable dt)
        {
            DataColumn[] columnArray1 = new DataColumn[(this.List.List.Count - 1) + 1];
            int num1 = 0;
            try
            {
                foreach (ConstraintColumn column2 in this.List.List)
                {
                    DataColumn column1 = Utilities.GetColumn(dt.Columns, column2.Name);
                    if (column1 == null)
                    {
                        throw new DataException(string.Format("Column '{0}' does not exist in the target table.", column2.Name));
                    }
                    if (column1.AllowDBNull)
                    {
                        throw new DataException(string.Format("Cannot define PRIMARY KEY constraint on nullable column '{0}'.", column1.ColumnName));
                    }
                    columnArray1[num1] = column1;
                    num1++;
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
                UniqueConstraint constraint1 = new UniqueConstraint(this.Name, columnArray1, this.IsPrimaryKey);
                dt.Constraints.Add(constraint1);
            }
            catch (Exception exception2)
            {
                ProjectData.SetProjectError(exception2);
                Exception exception1 = exception2;
                throw new DataException(exception1.Message, exception1);
            }
        }


        internal bool IsClustered;
        internal bool IsPrimaryKey;
        internal ConstraintColumnList List;
    }
}

