namespace DatasetQuery
{
  using System;
  using System.Collections;
  using System.Data;
  using System.Runtime.CompilerServices;

  internal class ArgumentList : ScriptNode
  {
    public ArgumentList(ArgumentItem item)
    {
      this.List = new ArrayList();
      if (item != null)
      {
        this.List.Add(item);
      }
    }

    public void Accept(IVisitor visitor)
    {
      visitor.Visit(this);
      foreach (ArgumentItem item1 in this.List)
      {
        item1.Accept(visitor);
      }
    }

    public void Add(ArgumentItem item)
    {
      if (item != null)
      {
        this.List.Add(item);
      }
    }

    public void CalculateRow(DataRow row)
    {
      foreach (ArgumentItem item1 in this.List)
      {
        if (!item1.Star)
        {
          item1.Expression.CalculateRow(row);
        }
      }
    }

    public object[] GetParameters(DataRow row)
    {
      int num1 = 0;
      object[] objArray2 = new object[(this.List.Count - 1) + 1];
      foreach (ArgumentItem item1 in this.List)
      {
        if (!item1.Star)
        {
          objArray2[num1] = RuntimeHelpers.GetObjectValue(item1.Expression.KeepRow(row));
        }
        num1++;
      }
      return objArray2;
    }


    internal ArrayList List;
  }
}

