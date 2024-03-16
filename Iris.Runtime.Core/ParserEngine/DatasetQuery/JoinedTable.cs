namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class JoinedTable : ScriptNode
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.LeftTableSource.Accept(visitor);
            this.RightTableSource.Accept(visitor);
            this.Search.Accept(visitor);
        }

        public BaseOperator Evaluate(DataSet ds, BaseOperator last)
        {
            BaseOperator operator3 = this.LeftTableSource.Evaluate(ds, last);
            if (StringType.StrLike(operator3.Table.TableName, "@@*", CompareMethod.Binary))
            {
                operator3.Table.TableName = this.LeftTableSource.TableName;
            }
            BaseOperator operator4 = this.RightTableSource.Evaluate(ds, last);
            if (StringType.StrLike(operator4.Table.TableName, "@@*", CompareMethod.Binary))
            {
                operator4.Table.TableName = this.RightTableSource.TableName;
            }
            if (this.Search != null)
            {
                ComparisonsVistor vistor1 = new ComparisonsVistor();
                this.Search.Accept(vistor1);
                if (vistor1.List.Count > 0)
                {
                    throw new DataException("Only equal JOINs are supported");
                }
                string[] textArray1 = new string[(this.Search.List.Count - 1) + 1];
                string[] textArray2 = new string[(this.Search.List.Count - 1) + 1];
                int num1 = 0;
                foreach (SearchItem item1 in this.Search.List)
                {
                    if ((StringType.StrCmp(item1.Operation, string.Empty, false) != 0) && (StringType.StrCmp(item1.Operation, "AND", false) != 0))
                    {
                        throw new DataException("Only AND supported in composite key");
                    }
                    Comparisons comparisons2 = (Comparisons) item1.Predicate;
                    textArray1[num1] = comparisons2.LeftExpression.ColumnName.ToLower();
                    textArray2[num1] = comparisons2.RightExpression.ColumnName.ToLower();
                    num1++;
                }
                Comparisons comparisons1 = (Comparisons) ((SearchItem) this.Search.List[0]).Predicate;
                string text1 = this.JoinType;
                if (StringType.StrCmp(text1, "INNER", false) != 0)
                {
                    if (StringType.StrCmp(text1, "LEFT", false) != 0)
                    {
                        if (StringType.StrCmp(text1, "RIGHT", false) != 0)
                        {
                            if (StringType.StrCmp(text1, "FULL", false) != 0)
                            {
                                throw new DataException("Unsupported join type " + this.JoinType);
                            }
                            return new FullJoin(operator3, textArray1, operator4, textArray2);
                        }
                        return new RightJoin(operator3, textArray1, operator4, textArray2);
                    }
                    return new LeftJoin(operator3, textArray1, operator4, textArray2);
                }
                return new InnerJoin(operator3, textArray1, operator4, textArray2);
            }
            return new CrossJoin(operator3, operator4);
        }


        internal string JoinType;
        internal TableSource LeftTableSource;
        internal TableSource RightTableSource;
        internal SearchList Search;
    }
}

