namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Text;

    internal class OrderByList
    {
        public OrderByList(OrderItem item)
        {
            this.List = new ArrayList();
            this.List.Insert(0, item);
        }

        public void Add(OrderItem item)
        {
            this.List.Insert(0, item);
        }

        public string GetSort(DataColumnCollection columns)
        {
            StringBuilder builder1 = new StringBuilder();
            foreach (OrderItem item1 in this.List)
            {
                DataColumn column1 = null;
                if (Information.IsNumeric(item1.OrderBy))
                {
                    try
                    {
                        column1 = columns[IntegerType.FromString(item1.OrderBy) - 1];
                    }
                    catch (Exception exception2)
                    {
                        ProjectData.SetProjectError(exception2);
                        Exception exception1 = exception2;
                        ProjectData.ClearProjectError();
                    }
                }
                else
                {
                    column1 = Utilities.GetColumn(columns, item1.OrderBy);
                }
                if (column1 == null)
                {
                    throw new DataException(string.Format("Invalid column name or ordinal '{0}'.", item1.OrderBy));
                }
                builder1.Append(column1.ColumnName).Append(" ").Append(item1.SortDir).Append(",");
            }
            return builder1.ToString().TrimEnd(new char[] { ',' });
        }


        internal ArrayList List;
    }
}

