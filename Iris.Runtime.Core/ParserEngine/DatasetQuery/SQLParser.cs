namespace DatasetQuery
{
  using Microsoft.VisualBasic;
  using Microsoft.VisualBasic.CompilerServices;
  using DatasetQuery.GoldParser;
  using System;
  using System.Collections;
  using System.Data;
  using System.Runtime.CompilerServices;

  internal class SQLParser : TemplateParser
  {
    public SQLParser(string input, Grammar grammar)
      : base(input, grammar)
    {
    }

    protected override object CreateRule_Action_Cascade(ArrayList Tokens)
    {
      return System.Data.Rule.Cascade;
    }

    protected override object CreateRule_Action_No_Action(ArrayList Tokens)
    {
      return System.Data.Rule.None;
    }

    protected override object CreateRule_Action_Set_Default(ArrayList Tokens)
    {
      return System.Data.Rule.SetDefault;
    }

    protected override object CreateRule_Action_Set_Null(ArrayList Tokens)
    {
      return System.Data.Rule.SetNull;
    }

    protected override object CreateRule_Alias(ArrayList Tokens)
    {
      return "";
    }

    protected override object CreateRule_Alias_As_Identifier(ArrayList Tokens)
    {
      return LateBinding.LateGet(LateBinding.LateGet(((Token)Tokens[1]).Data, null, "Replace", new object[] { "[", "" }, null, null), null, "Replace", new object[] { "]", "" }, null, null);
    }

    protected override object CreateRule_Alias_As_Stringliteral(ArrayList Tokens)
    {
      return LateBinding.LateGet(LateBinding.LateGet(((Token)Tokens[1]).Data, null, "Replace", new object[] { "[", "" }, null, null), null, "Replace", new object[] { "]", "" }, null, null);
    }

    protected override object CreateRule_Alias_Identifier(ArrayList Tokens)
    {
      return LateBinding.LateGet(LateBinding.LateGet(((Token)Tokens[0]).Data, null, "Replace", new object[] { "[", "" }, null, null), null, "Replace", new object[] { "]", "" }, null, null);
    }

    protected override object CreateRule_Alldistinct_All(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Data;
    }

    protected override object CreateRule_Alldistinct_Distinct(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Data;
    }

    protected override object CreateRule_Argumentlist(ArrayList Tokens)
    {
      return new ArgumentList((ArgumentItem)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Argumentlist_Comma(ArrayList Tokens)
    {
      ArgumentList list1 = (ArgumentList)((Token)Tokens[0]).Reduction.Tag;
      list1.Add((ArgumentItem)((Token)Tokens[2]).Reduction.Tag);
      return list1;
    }

    protected override object CreateRule_Argumentlistopt(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Argumentlistopt_Lparan_Rparan(ArrayList Tokens)
    {
      return new ArgListOpt(StringType.FromObject(((Token)Tokens[1]).Reduction.Tag), (ArgumentList)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Assignlist_Identifier_Eq(ArrayList Tokens)
    {
      return new AssignList(new AssignValue(StringType.FromObject(((Token)Tokens[0]).Data), (InsertValue)((Token)Tokens[2]).Reduction.Tag));
    }

    protected override object CreateRule_Assignlist_Identifier_Eq_Comma(ArrayList Tokens)
    {
      AssignList list1 = (AssignList)((Token)Tokens[4]).Reduction.Tag;
      list1.Add(new AssignValue(StringType.FromObject(((Token)Tokens[0]).Data), (InsertValue)((Token)Tokens[2]).Reduction.Tag));
      return list1;
    }

    protected override object CreateRule_Case_Case_End(ArrayList Tokens)
    {
      return new CaseValue((Expression)((Token)Tokens[1]).Reduction.Tag, (CaseWhenList)((Token)Tokens[2]).Reduction.Tag, (Expression)((Token)Tokens[3]).Reduction.Tag);
    }

    protected override object CreateRule_Caseelse(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Caseelse_Else(ArrayList Tokens)
    {
      return ((Token)Tokens[1]).Reduction.Tag;
    }

    protected override object CreateRule_Casetype(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Casetype2(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Casewhen_When_Then(ArrayList Tokens)
    {
      return new CaseItem((SearchList)((Token)Tokens[1]).Reduction.Tag, (Expression)((Token)Tokens[3]).Reduction.Tag);
    }

    protected override object CreateRule_Casewhenlist(ArrayList Tokens)
    {
      CaseWhenList list1 = (CaseWhenList)((Token)Tokens[1]).Reduction.Tag;
      list1.Add((CaseItem)((Token)Tokens[0]).Reduction.Tag);
      return list1;
    }

    protected override object CreateRule_Casewhenlist2(ArrayList Tokens)
    {
      return new CaseWhenList((CaseItem)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Checkconstraint_Check(ArrayList Tokens)
    {
      return new CheckedConstraint((SearchList)((Token)Tokens[1]).Reduction.Tag);
    }

    protected override object CreateRule_Clusteredunclustered(ArrayList Tokens)
    {
      return false;
    }

    protected override object CreateRule_Clusteredunclustered_Clustered(ArrayList Tokens)
    {
      return true;
    }

    protected override object CreateRule_Clusteredunclustered_Nonclustered(ArrayList Tokens)
    {
      return false;
    }

    protected override object CreateRule_Collation(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Collation_Collate_Identifier(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Columnconstraint(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Columnconstraint_Constraint_Identifier(ArrayList Tokens)
    {
      ColumnConstraintType type1 = (ColumnConstraintType)((Token)Tokens[2]).Reduction.Tag;
      type1.Name = StringType.FromObject(((Token)Tokens[1]).Data);
      return type1;
    }

    protected override object CreateRule_Columnconstrainttype(ArrayList Tokens)
    {
      return new NullConstraint(BooleanType.FromObject(((Token)Tokens[0]).Reduction.Tag));
    }

    protected override object CreateRule_Columnconstrainttype2(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Columnconstrainttype3(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Columnconstrainttype4(ArrayList Tokens)
    {
      return new RowGuidConstraint();
    }

    protected override object CreateRule_Columnconstrainttype5(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Columnconstrainttype6(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Columnconstrainttype7(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Columndefinition_Identifier(ArrayList Tokens)
    {
      return new ColumnDefinition(StringType.FromObject(((Token)Tokens[0]).Data), (DataType)((Token)Tokens[1]).Reduction.Tag, (ConstraintList)((Token)Tokens[3]).Reduction.Tag);
    }

    protected override object CreateRule_Columnlist(ArrayList Tokens)
    {
      return new ColumnList((ColumnSource)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Columnlist_Comma(ArrayList Tokens)
    {
      ColumnList list1 = (ColumnList)((Token)Tokens[2]).Reduction.Tag;
      list1.Add((ColumnSource)((Token)Tokens[0]).Reduction.Tag);
      return list1;
    }

    protected override object CreateRule_Columns(ArrayList Tokens)
    {
      return new ColumnsStm(StringType.FromObject(((Token)Tokens[0]).Reduction.Tag), (TopStm)((Token)Tokens[1]).Reduction.Tag, (ColumnList)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Columns_Times(ArrayList Tokens)
    {
      return new ColumnsStm(StringType.FromObject(((Token)Tokens[0]).Reduction.Tag), (TopStm)((Token)Tokens[1]).Reduction.Tag, true);
    }

    protected override object CreateRule_Columnsource(ArrayList Tokens)
    {
      return new ColumnSource((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Reduction.Tag));
    }

    protected override object CreateRule_Columnsource_Idendifier(ArrayList Tokens)
    {
      return new ColumnSource(StringType.FromObject(((Token)Tokens[0]).Data), null);
    }

    protected override object CreateRule_Columnsource_Identifier_Eq(ArrayList Tokens)
    {
      return new ColumnSource(StringType.FromObject(((Token)Tokens[0]).Data), (Expression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Columnsource_Stringliteral_Eq(ArrayList Tokens)
    {
      return new ColumnSource(StringType.FromObject(((Token)Tokens[0]).Data), (Expression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Comparisons(ArrayList Tokens)
    {
      return new Comparisons((Expression)((Token)Tokens[0]).Reduction.Tag, "", null);
    }

    protected override object CreateRule_Comparisons_Eq(ArrayList Tokens)
    {
      return new Comparisons((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (Expression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Comparisons_Exclameq(ArrayList Tokens)
    {
      return new Comparisons((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (Expression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Comparisons_Gt(ArrayList Tokens)
    {
      return new Comparisons((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (Expression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Comparisons_Gteq(ArrayList Tokens)
    {
      return new Comparisons((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (Expression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Comparisons_Lt(ArrayList Tokens)
    {
      return new Comparisons((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (Expression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Comparisons_Lteq(ArrayList Tokens)
    {
      return new Comparisons((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (Expression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Comparisons_Ltgt(ArrayList Tokens)
    {
      return new Comparisons((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (Expression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Constraintcolumn_Identifier(ArrayList Tokens)
    {
      return new ConstraintColumn(StringType.FromObject(((Token)Tokens[0]).Data), StringType.FromObject(((Token)Tokens[1]).Data));
    }

    protected override object CreateRule_Constraintcolumnlist(ArrayList Tokens)
    {
      return new ConstraintColumnList((ConstraintColumn)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Constraintcolumnlist_Comma(ArrayList Tokens)
    {
      ConstraintColumnList list1 = (ConstraintColumnList)((Token)Tokens[0]).Reduction.Tag;
      list1.Add((ConstraintColumn)((Token)Tokens[2]).Reduction.Tag);
      return list1;
    }

    protected override object CreateRule_Constraintcolumns(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Constraintcolumns_Lparan_Rparan(ArrayList Tokens)
    {
      return ((Token)Tokens[1]).Reduction.Tag;
    }

    protected override object CreateRule_Constraintlist(ArrayList Tokens)
    {
      ConstraintList list1 = (ConstraintList)((Token)Tokens[0]).Reduction.Tag;
      list1.Add((ColumnConstraintType)((Token)Tokens[1]).Reduction.Tag);
      return list1;
    }

    protected override object CreateRule_Constraintlist2(ArrayList Tokens)
    {
      return new ConstraintList((ColumnConstraintType)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Constraintlist3(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Createcolumn(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Createcolumn_Identifier_As_Stringliteral(ArrayList Tokens)
    {
      return new ColumnExpression(StringType.FromObject(((Token)Tokens[0]).Data), (DataType)((Token)Tokens[1]).Reduction.Tag, StringType.FromObject(((Token)Tokens[3]).Data));
    }

    protected override object CreateRule_Createcolumn2(ArrayList Tokens)
    {
      return new ColumnTableConstraint((ColumnConstraintType)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Createcolumns(ArrayList Tokens)
    {
      return new CreateColumnList((CreateColumn)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Createcolumns_Comma(ArrayList Tokens)
    {
      CreateColumnList list1 = (CreateColumnList)((Token)Tokens[0]).Reduction.Tag;
      list1.Add((CreateColumn)((Token)Tokens[2]).Reduction.Tag);
      return list1;
    }

    protected override object CreateRule_Createindexstm_Create_Index_Identifier_On_Identifier_Lparan_Rparan(ArrayList Tokens)
    {
      return new CreateIndexStm(BooleanType.FromObject(((Token)Tokens[1]).Reduction.Tag), BooleanType.FromObject(((Token)Tokens[2]).Reduction.Tag), StringType.FromObject(((Token)Tokens[4]).Data), StringType.FromObject(((Token)Tokens[6]).Data), (ConstraintColumnList)((Token)Tokens[8]).Reduction.Tag);
    }

    protected override object CreateRule_Createtablestm_Create_Table_Identifier_Lparan_Rparan(ArrayList Tokens)
    {
      return new CreateTableStm(StringType.FromObject(((Token)Tokens[2]).Data), (CreateColumnList)((Token)Tokens[4]).Reduction.Tag);
    }

    protected override object CreateRule_Defaultconstraint_Default(ArrayList Tokens)
    {
      return new DefaultConstraint((Expression)((Token)Tokens[1]).Reduction.Tag);
    }

    protected override object CreateRule_Deletestm_Delete_Identifier(ArrayList Tokens)
    {
      return new DeleteStm(StringType.FromObject(((Token)Tokens[2]).Data), (SearchList)((Token)Tokens[3]).Reduction.Tag);
    }

    protected override object CreateRule_Dropindexstm_Drop_Index(ArrayList Tokens)
    {
      return new DropIndexStm((IdentifierList)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Droptablestm_Drop_Table_Identifier(ArrayList Tokens)
    {
      return new DropTableStm(StringType.FromObject(((Token)Tokens[2]).Data));
    }

    protected override object CreateRule_Expression(ArrayList Tokens)
    {
      return new Expression(null, "", (UnaryExpression)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Expression_Amp(ArrayList Tokens)
    {
      return new Expression((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (UnaryExpression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Expression_Caret(ArrayList Tokens)
    {
      return new Expression((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (UnaryExpression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Expression_Div(ArrayList Tokens)
    {
      return new Expression((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (UnaryExpression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Expression_Minus(ArrayList Tokens)
    {
      return new Expression((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (UnaryExpression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Expression_Percent(ArrayList Tokens)
    {
      return new Expression((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (UnaryExpression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Expression_Pipe(ArrayList Tokens)
    {
      return new Expression((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (UnaryExpression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Expression_Plus(ArrayList Tokens)
    {
      return new Expression((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (UnaryExpression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Expression_Times(ArrayList Tokens)
    {
      return new Expression((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Data), (UnaryExpression)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Expressionlist(ArrayList Tokens)
    {
      return new ExpressionList((Expression)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Expressionlist_Comma(ArrayList Tokens)
    {
      ExpressionList list1 = (ExpressionList)((Token)Tokens[2]).Reduction.Tag;
      list1.Add((Expression)((Token)Tokens[0]).Reduction.Tag);
      return list1;
    }

    protected override object CreateRule_Foreignkey_Foreign_Key_Lparan_Rparan_References_Identifier(ArrayList Tokens)
    {
      return new DatasetQuery.ForeignKeyConstraint((ConstraintColumnList)((Token)Tokens[3]).Reduction.Tag, StringType.FromObject(((Token)Tokens[6]).Data), (IdList)((Token)Tokens[7]).Reduction.Tag, (OnChangeRule)((Token)Tokens[8]).Reduction.Tag, (OnChangeRule)((Token)Tokens[9]).Reduction.Tag);
    }

    protected override object CreateRule_Foreignkey_Foreign_Key_References_Identifier(ArrayList Tokens)
    {
      return new DatasetQuery.ForeignKeyConstraint(null, StringType.FromObject(((Token)Tokens[3]).Data), (IdList)((Token)Tokens[4]).Reduction.Tag, (OnChangeRule)((Token)Tokens[5]).Reduction.Tag, (OnChangeRule)((Token)Tokens[6]).Reduction.Tag);
    }

    protected override object CreateRule_Foreignkey_References_Identifier(ArrayList Tokens)
    {
      return new DatasetQuery.ForeignKeyConstraint(null, StringType.FromObject(((Token)Tokens[1]).Data), (IdList)((Token)Tokens[2]).Reduction.Tag, (OnChangeRule)((Token)Tokens[3]).Reduction.Tag, (OnChangeRule)((Token)Tokens[4]).Reduction.Tag);
    }

    protected override object CreateRule_From(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_From_From(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Fromclause(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Fromclause_From(ArrayList Tokens)
    {
      return ((Token)Tokens[1]).Reduction.Tag;
    }

    protected override object CreateRule_Functionargs(ArrayList Tokens)
    {
      return new ArgumentItem((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Reduction.Tag));
    }

    protected override object CreateRule_Functionargs_Times(ArrayList Tokens)
    {
      return new ArgumentItem(true);
    }

    protected override object CreateRule_Functionargs2(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Groupclause(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Groupclause_Group_By(ArrayList Tokens)
    {
      return ((Token)Tokens[2]).Reduction.Tag;
    }

    protected override object CreateRule_Groupclause_Group_By_All(ArrayList Tokens)
    {
      throw new NotSupportedException("GROUP BY ALL");
    }

    protected override object CreateRule_Havingclause(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Havingclause_Having(ArrayList Tokens)
    {
      return ((Token)Tokens[1]).Reduction.Tag;
    }

    protected override object CreateRule_Identifierlist_Comma_Identifier(ArrayList Tokens)
    {
      IdentifierList list1 = (IdentifierList)((Token)Tokens[0]).Reduction.Tag;
      list1.Add(StringType.FromObject(((Token)Tokens[2]).Data));
      return list1;
    }

    protected override object CreateRule_Identifierlist_Identifier(ArrayList Tokens)
    {
      return new IdentifierList(StringType.FromObject(((Token)Tokens[0]).Data));
    }

    protected override object CreateRule_Identityconstraint_Identity(ArrayList Tokens)
    {
      return new IdentityConstraint();
    }

    protected override object CreateRule_Identityconstraint_Identity_Lparan_Comma_Rparan(ArrayList Tokens)
    {
      return new IdentityConstraint(RuntimeHelpers.GetObjectValue(((Token)Tokens[2]).Reduction.Tag), RuntimeHelpers.GetObjectValue(((Token)Tokens[4]).Reduction.Tag));
    }

    protected override object CreateRule_Idlist(ArrayList Tokens)
    {
      return new IdList(new IdItem((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Reduction.Tag)));
    }

    protected override object CreateRule_Idlist_Comma(ArrayList Tokens)
    {
      IdList list1 = (IdList)((Token)Tokens[3]).Reduction.Tag;
      list1.Add(new IdItem((Expression)((Token)Tokens[0]).Reduction.Tag, StringType.FromObject(((Token)Tokens[1]).Reduction.Tag)));
      return list1;
    }

    protected override object CreateRule_Insertcolumns(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Insertcolumns_Lparan_Rparan(ArrayList Tokens)
    {
      return ((Token)Tokens[1]).Reduction.Tag;
    }

    protected override object CreateRule_Insertlist(ArrayList Tokens)
    {
      return new InsertValueList((InsertValue)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Insertlist_Comma(ArrayList Tokens)
    {
      InsertValueList list1 = (InsertValueList)((Token)Tokens[0]).Reduction.Tag;
      list1.Add((InsertValue)((Token)Tokens[2]).Reduction.Tag);
      return list1;
    }

    protected override object CreateRule_Insertstm_Insert_Identifier(ArrayList Tokens)
    {
      return new InsertSelectStm(StringType.FromObject(((Token)Tokens[2]).Data), (IdList)((Token)Tokens[3]).Reduction.Tag, (UnionList)((Token)Tokens[4]).Reduction.Tag);
    }

    protected override object CreateRule_Insertstm_Insert_Identifier_Default_Values(ArrayList Tokens)
    {
      return new InsertValuesStm(StringType.FromObject(((Token)Tokens[2]).Data));
    }

    protected override object CreateRule_Insertstm_Insert_Identifier_Values_Lparan_Rparan(ArrayList Tokens)
    {
      return new InsertValuesStm(StringType.FromObject(((Token)Tokens[2]).Data), (IdList)((Token)Tokens[3]).Reduction.Tag, (InsertValueList)((Token)Tokens[6]).Reduction.Tag);
    }

    protected override object CreateRule_Insertupdateitem(ArrayList Tokens)
    {
      return new InsertValue((Expression)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Insertupdateitem_Default(ArrayList Tokens)
    {
      return new InsertValue();
    }

    protected override object CreateRule_Integervalue_Integerliteral(ArrayList Tokens)
    {
      return this.GetIntegerValue(StringType.FromObject(((Token)Tokens[0]).Data));
    }

    protected override object CreateRule_Integervalue_Minus_Integerliteral(ArrayList Tokens)
    {
      return this.GetIntegerValue(StringType.FromObject(ObjectType.StrCatObj(((Token)Tokens[0]).Data, ((Token)Tokens[1]).Data)));
    }

    protected override object CreateRule_Integervalue_Plus_Integerliteral(ArrayList Tokens)
    {
      return this.GetIntegerValue(StringType.FromObject(((Token)Tokens[1]).Data));
    }

    protected override object CreateRule_Into(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Into_Into(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Intoclause(ArrayList Tokens)
    {
      return "";
    }

    protected override object CreateRule_Intoclause_Into_Identifier(ArrayList Tokens)
    {
      return ((Token)Tokens[1]).Data;
    }

    protected override object CreateRule_Joinedtable_Join_On(ArrayList Tokens)
    {
      JoinedTable table1 = new JoinedTable();
      table1.LeftTableSource = (TableSource)((Token)Tokens[0]).Reduction.Tag;
      table1.JoinType = StringType.FromObject(((Token)Tokens[1]).Reduction.Tag).ToUpper();
      table1.RightTableSource = (TableSource)((Token)Tokens[3]).Reduction.Tag;
      table1.Search = (SearchList)((Token)Tokens[5]).Reduction.Tag;
      return table1;
    }

    protected override object CreateRule_Joinedtable_Lparan_Rparan(ArrayList Tokens)
    {
      return ((Token)Tokens[1]).Reduction.Tag;
    }

    protected override object CreateRule_Jointype(ArrayList Tokens)
    {
      return "INNER";
    }

    protected override object CreateRule_Jointype_Full(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Data;
    }

    protected override object CreateRule_Jointype_Full_Outer(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Data;
    }

    protected override object CreateRule_Jointype_Inner(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Data;
    }

    protected override object CreateRule_Jointype_Left(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Data;
    }

    protected override object CreateRule_Jointype_Left_Outer(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Data;
    }

    protected override object CreateRule_Jointype_Right(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Data;
    }

    protected override object CreateRule_Jointype_Right_Outer(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Data;
    }

    protected override object CreateRule_Not(ArrayList Tokens)
    {
      return false;
    }

    protected override object CreateRule_Not_Not(ArrayList Tokens)
    {
      return true;
    }

    protected override object CreateRule_Nullnotnull_Not_Null(ArrayList Tokens)
    {
      return false;
    }

    protected override object CreateRule_Nullnotnull_Null(ArrayList Tokens)
    {
      return true;
    }

    protected override object CreateRule_Orderclause(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Orderclause_Order_By(ArrayList Tokens)
    {
      return ((Token)Tokens[2]).Reduction.Tag;
    }

    protected override object CreateRule_Orderlist(ArrayList Tokens)
    {
      return new OrderByList(new OrderItem(RuntimeHelpers.GetObjectValue(((Token)Tokens[0]).Reduction.Tag), StringType.FromObject(((Token)Tokens[1]).Reduction.Tag)));
    }

    protected override object CreateRule_Orderlist_Comma(ArrayList Tokens)
    {
      OrderByList list1 = (OrderByList)((Token)Tokens[3]).Reduction.Tag;
      list1.Add(new OrderItem(RuntimeHelpers.GetObjectValue(((Token)Tokens[0]).Reduction.Tag), StringType.FromObject(((Token)Tokens[1]).Reduction.Tag)));
      return list1;
    }

    protected override object CreateRule_Ordertype_Identifier(ArrayList Tokens)
    {
      return LateBinding.LateGet(LateBinding.LateGet(((Token)Tokens[0]).Data, null, "Replace", new object[] { "[", "" }, null, null), null, "Replace", new object[] { "]", "" }, null, null);
    }

    protected override object CreateRule_Ordertype_Integerliteral(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Data;
    }

    protected override object CreateRule_Predicate(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Predicate_Between_And(ArrayList Tokens)
    {
      return new BetweenPredicate((Expression)((Token)Tokens[0]).Reduction.Tag, BooleanType.FromObject(((Token)Tokens[1]).Reduction.Tag), (Expression)((Token)Tokens[3]).Reduction.Tag, (Expression)((Token)Tokens[5]).Reduction.Tag);
    }

    protected override object CreateRule_Predicate_Exists_Lparan_Rparan(ArrayList Tokens)
    {
      return new ExistsPredicate((UnionList)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Predicate_In_Lparan_Rparan(ArrayList Tokens)
    {
      return new InQueryPredicate((Expression)((Token)Tokens[0]).Reduction.Tag, BooleanType.FromObject(((Token)Tokens[1]).Reduction.Tag), (UnionList)((Token)Tokens[4]).Reduction.Tag);
    }

    protected override object CreateRule_Predicate_In_Lparan_Rparan2(ArrayList Tokens)
    {
      return new InListPredicate((Expression)((Token)Tokens[0]).Reduction.Tag, BooleanType.FromObject(((Token)Tokens[1]).Reduction.Tag), (ExpressionList)((Token)Tokens[4]).Reduction.Tag);
    }

    protected override object CreateRule_Predicate_Is_Null(ArrayList Tokens)
    {
      return new IsNullPredicate((Expression)((Token)Tokens[0]).Reduction.Tag, BooleanType.FromObject(((Token)Tokens[2]).Reduction.Tag));
    }

    protected override object CreateRule_Predicate_Like(ArrayList Tokens)
    {
      return new LikePredicate((Expression)((Token)Tokens[0]).Reduction.Tag, BooleanType.FromObject(((Token)Tokens[1]).Reduction.Tag), (Expression)((Token)Tokens[3]).Reduction.Tag);
    }

    protected override object CreateRule_Primarykey(ArrayList Tokens)
    {
      return new PrimaryUniqueConstraint(BooleanType.FromObject(((Token)Tokens[0]).Reduction.Tag), BooleanType.FromObject(((Token)Tokens[1]).Reduction.Tag), (ConstraintColumnList)((Token)Tokens[2]).Reduction.Tag);
    }

    protected override object CreateRule_Primaryunique_Primary_Key(ArrayList Tokens)
    {
      return true;
    }

    protected override object CreateRule_Primaryunique_Unique(ArrayList Tokens)
    {
      return false;
    }

    protected override object CreateRule_Refcolumns(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Refcolumns_Lparan_Rparan(ArrayList Tokens)
    {
      return ((Token)Tokens[1]).Reduction.Tag;
    }

    protected override object CreateRule_Restriction(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Restriction2(ArrayList Tokens)
    {
      return "";
    }

    protected override object CreateRule_Rowguidcol_Rowguidcol(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Rule(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Rule_On_Delete(ArrayList Tokens)
    {
      return new OnChangeRule(StringType.FromObject(((Token)Tokens[1]).Data), (System.Data.Rule)IntegerType.FromObject(((Token)Tokens[2]).Reduction.Tag));
    }

    protected override object CreateRule_Rule_On_Update(ArrayList Tokens)
    {
      return new OnChangeRule(StringType.FromObject(((Token)Tokens[1]).Data), (System.Data.Rule)IntegerType.FromObject(((Token)Tokens[2]).Reduction.Tag));
    }

    protected override object CreateRule_Searchlist(ArrayList Tokens)
    {
      return new SearchList(new SearchItem(BooleanType.FromObject(((Token)Tokens[0]).Reduction.Tag), (Predicate)((Token)Tokens[1]).Reduction.Tag, StringType.FromObject(((Token)Tokens[2]).Reduction.Tag), ""));
    }

    protected override object CreateRule_Searchlist_And(ArrayList Tokens)
    {
      SearchList list1 = (SearchList)((Token)Tokens[0]).Reduction.Tag;
      list1.Add(new SearchItem(BooleanType.FromObject(((Token)Tokens[2]).Reduction.Tag), (Predicate)((Token)Tokens[3]).Reduction.Tag, StringType.FromObject(((Token)Tokens[4]).Reduction.Tag), StringType.FromObject(((Token)Tokens[1]).Data)));
      return list1;
    }

    protected override object CreateRule_Searchlist_Or(ArrayList Tokens)
    {
      SearchList list1 = (SearchList)((Token)Tokens[0]).Reduction.Tag;
      list1.Add(new SearchItem(BooleanType.FromObject(((Token)Tokens[2]).Reduction.Tag), (Predicate)((Token)Tokens[3]).Reduction.Tag, StringType.FromObject(((Token)Tokens[4]).Reduction.Tag), StringType.FromObject(((Token)Tokens[1]).Data)));
      return list1;
    }

    protected override object CreateRule_Selectstm_Select(ArrayList Tokens)
    {
      return new SelectStm((ColumnsStm)((Token)Tokens[1]).Reduction.Tag, StringType.FromObject(((Token)Tokens[2]).Reduction.Tag), (TableSourceList)((Token)Tokens[3]).Reduction.Tag, (SearchList)((Token)Tokens[4]).Reduction.Tag, (IdList)((Token)Tokens[5]).Reduction.Tag, (SearchList)((Token)Tokens[6]).Reduction.Tag, (OrderByList)((Token)Tokens[7]).Reduction.Tag);
    }

    protected override object CreateRule_Sorttype(ArrayList Tokens)
    {
      return "";
    }

    protected override object CreateRule_Sorttype_Asc(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Data;
    }

    protected override object CreateRule_Sorttype_Desc(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Data;
    }

    protected override object CreateRule_Specialfunction_Cast_Lparan_As_Rparan(ArrayList Tokens)
    {
      return new ConvertValue((DataType)((Token)Tokens[4]).Reduction.Tag, (Expression)((Token)Tokens[2]).Reduction.Tag, 0);
    }

    protected override object CreateRule_Specialfunction_Convert_Lparan_Comma_Comma_Numericliteral_Rparan(ArrayList Tokens)
    {
      return new ConvertValue((DataType)((Token)Tokens[2]).Reduction.Tag, (Expression)((Token)Tokens[4]).Reduction.Tag, IntegerType.FromObject(((Token)Tokens[6]).Reduction.Tag));
    }

    protected override object CreateRule_Specialfunction_Convert_Lparan_Comma_Rparan(ArrayList Tokens)
    {
      return new ConvertValue((DataType)((Token)Tokens[2]).Reduction.Tag, (Expression)((Token)Tokens[4]).Reduction.Tag, 0);
    }

    protected override object CreateRule_Sqlstm(ArrayList Tokens)
    {
      return new SQLStm((SQLStatement)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Sqlstm2(ArrayList Tokens)
    {
      return new SQLStm((SQLStatement)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Sqlstm3(ArrayList Tokens)
    {
      return new SQLStm((SQLStatement)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Sqlstm4(ArrayList Tokens)
    {
      return new SQLStm((SQLStatement)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Sqlstm5(ArrayList Tokens)
    {
      return new SQLStm((SQLStatement)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Sqlstm6(ArrayList Tokens)
    {
      return new SQLStm((SQLStatement)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Sqlstm7(ArrayList Tokens)
    {
      return new SQLStm((SQLStatement)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Sqlstm8(ArrayList Tokens)
    {
      return new SQLStm((SQLStatement)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Sqlstm9(ArrayList Tokens)
    {
      return new SQLStm((SQLStatement)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Tableconstraint(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Tableconstraint_Constraint_Identifier(ArrayList Tokens)
    {
      ColumnConstraintType type1 = (ColumnConstraintType)((Token)Tokens[2]).Reduction.Tag;
      type1.Name = StringType.FromObject(((Token)Tokens[1]).Data);
      return type1;
    }

    protected override object CreateRule_Tableconstrainttype(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Tableconstrainttype2(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Tableconstrainttype3(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Tablesource(ArrayList Tokens)
    {
      return new TableSource((JoinedTable)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Tablesource_Identifier(ArrayList Tokens)
    {
      return new TableSource(StringType.FromObject(((Token)Tokens[0]).Data), StringType.FromObject(((Token)Tokens[1]).Reduction.Tag));
    }

    protected override object CreateRule_Tablesource_Lparan_Rparan(ArrayList Tokens)
    {
      return new TableSource((UnionList)((Token)Tokens[1]).Reduction.Tag, StringType.FromObject(((Token)Tokens[3]).Reduction.Tag));
    }

    protected override object CreateRule_Tablesourcelist(ArrayList Tokens)
    {
      return new TableSourceList((TableSource)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Tablesourcelist_Comma(ArrayList Tokens)
    {
      TableSourceList list1 = (TableSourceList)((Token)Tokens[2]).Reduction.Tag;
      list1.Add((TableSource)((Token)Tokens[0]).Reduction.Tag);
      return list1;
    }

    protected override object CreateRule_Tablesourcelist_Cross_Join(ArrayList Tokens)
    {
      TableSourceList list1 = (TableSourceList)((Token)Tokens[3]).Reduction.Tag;
      list1.Add((TableSource)((Token)Tokens[0]).Reduction.Tag);
      return list1;
    }

    protected override object CreateRule_Top(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Top_Top_Integerliteral(ArrayList Tokens)
    {
      return new TopStm(IntegerType.FromObject(((Token)Tokens[1]).Data), false);
    }

    protected override object CreateRule_Top_Top_Integerliteral_Percent(ArrayList Tokens)
    {
      return new TopStm(IntegerType.FromObject(((Token)Tokens[1]).Data), true);
    }

    protected override object CreateRule_Truncatestm_Truncate_Table_Identifier(ArrayList Tokens)
    {
      return new TruncateStm(StringType.FromObject(((Token)Tokens[2]).Data));
    }

    protected override object CreateRule_Type_Bigint(ArrayList Tokens)
    {
      return new DataType(typeof(long), 1, 0, 0);
    }

    protected override object CreateRule_Type_Binary_Lparan_Integerliteral_Rparan(ArrayList Tokens)
    {
      return new DataType(typeof(byte[]), IntegerType.FromObject(((Token)Tokens[2]).Data), 0, 0);
    }

    protected override object CreateRule_Type_Bit(ArrayList Tokens)
    {
      return new DataType(typeof(bool), 1, 0, 0);
    }

    protected override object CreateRule_Type_Char_Lparan_Integerliteral_Rparan(ArrayList Tokens)
    {
      return new DataType(typeof(string), IntegerType.FromObject(((Token)Tokens[2]).Data), 0, 0);
    }

    protected override object CreateRule_Type_Datetime(ArrayList Tokens)
    {
      return new DataType(typeof(DateTime), 1, 0, 0);
    }

    protected override object CreateRule_Type_Decimal_Lparan_Integerliteral_Comma_Integerliteral_Rparan(ArrayList Tokens)
    {
      return new DataType(typeof(decimal), 1, IntegerType.FromObject(((Token)Tokens[2]).Data), IntegerType.FromObject(((Token)Tokens[4]).Data));
    }

    protected override object CreateRule_Type_Decimal_Lparan_Integerliteral_Rparan(ArrayList Tokens)
    {
      return new DataType(typeof(decimal), 1, IntegerType.FromObject(((Token)Tokens[2]).Data), 0);
    }

    protected override object CreateRule_Type_Float(ArrayList Tokens)
    {
      return new DataType(typeof(double), 1, 0, 0);
    }

    protected override object CreateRule_Type_Image(ArrayList Tokens)
    {
      return new DataType(typeof(byte[]), 0, 0, 0);
    }

    protected override object CreateRule_Type_Int(ArrayList Tokens)
    {
      return new DataType(typeof(int), 1, 0, 0);
    }

    protected override object CreateRule_Type_Money(ArrayList Tokens)
    {
      return new DataType(typeof(decimal), 1, 0, 0);
    }

    protected override object CreateRule_Type_Nchar_Lparan_Integerliteral_Rparan(ArrayList Tokens)
    {
      return new DataType(typeof(string), IntegerType.FromObject(((Token)Tokens[2]).Data), 0, 0);
    }

    protected override object CreateRule_Type_Ntext(ArrayList Tokens)
    {
      return new DataType(typeof(string), 0, 0, 0);
    }

    protected override object CreateRule_Type_Numeric_Lparan_Integerliteral_Comma_Integerliteral_Rparan(ArrayList Tokens)
    {
      return new DataType(typeof(decimal), 1, IntegerType.FromObject(((Token)Tokens[2]).Data), IntegerType.FromObject(((Token)Tokens[4]).Data));
    }

    protected override object CreateRule_Type_Numeric_Lparan_Integerliteral_Rparan(ArrayList Tokens)
    {
      return new DataType(typeof(decimal), 1, IntegerType.FromObject(((Token)Tokens[2]).Data), 0);
    }

    protected override object CreateRule_Type_Nvarchar_Lparan_Integerliteral_Rparan(ArrayList Tokens)
    {
      return new DataType(typeof(string), 0x7fffffff, 0, 0);
    }

    protected override object CreateRule_Type_Real(ArrayList Tokens)
    {
      return new DataType(typeof(float), 1, 0, 0);
    }

    protected override object CreateRule_Type_Smalldatetime(ArrayList Tokens)
    {
      return new DataType(typeof(DateTime), 1, 0, 0);
    }

    protected override object CreateRule_Type_Smallint(ArrayList Tokens)
    {
      return new DataType(typeof(short), 1, 0, 0);
    }

    protected override object CreateRule_Type_Smallmoney(ArrayList Tokens)
    {
      return new DataType(typeof(decimal), 1, 0, 0);
    }

    protected override object CreateRule_Type_Sql_variant(ArrayList Tokens)
    {
      return new DataType(typeof(object), 1, 0, 0);
    }

    protected override object CreateRule_Type_Sysname(ArrayList Tokens)
    {
      return new DataType(typeof(string), 0, 0, 0);
    }

    protected override object CreateRule_Type_Text(ArrayList Tokens)
    {
      return new DataType(typeof(string), 0, 0, 0);
    }

    protected override object CreateRule_Type_Timestamp(ArrayList Tokens)
    {
      return new DataType(typeof(byte[]), 8, 0, 0);
    }

    protected override object CreateRule_Type_Tinyint(ArrayList Tokens)
    {
      return new DataType(typeof(byte), 1, 0, 0);
    }

    protected override object CreateRule_Type_Uniqueidentifier(ArrayList Tokens)
    {
      return new DataType(typeof(Guid), 1, 0, 0);
    }

    protected override object CreateRule_Type_Varbinary_Lparan_Integerliteral_Rparan(ArrayList Tokens)
    {
      return new DataType(typeof(byte[]), 0x7fffffff, 0, 0);
    }

    protected override object CreateRule_Type_Varchar_Lparan_Integerliteral_Rparan(ArrayList Tokens)
    {
      return new DataType(typeof(string), 0x7fffffff, 0, 0);
    }

    protected override object CreateRule_Unaryexp(ArrayList Tokens)
    {
      return new UnaryExpression((Value)((Token)Tokens[0]).Reduction.Tag, "");
    }

    protected override object CreateRule_Unaryexp_Minus(ArrayList Tokens)
    {
      return new UnaryExpression((Value)((Token)Tokens[1]).Reduction.Tag, StringType.FromObject(((Token)Tokens[0]).Data));
    }

    protected override object CreateRule_Unaryexp_Plus(ArrayList Tokens)
    {
      return new UnaryExpression((Value)((Token)Tokens[1]).Reduction.Tag, StringType.FromObject(((Token)Tokens[0]).Data));
    }

    protected override object CreateRule_Unaryexp_Tilde(ArrayList Tokens)
    {
      return new UnaryExpression((Value)((Token)Tokens[1]).Reduction.Tag, StringType.FromObject(((Token)Tokens[0]).Data));
    }

    protected override object CreateRule_Union_Union(ArrayList Tokens)
    {
      return "";
    }

    protected override object CreateRule_Union_Union_All(ArrayList Tokens)
    {
      return ((Token)Tokens[1]).Data;
    }

    protected override object CreateRule_Unionstm(ArrayList Tokens)
    {
      UnionList list1 = (UnionList)((Token)Tokens[2]).Reduction.Tag;
      list1.Add((SelectStm)((Token)Tokens[0]).Reduction.Tag);
      if (StringType.StrCmp(StringType.FromObject(((Token)Tokens[1]).Reduction.Tag).ToUpper(), "ALL", false) == 0)
      {
        list1.All = true;
      }
      return list1;
    }

    protected override object CreateRule_Unionstm2(ArrayList Tokens)
    {
      return new UnionList((SelectStm)((Token)Tokens[0]).Reduction.Tag);
    }

    protected override object CreateRule_Unique(ArrayList Tokens)
    {
      return false;
    }

    protected override object CreateRule_Unique_Unique(ArrayList Tokens)
    {
      return true;
    }

    protected override object CreateRule_Updatestm_Update_Identifier_Set(ArrayList Tokens)
    {
      return new UpdateStm(StringType.FromObject(((Token)Tokens[1]).Data), (AssignList)((Token)Tokens[3]).Reduction.Tag, (SearchList)((Token)Tokens[4]).Reduction.Tag);
    }

    protected override object CreateRule_Value(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Value_Hexliteral(ArrayList Tokens)
    {
      return new BinaryValue(StringType.FromObject(((Token)Tokens[0]).Data).Replace("0x", ""));
    }

    protected override object CreateRule_Value_Identifier(ArrayList Tokens)
    {
      string text1 = StringType.FromObject(((Token)Tokens[0]).Data).Replace("[", "").Replace("]", "");
      if (((Token)Tokens[1]).Reduction.Tag == null)
      {
        return new IdentifierValue(text1);
      }
      text1 = text1.ToLower();
      ArgumentList list1 = ((ArgListOpt)((Token)Tokens[1]).Reduction.Tag).ArgList;
      string text2 = text1;
      if (StringType.StrCmp(text2, "avg", false) == 0)
      {
        return new AverageAggregateFunction(text1, list1);
      }
      if (StringType.StrCmp(text2, "count", false) == 0)
      {
        return new CountAggregateFunction(text1, list1);
      }
      if (StringType.StrCmp(text2, "sum", false) == 0)
      {
        return new SumAggregateFunction(text1, list1);
      }
      if (StringType.StrCmp(text2, "min", false) == 0)
      {
        return new MinAggregateFunction(text1, list1);
      }
      if (StringType.StrCmp(text2, "max", false) == 0)
      {
        return new MaxAggregateFunction(text1, list1);
      }
      if ((StringType.StrCmp(text2, "stdev", false) == 0) || (StringType.StrCmp(text2, "stddev", false) == 0))
      {
        return new StdDevAggregateFunction(text1, list1);
      }
      if (StringType.StrCmp(text2, "var", false) == 0)
      {
        return new VarianceAggregateFunction(text1, list1);
      }
      return new BuiltinFunction(text1, list1);
    }

    protected override object CreateRule_Value_Integerliteral(ArrayList Tokens)
    {
      decimal num1 = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(((Token)Tokens[0]).Data));
      if ((decimal.Compare(num1, new decimal(-1, 0x7fffffff, 0, false, 0)) > 0) || (decimal.Compare(num1, new decimal(0, -2147483648, 0, true, 0)) < 0))
      {
        return new DecimalValue(num1);
      }
      if ((decimal.Compare(num1, new decimal(0x7fffffff)) <= 0) && (decimal.Compare(num1, new decimal(-2147483648)) >= 0))
      {
        return new Int32Value(Convert.ToInt32(num1));
      }
      return new Int64Value(Convert.ToInt64(num1));
    }

    protected override object CreateRule_Value_Lparan_Rparan(ArrayList Tokens)
    {
      return new SearchValue((SearchList)((Token)Tokens[1]).Reduction.Tag);
    }

    protected override object CreateRule_Value_Lparan_Rparan2(ArrayList Tokens)
    {
      return new SubQueryValue((SelectStm)((Token)Tokens[1]).Reduction.Tag);
    }

    protected override object CreateRule_Value_Null(ArrayList Tokens)
    {
      return new NullValue();
    }

    protected override object CreateRule_Value_Realliteral(ArrayList Tokens)
    {
      double num1 = DoubleType.FromObject(((Token)Tokens[0]).Data);
      if ((num1 <= 3.4028234663852886E+38) && (num1 >= -3.4028234663852886E+38))
      {
        return new RealValue((float)num1);
      }
      return new FloatValue(num1);
    }

    protected override object CreateRule_Value_Stringliteral(ArrayList Tokens)
    {
      string text1 = StringType.FromObject(((Token)Tokens[0]).Data);
      text1 = text1.Substring(1);
      text1 = text1.Replace("''", "'");
      text1 = text1.Substring(0, text1.Length - 1);
      try
      {
        if (!Information.IsNumeric(text1))
        {
          return new DateValue(DateTime.Parse(text1));
        }
      }
      catch (Exception exception2)
      {
        ProjectData.SetProjectError(exception2);
        Exception exception1 = exception2;
        ProjectData.ClearProjectError();
      }
      return new StringValue(text1);
    }

    protected override object CreateRule_Value2(ArrayList Tokens)
    {
      return ((Token)Tokens[0]).Reduction.Tag;
    }

    protected override object CreateRule_Whereclause(ArrayList Tokens)
    {
      return null;
    }

    protected override object CreateRule_Whereclause_Where(ArrayList Tokens)
    {
      return ((Token)Tokens[1]).Reduction.Tag;
    }

    private object GetIntegerValue(string literal)
    {
      decimal num1 = Convert.ToDecimal(literal);
      if ((decimal.Compare(num1, new decimal(-1, 0x7fffffff, 0, false, 0)) <= 0) && (decimal.Compare(num1, new decimal(0, -2147483648, 0, true, 0)) >= 0))
      {
        return Convert.ToInt64(num1);
      }
      return DBNull.Value;
    }

  }
}

