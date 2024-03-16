namespace DatasetQuery.GoldParser
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    internal class Token
    {
        public Token(DatasetQuery.GoldParser.Symbol symbol, DatasetQuery.GoldParser.Reduction reduction)
        {
            this.m_lineNumber = 0;
            this.m_symbol = symbol;
            this.m_reduction = reduction;
        }

        public Token(DatasetQuery.GoldParser.Symbol symbol, object data, int lineNumber)
        {
            this.m_lineNumber = 0;
            this.m_symbol = symbol;
            this.m_data = RuntimeHelpers.GetObjectValue(data);
            this.m_lineNumber = lineNumber;
        }

        public override string ToString()
        {
            if (this.SymbolType != DatasetQuery.GoldParser.SymbolType.Terminal)
            {
                return this.Symbol.ToString();
            }
            StringBuilder builder1 = new StringBuilder();
            int num2 = StringType.FromObject(this.m_data).Length - 1;
            for (int num1 = 0; num1 <= num2; num1++)
            {
                char ch1 = StringType.FromObject(this.m_data)[num1];
                if (ch1 < ' ')
                {
                    switch (ch1)
                    {
                        case '\t':
                            builder1.Append("{HT}");
                            break;

                        case '\n':
                            builder1.Append("{LF}");
                            break;

                        case '\r':
                            builder1.Append("{CR}");
                            break;
                    }
                }
                else
                {
                    builder1.Append(ch1);
                }
            }
            return builder1.ToString();
        }


        public object Data
        {
            get
            {
                return this.m_data;
            }
        }

        public DatasetQuery.GoldParser.LalrState LalrState
        {
            get
            {
                return this.m_state;
            }
            set
            {
                this.m_state = value;
            }
        }

        public int LineNumber
        {
            get
            {
                if (this.m_reduction != null)
                {
                    return this.m_reduction.LineNumber;
                }
                return this.m_lineNumber;
            }
        }

        public string Name
        {
            get
            {
                return this.Symbol.Name;
            }
        }

        public DatasetQuery.GoldParser.Reduction Reduction
        {
            get
            {
                return this.m_reduction;
            }
            set
            {
                this.m_reduction = value;
            }
        }

        public DatasetQuery.GoldParser.Symbol Symbol
        {
            get
            {
                return this.m_symbol;
            }
            set
            {
                this.m_symbol = value;
            }
        }

        public DatasetQuery.GoldParser.SymbolType SymbolType
        {
            get
            {
                return this.Symbol.SymbolType;
            }
        }


        private object m_data;
        private int m_lineNumber;
        private DatasetQuery.GoldParser.Reduction m_reduction;
        private DatasetQuery.GoldParser.LalrState m_state;
        private DatasetQuery.GoldParser.Symbol m_symbol;
    }
}

