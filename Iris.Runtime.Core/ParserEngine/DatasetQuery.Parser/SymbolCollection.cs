namespace DatasetQuery.GoldParser
{
    using System;
    using System.Collections;
    using System.Reflection;

    internal class SymbolCollection : IEnumerable
    {
        public SymbolCollection(Symbol[] symbolTable)
        {
            this.m_symbolTable = symbolTable;
        }

        public IEnumerator GetEnumerator()
        {
            return this.m_symbolTable.GetEnumerator();
        }


        public int Count
        {
            get
            {
                return this.m_symbolTable.Length;
            }
        }

        public Symbol this[int index]
        {
            get
            {
                return this.m_symbolTable[index];
            }
        }


        private Symbol[] m_symbolTable;
    }
}

