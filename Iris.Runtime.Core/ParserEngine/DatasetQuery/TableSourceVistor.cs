namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;

    internal class TableSourceVistor : IVisitor
    {
        public TableSourceVistor()
        {
            this.AliasList = new ArrayList();
            this.NameList = new ArrayList();
        }

        public void Visit(object obj)
        {
            if (obj is TableSource)
            {
                if (StringType.StrCmp(((TableSource) obj).AliasName, "", false) != 0)
                {
                    this.AliasList.Add(RuntimeHelpers.GetObjectValue(obj));
                }
                this.NameList.Add(RuntimeHelpers.GetObjectValue(obj));
            }
        }


        public ArrayList AliasList;
        public ArrayList NameList;
    }
}

