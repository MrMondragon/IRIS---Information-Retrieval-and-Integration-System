namespace DatasetQuery.GoldParser
{
    using System;
    using System.Collections;

    internal class TokenStack : Stack
    {
        public void CopyTo(Token[] array, int index)
        {
            foreach (Token token1 in this)
            {
                array[index] = token1;
                index++;
            }
        }

        public Token PeekToken()
        {
            return (Token) this.Peek();
        }

        public Token PopToken()
        {
            return (Token) this.Pop();
        }

        public void PushToken(Token token)
        {
            this.Push(token);
        }

    }
}

