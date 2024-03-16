namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class ColumnExpression : CreateColumn
    {
        public ColumnExpression(string Identifier, DatasetQuery.DataType Type, string Expr)
        {
            this.Name = Identifier.Replace("[", "").Replace("]", "");
            this.DataType = Type;
            string text1 = Expr;
            text1 = text1.Substring(1);
            text1 = text1.Replace("''", "'");
            this.Expression = text1.Substring(0, text1.Length - 1);
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
            string text1 = this.Expression.Trim();
            if ((StringType.StrCmp(StringType.FromChar(text1[0]), "0", false) == 0) && ((StringType.StrCmp(StringType.FromChar(text1[1]), "x", false) == 0) || (StringType.StrCmp(StringType.FromChar(text1[1]), "X", false) == 0)))
            {
                throw new DataException(string.Format("Column '{0}' does not allow a binary constant expression.", column1.ColumnName));
            }
            try
            {
                column1.Expression = this.Expression;
            }
            catch (Exception exception2)
            {
                ProjectData.SetProjectError(exception2);
                Exception exception1 = exception2;
                throw new DataException(string.Format("Column '{0}' expression: {1}", column1.ColumnName, exception1.Message), exception1);
            }
        }


        internal DatasetQuery.DataType DataType;
        internal string Expression;
        internal string Name;
    }
}

