namespace DatasetQuery
{
  using Microsoft.VisualBasic;
  using Microsoft.VisualBasic.CompilerServices;
  using System;
  using System.Collections;
  using System.Data;
  using System.Runtime.CompilerServices;

  internal class ColumnsStm : ScriptNode
  {
    public ColumnsStm(string r, TopStm t, ColumnList l)
    {
      this.IsDistinct = StringType.FromBoolean(StringType.StrCmp(r.ToUpper(), "DISTINCT", false) == 0);
      this.Top = t;
      this.AllColumns = false;
      this.Columns = l;
    }

    public ColumnsStm(string r, TopStm t, bool All)
    {
      this.IsDistinct = StringType.FromBoolean(StringType.StrCmp(r.ToUpper(), "DISTINCT", false) == 0);
      this.Top = t;
      this.AllColumns = All;
      this.Columns = null;
    }

    public void Accept(IVisitor visitor)
    {
      visitor.Visit(this);
      if (this.Top != null)
      {
        this.Top.Accept(visitor);
      }
      if (this.Columns != null)
      {
        this.Columns.Accept(visitor);
      }
    }

    public int AddAnyAggregateColumns(DataTable output, SearchList having)
    {
      AggregateVistor vistor1 = new AggregateVistor();
      having.Accept(vistor1);
      int num2 = 1;
      foreach (FunctionValue value1 in vistor1.List)
      {
        ColumnSource source1 = new ColumnSource("Aggreg" + StringType.FromInteger(num2), new Expression(null, "", new UnaryExpression(value1, "")));
        this.Columns.List.Add(source1);
        DataColumn column1 = new DataColumn("Aggreg" + StringType.FromInteger(num2), typeof(decimal));
        column1.Caption = "DELETE";
        output.Columns.Add(column1);
        num2++;
      }
      return vistor1.List.Count;
    }

    private void CheckColumnInGroupBy(IdList groupby, DataColumn col, string underlyingName)
    {
      bool flag1 = false;
      foreach (IdItem item1 in groupby.List)
      {
        if (item1.Expression.IsColumnName)
        {
          string text1 = item1.Expression.ColumnName;
          if (((string.Compare(col.ColumnName, text1, true) != 0) && (string.Compare(underlyingName, text1, true) != 0)) && !this.IdentifiersMatch(col, text1))
          {
            continue;
          }
          flag1 = true;
          break;
        }
        if (item1.Expression.IsSubQuery || item1.Expression.IsAggregate)
        {
          throw new DataException("Cannot use an aggregate or a subquery in an expression used for the group by list of a GROUP BY clause.");
        }
        flag1 = true;
      }
      if (!flag1)
      {
        throw new DataException(string.Format("Column '{0}' is invalid in the select list because it is not contained in either an aggregate function or the GROUP BY clause.", col.ColumnName));
      }
    }

    public object[] GetAggregateValues(DataTable output, DataRow lastrow)
    {
      object[] objArray2 = new object[(this.Columns.List.Count - 1) + 1];
      int num1 = 0;
      foreach (ColumnSource source1 in this.Columns.List)
      {

        objArray2[num1] = RuntimeHelpers.GetObjectValue(source1.Expression.KeepRow(lastrow));
        if (!source1.TypeKnown && (objArray2[num1] != DBNull.Value))
        {
          if (output.Rows.Count == 0)
          {
            output.Columns[num1].DataType = objArray2[num1].GetType();
          }
          source1.TypeKnown = true;
        }
        num1++;
      }
      return objArray2;
    }

