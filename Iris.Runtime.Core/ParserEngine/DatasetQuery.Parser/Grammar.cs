namespace DatasetQuery.GoldParser
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;

    internal class Grammar
    {
        public Grammar(BinaryReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            this.m_reader = reader;
            this.Load();
        }

        private Hashtable CreateDfaTransitionVector(DfaEdge[] edges)
        {
            Hashtable hashtable2 = new Hashtable();
            for (int num1 = edges.Length - 1; num1 >= 0; num1--)
            {
                string text1 = this.m_charSetTable[edges[num1].CharSetIndex];
                int num3 = text1.Length - 1;
                for (int num2 = 0; num2 <= num3; num2++)
                {
                    hashtable2[text1[num2]] = edges[num1].TargetIndex;
                }
            }
            return hashtable2;
        }

        private void Load()
        {
            if (StringType.StrCmp("GOLD Parser Tables/v1.0", this.ReadString(), false) != 0)
            {
                throw new Exception(Res.GetString("Grammar_WrongFileHeader"));
            }
        Label_00D1:
            if (this.m_reader.PeekChar() != -1)
            {
                switch (this.ReadNextRecord())
                {
                    case RecordType.CharSets:
                        this.ReadCharSets();
                        goto Label_00D1;

                    case RecordType.DfaStates:
                        this.ReadDfaStates();
                        goto Label_00D1;

                    case RecordType.Initial:
                        this.ReadInitialStates();
                        goto Label_00D1;

                    case RecordType.LalrStates:
                        this.ReadLalrStates();
                        goto Label_00D1;

                    case RecordType.Parameters:
                        this.ReadHeader();
                        goto Label_00D1;

                    case RecordType.Rules:
                        this.ReadRules();
                        goto Label_00D1;

                    case RecordType.Symbols:
                        this.ReadSymbols();
                        goto Label_00D1;

                    case RecordType.TableCounts:
                        this.ReadTableCounts();
                        goto Label_00D1;
                }
                throw new Exception(Res.GetString("Grammar_InvalidRecordType"));
            }
        }

        private bool ReadBool()
        {
            return (this.ReadByte() == 1);
        }

        private bool ReadBoolEntry()
        {
            if (this.ReadEntryType() != EntryType.Boolean)
            {
                throw new Exception(Res.GetString("Grammar_BooleanEntryExpected"));
            }
            this.m_entryCount--;
            return this.ReadBool();
        }

        private byte ReadByte()
        {
            return this.m_reader.ReadByte();
        }

        private byte ReadByteEntry()
        {
            if (this.ReadEntryType() != EntryType.Byte)
            {
                throw new Exception(Res.GetString("Grammar_ByteEntryExpected"));
            }
            this.m_entryCount--;
            return this.ReadByte();
        }

        private void ReadCharSets()
        {
            this.m_charSetTable[this.ReadInt16Entry()] = this.ReadStringEntry();
        }

        private void ReadDfaStates()
        {
            int num1 = this.ReadInt16Entry();
            Symbol symbol1 = null;
            if (this.ReadBoolEntry())
            {
                symbol1 = this.m_symbolTable[this.ReadInt16Entry()];
            }
            else
            {
                this.ReadInt16Entry();
            }
            this.ReadEmptyEntry();
            DfaEdge[] edgeArray1 = new DfaEdge[((int) Math.Round((double) ((((double) this.m_entryCount) / 3) - 1))) + 1];
            int num3 = edgeArray1.Length - 1;
            for (int num2 = 0; num2 <= num3; num2++)
            {
                edgeArray1[num2].CharSetIndex = this.ReadInt16Entry();
                edgeArray1[num2].TargetIndex = this.ReadInt16Entry();
                this.ReadEmptyEntry();
            }
            Hashtable hashtable1 = this.CreateDfaTransitionVector(edgeArray1);
            DfaState state1 = new DfaState(num1, symbol1, hashtable1);
            this.m_dfaStateTable[num1] = state1;
        }

        private void ReadEmptyEntry()
        {
            if (this.ReadEntryType() != EntryType.Empty)
            {
                throw new Exception(Res.GetString("Grammar_EmptyEntryExpected"));
            }
            this.m_entryCount--;
        }

        private EntryType ReadEntryType()
        {
            if (this.m_entryCount == 0)
            {
                throw new Exception(Res.GetString("Grammar_NoEntry"));
            }
            return (EntryType) this.ReadByte();
        }

        private void ReadHeader()
        {
            this.m_name = this.ReadStringEntry();
            this.m_version = this.ReadStringEntry();
            this.m_author = this.ReadStringEntry();
            this.m_about = this.ReadStringEntry();
            this.m_caseSensitive = this.ReadBoolEntry();
            this.m_startSymbolIndex = this.ReadInt16Entry();
        }

        private void ReadInitialStates()
        {
            this.m_dfaInitialState = this.ReadInt16Entry();
            this.m_lalrInitialState = this.ReadInt16Entry();
        }

        private int ReadInt16()
        {
            return this.m_reader.ReadInt16();
        }

        private int ReadInt16Entry()
        {
            if (this.ReadEntryType() != EntryType.Integer)
            {
                throw new Exception(Res.GetString("Grammar_IntegerEntryExpected"));
            }
            this.m_entryCount--;
            return this.ReadInt16();
        }

        private void ReadLalrStates()
        {
            int num2 = this.ReadInt16Entry();
            this.ReadEmptyEntry();
            LalrStateAction[] actionArray1 = new LalrStateAction[((int) Math.Round((double) ((((double) this.m_entryCount) / 4) - 1))) + 1];
            int num6 = actionArray1.Length - 1;
            int num1 = 0;
            while (num1 <= num6)
            {
                Symbol symbol1 = this.m_symbolTable[this.ReadInt16Entry()];
                LalrAction action1 = (LalrAction) this.ReadInt16Entry();
                int num3 = this.ReadInt16Entry();
                this.ReadEmptyEntry();
                actionArray1[num1] = new LalrStateAction(num1, symbol1, action1, num3);
                num1++;
            }
            LalrStateAction[] actionArray2 = new LalrStateAction[(this.m_symbolTable.Length - 1) + 1];
            int num5 = actionArray2.Length - 1;
            num1 = 0;
            while (num1 <= num5)
            {
                actionArray2[num1] = null;
                num1++;
            }
            int num4 = actionArray1.Length - 1;
            for (num1 = 0; num1 <= num4; num1++)
            {
                actionArray2[actionArray1[num1].Symbol.Index] = actionArray1[num1];
            }
            LalrState state1 = new LalrState(num2, actionArray1, actionArray2);
            this.m_lalrStateTable[num2] = state1;
        }

        private RecordType ReadNextRecord()
        {
            char ch1 = Strings.ChrW(this.ReadByte());
            switch (ch1)
            {
                case 'M':
                    this.m_entryCount = this.ReadInt16();
                    return (RecordType) this.ReadByteEntry();
            }
            throw new Exception(Res.GetString("Grammar_InvalidRecordHeader"));
        }

        private void ReadRules()
        {
            int num1 = this.ReadInt16Entry();
            Symbol symbol1 = this.m_symbolTable[this.ReadInt16Entry()];
            this.ReadEmptyEntry();
            Symbol[] symbolArray1 = new Symbol[(this.m_entryCount - 1) + 1];
            int num3 = symbolArray1.Length - 1;
            for (int num2 = 0; num2 <= num3; num2++)
            {
                symbolArray1[num2] = this.m_symbolTable[this.ReadInt16Entry()];
            }
            Rule rule1 = new Rule(num1, symbol1, symbolArray1);
            this.m_ruleTable[num1] = rule1;
        }

        private string ReadString()
        {
            StringBuilder builder1 = new StringBuilder();
            for (char ch1 = Strings.ChrW(this.ReadInt16()); ch1 != '\0'; ch1 = Strings.ChrW(this.ReadInt16()))
            {
                builder1.Append(ch1);
            }
            return builder1.ToString();
        }

        private string ReadStringEntry()
        {
            if (this.ReadEntryType() != EntryType.String)
            {
                throw new Exception(Res.GetString("Grammar_StringEntryExpected"));
            }
            this.m_entryCount--;
            return this.ReadString();
        }

        private void ReadSymbols()
        {
            int num1 = this.ReadInt16Entry();
            string text1 = this.ReadStringEntry();
            SymbolType type1 = (SymbolType) this.ReadInt16Entry();
            Symbol symbol1 = new Symbol(num1, text1, type1);
            this.m_symbolTable[num1] = symbol1;
        }

        private void ReadTableCounts()
        {
            this.m_symbolTable = new Symbol[(this.ReadInt16Entry() - 1) + 1];
            this.m_charSetTable = new string[(this.ReadInt16Entry() - 1) + 1];
            this.m_ruleTable = new Rule[(this.ReadInt16Entry() - 1) + 1];
            this.m_dfaStateTable = new DfaState[(this.ReadInt16Entry() - 1) + 1];
            this.m_lalrStateTable = new LalrState[(this.ReadInt16Entry() - 1) + 1];
        }


        public string About
        {
            get
            {
                return this.m_about;
            }
        }

        public string Author
        {
            get
            {
                return this.m_author;
            }
        }

        public bool CaseSensitive
        {
            get
            {
                return this.m_caseSensitive;
            }
        }

        public CharSetCollection CharSetTable
        {
            get
            {
                if (this.m_charSets == null)
                {
                    this.m_charSets = new CharSetCollection(this.m_charSetTable);
                }
                return this.m_charSets;
            }
        }

        public int DfaInitialState
        {
            get
            {
                return this.m_dfaInitialState;
            }
        }

        public DfaStateCollection DfaStateTable
        {
            get
            {
                if (this.m_dfaStates == null)
                {
                    this.m_dfaStates = new DfaStateCollection(this.m_dfaStateTable);
                }
                return this.m_dfaStates;
            }
        }

        public LalrState InitialLalrState
        {
            get
            {
                return this.m_lalrStateTable[this.m_lalrInitialState];
            }
        }

        public LalrStateCollection LalrStateTable
        {
            get
            {
                if (this.m_lalrStates == null)
                {
                    this.m_lalrStates = new LalrStateCollection(this.m_lalrStateTable);
                }
                return this.m_lalrStates;
            }
        }

        public string Name
        {
            get
            {
                return this.m_name;
            }
        }

        public RuleCollection RuleTable
        {
            get
            {
                if (this.m_rules == null)
                {
                    this.m_rules = new RuleCollection(this.m_ruleTable);
                }
                return this.m_rules;
            }
        }

        public Symbol StartSymbol
        {
            get
            {
                return this.m_symbolTable[this.m_startSymbolIndex];
            }
        }

        public SymbolCollection SymbolTable
        {
            get
            {
                if (this.m_symbols == null)
                {
                    this.m_symbols = new SymbolCollection(this.m_symbolTable);
                }
                return this.m_symbols;
            }
        }

        public string Version
        {
            get
            {
                return this.m_version;
            }
        }


        public const string FileHeader = "GOLD Parser Tables/v1.0";
        private string m_about;
        private string m_author;
        private bool m_caseSensitive;
        private CharSetCollection m_charSets;
        private string[] m_charSetTable;
        private int m_dfaInitialState;
        private DfaStateCollection m_dfaStates;
        private DfaState[] m_dfaStateTable;
        private int m_entryCount;
        private int m_lalrInitialState;
        private LalrStateCollection m_lalrStates;
        private LalrState[] m_lalrStateTable;
        private string m_name;
        private BinaryReader m_reader;
        private RuleCollection m_rules;
        private Rule[] m_ruleTable;
        private int m_startSymbolIndex;
        private SymbolCollection m_symbols;
        private Symbol[] m_symbolTable;
        private string m_version;


        [StructLayout(LayoutKind.Sequential)]
        private struct DfaEdge
        {
            public int CharSetIndex;
            public int TargetIndex;
        }

        private enum EntryType
        {
            Boolean = 0x42,
            Byte = 0x62,
            Empty = 0x45,
            Integer = 0x49,
            String = 0x53
        }

        private enum RecordType
        {
            CharSets = 0x43,
            Comment = 0x21,
            DfaStates = 0x44,
            Initial = 0x49,
            LalrStates = 0x4c,
            Parameters = 80,
            Rules = 0x52,
            Symbols = 0x53,
            TableCounts = 0x54
        }
    }
}

