namespace DatasetQuery.GoldParser
{
    using System;

    internal enum SymbolType
    {
        NonTerminal,
        Terminal,
        Whitespace,
        End,
        CommentStart,
        CommentEnd,
        CommentLine,
        Error
    }
}

