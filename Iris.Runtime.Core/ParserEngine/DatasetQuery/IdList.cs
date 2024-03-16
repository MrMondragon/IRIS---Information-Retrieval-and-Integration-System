namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Text;

    internal class IdList : ScriptNode
    {
        public IdList(IdItem item)
        {
            this.List = new ArrayList();
            this.List.Insert(0, item);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (IdItem item1 in this.List)
            {
                item1.Accept(visitor);
            }
        }

        public void Add(IdItem item)
        {
            this.List.Insert(0, item);
        }

        public void CheckForDuplicates()
        {
            ArrayList list1 = new ArrayList();
            foreach (IdItem item1 in this.List)
            {
                string text1 = item1.Expression.ColumnName.ToLower();
                if (list1.Contains(text1))
                {
                    throw new DataException(string.Format("Column name '{0}' appears more than once in the column list.", text1));
                }
                list1.Add(text1);
            }
        }

        public string GetSort(DataColumnCollection columns)
        {
            IEnumerator enumerator1 = null;
            StringBuilder builder1 = new StringBuilder();
            try
            {
                enumerator1 = this.IdentifierList.List.GetEnumerator();
                while (enumerator1.MoveNext())
                {
                    string text2 = StringType.FromObject(enumerator1.Current);
                    DataColumn column1 = Utilities.GetColumn(columns, text2);
                    if (column1 == null)
                    {
                        throw new DataException("Invalid column name '" + text2 + "' in GROUP BY");
                    }
                    builder1.Append(column1.ColumnName).Append(" ASC,");
                }
            }
            finally
            {
                if (enumerator1 is IDisposable)
                {
                    ((IDisposable) enumerator1).Dispose();
                }
            }
            return builder1.ToString().TrimEnd(new char[] { ',' });
        }


        public IdentifierInGroupByVistor IdentifierList
        {
            get
            {
                if (this._IDList == null)
                {
                    this._IDList = new IdentifierInGroupByVistor();
                    this.Accept(this._IDList);
                }
                return this._IDList;
            }
        }


        internal IdentifierInGroupByVistor _IDList;
        internal ArrayList List;
    }
}

