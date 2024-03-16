namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;

    internal class ComparisonsVistor : IVisitor
    {
        public ComparisonsVistor()
        {
            this.List = new ArrayList();
        }

        public void Visit(object obj)
        {
            if (obj is Comparisons)
            {
                Comparisons comparisons1 = (Comparisons) obj;
                if (BooleanType.FromObject((BooleanType.FromObject(comparisons1.IsComparison) && BooleanType.FromObject(StringType.StrCmp(comparisons1.Operation, "=", false) != 0)) && true))
                {
                    this.List.Add(RuntimeHelpers.GetObjectValue(obj));
                }
            }
        }


        public ArrayList List;
    }
}

