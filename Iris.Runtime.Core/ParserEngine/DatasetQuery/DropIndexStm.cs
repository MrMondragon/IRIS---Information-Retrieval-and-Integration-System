namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;

    internal class DropIndexStm : SQLStatement
    {
        public DropIndexStm(IdentifierList IdList)
        {
            this.List = IdList;
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
          IEnumerator enumerator1 = null;
            try
            {
                enumerator1 = this.List.List.GetEnumerator();
                while (enumerator1.MoveNext())
                {
                    string[] textArray1 = StringType.FromObject(enumerator1.Current).Split(new char[] { '.' });
                    DataTable table1 = ds.Tables[textArray1[0]];
                    if (table1 == null)
                    {
                        throw new DataException(string.Format("Invalid table name '{0}'.", textArray1[0]));
                    }
                    Constraint constraint1 = table1.Constraints[textArray1[1]];
                    if (constraint1 == null)
                    {
                        throw new DataException(string.Format("Index '{0}' does not exist in the target table.", textArray1[1]));
                    }
                    table1.Constraints.Remove(constraint1);
                }
            }
            finally
            {
                if (enumerator1 is IDisposable)
                {
                    ((IDisposable) enumerator1).Dispose();
                }
            }
            return -1;
        }


        internal IdentifierList List;
    }
}

