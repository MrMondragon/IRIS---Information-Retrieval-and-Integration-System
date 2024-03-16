namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class ForeignKeyConstraint : ColumnConstraintType
    {
        public ForeignKeyConstraint(ConstraintColumnList ConstraintList, string Identifier, IdList RelatedColumns, OnChangeRule Rule1, OnChangeRule Rule2)
        {
            this.ColumnList = ConstraintList;
            this.RelatedTableName = Identifier.Replace("[", "").Replace("]", "");
            this.RelatedColumnList = RelatedColumns;
            if (Rule1 != null)
            {
                if (Rule1.IsUpdate)
                {
                    this.UpdateRule = Rule1.Rule;
                }
                else
                {
                    this.DeleteRule = Rule1.Rule;
                }
            }
            if (Rule2 != null)
            {
                if (StringType.StrCmp(Rule2.Name, Rule1.Name, false) == 0)
                {
                    throw new DataException(string.Format("{0} rule already defined.", Rule2.Name));
                }
                if (Rule2.IsUpdate)
                {
                    this.UpdateRule = Rule2.Rule;
                }
                else
                {
                    this.DeleteRule = Rule2.Rule;
                }
            }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            if (this.RelatedColumnList != null)
            {
                this.RelatedColumnList.Accept(visitor);
            }
        }

        public override void CreateOnColumn(DataColumn dc)
        {
            this.InternalCreateOnTable(dc.Table, dc);
        }

        public override void CreateOnTable(DataTable dt)
        {
            this.InternalCreateOnTable(dt, null);
        }

        public void InternalCreateOnTable(DataTable dt, DataColumn column)
        {
            DataColumn column1;
            DataTable table1 = dt.DataSet.Tables[this.RelatedTableName];
            if (table1 == null)
            {
                throw new DataException(string.Format("Foreign key '{0}' references invalid table '{1}'.", this.Name, this.RelatedTableName));
            }
            int num1 = 0;
            DataColumn[] columnArray1 = new DataColumn[(this.RelatedColumnList.List.Count - 1) + 1];
            foreach (IdItem item1 in this.RelatedColumnList.List)
            {
                string text1 = item1.Expression.ColumnName;
                column1 = Utilities.GetColumn(table1.Columns, text1);
                if (column1 == null)
                {
                    throw new DataException(string.Format("Column '{0}' does not exist in the target table.", text1));
                }
                columnArray1[num1] = column1;
                num1++;
            }
            DataColumn[] columnArray2 = new DataColumn[1];
            if (this.ColumnList == null)
            {
                columnArray2[0] = column;
                num1 = 1;
            }
            else
            {
                columnArray2 = new DataColumn[(this.ColumnList.List.Count - 1) + 1];
                num1 = 0;
                foreach (ConstraintColumn column2 in this.ColumnList.List)
                {
                    column1 = Utilities.GetColumn(dt.Columns, column2.Name);
                    if (column1 == null)
                    {
                        throw new DataException(string.Format("Column '{0}' does not exist in the target table.", column2.Name));
                    }
                    columnArray2[num1] = column1;
                    num1++;
                }
            }
            try
            {
                System.Data.ForeignKeyConstraint constraint1 = new System.Data.ForeignKeyConstraint(this.Name, columnArray1, columnArray2);
                dt.Constraints.Add(constraint1);
                constraint1.UpdateRule = this.UpdateRule;
                constraint1.DeleteRule = this.DeleteRule;
            }
            catch (Exception exception2)
            {
                ProjectData.SetProjectError(exception2);
                Exception exception1 = exception2;
                throw new DataException(exception1.Message, exception1);
            }
        }


        internal ConstraintColumnList ColumnList;
        internal Rule DeleteRule;
        internal IdList RelatedColumnList;
        internal string RelatedTableName;
        internal Rule UpdateRule;
    }
}

