namespace DatasetQuery.GoldParser
{
    using System;

    internal enum ParseMessage
    {
        Empty,
        TokenRead,
        Reduction,
        Accept,
        NotLoadedError,
        LexicalError,
        SyntaxError,
        CommentError,
        InternalError
    }
}

