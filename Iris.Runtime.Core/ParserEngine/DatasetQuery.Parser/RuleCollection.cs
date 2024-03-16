namespace DatasetQuery.GoldParser
{
    using System;
    using System.Collections;
    using System.Reflection;

    internal class RuleCollection : IEnumerable
    {
        public RuleCollection(Rule[] ruleTable)
        {
            this.m_ruleTable = ruleTable;
        }

        public IEnumerator GetEnumerator()
        {
            return this.m_ruleTable.GetEnumerator();
        }


        public int Count
        {
            get
            {
                return this.m_ruleTable.Length;
            }
        }

        public Rule this[int index]
        {
            get
            {
                return this.m_ruleTable[index];
            }
        }


        private Rule[] m_ruleTable;
    }
}