    public DataTable GetColumns(DataTable input, IdList GroupBy)
    {
      int num1=0;
      DataColumn column1;
      DataTable table2 = new DataTable("@@" + DateAndTime.Now.Ticks.ToString());
      if (this.AllColumns)
      {
        IEnumerator enumerator3 = null;
        try
        {
          enumerator3 = input.Columns.GetEnumerator();
          while (enumerator3.MoveNext())
          {
            column1 = (DataColumn)enumerator3.Current;
            if (GroupBy != null)
            {
              this.CheckColumnInGroupBy(GroupBy, column1, string.Empty);
            }
            table2.Columns.Add(Utilities.CloneColumn(column1));
          }
        }
        finally
        {
          if (enumerator3 is IDisposable)
          {
            ((IDisposable)enumerator3).Dispose();
          }
        }
      }
      else
      {
        int num3 = 1;
        int num2 = 0;
        try
        {
          foreach (ColumnSource source1 in this.Columns.List)
          {
            if (StringType.StrCmp(source1.ColumnName, "", false) == 0)
            {
              source1.ColumnName = "Column" + StringType.FromInteger(num3);
              num3++;
            }
            if (source1.Expression != null)
            {
              if (source1.Expression.IsAggregate)
              {
                num1++;
                if ((num2 > 0) && (GroupBy == null))
                {
                  throw new DataException("Invalid mixing of aggregate and non-aggregate columns or missing GROUP BY");
                }
              }
              else if (!source1.Expression.IsConstant)
              {
                num2++;
                if ((num1 > 0) && (GroupBy == null))
                {
                  throw new DataException("Invalid mixing of aggregate and non-aggregate columns or missing GROUP BY");
                }
              }
            }
            if (source1.ColumnName.EndsWith(".*"))
            {
              IEnumerator enumerator1 = null;
              string text1 = source1.ColumnName.Replace(".*", "").ToLower();
              int num4 = 0;
              try
              {
                enumerator1 = input.Columns.GetEnumerator();
                while (enumerator1.MoveNext())
                {
                  column1 = (DataColumn)enumerator1.Current;
                  DataColumn column2 = null;
                  if (StringType.StrCmp(text1, input.TableName.ToLower(), false) == 0)
                  {
                    column2 = column1;
                  }
                  else if (column1.ColumnName.ToLower().StartsWith(text1))
                  {
                    column2 = Utilities.GetColumn(input.Columns, column1.ColumnName);
                  }
                  if (column2 != null)
                  {
                    column2 = Utilities.CloneColumn(column2);
                    column2.ColumnName = Utilities.AvoidDuplicateColumnName(table2.Columns, column2.ColumnName);
                    table2.Columns.Add(column2);
                    if (source1.Ordinal == -1)
                    {
                      source1.Ordinal = (short)column1.Ordinal;
                    }
                    num4++;
                  }
                }
              }
              finally
              {
                if (enumerator1 is IDisposable)
                {
                  ((IDisposable)enumerator1).Dispose();
                }
              }
              source1.Count = (short)num4;
            }
            else
            {
              column1 = source1.GetDataColumn(input);
              if (source1.Expression.IsColumnName & (StringType.StrCmp(source1.AliasName, "", false) != 0))
              {
                column1.Caption = source1.AliasName;
                column1.ColumnName = source1.AliasName;
              }
              else
              {
                column1.Caption = source1.ColumnName;
              }
              column1.ColumnName = Utilities.AvoidDuplicateColumnName(table2.Columns, column1.ColumnName);
              table2.Columns.Add(column1);
              AggregateVistor vistor1 = new AggregateVistor();
              source1.Expression.Accept(vistor1);
              if ((!source1.Expression.IsConstant && (GroupBy != null)) && (vistor1.List.Count < 1))
              {
                this.CheckColumnInGroupBy(GroupBy, column1, source1.ColumnName);
              }
            }
          }
        }
        finally
        {
          IEnumerator enumerator2 = null;
          if (enumerator2 is IDisposable)
          {
            ((IDisposable)enumerator2).Dispose();
          }
        }
      }
      if (num1 > 0)
      {
        this.AreAggregates = true;
      }
      return table2;
    }

    private bool IdentifiersMatch(DataColumn col, string name)
    {
      if (((string.Compare(col.ColumnName, col.Table.TableName + "." + name, true) != 0) && (string.Compare(name, Strings.Mid(col.ColumnName, col.ColumnName.IndexOf(".") + 2), true) != 0)) && (string.Compare(name, col.Table.TableName + "." + col.ColumnName, true) != 0))
      {
        return false;
      }
      return true;
    }

    public void ProcessAggregates(DataRow row)
    {
      foreach (ColumnSource source1 in this.Columns.List)
      {
        source1.Expression.CalculateRow(row);
      }
    }

    public object[] ProcessRow(DataTable output, DataRow row)
    {
      object[] objArray2 = new object[(output.Columns.Count - 1) + 1];
      int num1 = 0;
      foreach (ColumnSource source1 in this.Columns.List)
      {
        if (source1.ColumnName.EndsWith(".*"))
        {
          DataTable table1 = row.Table;
          int num2 = source1.Ordinal;
          int num4 = source1.Count - 1;
          for (int num3 = 0; num3 <= num4; num3++)
          {
            objArray2[num1] = RuntimeHelpers.GetObjectValue(row[num2]);
            num1++;
            num2++;
          }
        }
        else
        {
          objArray2[num1] = RuntimeHelpers.GetObjectValue(source1.ProcessValue(row));
          if (!source1.TypeKnown && (objArray2[num1] != DBNull.Value))
          {
            if (output.Rows.Count == 0)
            {
              output.Columns[num1].DataType = objArray2[num1].GetType();
            }
            source1.TypeKnown = true;
          }
          num1++;
        }
      }
      return objArray2;
    }

    public void ResetAggregates()
    {
      foreach (ColumnSource source1 in this.Columns.List)
      {
        source1.Expression.CalculateRow(null);
      }
    }


    internal bool AllColumns;
    internal bool AreAggregates;
    internal ColumnList Columns;
    internal string IsDistinct;
    internal TopStm Top;


    public class AggregateVistor : IVisitor
    {
      public AggregateVistor()
      {
        this.List = new ArrayList();
      }

      public void Visit(object obj)
      {
        if (obj is AggregateFunctionValue)
        {
          this.List.Add(RuntimeHelpers.GetObjectValue(obj));
        }
      }


      public ArrayList List;
    }
  }
}

