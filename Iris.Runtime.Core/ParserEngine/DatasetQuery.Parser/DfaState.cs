namespace DatasetQuery.GoldParser
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;

    internal class DfaState
    {
        public DfaState(int index, Symbol acceptSymbol, Hashtable transitionVector)
        {
            this.m_index = index;
            this.m_acceptSymbol = acceptSymbol;
            this.m_transitionVector = transitionVector;
        }

        public int GetNextState(char value)
        {
            object obj1 = RuntimeHelpers.GetObjectValue(this.m_transitionVector[value]);
            if (obj1 != null)
            {
                return IntegerType.FromObject(obj1);
            }
            return -1;
        }


        public Symbol AcceptSymbol
        {
            get
            {
                return this.m_acceptSymbol;
            }
        }

        public int Index
        {
            get
            {
                return this.m_index;
            }
        }


        private Symbol m_acceptSymbol;
        private int m_index;
        private Hashtable m_transitionVector;
    }
}

