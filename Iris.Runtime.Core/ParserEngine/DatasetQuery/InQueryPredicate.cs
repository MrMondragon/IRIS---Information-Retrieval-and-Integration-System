namespace DatasetQuery
{
  using Microsoft.VisualBasic.CompilerServices;
  using System;
  using System.Data;
  using System.Runtime.CompilerServices;

  internal class InQueryPredicate : Predicate
  {
    public InQueryPredicate(Expression Left, bool UseNot, UnionList Query)
    {
      this.LeftExpression = Left;
      this.SelectQuery = Query;
      this.NotApplied = UseNot;
    }

    public override void Accept(IVisitor visitor)
    {
      visitor.Visit(this);
      this.LeftExpression.Accept(visitor);
      this.SelectQuery.Accept(visitor);
    }

    public override object KeepRow(DataRow row)
    {
      object obj1 = false;
      object obj2 = RuntimeHelpers.GetObjectValue(this.LeftExpression.KeepRow(row));
      if (Convert.IsDBNull(obj2))
        obj2 = null;
      if (row != null)
      {
        if (this.View == null)
        {
          this.View = this.SelectQuery.Execute(row.Table.DataSet);
        }
        int num2 = this.View.Count - 1;
        for (int num1 = 0; num1 <= num2; num1++)
        {
          if (ObjectType.ObjTst(this.View[num1].Row[0], obj2, false) == 0)
          {
            obj1 = true;
            break;
          }
        }
        if (this.NotApplied)
        {
          obj1 = ObjectType.NotObj(obj1);
        }
      }
      return obj1;
    }


    public override object IsInQuery
    {
      get
      {
        return true;
      }
    }


    internal Expression LeftExpression;
    internal bool NotApplied;
    internal UnionList SelectQuery;
    internal DataView View;
  }
}

