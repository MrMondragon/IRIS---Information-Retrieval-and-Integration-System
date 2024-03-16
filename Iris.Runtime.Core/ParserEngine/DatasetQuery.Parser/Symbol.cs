namespace DatasetQuery.GoldParser
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Text;

    internal class Symbol
    {
        static Symbol()
        {
            Symbol.m_quotedChars = "|-+*?()(){}<>!";
        }

        public Symbol(int index, string name, DatasetQuery.GoldParser.SymbolType symbolType)
        {
            this.m_index = index;
            this.m_name = name;
            this.m_symbolType = symbolType;
        }

        private string FormatTerminalSymbol(string source)
        {
            StringBuilder builder1 = new StringBuilder();
            int num2 = source.Length - 1;
            for (int num1 = 0; num1 <= num2; num1++)
            {
                char ch1 = source[num1];
                if (ch1 == '\'')
                {
                    builder1.Append("'");
                }
                else if (Symbol.IsQuotedChar(ch1) || (StringType.StrCmp(StringType.FromChar(ch1), "\"", false) == 0))
                {
                    builder1.Append(new char[] { '\'', ch1, '\'' });
                }
                else
                {
                    builder1.Append(ch1);
                }
            }
            return builder1.ToString();
        }

        private static bool IsQuotedChar(char value)
        {
            return (Symbol.m_quotedChars.IndexOf(value) >= 0);
        }

        public override string ToString()
        {
            if (this.m_text == null)
            {
                switch (this.SymbolType)
                {
                    case DatasetQuery.GoldParser.SymbolType.NonTerminal:
                        this.m_text = "<" + this.Name + ">";
                        goto Label_0069;

                    case DatasetQuery.GoldParser.SymbolType.Terminal:
                        this.m_text = this.FormatTerminalSymbol(this.Name);
                        goto Label_0069;
                }
                this.m_text = "(" + this.Name + ")";
            }
        Label_0069:
            return this.m_text;
        }


        public int Index
        {
            get
            {
                return this.m_index;
            }
        }

        public string Name
        {
            get
            {
                return this.m_name;
            }
        }

        public DatasetQuery.GoldParser.SymbolType SymbolType
        {
            get
            {
                return this.m_symbolType;
            }
        }


        private int m_index;
        private string m_name;
        private static readonly string m_quotedChars;
        private DatasetQuery.GoldParser.SymbolType m_symbolType;
        private string m_text;
    }
}

