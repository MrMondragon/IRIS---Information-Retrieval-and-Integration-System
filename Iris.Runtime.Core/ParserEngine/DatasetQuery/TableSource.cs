namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class TableSource : ScriptNode
    {
        public TableSource(DatasetQuery.JoinedTable join)
        {
            this.JoinedTable = join;
        }

        public TableSource(UnionList Query, string Alias)
        {
            this.SelectQuery = Query;
            this.AliasName = Alias.ToUpper();
            this.TableName = Alias;
        }

        public TableSource(string Name, string Alias)
        {
            this.TableName = Name.Replace("[", "").Replace("]", "");
            this.AliasName = Alias.ToUpper();
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            if (this.SelectQuery != null)
            {
                this.SelectQuery.Accept(visitor);
            }
            if (this.JoinedTable != null)
            {
                this.JoinedTable.Accept(visitor);
            }
        }

        public BaseOperator Evaluate(DataSet ds, BaseOperator last)
        {
            BaseOperator operator1 = null;
            if (this.JoinedTable == null)
            {
                DataTable table1;
                if (this.SelectQuery != null)
                {
                    table1 = Utilities.ToTable(this.SelectQuery.Execute(ds));
                    table1.TableName = this.TableName;
                    return new IndexScan(table1, "", "");
                }
                table1 = ds.Tables[this.TableName];
                if (table1 == null)
                {
                    table1 = ds.Tables["##objectsources"];
                    if (table1 != null)
                    {
                        DataRow row1 = table1.Rows.Find(this.TableName);
                        if (row1 == null)
                        {
                            table1 = null;
                        }
                        else
                        {
                            operator1 = new ObjectScan(StringType.FromObject(row1[0]), (IObjectSource) row1[1]);
                        }
                    }
                    if (table1 == null)
                    {
                        throw new DataException("Invalid table name '" + this.TableName + "'");
                    }
                    return operator1;
                }
                return new IndexScan(table1, "", "");
            }
            return this.JoinedTable.Evaluate(ds, last);
        }


        internal string AliasName;
        internal DatasetQuery.JoinedTable JoinedTable;
        internal UnionList SelectQuery;
        internal string TableName;
    }
}

