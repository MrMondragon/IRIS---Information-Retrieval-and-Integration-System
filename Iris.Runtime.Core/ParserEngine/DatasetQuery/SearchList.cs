namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class SearchList : ScriptNode
    {
        public SearchList(SearchItem item)
        {
            this.List = new ArrayList();
            this.List.Insert(0, item);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (SearchItem item1 in this.List)
            {
                item1.Accept(visitor);
            }
        }

        public void Add(SearchItem item)
        {
            this.List.Insert(0, item);
        }

        public void CalculateRow(DataRow row)
        {
            foreach (SearchItem item1 in this.List)
            {
                item1.Predicate.CalculateRow(row);
            }
        }

        public object KeepRow(DataRow row)
        {
            SearchItem item1 = (SearchItem) this.List[0];
            object obj2 = RuntimeHelpers.GetObjectValue(item1.KeepRow(row));
            if (this.List.Count < 2)
            {
                if (obj2 == DBNull.Value)
                {
                    return obj2;
                }
                if (this.List.Count == 1)
                {
                    return obj2;
                }
                if (BooleanType.FromObject((BooleanType.FromObject(StringType.StrCmp(item1.Operation, "AND", false) == 0) && BooleanType.FromObject(ObjectType.NotObj(obj2))) && true))
                {
                    return false;
                }
            }
            bool flag1 = false;
            int num2 = this.List.Count - 1;
            for (int num1 = 1; num1 <= num2; num1++)
            {
                object obj3 = RuntimeHelpers.GetObjectValue(((SearchItem) this.List[num1]).KeepRow(row));
                if (obj3 == DBNull.Value)
                {
                    return false;
                }
                string text1 = ((SearchItem) this.List[num1 - 1]).Operation;
                if (StringType.StrCmp(text1, "AND", false) == 0)
                {
                    flag1 = BooleanType.FromObject(ObjectType.BitAndObj(obj2, obj3));
                    if (!flag1)
                    {
                        return flag1;
                    }
                }
                else if (StringType.StrCmp(text1, "OR", false) == 0)
                {
                    flag1 = BooleanType.FromObject(ObjectType.BitOrObj(obj2, obj3));
                    if (flag1)
                    {
                        return flag1;
                    }
                }
                obj2 = RuntimeHelpers.GetObjectValue(obj3);
            }
            return flag1;
        }


        public bool IsAggregate
        {
            get
            {
                bool flag1 = false;
                foreach (SearchItem item1 in this.List)
                {
                    flag1 = item1.Predicate.IsAggregate;
                    if (flag1)
                    {
                        return flag1;
                    }
                }
                return flag1;
            }
        }


        internal bool IsWhere;
        internal ArrayList List;
    }
}

