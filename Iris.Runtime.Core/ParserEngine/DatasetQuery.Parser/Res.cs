namespace DatasetQuery.GoldParser
{
    using System;
    using System.Globalization;
    using System.Resources;

    internal sealed class Res
    {
        static Res()
        {
            Res.ms_loader = null;
        }

        private Res()
        {
            this.m_resources = new ResourceManager("GoldParser", this.GetType().Module.Assembly);
        }

        private static Res GetLoader()
        {
            if (Res.ms_loader == null)
            {
                Type type1 = typeof(Res);
                lock (type1)
                {
                    if (Res.ms_loader == null)
                    {
                        Res.ms_loader = new Res();
                    }
                }
            }
            return Res.ms_loader;
        }

        public static string GetString(string name)
        {
            return Res.GetString(null, name);
        }

        public static string GetString(CultureInfo culture, string name)
        {
            Res res1 = Res.GetLoader();
            if (res1 == null)
            {
                return null;
            }
            return res1.m_resources.GetString(name, culture);
        }


        internal const string Grammar_BooleanEntryExpected = "Grammar_BooleanEntryExpected";
        internal const string Grammar_ByteEntryExpected = "Grammar_ByteEntryExpected";
        internal const string Grammar_EmptyEntryExpected = "Grammar_EmptyEntryExpected";
        internal const string Grammar_IntegerEntryExpected = "Grammar_IntegerEntryExpected";
        internal const string Grammar_InvalidRecordHeader = "Grammar_InvalidRecordHeader";
        internal const string Grammar_InvalidRecordType = "Grammar_InvalidRecordType";
        internal const string Grammar_NoEntry = "Grammar_NoEntry";
        internal const string Grammar_StringEntryExpected = "Grammar_StringEntryExpected";
        internal const string Grammar_WrongFileHeader = "Grammar_WrongFileHeader";
        private ResourceManager m_resources;
        private static Res ms_loader;
    }
}

