namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class ColumnDefinition : CreateColumn
    {
        public ColumnDefinition(string Identifier, DatasetQuery.DataType Type, ConstraintList List)
        {
            this.Name = Identifier.Replace("[", "").Replace("]", "");
            this.DataType = Type;
            this.Constraints = List;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Create(DataTable dt)
        {
            DataColumn column1 = new DataColumn();
            dt.Columns.Add(column1);
            column1.ColumnName = this.Name;
            column1.DataType = this.DataType.DotNetType;
            if ((StringType.StrCmp(column1.DataType.Name, "String", false) == 0) && (this.DataType.Size > 0))
            {
                column1.MaxLength = this.DataType.Size;
            }
            if (this.Constraints != null)
            {
                foreach (ColumnConstraintType type1 in this.Constraints.List)
                {
                    type1.CreateOnColumn(column1);
                }
            }
        }


        internal ConstraintList Constraints;
        internal DatasetQuery.DataType DataType;
        internal string Name;
    }
}

