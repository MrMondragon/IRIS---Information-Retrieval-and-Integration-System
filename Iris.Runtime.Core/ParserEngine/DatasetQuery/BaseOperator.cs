namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Text;

    internal abstract class BaseOperator
    {
        public abstract DataTable Execute();
        public string GetSort(string[] columns)
        {
            StringBuilder builder1 = new StringBuilder();
            foreach (string text2 in columns)
            {
                if (StringType.StrCmp(this._table.TableName, "", false) != 0)
                {
                    builder1.Append(text2.Replace(this._table.TableName.ToLower() + ".", "")).Append(",");
                }
                else
                {
                    builder1.Append(text2).Append(",");
                }
            }
            return builder1.ToString().TrimEnd(new char[] { ',' });
        }


        public DataTable Table
        {
            get
            {
                return this._table;
            }
        }


        protected DataTable _table;
    }
}

