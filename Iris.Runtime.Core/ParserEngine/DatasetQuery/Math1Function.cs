namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    internal class Math1Function : BaseFunction
    {
        public Math1Function(string name)
        {
            this.FunctionName = name.ToLower();
        }

        public override object Execute(object[] pars)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(pars[0]);
            if (obj2 != DBNull.Value)
            {
                string text1 = this.FunctionName;
                if (StringType.StrCmp(text1, "acos", false) == 0)
                {
                    obj2 = Math.Acos(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "asin", false) == 0)
                {
                    obj2 = Math.Asin(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "atan", false) == 0)
                {
                    obj2 = Math.Atan(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "cos", false) == 0)
                {
                    obj2 = Math.Cos(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "cosh", false) == 0)
                {
                    obj2 = Math.Cosh(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "ceiling", false) == 0)
                {
                    obj2 = Math.Ceiling(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "exp", false) == 0)
                {
                    obj2 = Math.Exp(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "floor", false) == 0)
                {
                    obj2 = Math.Floor(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "log", false) == 0)
                {
                    obj2 = Math.Log(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "log10", false) == 0)
                {
                    obj2 = Math.Log10(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "sign", false) == 0)
                {
                    object[] objArray1 = new object[] { RuntimeHelpers.GetObjectValue(obj2) };
                    bool[] flagArray1 = new bool[] { true };
                    if (flagArray1[0])
                    {
                        obj2 = RuntimeHelpers.GetObjectValue(objArray1[0]);
                    }
                    obj2 = RuntimeHelpers.GetObjectValue(LateBinding.LateGet(null, typeof(Math), "Sign", objArray1, null, flagArray1));
                }
                else if (StringType.StrCmp(text1, "sin", false) == 0)
                {
                    obj2 = Math.Sin(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "sinh", false) == 0)
                {
                    obj2 = Math.Sinh(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "sqrt", false) == 0)
                {
                    obj2 = Math.Sqrt(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "tan", false) == 0)
                {
                    obj2 = Math.Tan(DoubleType.FromObject(obj2));
                }
                else if (StringType.StrCmp(text1, "tanh", false) == 0)
                {
                    obj2 = Math.Tanh(DoubleType.FromObject(obj2));
                }
                if (double.IsNaN(DoubleType.FromObject(obj2)))
                {
                    obj2 = DBNull.Value;
                }
            }
            return obj2;
        }


        public override int ParameterCount
        {
            get
            {
                return 1;
            }
        }


        private string FunctionName;
    }
}

