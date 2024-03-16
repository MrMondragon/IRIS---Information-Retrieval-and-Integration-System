namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;

    internal abstract class ColumnConstraintType : ScriptNode
    {
        public abstract void Accept(IVisitor visitor);
        public abstract void CreateOnColumn(DataColumn dc);
        public abstract void CreateOnTable(DataTable dt);

        public string Name
        {
            get
            {
                if ((StringType.StrCmp(this.Identifier, string.Empty, false) == 0) || (StringType.StrCmp(this.Identifier, null, false) == 0))
                {
                    this.Identifier = Guid.NewGuid().ToString();
                }
                return this.Identifier;
            }
            set
            {
                this.Identifier = value.Replace("[", "").Replace("]", "");
            }
        }


        private string Identifier;
    }
}

