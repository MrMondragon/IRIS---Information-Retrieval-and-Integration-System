namespace DatasetQuery
{
    using System;
    using System.Collections;
    using System.Data;

    internal class TableSourceList : ScriptNode
    {
        public TableSourceList(TableSource item)
        {
            this.List = new ArrayList();
            this.List.Insert(0, item);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (TableSource source1 in this.List)
            {
                source1.Accept(visitor);
            }
        }

        public void Add(TableSource item)
        {
            this.List.Insert(0, item);
        }

        public BaseOperator Evaluate(DataSet ds)
        {
            BaseOperator operator2 = null;
            foreach (TableSource source1 in this.List)
            {
                operator2 = source1.Evaluate(ds, operator2);
            }
            return operator2;
        }

        public void Optimize()
        {
            if (this.List.Count > 1)
            {
                int num1 = this.List.Count - 1;
                TableSource source2 = (TableSource) this.List[num1];
                while (num1 > 0)
                {
                    TableSource source1 = (TableSource) this.List[num1 - 1];
                    JoinedTable table1 = new JoinedTable();
                    if (source1.SelectQuery != null)
                    {
                        table1.LeftTableSource = new TableSource(source1.SelectQuery, source1.TableName);
                    }
                    else
                    {
                        table1.LeftTableSource = new TableSource(source1.TableName, source1.AliasName);
                    }
                    table1.JoinType = "CROSS";
                    if (source2.JoinedTable == null)
                    {
                        if (source2.SelectQuery != null)
                        {
                            table1.RightTableSource = new TableSource(source2.SelectQuery, source2.TableName);
                        }
                        else
                        {
                            table1.RightTableSource = new TableSource(source2.TableName, source2.AliasName);
                        }
                    }
                    else
                    {
                        table1.RightTableSource = source2;
                    }
                    table1.Search = null;
                    source1.JoinedTable = table1;
                    source1.TableName = "";
                    source1.AliasName = "";
                    this.List.Remove(source2);
                    source2 = source1;
                    num1--;
                }
            }
        }


        internal ArrayList List;
    }
}

