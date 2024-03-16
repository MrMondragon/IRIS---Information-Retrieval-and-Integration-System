namespace DatasetQuery.GoldParser
{
    using System;
    using System.Text;

    internal class Rule
    {
        public Rule(int index, Symbol nonTerminal, Symbol[] symbols)
        {
            this.m_index = index;
            this.m_nonTerminal = nonTerminal;
            this.m_symbols = symbols;
        }

        public override string ToString()
        {
            return (this.Name + " ::= " + this.Definition);
        }


        public bool ContainsOneNonTerminal
        {
            get
            {
                if ((this.m_symbols.Length == 1) && (this.m_symbols[0].SymbolType == SymbolType.NonTerminal))
                {
                    return true;
                }
                return false;
            }
        }

        public int Count
        {
            get
            {
                return this.m_symbols.Length;
            }
        }

        public string Definition
        {
            get
            {
                StringBuilder builder1 = new StringBuilder();
                int num2 = this.m_symbols.Length - 1;
                for (int num1 = 0; num1 <= num2; num1++)
                {
                    builder1.Append(this.m_symbols[num1].ToString());
                    if (num1 < (this.m_symbols.Length - 1))
                    {
                        builder1.Append(' ');
                    }
                }
                return builder1.ToString();
            }
        }

        public int Index
        {
            get
            {
                return this.m_index;
            }
        }

        public Symbol this[int index]
        {
            get
            {
                return this.m_symbols[index];
            }
        }

        public string Name
        {
            get
            {
                return ("<" + this.m_nonTerminal.Name + ">");
            }
        }

        public Symbol NonTerminal
        {
            get
            {
                return this.m_nonTerminal;
            }
        }


        private int m_index;
        private Symbol m_nonTerminal;
        private Symbol[] m_symbols;
    }
}

