namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class CreateTableStm : SQLStatement
    {
        public CreateTableStm(string Identifier, CreateColumnList ColumnList)
        {
            this.Name = Identifier.Replace("[", "").Replace("]", "");
            this.List = ColumnList;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.List.Accept(visitor);
        }

        public override DataView Execute(DataSet ds)
        {
            return this.BuildResult(StringType.FromInteger(this.ExecuteNonQuery(ds)));
        }

        public override int ExecuteNonQuery(DataSet ds)
        {
            DataTable table1 = new DataTable(this.Name);
            try
            {
                ds.Tables.Add(table1);
            }
            catch (DuplicateNameException exception4)
            {
                ProjectData.SetProjectError(exception4);
                DuplicateNameException exception1 = exception4;
                throw new DataException(exception1.Message, exception1);
            }
            try
            {
                this.List.Create(table1);
            }
            catch (DataException exception5)
            {
                ProjectData.SetProjectError(exception5);
                DataException exception2 = exception5;
                table1.Constraints.Clear();
                ds.Tables.Remove(table1);
                throw new DataException(exception2.Message, exception2);
            }
            catch (Exception exception6)
            {
                ProjectData.SetProjectError(exception6);
                Exception exception3 = exception6;
                throw new DataException(exception3.Message, exception3);
            }
            return -1;
        }


        internal CreateColumnList List;
        internal string Name;
    }
}

