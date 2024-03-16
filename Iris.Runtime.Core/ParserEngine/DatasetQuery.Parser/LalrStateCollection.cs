namespace DatasetQuery.GoldParser
{
    using System;
    using System.Collections;
    using System.Reflection;

    internal class LalrStateCollection : IEnumerable
    {
        public LalrStateCollection(LalrState[] lalrStateTable)
        {
            this.m_lalrStateTable = lalrStateTable;
        }

        public IEnumerator GetEnumerator()
        {
            return this.m_lalrStateTable.GetEnumerator();
        }


        public int Count
        {
            get
            {
                return this.m_lalrStateTable.Length;
            }
        }

        public LalrState this[int index]
        {
            get
            {
                return this.m_lalrStateTable[index];
            }
        }


        private LalrState[] m_lalrStateTable;
    }
}

