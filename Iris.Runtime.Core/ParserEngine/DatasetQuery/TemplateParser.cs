namespace DatasetQuery
{
  using Microsoft.VisualBasic.CompilerServices;
  using DatasetQuery.GoldParser;
  using System;
  using System.Collections;
  using System.IO;
  using System.Runtime.CompilerServices;
  using System.Runtime.InteropServices;
  using System.Text;

  internal abstract class TemplateParser : Parser
  {
    public TemplateParser(string input, Grammar grammar)
      : base(input, grammar)
    {
    }

    private object CreateNewObject(Reduction TheReduction)
    {
      object obj2 = null;
      Reduction reduction1 = TheReduction;
      switch (reduction1.Rule.Index)
      {
        case 0:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Bigint(reduction1.Tokens));
          break;

        case 1:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Binary_Lparan_Integerliteral_Rparan(reduction1.Tokens));
          break;

        case 2:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Bit(reduction1.Tokens));
          break;

        case 3:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Char_Lparan_Integerliteral_Rparan(reduction1.Tokens));
          break;

        case 4:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Datetime(reduction1.Tokens));
          break;

        case 5:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Decimal_Lparan_Integerliteral_Rparan(reduction1.Tokens));
          break;

        case 6:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Decimal_Lparan_Integerliteral_Comma_Integerliteral_Rparan(reduction1.Tokens));
          break;

        case 7:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Numeric_Lparan_Integerliteral_Rparan(reduction1.Tokens));
          break;

        case 8:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Numeric_Lparan_Integerliteral_Comma_Integerliteral_Rparan(reduction1.Tokens));
          break;

        case 9:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Float(reduction1.Tokens));
          break;

        case 10:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Image(reduction1.Tokens));
          break;

        case 11:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Int(reduction1.Tokens));
          break;

        case 12:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Money(reduction1.Tokens));
          break;

        case 13:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Nchar_Lparan_Integerliteral_Rparan(reduction1.Tokens));
          break;

        case 14:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Ntext(reduction1.Tokens));
          break;

        case 15:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Nvarchar_Lparan_Integerliteral_Rparan(reduction1.Tokens));
          break;

        case 0x10:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Real(reduction1.Tokens));
          break;

        case 0x11:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Smalldatetime(reduction1.Tokens));
          break;

        case 0x12:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Smallint(reduction1.Tokens));
          break;

        case 0x13:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Smallmoney(reduction1.Tokens));
          break;

        case 20:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Sql_variant(reduction1.Tokens));
          break;

        case 0x15:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Text(reduction1.Tokens));
          break;

        case 0x16:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Timestamp(reduction1.Tokens));
          break;

        case 0x17:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Tinyint(reduction1.Tokens));
          break;

        case 0x18:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Varbinary_Lparan_Integerliteral_Rparan(reduction1.Tokens));
          break;

        case 0x19:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Varchar_Lparan_Integerliteral_Rparan(reduction1.Tokens));
          break;

        case 0x1a:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Uniqueidentifier(reduction1.Tokens));
          break;

        case 0x1b:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Type_Sysname(reduction1.Tokens));
          break;

        case 0x1c:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Sqlstm(reduction1.Tokens));
          break;

        case 0x1d:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Sqlstm2(reduction1.Tokens));
          break;

        case 30:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Sqlstm3(reduction1.Tokens));
          break;

        case 0x1f:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Sqlstm4(reduction1.Tokens));
          break;

        case 0x20:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Sqlstm5(reduction1.Tokens));
          break;

        case 0x21:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Sqlstm6(reduction1.Tokens));
          break;

        case 0x22:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Sqlstm7(reduction1.Tokens));
          break;

        case 0x23:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Sqlstm8(reduction1.Tokens));
          break;

        case 0x24:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Sqlstm9(reduction1.Tokens));
          break;

        case 0x25:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Createtablestm_Create_Table_Identifier_Lparan_Rparan(reduction1.Tokens));
          break;

        case 0x26:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Createcolumns_Comma(reduction1.Tokens));
          break;

        case 0x27:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Createcolumns(reduction1.Tokens));
          break;

        case 40:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Createcolumn(reduction1.Tokens));
          break;

        case 0x29:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Createcolumn_Identifier_As_Stringliteral(reduction1.Tokens));
          break;

        case 0x2a:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Createcolumn2(reduction1.Tokens));
          break;

        case 0x2b:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Tableconstraint_Constraint_Identifier(reduction1.Tokens));
          break;

        case 0x2c:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Tableconstraint(reduction1.Tokens));
          break;

        case 0x2d:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Tableconstrainttype(reduction1.Tokens));
          break;

        case 0x2e:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Tableconstrainttype2(reduction1.Tokens));
          break;

        case 0x2f:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Tableconstrainttype3(reduction1.Tokens));
          break;

        case 0x30:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columndefinition_Identifier(reduction1.Tokens));
          break;

        case 0x31:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Collation_Collate_Identifier(reduction1.Tokens));
          break;

        case 50:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Collation(reduction1.Tokens));
          break;

        case 0x33:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Constraintlist(reduction1.Tokens));
          break;

        case 0x34:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Constraintlist2(reduction1.Tokens));
          break;

        case 0x35:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Constraintlist3(reduction1.Tokens));
          break;

        case 0x36:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnconstraint_Constraint_Identifier(reduction1.Tokens));
          break;

        case 0x37:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnconstraint(reduction1.Tokens));
          break;

        case 0x38:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnconstrainttype(reduction1.Tokens));
          break;

        case 0x39:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnconstrainttype2(reduction1.Tokens));
          break;

        case 0x3a:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnconstrainttype3(reduction1.Tokens));
          break;

        case 0x3b:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnconstrainttype4(reduction1.Tokens));
          break;

        case 60:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnconstrainttype5(reduction1.Tokens));
          break;

        case 0x3d:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnconstrainttype6(reduction1.Tokens));
          break;

        case 0x3e:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnconstrainttype7(reduction1.Tokens));
          break;

        case 0x3f:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Nullnotnull_Null(reduction1.Tokens));
          break;

        case 0x40:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Nullnotnull_Not_Null(reduction1.Tokens));
          break;

        case 0x41:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Rowguidcol_Rowguidcol(reduction1.Tokens));
          break;

        case 0x42:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Defaultconstraint_Default(reduction1.Tokens));
          break;

        case 0x43:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Identityconstraint_Identity(reduction1.Tokens));
          break;

        case 0x44:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Identityconstraint_Identity_Lparan_Comma_Rparan(reduction1.Tokens));
          break;

        case 0x45:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Integervalue_Minus_Integerliteral(reduction1.Tokens));
          break;

        case 70:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Integervalue_Plus_Integerliteral(reduction1.Tokens));
          break;

        case 0x47:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Integervalue_Integerliteral(reduction1.Tokens));
          break;

        case 0x48:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Primarykey(reduction1.Tokens));
          break;

        case 0x49:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Primaryunique_Primary_Key(reduction1.Tokens));
          break;

        case 0x4a:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Primaryunique_Unique(reduction1.Tokens));
          break;

        case 0x4b:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Clusteredunclustered_Clustered(reduction1.Tokens));
          break;

        case 0x4c:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Clusteredunclustered_Nonclustered(reduction1.Tokens));
          break;

        case 0x4d:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Clusteredunclustered(reduction1.Tokens));
          break;

        case 0x4e:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Constraintcolumns_Lparan_Rparan(reduction1.Tokens));
          break;

        case 0x4f:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Constraintcolumns(reduction1.Tokens));
          break;

        case 80:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Foreignkey_Foreign_Key_References_Identifier(reduction1.Tokens));
          break;

        case 0x51:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Foreignkey_Foreign_Key_Lparan_Rparan_References_Identifier(reduction1.Tokens));
          break;

        case 0x52:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Foreignkey_References_Identifier(reduction1.Tokens));
          break;

        case 0x53:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Rule_On_Delete(reduction1.Tokens));
          break;

        case 0x54:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Rule_On_Update(reduction1.Tokens));
          break;

        case 0x55:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Rule(reduction1.Tokens));
          break;

        case 0x56:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Action_Cascade(reduction1.Tokens));
          break;

        case 0x57:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Action_No_Action(reduction1.Tokens));
          break;

        case 0x58:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Action_Set_Default(reduction1.Tokens));
          break;

        case 0x59:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Action_Set_Null(reduction1.Tokens));
          break;

        case 90:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Refcolumns_Lparan_Rparan(reduction1.Tokens));
          break;

        case 0x5b:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Refcolumns(reduction1.Tokens));
          break;

        case 0x5c:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Checkconstraint_Check(reduction1.Tokens));
          break;

        case 0x5d:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Constraintcolumnlist_Comma(reduction1.Tokens));
          break;

        case 0x5e:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Constraintcolumnlist(reduction1.Tokens));
          break;

        case 0x5f:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Constraintcolumn_Identifier(reduction1.Tokens));
          break;

        case 0x60:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Createindexstm_Create_Index_Identifier_On_Identifier_Lparan_Rparan(reduction1.Tokens));
          break;

        case 0x61:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Unique_Unique(reduction1.Tokens));
          break;

        case 0x62:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Unique(reduction1.Tokens));
          break;

        case 0x63:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Droptablestm_Drop_Table_Identifier(reduction1.Tokens));
          break;

        case 100:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Dropindexstm_Drop_Index(reduction1.Tokens));
          break;

        case 0x65:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Identifierlist_Comma_Identifier(reduction1.Tokens));
          break;

        case 0x66:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Identifierlist_Identifier(reduction1.Tokens));
          break;

        case 0x67:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Insertstm_Insert_Identifier(reduction1.Tokens));
          break;

        case 0x68:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Insertstm_Insert_Identifier_Values_Lparan_Rparan(reduction1.Tokens));
          break;

        case 0x69:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Insertstm_Insert_Identifier_Default_Values(reduction1.Tokens));
          break;

        case 0x6a:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Insertcolumns_Lparan_Rparan(reduction1.Tokens));
          break;

        case 0x6b:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Insertcolumns(reduction1.Tokens));
          break;

        case 0x6c:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Into_Into(reduction1.Tokens));
          break;

        case 0x6d:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Into(reduction1.Tokens));
          break;

        case 110:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Insertupdateitem(reduction1.Tokens));
          break;

        case 0x6f:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Insertupdateitem_Default(reduction1.Tokens));
          break;

        case 0x70:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Insertlist_Comma(reduction1.Tokens));
          break;

        case 0x71:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Insertlist(reduction1.Tokens));
          break;

        case 0x72:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Updatestm_Update_Identifier_Set(reduction1.Tokens));
          break;

        case 0x73:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Assignlist_Identifier_Eq_Comma(reduction1.Tokens));
          break;

        case 0x74:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Assignlist_Identifier_Eq(reduction1.Tokens));
          break;

        case 0x75:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Deletestm_Delete_Identifier(reduction1.Tokens));
          break;

        case 0x76:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_From_From(reduction1.Tokens));
          break;

        case 0x77:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_From(reduction1.Tokens));
          break;

        case 120:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Truncatestm_Truncate_Table_Identifier(reduction1.Tokens));
          break;

        case 0x79:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Unionstm(reduction1.Tokens));
          break;

        case 0x7a:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Unionstm2(reduction1.Tokens));
          break;

        case 0x7b:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Union_Union_All(reduction1.Tokens));
          break;

        case 0x7c:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Union_Union(reduction1.Tokens));
          break;

        case 0x7d:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Selectstm_Select(reduction1.Tokens));
          break;

        case 0x7e:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columns_Times(reduction1.Tokens));
          break;

        case 0x7f:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columns(reduction1.Tokens));
          break;

        case 0x80:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Top_Top_Integerliteral_Percent(reduction1.Tokens));
          break;

        case 0x81:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Top_Top_Integerliteral(reduction1.Tokens));
          break;

        case 130:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Top(reduction1.Tokens));
          break;

        case 0x83:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnlist_Comma(reduction1.Tokens));
          break;

        case 0x84:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnlist(reduction1.Tokens));
          break;

        case 0x85:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnsource_Identifier_Eq(reduction1.Tokens));
          break;

        case 0x86:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnsource_Stringliteral_Eq(reduction1.Tokens));
          break;

        case 0x87:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnsource(reduction1.Tokens));
          break;

        case 0x88:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Columnsource_Idendifier(reduction1.Tokens));
          break;

        case 0x89:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Alias_As_Identifier(reduction1.Tokens));
          break;

        case 0x8a:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Alias_As_Stringliteral(reduction1.Tokens));
          break;

        case 0x8b:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Alias_Identifier(reduction1.Tokens));
          break;

        case 140:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Alias(reduction1.Tokens));
          break;

        case 0x8d:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Alldistinct_All(reduction1.Tokens));
          break;

        case 0x8e:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Alldistinct_Distinct(reduction1.Tokens));
          break;

        case 0x8f:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Restriction(reduction1.Tokens));
          break;

        case 0x90:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Restriction2(reduction1.Tokens));
          break;

        case 0x91:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Intoclause_Into_Identifier(reduction1.Tokens));
          break;

        case 0x92:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Intoclause(reduction1.Tokens));
          break;

        case 0x93:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Fromclause_From(reduction1.Tokens));
          break;

        case 0x94:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Fromclause(reduction1.Tokens));
          break;

        case 0x95:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Tablesourcelist_Comma(reduction1.Tokens));
          break;

        case 150:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Tablesourcelist_Cross_Join(reduction1.Tokens));
          break;

        case 0x97:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Tablesourcelist(reduction1.Tokens));
          break;

        case 0x98:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Tablesource_Identifier(reduction1.Tokens));
          break;

        case 0x99:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Tablesource_Lparan_Rparan(reduction1.Tokens));
          break;

        case 0x9a:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Tablesource(reduction1.Tokens));
          break;

        case 0x9b:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Joinedtable_Join_On(reduction1.Tokens));
          break;

        case 0x9c:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Joinedtable_Lparan_Rparan(reduction1.Tokens));
          break;

        case 0x9d:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Jointype_Inner(reduction1.Tokens));
          break;

        case 0x9e:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Jointype_Left(reduction1.Tokens));
          break;

        case 0x9f:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Jointype_Left_Outer(reduction1.Tokens));
          break;

        case 160:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Jointype_Right(reduction1.Tokens));
          break;

        case 0xa1:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Jointype_Right_Outer(reduction1.Tokens));
          break;

        case 0xa2:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Jointype_Full(reduction1.Tokens));
          break;

        case 0xa3:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Jointype_Full_Outer(reduction1.Tokens));
          break;

        case 0xa4:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Jointype(reduction1.Tokens));
          break;

        case 0xa5:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Whereclause_Where(reduction1.Tokens));
          break;

        case 0xa6:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Whereclause(reduction1.Tokens));
          break;

        case 0xa7:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Groupclause_Group_By(reduction1.Tokens));
          break;

        case 0xa8:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Groupclause_Group_By_All(reduction1.Tokens));
          break;

        case 0xa9:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Groupclause(reduction1.Tokens));
          break;

        case 170:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Idlist_Comma(reduction1.Tokens));
          break;

        case 0xab:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Idlist(reduction1.Tokens));
          break;

        case 0xac:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Orderclause_Order_By(reduction1.Tokens));
          break;

        case 0xad:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Orderclause(reduction1.Tokens));
          break;

        case 0xae:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Orderlist_Comma(reduction1.Tokens));
          break;

        case 0xaf:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Orderlist(reduction1.Tokens));
          break;

        case 0xb0:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Ordertype_Identifier(reduction1.Tokens));
          break;

        case 0xb1:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Ordertype_Integerliteral(reduction1.Tokens));
          break;

        case 0xb2:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Sorttype_Asc(reduction1.Tokens));
          break;

        case 0xb3:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Sorttype_Desc(reduction1.Tokens));
          break;

        case 180:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Sorttype(reduction1.Tokens));
          break;

        case 0xb5:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Havingclause_Having(reduction1.Tokens));
          break;

        case 0xb6:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Havingclause(reduction1.Tokens));
          break;

        case 0xb7:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Searchlist_And(reduction1.Tokens));
          break;

        case 0xb8:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Searchlist_Or(reduction1.Tokens));
          break;

        case 0xb9:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Searchlist(reduction1.Tokens));
          break;

        case 0xba:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Not_Not(reduction1.Tokens));
          break;

        case 0xbb:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Not(reduction1.Tokens));
          break;

        case 0xbc:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Predicate(reduction1.Tokens));
          break;

        case 0xbd:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Predicate_Like(reduction1.Tokens));
          break;

        case 190:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Predicate_Between_And(reduction1.Tokens));
          break;

        case 0xbf:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Predicate_Is_Null(reduction1.Tokens));
          break;

        case 0xc0:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Predicate_In_Lparan_Rparan(reduction1.Tokens));
          break;

        case 0xc1:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Predicate_In_Lparan_Rparan2(reduction1.Tokens));
          break;

        case 0xc2:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Predicate_Exists_Lparan_Rparan(reduction1.Tokens));
          break;

        case 0xc3:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Comparisons_Gt(reduction1.Tokens));
          break;

        case 0xc4:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Comparisons_Lt(reduction1.Tokens));
          break;

        case 0xc5:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Comparisons_Lteq(reduction1.Tokens));
          break;

        case 0xc6:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Comparisons_Gteq(reduction1.Tokens));
          break;

        case 0xc7:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Comparisons_Eq(reduction1.Tokens));
          break;

        case 200:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Comparisons_Ltgt(reduction1.Tokens));
          break;

        case 0xc9:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Comparisons_Exclameq(reduction1.Tokens));
          break;

        case 0xca:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Comparisons(reduction1.Tokens));
          break;

        case 0xcb:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Expressionlist_Comma(reduction1.Tokens));
          break;

        case 0xcc:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Expressionlist(reduction1.Tokens));
          break;

        case 0xcd:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Expression_Plus(reduction1.Tokens));
          break;

        case 0xce:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Expression_Minus(reduction1.Tokens));
          break;

        case 0xcf:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Expression_Amp(reduction1.Tokens));
          break;

        case 0xd0:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Expression_Pipe(reduction1.Tokens));
          break;

        case 0xd1:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Expression_Caret(reduction1.Tokens));
          break;

        case 210:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Expression_Times(reduction1.Tokens));
          break;

        case 0xd3:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Expression_Div(reduction1.Tokens));
          break;

        case 0xd4:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Expression_Percent(reduction1.Tokens));
          break;

        case 0xd5:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Expression(reduction1.Tokens));
          break;

        case 0xd6:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Unaryexp_Minus(reduction1.Tokens));
          break;

        case 0xd7:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Unaryexp_Plus(reduction1.Tokens));
          break;

        case 0xd8:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Unaryexp_Tilde(reduction1.Tokens));
          break;

        case 0xd9:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Unaryexp(reduction1.Tokens));
          break;

        case 0xda:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Value_Lparan_Rparan(reduction1.Tokens));
          break;

        case 0xdb:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Value_Lparan_Rparan2(reduction1.Tokens));
          break;

        case 220:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Value_Integerliteral(reduction1.Tokens));
          break;

        case 0xdd:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Value_Hexliteral(reduction1.Tokens));
          break;

        case 0xde:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Value_Realliteral(reduction1.Tokens));
          break;

        case 0xdf:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Value_Stringliteral(reduction1.Tokens));
          break;

        case 0xe0:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Value_Null(reduction1.Tokens));
          break;

        case 0xe1:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Value(reduction1.Tokens));
          break;

        case 0xe2:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Value_Identifier(reduction1.Tokens));
          break;

        case 0xe3:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Value2(reduction1.Tokens));
          break;

        case 0xe4:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Case_Case_End(reduction1.Tokens));
          break;

        case 0xe5:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Casetype(reduction1.Tokens));
          break;

        case 230:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Casetype2(reduction1.Tokens));
          break;

        case 0xe7:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Casewhenlist(reduction1.Tokens));
          break;

        case 0xe8:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Casewhenlist2(reduction1.Tokens));
          break;

        case 0xe9:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Casewhen_When_Then(reduction1.Tokens));
          break;

        case 0xea:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Caseelse_Else(reduction1.Tokens));
          break;

        case 0xeb:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Caseelse(reduction1.Tokens));
          break;

        case 0xec:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Specialfunction_Cast_Lparan_As_Rparan(reduction1.Tokens));
          break;

        case 0xed:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Specialfunction_Convert_Lparan_Comma_Comma_Numericliteral_Rparan(reduction1.Tokens));
          break;

        case 0xee:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Specialfunction_Convert_Lparan_Comma_Rparan(reduction1.Tokens));
          break;

        case 0xef:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Argumentlistopt_Lparan_Rparan(reduction1.Tokens));
          break;

        case 240:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Argumentlistopt(reduction1.Tokens));
          break;

        case 0xf1:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Argumentlist_Comma(reduction1.Tokens));
          break;

        case 0xf2:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Argumentlist(reduction1.Tokens));
          break;

        case 0xf3:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Functionargs_Times(reduction1.Tokens));
          break;

        case 0xf4:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Functionargs(reduction1.Tokens));
          break;

        case 0xf5:
          obj2 = RuntimeHelpers.GetObjectValue(this.CreateRule_Functionargs2(reduction1.Tokens));
          break;
      }
      reduction1 = null;
      return obj2;
    }

    protected abstract object CreateRule_Action_Cascade(ArrayList Tokens);
    protected abstract object CreateRule_Action_No_Action(ArrayList Tokens);
    protected abstract object CreateRule_Action_Set_Default(ArrayList Tokens);
    protected abstract object CreateRule_Action_Set_Null(ArrayList Tokens);
    protected abstract object CreateRule_Alias(ArrayList Tokens);
    protected abstract object CreateRule_Alias_As_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Alias_As_Stringliteral(ArrayList Tokens);
    protected abstract object CreateRule_Alias_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Alldistinct_All(ArrayList Tokens);
    protected abstract object CreateRule_Alldistinct_Distinct(ArrayList Tokens);
    protected abstract object CreateRule_Argumentlist(ArrayList Tokens);
    protected abstract object CreateRule_Argumentlist_Comma(ArrayList Tokens);
    protected abstract object CreateRule_Argumentlistopt(ArrayList Tokens);
    protected abstract object CreateRule_Argumentlistopt_Lparan_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Assignlist_Identifier_Eq(ArrayList Tokens);
    protected abstract object CreateRule_Assignlist_Identifier_Eq_Comma(ArrayList Tokens);
    protected abstract object CreateRule_Case_Case_End(ArrayList Tokens);
    protected abstract object CreateRule_Caseelse(ArrayList Tokens);
    protected abstract object CreateRule_Caseelse_Else(ArrayList Tokens);
    protected abstract object CreateRule_Casetype(ArrayList Tokens);
    protected abstract object CreateRule_Casetype2(ArrayList Tokens);
    protected abstract object CreateRule_Casewhen_When_Then(ArrayList Tokens);
    protected abstract object CreateRule_Casewhenlist(ArrayList Tokens);
    protected abstract object CreateRule_Casewhenlist2(ArrayList Tokens);
    protected abstract object CreateRule_Checkconstraint_Check(ArrayList Tokens);
    protected abstract object CreateRule_Clusteredunclustered(ArrayList Tokens);
    protected abstract object CreateRule_Clusteredunclustered_Clustered(ArrayList Tokens);
    protected abstract object CreateRule_Clusteredunclustered_Nonclustered(ArrayList Tokens);
    protected abstract object CreateRule_Collation(ArrayList Tokens);
    protected abstract object CreateRule_Collation_Collate_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Columnconstraint(ArrayList Tokens);
    protected abstract object CreateRule_Columnconstraint_Constraint_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Columnconstrainttype(ArrayList Tokens);
    protected abstract object CreateRule_Columnconstrainttype2(ArrayList Tokens);
    protected abstract object CreateRule_Columnconstrainttype3(ArrayList Tokens);
    protected abstract object CreateRule_Columnconstrainttype4(ArrayList Tokens);
    protected abstract object CreateRule_Columnconstrainttype5(ArrayList Tokens);
    protected abstract object CreateRule_Columnconstrainttype6(ArrayList Tokens);
    protected abstract object CreateRule_Columnconstrainttype7(ArrayList Tokens);
    protected abstract object CreateRule_Columndefinition_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Columnlist(ArrayList Tokens);
    protected abstract object CreateRule_Columnlist_Comma(ArrayList Tokens);
    protected abstract object CreateRule_Columns(ArrayList Tokens);
    protected abstract object CreateRule_Columns_Times(ArrayList Tokens);
    protected abstract object CreateRule_Columnsource(ArrayList Tokens);
    protected abstract object CreateRule_Columnsource_Idendifier(ArrayList Tokens);
    protected abstract object CreateRule_Columnsource_Identifier_Eq(ArrayList Tokens);
    protected abstract object CreateRule_Columnsource_Stringliteral_Eq(ArrayList Tokens);
    protected abstract object CreateRule_Comparisons(ArrayList Tokens);
    protected abstract object CreateRule_Comparisons_Eq(ArrayList Tokens);
    protected abstract object CreateRule_Comparisons_Exclameq(ArrayList Tokens);
    protected abstract object CreateRule_Comparisons_Gt(ArrayList Tokens);
    protected abstract object CreateRule_Comparisons_Gteq(ArrayList Tokens);
    protected abstract object CreateRule_Comparisons_Lt(ArrayList Tokens);
    protected abstract object CreateRule_Comparisons_Lteq(ArrayList Tokens);
    protected abstract object CreateRule_Comparisons_Ltgt(ArrayList Tokens);
    protected abstract object CreateRule_Constraintcolumn_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Constraintcolumnlist(ArrayList Tokens);
    protected abstract object CreateRule_Constraintcolumnlist_Comma(ArrayList Tokens);
    protected abstract object CreateRule_Constraintcolumns(ArrayList Tokens);
    protected abstract object CreateRule_Constraintcolumns_Lparan_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Constraintlist(ArrayList Tokens);
    protected abstract object CreateRule_Constraintlist2(ArrayList Tokens);
    protected abstract object CreateRule_Constraintlist3(ArrayList Tokens);
    protected abstract object CreateRule_Createcolumn(ArrayList Tokens);
    protected abstract object CreateRule_Createcolumn_Identifier_As_Stringliteral(ArrayList Tokens);
    protected abstract object CreateRule_Createcolumn2(ArrayList Tokens);
    protected abstract object CreateRule_Createcolumns(ArrayList Tokens);
    protected abstract object CreateRule_Createcolumns_Comma(ArrayList Tokens);
    protected abstract object CreateRule_Createindexstm_Create_Index_Identifier_On_Identifier_Lparan_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Createtablestm_Create_Table_Identifier_Lparan_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Defaultconstraint_Default(ArrayList Tokens);
    protected abstract object CreateRule_Deletestm_Delete_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Dropindexstm_Drop_Index(ArrayList Tokens);
    protected abstract object CreateRule_Droptablestm_Drop_Table_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Expression(ArrayList Tokens);
    protected abstract object CreateRule_Expression_Amp(ArrayList Tokens);
    protected abstract object CreateRule_Expression_Caret(ArrayList Tokens);
    protected abstract object CreateRule_Expression_Div(ArrayList Tokens);
    protected abstract object CreateRule_Expression_Minus(ArrayList Tokens);
    protected abstract object CreateRule_Expression_Percent(ArrayList Tokens);
    protected abstract object CreateRule_Expression_Pipe(ArrayList Tokens);
    protected abstract object CreateRule_Expression_Plus(ArrayList Tokens);
    protected abstract object CreateRule_Expression_Times(ArrayList Tokens);
    protected abstract object CreateRule_Expressionlist(ArrayList Tokens);
    protected abstract object CreateRule_Expressionlist_Comma(ArrayList Tokens);
    protected abstract object CreateRule_Foreignkey_Foreign_Key_Lparan_Rparan_References_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Foreignkey_Foreign_Key_References_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Foreignkey_References_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_From(ArrayList Tokens);
    protected abstract object CreateRule_From_From(ArrayList Tokens);
    protected abstract object CreateRule_Fromclause(ArrayList Tokens);
    protected abstract object CreateRule_Fromclause_From(ArrayList Tokens);
    protected abstract object CreateRule_Functionargs(ArrayList Tokens);
    protected abstract object CreateRule_Functionargs_Times(ArrayList Tokens);
    protected abstract object CreateRule_Functionargs2(ArrayList Tokens);
    protected abstract object CreateRule_Groupclause(ArrayList Tokens);
    protected abstract object CreateRule_Groupclause_Group_By(ArrayList Tokens);
    protected abstract object CreateRule_Groupclause_Group_By_All(ArrayList Tokens);
    protected abstract object CreateRule_Havingclause(ArrayList Tokens);
    protected abstract object CreateRule_Havingclause_Having(ArrayList Tokens);
    protected abstract object CreateRule_Identifierlist_Comma_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Identifierlist_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Identityconstraint_Identity(ArrayList Tokens);
    protected abstract object CreateRule_Identityconstraint_Identity_Lparan_Comma_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Idlist(ArrayList Tokens);
    protected abstract object CreateRule_Idlist_Comma(ArrayList Tokens);
    protected abstract object CreateRule_Insertcolumns(ArrayList Tokens);
    protected abstract object CreateRule_Insertcolumns_Lparan_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Insertlist(ArrayList Tokens);
    protected abstract object CreateRule_Insertlist_Comma(ArrayList Tokens);
    protected abstract object CreateRule_Insertstm_Insert_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Insertstm_Insert_Identifier_Default_Values(ArrayList Tokens);
    protected abstract object CreateRule_Insertstm_Insert_Identifier_Values_Lparan_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Insertupdateitem(ArrayList Tokens);
    protected abstract object CreateRule_Insertupdateitem_Default(ArrayList Tokens);
    protected abstract object CreateRule_Integervalue_Integerliteral(ArrayList Tokens);
    protected abstract object CreateRule_Integervalue_Minus_Integerliteral(ArrayList Tokens);
    protected abstract object CreateRule_Integervalue_Plus_Integerliteral(ArrayList Tokens);
    protected abstract object CreateRule_Into(ArrayList Tokens);
    protected abstract object CreateRule_Into_Into(ArrayList Tokens);
    protected abstract object CreateRule_Intoclause(ArrayList Tokens);
    protected abstract object CreateRule_Intoclause_Into_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Joinedtable_Join_On(ArrayList Tokens);
    protected abstract object CreateRule_Joinedtable_Lparan_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Jointype(ArrayList Tokens);
    protected abstract object CreateRule_Jointype_Full(ArrayList Tokens);
    protected abstract object CreateRule_Jointype_Full_Outer(ArrayList Tokens);
    protected abstract object CreateRule_Jointype_Inner(ArrayList Tokens);
    protected abstract object CreateRule_Jointype_Left(ArrayList Tokens);
    protected abstract object CreateRule_Jointype_Left_Outer(ArrayList Tokens);
    protected abstract object CreateRule_Jointype_Right(ArrayList Tokens);
    protected abstract object CreateRule_Jointype_Right_Outer(ArrayList Tokens);
    protected abstract object CreateRule_Not(ArrayList Tokens);
    protected abstract object CreateRule_Not_Not(ArrayList Tokens);
    protected abstract object CreateRule_Nullnotnull_Not_Null(ArrayList Tokens);
    protected abstract object CreateRule_Nullnotnull_Null(ArrayList Tokens);
    protected abstract object CreateRule_Orderclause(ArrayList Tokens);
    protected abstract object CreateRule_Orderclause_Order_By(ArrayList Tokens);
    protected abstract object CreateRule_Orderlist(ArrayList Tokens);
    protected abstract object CreateRule_Orderlist_Comma(ArrayList Tokens);
    protected abstract object CreateRule_Ordertype_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Ordertype_Integerliteral(ArrayList Tokens);
    protected abstract object CreateRule_Predicate(ArrayList Tokens);
    protected abstract object CreateRule_Predicate_Between_And(ArrayList Tokens);
    protected abstract object CreateRule_Predicate_Exists_Lparan_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Predicate_In_Lparan_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Predicate_In_Lparan_Rparan2(ArrayList Tokens);
    protected abstract object CreateRule_Predicate_Is_Null(ArrayList Tokens);
    protected abstract object CreateRule_Predicate_Like(ArrayList Tokens);
    protected abstract object CreateRule_Primarykey(ArrayList Tokens);
    protected abstract object CreateRule_Primaryunique_Primary_Key(ArrayList Tokens);
    protected abstract object CreateRule_Primaryunique_Unique(ArrayList Tokens);
    protected abstract object CreateRule_Refcolumns(ArrayList Tokens);
    protected abstract object CreateRule_Refcolumns_Lparan_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Restriction(ArrayList Tokens);
    protected abstract object CreateRule_Restriction2(ArrayList Tokens);
    protected abstract object CreateRule_Rowguidcol_Rowguidcol(ArrayList Tokens);
    protected abstract object CreateRule_Rule(ArrayList Tokens);
    protected abstract object CreateRule_Rule_On_Delete(ArrayList Tokens);
    protected abstract object CreateRule_Rule_On_Update(ArrayList Tokens);
    protected abstract object CreateRule_Searchlist(ArrayList Tokens);
    protected abstract object CreateRule_Searchlist_And(ArrayList Tokens);
    protected abstract object CreateRule_Searchlist_Or(ArrayList Tokens);
    protected abstract object CreateRule_Selectstm_Select(ArrayList Tokens);
    protected abstract object CreateRule_Sorttype(ArrayList Tokens);
    protected abstract object CreateRule_Sorttype_Asc(ArrayList Tokens);
    protected abstract object CreateRule_Sorttype_Desc(ArrayList Tokens);
    protected abstract object CreateRule_Specialfunction_Cast_Lparan_As_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Specialfunction_Convert_Lparan_Comma_Comma_Numericliteral_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Specialfunction_Convert_Lparan_Comma_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Sqlstm(ArrayList Tokens);
    protected abstract object CreateRule_Sqlstm2(ArrayList Tokens);
    protected abstract object CreateRule_Sqlstm3(ArrayList Tokens);
    protected abstract object CreateRule_Sqlstm4(ArrayList Tokens);
    protected abstract object CreateRule_Sqlstm5(ArrayList Tokens);
    protected abstract object CreateRule_Sqlstm6(ArrayList Tokens);
    protected abstract object CreateRule_Sqlstm7(ArrayList Tokens);
    protected abstract object CreateRule_Sqlstm8(ArrayList Tokens);
    protected abstract object CreateRule_Sqlstm9(ArrayList Tokens);
    protected abstract object CreateRule_Tableconstraint(ArrayList Tokens);
    protected abstract object CreateRule_Tableconstraint_Constraint_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Tableconstrainttype(ArrayList Tokens);
    protected abstract object CreateRule_Tableconstrainttype2(ArrayList Tokens);
    protected abstract object CreateRule_Tableconstrainttype3(ArrayList Tokens);
    protected abstract object CreateRule_Tablesource(ArrayList Tokens);
    protected abstract object CreateRule_Tablesource_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Tablesource_Lparan_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Tablesourcelist(ArrayList Tokens);
    protected abstract object CreateRule_Tablesourcelist_Comma(ArrayList Tokens);
    protected abstract object CreateRule_Tablesourcelist_Cross_Join(ArrayList Tokens);
    protected abstract object CreateRule_Top(ArrayList Tokens);
    protected abstract object CreateRule_Top_Top_Integerliteral(ArrayList Tokens);
    protected abstract object CreateRule_Top_Top_Integerliteral_Percent(ArrayList Tokens);
    protected abstract object CreateRule_Truncatestm_Truncate_Table_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Type_Bigint(ArrayList Tokens);
    protected abstract object CreateRule_Type_Binary_Lparan_Integerliteral_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Type_Bit(ArrayList Tokens);
    protected abstract object CreateRule_Type_Char_Lparan_Integerliteral_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Type_Datetime(ArrayList Tokens);
    protected abstract object CreateRule_Type_Decimal_Lparan_Integerliteral_Comma_Integerliteral_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Type_Decimal_Lparan_Integerliteral_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Type_Float(ArrayList Tokens);
    protected abstract object CreateRule_Type_Image(ArrayList Tokens);
    protected abstract object CreateRule_Type_Int(ArrayList Tokens);
    protected abstract object CreateRule_Type_Money(ArrayList Tokens);
    protected abstract object CreateRule_Type_Nchar_Lparan_Integerliteral_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Type_Ntext(ArrayList Tokens);
    protected abstract object CreateRule_Type_Numeric_Lparan_Integerliteral_Comma_Integerliteral_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Type_Numeric_Lparan_Integerliteral_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Type_Nvarchar_Lparan_Integerliteral_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Type_Real(ArrayList Tokens);
    protected abstract object CreateRule_Type_Smalldatetime(ArrayList Tokens);
    protected abstract object CreateRule_Type_Smallint(ArrayList Tokens);
    protected abstract object CreateRule_Type_Smallmoney(ArrayList Tokens);
    protected abstract object CreateRule_Type_Sql_variant(ArrayList Tokens);
    protected abstract object CreateRule_Type_Sysname(ArrayList Tokens);
    protected abstract object CreateRule_Type_Text(ArrayList Tokens);
    protected abstract object CreateRule_Type_Timestamp(ArrayList Tokens);
    protected abstract object CreateRule_Type_Tinyint(ArrayList Tokens);
    protected abstract object CreateRule_Type_Uniqueidentifier(ArrayList Tokens);
    protected abstract object CreateRule_Type_Varbinary_Lparan_Integerliteral_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Type_Varchar_Lparan_Integerliteral_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Unaryexp(ArrayList Tokens);
    protected abstract object CreateRule_Unaryexp_Minus(ArrayList Tokens);
    protected abstract object CreateRule_Unaryexp_Plus(ArrayList Tokens);
    protected abstract object CreateRule_Unaryexp_Tilde(ArrayList Tokens);
    protected abstract object CreateRule_Union_Union(ArrayList Tokens);
    protected abstract object CreateRule_Union_Union_All(ArrayList Tokens);
    protected abstract object CreateRule_Unionstm(ArrayList Tokens);
    protected abstract object CreateRule_Unionstm2(ArrayList Tokens);
    protected abstract object CreateRule_Unique(ArrayList Tokens);
    protected abstract object CreateRule_Unique_Unique(ArrayList Tokens);
    protected abstract object CreateRule_Updatestm_Update_Identifier_Set(ArrayList Tokens);
    protected abstract object CreateRule_Value(ArrayList Tokens);
    protected abstract object CreateRule_Value_Hexliteral(ArrayList Tokens);
    protected abstract object CreateRule_Value_Identifier(ArrayList Tokens);
    protected abstract object CreateRule_Value_Integerliteral(ArrayList Tokens);
    protected abstract object CreateRule_Value_Lparan_Rparan(ArrayList Tokens);
    protected abstract object CreateRule_Value_Lparan_Rparan2(ArrayList Tokens);
    protected abstract object CreateRule_Value_Null(ArrayList Tokens);
    protected abstract object CreateRule_Value_Realliteral(ArrayList Tokens);
    protected abstract object CreateRule_Value_Stringliteral(ArrayList Tokens);
    protected abstract object CreateRule_Value2(ArrayList Tokens);
    protected abstract object CreateRule_Whereclause(ArrayList Tokens);
    protected abstract object CreateRule_Whereclause_Where(ArrayList Tokens);
    public ParseMessage DoParse(TextReader Source, [Optional] bool GenerateContext /* = true */)
    {
      ParseMessage message2 = ParseMessage.Empty;
      //
      this.ErrorMessage = new StringBuilder();
      this.TrimReductions = false;
      bool flag1 = false;
      //bool flag2;
      while (!flag1)
      {
        message2 = this.Parse();
        switch (message2)
        {
          case ParseMessage.TokenRead:
            {
              if (StringType.StrCmp(this.CurrentToken.Name, "EOF", false) != 0)
              {
                this.LastToken = this.CurrentToken;
              }
              continue;
            }
          case ParseMessage.Reduction:
            {
              if (GenerateContext)
              {
                this.CurrentReduction.Tag = RuntimeHelpers.GetObjectValue(this.CreateNewObject(this.CurrentReduction));
              }
              continue;
            }
          case ParseMessage.Accept:
            {
              flag1 = true;
              //flag2 = true;
              continue;
            }
          case ParseMessage.NotLoadedError:
            {
              continue;
            }
          case ParseMessage.LexicalError:
            {
              this.ErrorMessage.Append("LEXICAL ERROR! Cannot recognize token");
              flag1 = true;
              continue;
            }
          case ParseMessage.SyntaxError:
            {
              this.ErrorMessage.Append("Line ").Append(this.LineNumber).Append(": Incorrect syntax near '").Append(this.LastToken.Data.ToString()).Append("'\r\n");
              flag1 = true;
              continue;
            }
          case ParseMessage.CommentError:
            break;

          case ParseMessage.InternalError:
            {
              this.ErrorMessage.Append("INTERNAL ERROR!");
              flag1 = true;
              continue;
            }
          default:
            {
              continue;
            }
        }
        this.ErrorMessage.Append("COMMENT ERROR! Unexpected end of file");
        flag1 = true;
      }
      return message2;
    }


    public string Message
    {
      get
      {
        return this.ErrorMessage.ToString();
      }
    }


    private StringBuilder ErrorMessage;
    private Token LastToken;


    private enum RuleConstants
    {
      Rule_Type_Bigint,
      Rule_Type_Binary_Lparan_Integerliteral_Rparan,
      Rule_Type_Bit,
      Rule_Type_Char_Lparan_Integerliteral_Rparan,
      Rule_Type_Datetime,
      Rule_Type_Decimal_Lparan_Integerliteral_Rparan,
      Rule_Type_Decimal_Lparan_Integerliteral_Comma_Integerliteral_Rparan,
      Rule_Type_Numeric_Lparan_Integerliteral_Rparan,
      Rule_Type_Numeric_Lparan_Integerliteral_Comma_Integerliteral_Rparan,
      Rule_Type_Float,
      Rule_Type_Image,
      Rule_Type_Int,
      Rule_Type_Money,
      Rule_Type_Nchar_Lparan_Integerliteral_Rparan,
      Rule_Type_Ntext,
      Rule_Type_Nvarchar_Lparan_Integerliteral_Rparan,
      Rule_Type_Real,
      Rule_Type_Smalldatetime,
      Rule_Type_Smallint,
      Rule_Type_Smallmoney,
      Rule_Type_Sql_variant,
      Rule_Type_Text,
      Rule_Type_Timestamp,
      Rule_Type_Tinyint,
      Rule_Type_Varbinary_Lparan_Integerliteral_Rparan,
      Rule_Type_Varchar_Lparan_Integerliteral_Rparan,
      Rule_Type_Uniqueidentifier,
      Rule_Type_Sysname,
      Rule_Sqlstm,
      Rule_Sqlstm2,
      Rule_Sqlstm3,
      Rule_Sqlstm4,
      Rule_Sqlstm5,
      Rule_Sqlstm6,
      Rule_Sqlstm7,
      Rule_Sqlstm8,
      Rule_Sqlstm9,
      Rule_Createtablestm_Create_Table_Identifier_Lparan_Rparan,
      Rule_Createcolumns_Comma,
      Rule_Createcolumns,
      Rule_Createcolumn,
      Rule_Createcolumn_Identifier_As_Stringliteral,
      Rule_Createcolumn2,
      Rule_Tableconstraint_Constraint_Identifier,
      Rule_Tableconstraint,
      Rule_Tableconstrainttype,
      Rule_Tableconstrainttype2,
      Rule_Tableconstrainttype3,
      Rule_Columndefinition_Identifier,
      Rule_Collation_Collate_Identifier,
      Rule_Collation,
      Rule_Constraintlist,
      Rule_Constraintlist2,
      Rule_Constraintlist3,
      Rule_Columnconstraint_Constraint_Identifier,
      Rule_Columnconstraint,
      Rule_Columnconstrainttype,
      Rule_Columnconstrainttype2,
      Rule_Columnconstrainttype3,
      Rule_Columnconstrainttype4,
      Rule_Columnconstrainttype5,
      Rule_Columnconstrainttype6,
      Rule_Columnconstrainttype7,
      Rule_Nullnotnull_Null,
      Rule_Nullnotnull_Not_Null,
      Rule_Rowguidcol_Rowguidcol,
      Rule_Defaultconstraint_Default,
      Rule_Identityconstraint_Identity,
      Rule_Identityconstraint_Identity_Lparan_Comma_Rparan,
      Rule_Integervalue_Minus_Integerliteral,
      Rule_Integervalue_Plus_Integerliteral,
      Rule_Integervalue_Integerliteral,
      Rule_Primarykey,
      Rule_Primaryunique_Primary_Key,
      Rule_Primaryunique_Unique,
      Rule_Clusteredunclustered_Clustered,
      Rule_Clusteredunclustered_Nonclustered,
      Rule_Clusteredunclustered,
      Rule_Constraintcolumns_Lparan_Rparan,
      Rule_Constraintcolumns,
      Rule_Foreignkey_Foreign_Key_References_Identifier,
      Rule_Foreignkey_Foreign_Key_Lparan_Rparan_References_Identifier,
      Rule_Foreignkey_References_Identifier,
      Rule_Rule_On_Delete,
      Rule_Rule_On_Update,
      Rule_Rule,
      Rule_Action_Cascade,
      Rule_Action_No_Action,
      Rule_Action_Set_Default,
      Rule_Action_Set_Null,
      Rule_Refcolumns_Lparan_Rparan,
      Rule_Refcolumns,
      Rule_Checkconstraint_Check,
      Rule_Constraintcolumnlist_Comma,
      Rule_Constraintcolumnlist,
      Rule_Constraintcolumn_Identifier,
      Rule_Createindexstm_Create_Index_Identifier_On_Identifier_Lparan_Rparan,
      Rule_Unique_Unique,
      Rule_Unique,
      Rule_Droptablestm_Drop_Table_Identifier,
      Rule_Dropindexstm_Drop_Index,
      Rule_Identifierlist_Comma_Identifier,
      Rule_Identifierlist_Identifier,
      Rule_Insertstm_Insert_Identifier,
      Rule_Insertstm_Insert_Identifier_Values_Lparan_Rparan,
      Rule_Insertstm_Insert_Identifier_Default_Values,
      Rule_Insertcolumns_Lparan_Rparan,
      Rule_Insertcolumns,
      Rule_Into_Into,
      Rule_Into,
      Rule_Insertupdateitem,
      Rule_Insertupdateitem_Default,
      Rule_Insertlist_Comma,
      Rule_Insertlist,
      Rule_Updatestm_Update_Identifier_Set,
      Rule_Assignlist_Identifier_Eq_Comma,
      Rule_Assignlist_Identifier_Eq,
      Rule_Deletestm_Delete_Identifier,
      Rule_From_From,
      Rule_From,
      Rule_Truncatestm_Truncate_Table_Identifier,
      Rule_Unionstm,
      Rule_Unionstm2,
      Rule_Union_Union_All,
      Rule_Union_Union,
      Rule_Selectstm_Select,
      Rule_Columns_Times,
      Rule_Columns,
      Rule_Top_Top_Integerliteral_Percent,
      Rule_Top_Top_Integerliteral,
      Rule_Top,
      Rule_Columnlist_Comma,
      Rule_Columnlist,
      Rule_Columnsource_Identifier_Eq,
      Rule_Columnsource_Stringliteral_Eq,
      Rule_Columnsource,
      Rule_Columnsource_Idendifier,
      Rule_Alias_As_Identifier,
      Rule_Alias_As_Stringliteral,
      Rule_Alias_Identifier,
      Rule_Alias,
      Rule_Alldistinct_All,
      Rule_Alldistinct_Distinct,
      Rule_Restriction,
      Rule_Restriction2,
      Rule_Intoclause_Into_Identifier,
      Rule_Intoclause,
      Rule_Fromclause_From,
      Rule_Fromclause,
      Rule_Tablesourcelist_Comma,
      Rule_Tablesourcelist_Cross_Join,
      Rule_Tablesourcelist,
      Rule_Tablesource_Identifier,
      Rule_Tablesource_Lparan_Rparan,
      Rule_Tablesource,
      Rule_Joinedtable_Join_On,
      Rule_Joinedtable_Lparan_Rparan,
      Rule_Jointype_Inner,
      Rule_Jointype_Left,
      Rule_Jointype_Left_Outer,
      Rule_Jointype_Right,
      Rule_Jointype_Right_Outer,
      Rule_Jointype_Full,
      Rule_Jointype_Full_Outer,
      Rule_Jointype,
      Rule_Whereclause_Where,
      Rule_Whereclause,
      Rule_Groupclause_Group_By,
      Rule_Groupclause_Group_By_All,
      Rule_Groupclause,
      Rule_Idlist_Comma,
      Rule_Idlist,
      Rule_Orderclause_Order_By,
      Rule_Orderclause,
      Rule_Orderlist_Comma,
      Rule_Orderlist,
      Rule_Ordertype_Identifier,
      Rule_Ordertype_Integerliteral,
      Rule_Sorttype_Asc,
      Rule_Sorttype_Desc,
      Rule_Sorttype,
      Rule_Havingclause_Having,
      Rule_Havingclause,
      Rule_Searchlist_And,
      Rule_Searchlist_Or,
      Rule_Searchlist,
      Rule_Not_Not,
      Rule_Not,
      Rule_Predicate,
      Rule_Predicate_Like,
      Rule_Predicate_Between_And,
      Rule_Predicate_Is_Null,
      Rule_Predicate_In_Lparan_Rparan,
      Rule_Predicate_In_Lparan_Rparan2,
      Rule_Predicate_Exists_Lparan_Rparan,
      Rule_Comparisons_Gt,
      Rule_Comparisons_Lt,
      Rule_Comparisons_Lteq,
      Rule_Comparisons_Gteq,
      Rule_Comparisons_Eq,
      Rule_Comparisons_Ltgt,
      Rule_Comparisons_Exclameq,
      Rule_Comparisons,
      Rule_Expressionlist_Comma,
      Rule_Expressionlist,
      Rule_Expression_Plus,
      Rule_Expression_Minus,
      Rule_Expression_Amp,
      Rule_Expression_Pipe,
      Rule_Expression_Caret,
      Rule_Expression_Times,
      Rule_Expression_Div,
      Rule_Expression_Percent,
      Rule_Expression,
      Rule_Unaryexp_Minus,
      Rule_Unaryexp_Plus,
      Rule_Unaryexp_Tilde,
      Rule_Unaryexp,
      Rule_Value_Lparan_Rparan,
      Rule_Value_Lparan_Rparan2,
      Rule_Value_Integerliteral,
      Rule_Value_Hexliteral,
      Rule_Value_Realliteral,
      Rule_Value_Stringliteral,
      Rule_Value_Null,
      Rule_Value,
      Rule_Value_Identifier,
      Rule_Value2,
      Rule_Case_Case_End,
      Rule_Casetype,
      Rule_Casetype2,
      Rule_Casewhenlist,
      Rule_Casewhenlist2,
      Rule_Casewhen_When_Then,
      Rule_Caseelse_Else,
      Rule_Caseelse,
      Rule_Specialfunction_Cast_Lparan_As_Rparan,
      Rule_Specialfunction_Convert_Lparan_Comma_Comma_Numericliteral_Rparan,
      Rule_Specialfunction_Convert_Lparan_Comma_Rparan,
      Rule_Argumentlistopt_Lparan_Rparan,
      Rule_Argumentlistopt,
      Rule_Argumentlist_Comma,
      Rule_Argumentlist,
      Rule_Functionargs_Times,
      Rule_Functionargs,
      Rule_Functionargs2
    }

    private enum SymbolConstants
    {
      Symbol_Eof,
      Symbol_Error,
      Symbol_Whitespace,
      Symbol_Commentend,
      Symbol_Commentline,
      Symbol_Commentstart,
      Symbol_Minus,
      Symbol_Exclameq,
      Symbol_Percent,
      Symbol_Amp,
      Symbol_Lparan,
      Symbol_Rparan,
      Symbol_Times,
      Symbol_Comma,
      Symbol_Div,
      Symbol_Caret,
      Symbol_Pipe,
      Symbol_Tilde,
      Symbol_Plus,
      Symbol_Lt,
      Symbol_Lteq,
      Symbol_Ltgt,
      Symbol_Eq,
      Symbol_Gt,
      Symbol_Gteq,
      Symbol_Action,
      Symbol_All,
      Symbol_And,
      Symbol_As,
      Symbol_Asc,
      Symbol_Between,
      Symbol_Bigint,
      Symbol_Binary,
      Symbol_Bit,
      Symbol_By,
      Symbol_Cascade,
      Symbol_Case,
      Symbol_Cast,
      Symbol_Char,
      Symbol_Check,
      Symbol_Clustered,
      Symbol_Collate,
      Symbol_Constraint,
      Symbol_Convert,
      Symbol_Create,
      Symbol_Cross,
      Symbol_Datetime,
      Symbol_Decimal,
      Symbol_Default,
      Symbol_Delete,
      Symbol_Desc,
      Symbol_Distinct,
      Symbol_Drop,
      Symbol_Else,
      Symbol_End,
      Symbol_Exists,
      Symbol_Float,
      Symbol_Foreign,
      Symbol_From,
      Symbol_Full,
      Symbol_Group,
      Symbol_Having,
      Symbol_Hexliteral,
      Symbol_Idendifier,
      Symbol_Identifier,
      Symbol_Identity,
      Symbol_Image,
      Symbol_In,
      Symbol_Index,
      Symbol_Inner,
      Symbol_Insert,
      Symbol_Int,
      Symbol_Integerliteral,
      Symbol_Into,
      Symbol_Is,
      Symbol_Join,
      Symbol_Key,
      Symbol_Left,
      Symbol_Like,
      Symbol_Money,
      Symbol_Nchar,
      Symbol_No,
      Symbol_Nonclustered,
      Symbol_Not,
      Symbol_Ntext,
      Symbol_Null,
      Symbol_Numeric,
      Symbol_Numericliteral,
      Symbol_Nvarchar,
      Symbol_On,
      Symbol_Or,
      Symbol_Order,
      Symbol_Outer,
      Symbol_Percent2,
      Symbol_Primary,
      Symbol_Real,
      Symbol_Realliteral,
      Symbol_References,
      Symbol_Right,
      Symbol_Rowguidcol,
      Symbol_Select,
      Symbol_Set,
      Symbol_Smalldatetime,
      Symbol_Smallint,
      Symbol_Smallmoney,
      Symbol_Sql_variant,
      Symbol_Stringliteral,
      Symbol_Sysname,
      Symbol_Table,
      Symbol_Text,
      Symbol_Then,
      Symbol_Timestamp,
      Symbol_Tinyint,
      Symbol_Top,
      Symbol_Truncate,
      Symbol_Union,
      Symbol_Unique,
      Symbol_Uniqueidentifier,
      Symbol_Update,
      Symbol_Values,
      Symbol_Varbinary,
      Symbol_Varchar,
      Symbol_When,
      Symbol_Where,
      Symbol_Action2,
      Symbol_Alias,
      Symbol_Alldistinct,
      Symbol_Argumentlist,
      Symbol_Argumentlistopt,
      Symbol_Assignlist,
      Symbol_Case2,
      Symbol_Caseelse,
      Symbol_Casetype,
      Symbol_Casewhen,
      Symbol_Casewhenlist,
      Symbol_Checkconstraint,
      Symbol_Clusteredunclustered,
      Symbol_Collation,
      Symbol_Columnconstraint,
      Symbol_Columnconstrainttype,
      Symbol_Columndefinition,
      Symbol_Columnlist,
      Symbol_Columnsource,
      Symbol_Columns,
      Symbol_Comparisons,
      Symbol_Constraintcolumn,
      Symbol_Constraintcolumnlist,
      Symbol_Constraintcolumns,
      Symbol_Constraintlist,
      Symbol_Createcolumn,
      Symbol_Createcolumns,
      Symbol_Createindexstm,
      Symbol_Createtablestm,
      Symbol_Defaultconstraint,
      Symbol_Deletestm,
      Symbol_Dropindexstm,
      Symbol_Droptablestm,
      Symbol_Expression,
      Symbol_Expressionlist,
      Symbol_Foreignkey,
      Symbol_From2,
      Symbol_Fromclause,
      Symbol_Functionargs,
      Symbol_Groupclause,
      Symbol_Havingclause,
      Symbol_Idlist,
      Symbol_Identifierlist,
      Symbol_Identityconstraint,
      Symbol_Insertcolumns,
      Symbol_Insertlist,
      Symbol_Insertstm,
      Symbol_Insertupdateitem,
      Symbol_Integervalue,
      Symbol_Into2,
      Symbol_Intoclause,
      Symbol_Jointype,
      Symbol_Joinedtable,
      Symbol_Not2,
      Symbol_Nullnotnull,
      Symbol_Orderclause,
      Symbol_Orderlist,
      Symbol_Ordertype,
      Symbol_Predicate,
      Symbol_Primarykey,
      Symbol_Primaryunique,
      Symbol_Refcolumns,
      Symbol_Restriction,
      Symbol_Rowguidcol2,
      Symbol_Rule,
      Symbol_Searchlist,
      Symbol_Selectstm,
      Symbol_Sorttype,
      Symbol_Specialfunction,
      Symbol_Sqlstm,
      Symbol_Tableconstraint,
      Symbol_Tableconstrainttype,
      Symbol_Tablesource,
      Symbol_Tablesourcelist,
      Symbol_Top2,
      Symbol_Truncatestm,
      Symbol_Type,
      Symbol_Unaryexp,
      Symbol_Union2,
      Symbol_Unionstm,
      Symbol_Unique2,
      Symbol_Updatestm,
      Symbol_Value,
      Symbol_Whereclause
    }
  }
}

