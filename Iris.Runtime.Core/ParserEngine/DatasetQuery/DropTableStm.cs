namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class DropTableStm : SQLStatement
    {
        public DropTableStm(string Identifier)
        {
            this.Name = Identifier.Replace("[", "").Replace("]", "");
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
            DataTable table1 = ds.Tables[this.Name];
            if (table1 == null)
            {
                throw new DataException(string.Format("Invalid table name '{0}'.", this.Name));
            }
            try
            {
                table1.Constraints.Clear();
                ds.Tables.Remove(this.Name);
            }
            catch (DataException exception3)
            {
                ProjectData.SetProjectError(exception3);
                DataException exception1 = exception3;
                throw;
            }
            catch (Exception exception4)
            {
                ProjectData.SetProjectError(exception4);
                Exception exception2 = exception4;
                throw new DataException(exception2.Message, exception2);
            }
            return -1;
        }


        internal string Name;
    }
}

