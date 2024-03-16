namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    internal class VBString1Function : BaseFunction
    {
        public VBString1Function(string name)
        {
            this.name = name;
        }

        public override object Execute(object[] pars)
        {
            object obj2 = RuntimeHelpers.GetObjectValue(pars[0]);
            if (obj2 != DBNull.Value)
            {
                string text1 = StringType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(obj2), typeof(string), 0));
                string text2 = this.name;
                if (StringType.StrCmp(text2, "lower", false) == 0)
                {
                    return Strings.LCase(text1);
                }
                if (StringType.StrCmp(text2, "ltrim", false) == 0)
                {
                    return Strings.LTrim(text1);
                }
                if (StringType.StrCmp(text2, "rtrim", false) == 0)
                {
                    return Strings.RTrim(text1);
                }
                if (StringType.StrCmp(text2, "trim", false) == 0)
                {
                    return Strings.Trim(text1);
                }
                if (StringType.StrCmp(text2, "upper", false) == 0)
                {
                    obj2 = text1.ToUpper();
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


        private string name;
    }
}

