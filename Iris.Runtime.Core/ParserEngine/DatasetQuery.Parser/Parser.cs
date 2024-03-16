namespace DatasetQuery.GoldParser
{
    using System;
    using System.Collections;

    internal class Parser
    {
        public Parser(string input, DatasetQuery.GoldParser.Grammar grammar)
        {
            this.m_stack = new TokenStack();
            this.m_tokens = new TokenStack();
            this.m_inputTokens = new TokenStack();
            this.m_haveReduction = false;
            this.m_commentLevel = 0;
            this.m_comments = new Hashtable();
            this.m_grammar = grammar;
            CharReader reader1 = new CharReader(input);
            this.m_tokenReader = new TokenReader(reader1, grammar);
            this.m_currentLalrState = this.m_grammar.InitialLalrState;
            Token token1 = new Token(this.m_grammar.StartSymbol, null);
            token1.LalrState = this.m_currentLalrState;
            this.m_stack.Push(token1);
        }

        public ParseMessage Parse()
        {
            Token token1;
            if (this.m_grammar != null)
            {
                goto Label_0180;
            }
            return ParseMessage.NotLoadedError;
        Label_0140:
            switch (this.ParseToken(token1))
            {
                case TokenParseResult.Accept:
                    return ParseMessage.Accept;

                case TokenParseResult.Shift:
                    this.m_inputTokens.Pop();
                    goto Label_0180;

                case TokenParseResult.ReduceNormal:
                    return ParseMessage.Reduction;

                case TokenParseResult.ReduceEliminated:
                    goto Label_0180;

                case TokenParseResult.SyntaxError:
                    return ParseMessage.SyntaxError;

                case TokenParseResult.InternalError:
                    return ParseMessage.InternalError;
            }
        Label_0180:
            //if (1 == 0)
            //{
            //    ParseMessage message1;
            //    return message1;
            //}
            if (this.m_inputTokens.Count == 0)
            {
                token1 = this.m_tokenReader.ReadToken();
                if (token1 == null)
                {
                    return ParseMessage.InternalError;
                }
                if (token1.SymbolType != SymbolType.Whitespace)
                {
                    this.m_inputTokens.Push(token1);
                    if (((this.m_commentLevel == 0) && (token1.SymbolType != SymbolType.CommentLine)) && (token1.SymbolType != SymbolType.CommentStart))
                    {
                        return ParseMessage.TokenRead;
                    }
                }
                goto Label_0180;
            }
            if (this.m_commentLevel > 0)
            {
                token1 = this.m_inputTokens.PopToken();
                if (token1 != null)
                {
                    switch (token1.SymbolType)
                    {
                        case SymbolType.End:
                            return ParseMessage.CommentError;

                        case SymbolType.CommentStart:
                            this.m_commentLevel++;
                            goto Label_0180;

                        case SymbolType.CommentEnd:
                            this.m_commentLevel--;
                            goto Label_0180;
                    }
                }
                goto Label_0180;
            }
            token1 = this.m_inputTokens.PeekToken();
            if (token1 == null)
            {
                goto Label_0180;
            }
            switch (token1.SymbolType)
            {
                case SymbolType.CommentStart:
                    this.m_commentLevel++;
                    this.m_inputTokens.Pop();
                    goto Label_0180;

                case SymbolType.CommentEnd:
                    goto Label_0140;

                case SymbolType.CommentLine:
                {
                    this.m_inputTokens.Pop();
                    string text1 = this.m_tokenReader.ReadToLineEnd();
                    this.m_comments[this.LineNumber] = text1;
                    goto Label_0180;
                }
                case SymbolType.Error:
                    return ParseMessage.LexicalError;
            }
            goto Label_0140;
        }

        private TokenParseResult ParseToken(Token nextToken)
        {
            LalrStateAction action1 = this.m_currentLalrState.GetActionBySymbolIndex(nextToken.Symbol.Index);
            Array.Clear(this.m_tokens.ToArray(), 0, this.m_tokens.ToArray().Length);
            if (action1 == null)
            {
                int num4 = this.m_currentLalrState.ActionCount - 1;
                for (int num3 = 0; num3 <= num4; num3++)
                {
                    switch (this.m_currentLalrState.GetAction(num3).Symbol.SymbolType)
                    {
                        case SymbolType.Terminal:
                        case SymbolType.Whitespace:
                            goto Label_021D;

                        case SymbolType.End:
                            break;

                        default:
                            goto Label_021D;
                    }
                    Token token2 = new Token(this.m_currentLalrState.GetAction(num3).Symbol, "", this.m_tokenReader.LineNumber);
                    this.m_tokens.Push(token2);
                Label_021D:;
                }
            }
            else
            {
                Rule rule1;
                Token token1;
                TokenParseResult result2;
                this.m_haveReduction = false;
                switch (action1.Action)
                {
                    case LalrAction.Shift:
                        this.m_currentLalrState = this.Grammar.LalrStateTable[action1.Value];
                        nextToken.LalrState = this.m_currentLalrState;
                        this.m_stack.Push(nextToken);
                        return TokenParseResult.Shift;

                    case LalrAction.Reduce:
                    {
                        int num1 = action1.Value;
                        rule1 = this.Grammar.RuleTable[num1];
                        if (!this.TrimReductions || !rule1.ContainsOneNonTerminal)
                        {
                            this.m_haveReduction = true;
                            Reduction reduction1 = new Reduction(rule1);
                            int num5 = rule1.Count - 1;
                            for (int num2 = 0; num2 <= num5; num2++)
                            {
                                reduction1.InsertToken(0, this.m_stack.PopToken());
                            }
                            token1 = new Token(rule1.NonTerminal, reduction1);
                            result2 = TokenParseResult.ReduceNormal;
                            break;
                        }
                        token1 = this.m_stack.PopToken();
                        token1.Symbol = rule1.NonTerminal;
                        result2 = TokenParseResult.ReduceEliminated;
                        break;
                    }
                    case LalrAction.Goto:
                        goto Label_0229;

                    case LalrAction.Accept:
                        this.m_haveReduction = true;
                        return TokenParseResult.Accept;

                    default:
                        goto Label_0229;
                }
                LalrStateAction action2 = this.m_stack.PeekToken().LalrState.GetActionBySymbolIndex(rule1.NonTerminal.Index);
                if (action2 != null)
                {
                    this.m_currentLalrState = this.Grammar.LalrStateTable[action2.Value];
                    token1.LalrState = this.m_currentLalrState;
                    this.m_stack.Push(token1);
                    return result2;
                }
                return TokenParseResult.InternalError;
            }
        Label_0229:
            return TokenParseResult.SyntaxError;
        }


        public Hashtable Comments
        {
            get
            {
                return this.m_comments;
            }
        }

        public LalrState CurrentLalrState
        {
            get
            {
                return this.m_currentLalrState;
            }
        }

        public Reduction CurrentReduction
        {
            get
            {
                if (this.m_haveReduction)
                {
                    return this.m_stack.PeekToken().Reduction;
                }
                return null;
            }
            set
            {
                if (this.m_haveReduction)
                {
                    this.m_stack.PeekToken().Reduction = value;
                }
            }
        }

        public Token CurrentToken
        {
            get
            {
                return this.m_inputTokens.PeekToken();
            }
        }

        public DatasetQuery.GoldParser.Grammar Grammar
        {
            get
            {
                return this.m_grammar;
            }
        }

        public int LineNumber
        {
            get
            {
                return this.m_tokenReader.LineNumber;
            }
        }

        public TokenStack TokenTable
        {
            get
            {
                return this.m_tokens;
            }
        }

        public bool TrimReductions
        {
            get
            {
                return this.m_trimReductions;
            }
            set
            {
                this.m_trimReductions = value;
            }
        }


        private int m_commentLevel;
        private Hashtable m_comments;
        private LalrState m_currentLalrState;
        private DatasetQuery.GoldParser.Grammar m_grammar;
        private bool m_haveReduction;
        private TokenStack m_inputTokens;
        private TokenStack m_stack;
        private TokenReader m_tokenReader;
        private TokenStack m_tokens;
        private bool m_trimReductions;


        private enum TokenParseResult
        {
            Empty,
            Accept,
            Shift,
            ReduceNormal,
            ReduceEliminated,
            SyntaxError,
            InternalError
        }
    }
}

