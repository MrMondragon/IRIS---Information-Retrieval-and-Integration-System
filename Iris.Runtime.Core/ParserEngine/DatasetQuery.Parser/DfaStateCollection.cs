namespace DatasetQuery.GoldParser
{
    using System;
    using System.Collections;
    using System.Reflection;

    internal class DfaStateCollection : IEnumerable
    {
        public DfaStateCollection(DfaState[] dfaStateTable)
        {
            this.m_dfaStateTable = dfaStateTable;
        }

        public IEnumerator GetEnumerator()
        {
            return this.m_dfaStateTable.GetEnumerator();
        }


        public int Count
        {
            get
            {
                return this.m_dfaStateTable.Length;
            }
        }

        public DfaState this[int index]
        {
            get
            {
                return this.m_dfaStateTable[index];
            }
        }


        private DfaState[] m_dfaStateTable;
    }
}

