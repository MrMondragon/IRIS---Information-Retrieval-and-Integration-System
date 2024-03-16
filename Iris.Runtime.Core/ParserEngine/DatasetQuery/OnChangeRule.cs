namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal class OnChangeRule
    {
        public OnChangeRule(string Type, System.Data.Rule RuleType)
        {
            this.Name = Type.ToUpper();
            this.Rule = RuleType;
        }


        public bool IsDelete
        {
            get
            {
                return (StringType.StrCmp(this.Name, "DELETE", false) == 0);
            }
        }

        public bool IsUpdate
        {
            get
            {
                return (StringType.StrCmp(this.Name, "UPDATE", false) == 0);
            }
        }


        internal string Name;
        internal System.Data.Rule Rule;
    }
}

