namespace DatasetQuery.GoldParser
{
    using System;

    internal class LalrState
    {
        public LalrState(int index, LalrStateAction[] actions, LalrStateAction[] transitionVector)
        {
            this.m_index = index;
            this.m_actions = actions;
            this.m_transitionVector = transitionVector;
        }

        public LalrStateAction GetAction(int index)
        {
            return this.m_actions[index];
        }

        public LalrStateAction GetActionBySymbolIndex(int symbolIndex)
        {
            return this.m_transitionVector[symbolIndex];
        }


        public int ActionCount
        {
            get
            {
                return this.m_actions.Length;
            }
        }

        public int Index
        {
            get
            {
                return this.m_index;
            }
        }


        private LalrStateAction[] m_actions;
        private int m_index;
        private LalrStateAction[] m_transitionVector;
    }
}

