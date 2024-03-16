namespace DatasetQuery.GoldParser
{
    using System;

    internal class LalrStateAction
    {
        public LalrStateAction(int index, DatasetQuery.GoldParser.Symbol symbol, LalrAction action, int value)
        {
            this.m_index = index;
            this.m_symbol = symbol;
            this.m_action = action;
            this.m_value = value;
        }


        public LalrAction Action
        {
            get
            {
                return this.m_action;
            }
        }

        public int Index
        {
            get
            {
                return this.m_index;
            }
        }

        public DatasetQuery.GoldParser.Symbol Symbol
        {
            get
            {
                return this.m_symbol;
            }
        }

        public int Value
        {
            get
            {
                return this.m_value;
            }
        }


        private LalrAction m_action;
        private int m_index;
        private DatasetQuery.GoldParser.Symbol m_symbol;
        private int m_value;
    }
}

