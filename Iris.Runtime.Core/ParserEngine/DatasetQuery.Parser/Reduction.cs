namespace DatasetQuery.GoldParser
{
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;

    internal class Reduction
    {
        public Reduction(DatasetQuery.GoldParser.Rule rule)
        {
            this.m_tokens = new ArrayList();
            this.m_rule = rule;
        }

        public void InsertToken(int index, Token token)
        {
            this.m_tokens.Insert(index, token);
        }


        public int Count
        {
            get
            {
                return this.m_tokens.Count;
            }
        }

        public Token this[int index]
        {
            get
            {
                return (Token) this.m_tokens[index];
            }
        }

        public int LineNumber
        {
            get
            {
                if (this.m_tokens.Count > 0)
                {
                    return ((Token) this.m_tokens[0]).LineNumber;
                }
                return -1;
            }
        }

        public int ReductionNumber
        {
            get
            {
                return this.m_number;
            }
            set
            {
                this.m_number = value;
            }
        }

        public DatasetQuery.GoldParser.Rule Rule
        {
            get
            {
                return this.m_rule;
            }
        }

        public object Tag
        {
            get
            {
                return this.m_data;
            }
            set
            {
                this.m_data = RuntimeHelpers.GetObjectValue(value);
            }
        }

        public ArrayList Tokens
        {
            get
            {
                return this.m_tokens;
            }
        }


        private object m_data;
        private int m_number;
        private DatasetQuery.GoldParser.Rule m_rule;
        private ArrayList m_tokens;
    }
}

