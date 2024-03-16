namespace DatasetQuery
{
  using Microsoft.VisualBasic;
  using Microsoft.VisualBasic.CompilerServices;
  using System;
  using System.Collections;
  using System.Data;
  using System.Runtime.CompilerServices;

  internal class SelectStm : SQLStatement
  {
    public SelectStm(ColumnsStm Columns, string Into, TableSourceList FromStm, SearchList WhereStm, IdList Groupby, SearchList Having, OrderByList Orderby)
    {
      this.Columns = Columns;
      this.Into = Into;
      this.FromStm = FromStm;
      this.WhereStm = WhereStm;
      this.GroupBy = Groupby;
      this.Having = Having;
      this.OrderBy = Orderby;
      if (FromStm != null)
      {
        this.RemoveAliases();
      }
      if (this.Columns.Columns != null)
      {
        this.Columns.Columns.Optimize();
      }
      if (WhereStm != null)
      {
        WhereStm.IsWhere = true;
      }
    }

    public override void Accept(IVisitor visitor)
    {
      visitor.Visit(this);
      this.Columns.Accept(visitor);
      if (this.FromStm != null)
      {
        this.FromStm.Accept(visitor);
      }
      if (this.WhereStm != null)
      {
        this.WhereStm.Accept(visitor);
      }
      if (this.GroupBy != null)
      {
        this.GroupBy.Accept(visitor);
      }
      if (this.Having != null)
      {
        this.Having.Accept(visitor);
      }
    }

    public override DataView Execute(DataSet dataset)
    {
      DataTable table1 = null;
      if (this.output == null)
      {
        if (this.FromStm != null)
        {
          this.FromStm.Optimize();
          table1 = this.FromStm.Evaluate(dataset).Execute();
        }
        else if (this.Columns.AllColumns)
        {
          throw new DataException("Must specify table to select from.");
        }
        this.output = this.Columns.GetColumns(table1, this.GroupBy);
        if (StringType.StrCmp(this.Into, "", false) != 0)
        {
          this.output.TableName = this.Into.Replace("[", "").Replace("]", "");
        }
        if ((this.Having != null) && (this.Columns.AddAnyAggregateColumns(this.output, this.Having) > 0))
        {
          this.Columns.AreAggregates = true;
        }
      }
      else
      {
        table1 = this.FromStm.Evaluate(dataset).Execute();
        this.output.Clear();
      }
      DataView view2 = new DataView(this.output);
      int num1 = 0x7fffffff;
      if ((this.Columns.Top != null) && (this.OrderBy == null))
      {
        num1 = this.Columns.Top.MaxRows;
      }
      if (num1 > 0)
      {
        int num2 = 0;
        if (table1 != null)
        {
          DataRow[] rowArray1;
          if (this.GroupBy != null)
          {
            rowArray1 = table1.Select("", this.GroupBy.GetSort(table1.Columns));
            this.Columns.AreAggregates = true;
          }
          else
          {
            rowArray1 = table1.Select();
          }
          DataRow row1 = null;
          this.output.BeginLoadData();
          foreach (DataRow row2 in rowArray1)
          {
            if (BooleanType.FromObject(BooleanType.FromObject(this.WhereStm == null) || BooleanType.FromObject(this.WhereStm.KeepRow(row2))))
            {
              bool flag1 = false;
              if (this.Columns.AllColumns)
              {
                this.output.LoadDataRow(row2.ItemArray, true);
                flag1 = true;
              }
              else if (this.Columns.AreAggregates)
              {
                if (this.GroupBy != null)
                {
                  bool flag2 = false;
                  flag2 = false;
                  if (row1 != null)
                  {
                    flag2 = true;
                    foreach (IdItem item1 in this.GroupBy.List)
                    {
                      object obj1 = RuntimeHelpers.GetObjectValue(item1.Expression.KeepRow(row1));
                      object obj2 = RuntimeHelpers.GetObjectValue(item1.Expression.KeepRow(row2));
                      if (!Utilities.ColumnEqual(RuntimeHelpers.GetObjectValue(obj1), RuntimeHelpers.GetObjectValue(obj2)))
                      {
                        flag2 = false;
                        break;
                      }
                    }
                    if (!flag2)
                    {
                      flag1 = this.ProcessHaving(this.output, row1);
                    }
                  }
                  if (!flag2)
                  {
                    num2 = 0;
                  }
                  row1 = row2;
                }
                this.Columns.ProcessAggregates(row2);
                num2++;
              }
              else
              {
                try
                {
                  this.output.LoadDataRow(this.Columns.ProcessRow(this.output, row2), true);
                }
                catch (Exception exception2)
                {
                  ProjectData.SetProjectError(exception2);
                  Exception exception1 = exception2;
                  throw new DataException(exception1.Message, exception1);
                }
                flag1 = true;
              }
              if (flag1)
              {
                num1--;
                if (num1 <= 0)
                {
                  break;
                }
              }
            }
          }
          if (num2 > 0)
          {
            this.ProcessHaving(this.output, row1);
          }
          this.output.EndLoadData();
        }
        if (table1 == null)
        {
          DataRow row3 = this.output.Rows.Add(this.Columns.ProcessRow(this.output, null));
          if (BooleanType.FromObject(ObjectType.NotObj(BooleanType.FromObject(this.WhereStm == null) || BooleanType.FromObject(this.WhereStm.KeepRow(row3)))))
          {
            row3.Delete();
          }
        }
        else if (((this.GroupBy == null) && this.Columns.AreAggregates) && (num2 == 0))
        {
          this.output.LoadDataRow(this.Columns.GetAggregateValues(this.output, null), true);
        }
        else
        {
          if (BooleanType.FromString(this.Columns.IsDistinct) && (this.GroupBy == null))
          {
            Utilities.Distinct(view2);
          }
          if (this.OrderBy != null)
          {
            view2.Sort = this.OrderBy.GetSort(this.output.Columns);
          }
          if (this.Columns.Top != null)
          {
            Utilities.TruncateToMaxRows(view2, this.Columns.Top.MaxRows);
          }
        }
      }
      DataTable table2 = view2.Table;
      string[] textArray1 = new string[(table2.Columns.Count - 1) + 1];
      int num3 = 0;
      foreach (DataColumn column1 in table2.Columns)
      {
        if (StringType.StrCmp(column1.Caption, "DELETE", false) == 0)
        {
          textArray1[num3] = column1.ColumnName;
          num3++;
        }
        else
        {
          column1.ColumnName = column1.Caption;
        }
      }
      while (num3 > 0)
      {
        table2.Columns.Remove(textArray1[num3 - 1]);
        num3--;
      }
      foreach (DataColumn column2 in table2.Columns)
      {
        if (column2.ColumnName.IndexOf('.') >= 0)
        {
          string text1 = column2.ColumnName.Substring(column2.ColumnName.IndexOf('.') + 1);
          column2.ColumnName = Utilities.AvoidDuplicateColumnName(table2.Columns, text1);
        }
      }
      table2 = null;
      return view2;
    }

    public override int ExecuteNonQuery(DataSet dataset)
    {
      throw new NotImplementedException();
    }

    private bool ProcessHaving(DataTable output, DataRow lastrow)
    {
      bool flag1;
      object[] objArray1 = this.Columns.GetAggregateValues(output, lastrow);
      if (this.Having == null)
      {
        flag1 = true;
      }
      else
      {
        DataRow row1 = output.NewRow();
        row1.ItemArray = objArray1;
        object obj1 = RuntimeHelpers.GetObjectValue(this.Having.KeepRow(row1));
        if (obj1 == DBNull.Value)
        {
          flag1 = false;
        }
        else
        {
          flag1 = BooleanType.FromObject(obj1);
        }
        row1.Delete();
      }
      if (flag1)
      {
        output.LoadDataRow(objArray1, true);
      }
      this.Columns.ResetAggregates();
      return flag1;
    }

    public void RemoveAliases()
    {
      TableSourceVistor vistor1 = new TableSourceVistor();
      this.FromStm.Accept(vistor1);
      this.ids = new IdentifierVistor();
      this.Accept(this.ids);
      foreach (IdentifierValue value1 in this.ids.List)
      {
        if (value1.Identifier.IndexOf(".") >= 0)
        {
          value1.Identifier = this.SubstituteAlias(vistor1, value1.Identifier);
        }
      }
      if (this.OrderBy != null)
      {
        OrderByList list1 = this.OrderBy;
        foreach (OrderItem item1 in list1.List)
        {
          if (item1.OrderBy.IndexOf(".") >= 0)
          {
            item1.OrderBy = this.SubstituteAlias(vistor1, item1.OrderBy);
          }
        }
        list1 = null;
      }
      try
      {
        foreach (TableSource source1 in vistor1.AliasList)
        {
          source1.AliasName = "";
        }
      }
      finally
      {
        IEnumerator enumerator1 = null;
        if (enumerator1 is IDisposable)
        {
          ((IDisposable)enumerator1).Dispose();
        }
      }
    }

    private string SubstituteAlias(TableSourceVistor tablesources, string identifier)
    {
      string text2 = identifier;
      int num1 = identifier.IndexOf(".");
      string text1 = Strings.Mid(identifier, 1, num1).ToUpper();
      foreach (TableSource source1 in tablesources.AliasList)
      {
        if ((StringType.StrCmp(source1.AliasName, text1, false) == 0) && (StringType.StrCmp(source1.TableName, "", false) != 0))
        {
          text2 = source1.TableName + Strings.Mid(identifier, num1 + 1);
          text1 = source1.TableName.ToUpper();
          break;
        }
      }
      bool flag1 = false;
      foreach (TableSource source2 in tablesources.NameList)
      {
        if ((source2.TableName != null) && (StringType.StrCmp(source2.TableName.ToUpper(), text1, false) == 0))
        {
          flag1 = true;
          break;
        }
      }
      if (!flag1)
      {
        throw new DataException(string.Format("The column prefix '{0}' does not match with a table name used in the query.", text1));
      }
      return text2;
    }


    internal ColumnsStm Columns;
    internal TableSourceList FromStm;
    internal IdList GroupBy;
    internal SearchList Having;
    internal IdentifierVistor ids;
    internal string Into;
    internal OrderByList OrderBy;
    internal DataTable output;
    internal SearchList WhereStm;
  }
}

