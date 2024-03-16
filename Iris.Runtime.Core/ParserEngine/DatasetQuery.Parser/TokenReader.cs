namespace DatasetQuery.GoldParser
{
    using System;
    using System.Collections;

    internal class TokenReader
    {
        public TokenReader(CharReader reader, Grammar grammar)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("charReader");
            }
            if (grammar == null)
            {
                throw new ArgumentNullException("grammar");
            }
            this.m_charReader = reader;
            this.m_dfaStateTable = grammar.DfaStateTable;
            this.m_symbolTable = grammar.SymbolTable;
            this.m_dfaInitialState = grammar.DfaInitialState;
            try
            {
                foreach (Symbol symbol1 in this.m_symbolTable)
                {
                    switch (symbol1.SymbolType)
                    {
                        case SymbolType.End:
                            break;

                        case SymbolType.CommentStart:
                        case SymbolType.CommentEnd:
                        case SymbolType.CommentLine:
                        {
                            continue;
                        }
                        case SymbolType.Error:
                        {
                            this.m_errorSymbol = symbol1;
                            continue;
                        }
                        default:
                        {
                            continue;
                        }
                    }
                    this.m_endSymbol = symbol1;
                }
            }
            finally
            {
                IEnumerator enumerator1=null;
                if (enumerator1 is IDisposable)
                {
                    ((IDisposable) enumerator1).Dispose();
                }
            }
        }

        public Token ReadToken()
        {
            int num3 = this.m_dfaInitialState;
            int num2 = 0;
            int num4 = -1;
            int num1 = 0;
            if (this.m_charReader.CurrentChar == '\0')
            {
                return new Token(this.m_endSymbol, "", this.LineNumber);
            }
            Symbol symbol1 = this.m_errorSymbol;
            string text1 = "";
            while (1 != 0)
            {
                char ch1 = this.m_charReader.GetChar(num2);
                int num5 = this.m_dfaStateTable[num3].GetNextState(ch1);
                if (num5 >= 0)
                {
                    if (this.m_dfaStateTable[num5].AcceptSymbol != null)
                    {
                        num4 = num5;
                        num1 = num2 + 1;
                    }
                    num3 = num5;
                    num2++;
                }
                else
                {
                    if (num4 == -1)
                    {
                        symbol1 = this.m_errorSymbol;
                        text1 = this.m_charReader.Accept();
                        break;
                    }
                    symbol1 = this.m_dfaStateTable[num4].AcceptSymbol;
                    text1 = this.m_charReader.Accept(num1);
                    break;
                }
            }
            return new Token(symbol1, text1, this.LineNumber);
        }

        public string ReadToLineEnd()
        {
            return this.m_charReader.AcceptToLineEnd();
        }


        public int LineNumber
        {
            get
            {
                return this.m_charReader.LineNumber;
            }
        }


        private CharReader m_charReader;
        private int m_dfaInitialState;
        private DfaStateCollection m_dfaStateTable;
        private Symbol m_endSymbol;
        private Symbol m_errorSymbol;
        private SymbolCollection m_symbolTable;
    }
}

