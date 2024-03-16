namespace DatasetQuery.GoldParser
{
    using System;
    using System.Collections;

    internal class CharSetCollection : IEnumerable
    {
        public CharSetCollection(string[] strings)
        {
            this.m_charSetTable = strings;
        }

        public IEnumerator GetEnumerator()
        {
            return this.m_charSetTable.GetEnumerator();
        }


        public int Count
        {
            get
            {
                return this.m_charSetTable.Length;
            }
        }

        public string this[int index]
        {
            get
            {
                return this.m_charSetTable[index];
            }
        }


        private string[] m_charSetTable;
    }
}

