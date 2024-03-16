namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Data;

    internal class BuiltinFunction : FunctionValue
    {
        static BuiltinFunction()
        {
            BuiltinFunction.MethodHash = new Hashtable();
            BuiltinFunction.RegisterFunction("ISNULL", new IsNullFunction());
            BuiltinFunction.RegisterFunction("DATEADD", new DateAddFunction());
            BuiltinFunction.RegisterFunction("DATEPART", new DatePartFunction());
            BuiltinFunction.RegisterFunction("DATEDIFF", new DateDiffFunction());
            BuiltinFunction.RegisterFunction("NEWID", new NewGuidFunction());
            BuiltinFunction.RegisterFunction("IsDate", new IsDateFunction());
            BuiltinFunction.RegisterFunction("IsNumeric", new IsNumericFunction());
            BuiltinFunction.RegisterFunction("DATALENGTH", new DataLengthFunction());
            BuiltinFunction.RegisterFunction("Rand", new RandFunction());
            VBMath.Randomize();
            BuiltinFunction.RegisterFunction("Abs", new AbsFunction());
            BuiltinFunction.RegisterFunction("Acos", new Math1Function("Acos"));
            BuiltinFunction.RegisterFunction("Asin", new Math1Function("Asin"));
            BuiltinFunction.RegisterFunction("Atan", new Math1Function("Atan"));
            BuiltinFunction.RegisterFunction("Ceiling", new Math1Function("Ceiling"));
            BuiltinFunction.RegisterFunction("Cos", new Math1Function("Cos"));
            BuiltinFunction.RegisterFunction("Cosh", new Math1Function("Cosh"));
            BuiltinFunction.RegisterFunction("Exp", new Math1Function("Exp"));
            BuiltinFunction.RegisterFunction("Floor", new Math1Function("Floor"));
            BuiltinFunction.RegisterFunction("Log", new Math1Function("Log"));
            BuiltinFunction.RegisterFunction("Log10", new Math1Function("Log10"));
            BuiltinFunction.RegisterFunction("Power", new PowerFunction());
            BuiltinFunction.RegisterFunction("Round", new RoundFunction());
            BuiltinFunction.RegisterFunction("Sign", new Math1Function("Sign"));
            BuiltinFunction.RegisterFunction("Sin", new Math1Function("Sin"));
            BuiltinFunction.RegisterFunction("Sinh", new Math1Function("Sinh"));
            BuiltinFunction.RegisterFunction("Sqrt", new Math1Function("Sqrt"));
            BuiltinFunction.RegisterFunction("Tan", new Math1Function("Tan"));
            BuiltinFunction.RegisterFunction("Tanh", new Math1Function("Tanh"));
            BuiltinFunction.RegisterFunction("GetDate", new NowFunction());
            BuiltinFunction.RegisterFunction("GetUtcDate", new UtcNowFunction());
            BuiltinFunction.RegisterFunction("Year", new Date1Function("year"));
            BuiltinFunction.RegisterFunction("Month", new Date1Function("month"));
            BuiltinFunction.RegisterFunction("Day", new Date1Function("day"));
            BuiltinFunction.RegisterFunction("Hour", new Date1Function("hour"));
            BuiltinFunction.RegisterFunction("Minute", new Date1Function("minute"));
            BuiltinFunction.RegisterFunction("Second", new Date1Function("second"));
            BuiltinFunction.RegisterFunction("Millisecond", new Date1Function("millisecond"));
            BuiltinFunction.RegisterFunction("DayOfWeek", new Date1Function("dayofweek"));
            BuiltinFunction.RegisterFunction("DayOfYear", new Date1Function("dayofyear"));
            BuiltinFunction.RegisterFunction("TimeOfDay", new Date1Function("timeofday"));
            BuiltinFunction.RegisterFunction("CHRW", new ChrWFunction());
            BuiltinFunction.RegisterFunction("ASCII", new AsciiFunction());
            BuiltinFunction.RegisterFunction("LOWER", new VBString1Function("lower"));
            BuiltinFunction.RegisterFunction("LTrim", new VBString1Function("ltrim"));
            BuiltinFunction.RegisterFunction("RTrim", new VBString1Function("rtrim"));
            BuiltinFunction.RegisterFunction("Trim", new VBString1Function("trim"));
            BuiltinFunction.RegisterFunction("UPPER", new VBString1Function("upper"));
            BuiltinFunction.RegisterFunction("Replace", new ReplaceFunction());
            BuiltinFunction.RegisterFunction("SUBSTRING", new SubStringFunction());
            BuiltinFunction.RegisterFunction("CHARINDEX", new IndexOfFunction());
        }

        public BuiltinFunction(string Name, ArgumentList List) : base(Name, List, -1)
        {
            this.theFunction = (BaseFunction) BuiltinFunction.MethodHash[Name.ToLower()];
            if (this.theFunction == null)
            {
                throw new DataException(string.Format("'{0}' is not a recognized function name.", Name));
            }
            if (List.List.Count < this.theFunction.ParameterCount)
            {
                throw new DataException(string.Format("The {0} function requires {1} arguments.", Name, this.theFunction.ParameterCount));
            }
            if ((this.theFunction.ParameterCount != -1) && (List.List.Count > this.theFunction.ParameterCount))
            {
                throw new DataException(string.Format("The {0} function does not take {1} arguments.", Name, List.List.Count));
            }
        }

        public override object Execute(DataRow row, object[] pars)
        {
            return this.theFunction.Execute(pars);
        }

        protected static void RegisterFunction(string SQLName, BaseFunction func)
        {
            BuiltinFunction.MethodHash.Add(SQLName.ToLower(), func);
        }


        private static Hashtable MethodHash;
        private BaseFunction theFunction;
    }
}

