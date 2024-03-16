namespace DatasetQuery
{
    using System;
    using System.Data;

    internal class ColumnTableConstraint : CreateColumn
    {
        public ColumnTableConstraint(ColumnConstraintType Constraint)
        {
            this.Constraint = Constraint;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            this.Constraint.Accept(visitor);
        }

        public override void Create(DataTable dt)
        {
            this.Constraint.CreateOnTable(dt);
        }


        internal ColumnConstraintType Constraint;
    }
}

