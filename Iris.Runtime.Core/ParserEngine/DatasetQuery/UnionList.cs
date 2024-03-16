namespace DatasetQuery
{
    using System;
    using System.Collections;
    using System.Data;

    internal class UnionList : SQLStatement
    {
        public UnionList(SelectStm item)
        {
            this.List = new ArrayList();
            this.List.Insert(0, item);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (SelectStm stm1 in this.List)
            {
                stm1.Accept(visitor);
            }
        }

        public void Add(SelectStm item)
        {
            this.List.Insert(0, item);
        }

        public override DataView Execute(DataSet dataset)
        {
            SelectStm stm1=null;
            DataView view3 = ((SelectStm) this.List[0]).Execute(dataset);
            int num4 = this.List.Count - 1;
            for (int num1 = 1; num1 <= num4; num1++)
            {
                stm1 = (SelectStm) this.List[num1];
                DataView view2 = stm1.Execute(dataset);
                DataRowCollection collection1 = view3.Table.Rows;
                int num3 = view2.Count - 1;
                for (int num2 = 0; num2 <= num3; num2++)
                {
                    collection1.Add(view2[num2].Row.ItemArray);
                }
                collection1 = null;
                view2.Table.Clear();
            }
            if (this.List.Count > 1)
            {
                if (!this.All)
                {
                    Utilities.Distinct(view3);
                }
                if (stm1.OrderBy != null)
                {
                    view3.Sort = stm1.OrderBy.GetSort(view3.Table.Columns);
                }
            }
            return view3;
        }

        public override int ExecuteNonQuery(DataSet dataset)
        {
            return -1;
        }


        internal bool All;
        internal ArrayList List;
    }
}

