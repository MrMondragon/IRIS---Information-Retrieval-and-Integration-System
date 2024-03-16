namespace DatasetQuery.GoldParser
{
    using System;

    internal class CharReader
    {
        public CharReader(string source)
        {
            this.m_lineNumber = 1;
            this.m_source = source;
            this.m_index = 0;
        }

        public string Accept()
        {
            int num2 = this.m_index;
            if (this.m_index < this.m_source.Length)
            {
                if (this.m_source[this.m_index] == '\n')
                {
                    this.m_lineNumber++;
                }
                this.m_index++;
            }
            int num1 = this.m_index - num2;
            if (num1 > 0)
            {
                return this.m_source.Substring(num2, num1);
            }
            return string.Empty;
        }

        public string Accept(int count)
        {
            int num1 = this.m_index;
            if (count < 0)
            {
                count = 0;
            }
            else if ((num1 + count) >= this.m_source.Length)
            {
                count = this.m_source.Length - num1;
            }
            int num3 = count - 1;
            for (int num2 = 0; num2 <= num3; num2++)
            {
                if (this.m_source[this.m_index] == '\n')
                {
                    this.m_lineNumber++;
                }
                this.m_index++;
            }
            if (count > 0)
            {
                return this.m_source.Substring(num1, count);
            }
            return string.Empty;
        }

        public char AcceptChar()
        {
            char ch2 = this.CurrentChar;
            if (this.m_index < this.m_source.Length)
            {
                if (ch2 == '\n')
                {
                    this.m_lineNumber++;
                }
                this.m_index++;
            }
            return ch2;
        }

        public string AcceptToLineEnd()
        {
            int num1 = this.m_index;
            while (((this.CurrentChar != '\n') && (this.CurrentChar != '\r')) && (this.CurrentChar != '\0'))
            {
                this.AcceptChar();
            }
            return this.m_source.Substring(num1, this.m_index - num1);
        }

        public char GetChar(int shift)
        {
            int num1 = this.m_index + shift;
            if ((num1 >= 0) && (num1 < this.m_source.Length))
            {
                return this.m_source[num1];
            }
            return '\0';
        }


        public char CurrentChar
        {
            get
            {
                return this.GetChar(0);
            }
        }

        public int LineNumber
        {
            get
            {
                return this.m_lineNumber;
            }
        }


        public const char EndOfString = '\0';
        private int m_index;
        private int m_lineNumber;
        private string m_source;
    }
}

