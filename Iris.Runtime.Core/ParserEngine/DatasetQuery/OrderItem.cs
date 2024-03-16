namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    internal class OrderItem
    {
        public OrderItem(object OrderBy, string Sort)
        {
            this.OrderBy = StringType.FromObject(OrderBy);
            this.SortDir = Sort;
        }


        internal string OrderBy;
        internal string SortDir;
    }
}

