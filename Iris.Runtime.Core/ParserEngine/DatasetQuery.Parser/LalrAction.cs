namespace DatasetQuery.GoldParser
{
    using System;

    internal enum LalrAction
    {
        Accept = 4,
        Error = 5,
        Goto = 3,
        Reduce = 2,
        Shift = 1
    }
}

