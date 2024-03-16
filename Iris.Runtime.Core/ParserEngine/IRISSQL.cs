using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using goldparser;

namespace Iris.Runtime.Core
{
  public class Parser : BaseParser
  {
    private LALRParser parser;

    public Parser()
      : base("GrammarName")
    {
    }

    public void Parse(string source)
    {
      NonterminalToken token = parser.Parse(source);
      if (token != null)
      {
        Object obj = CreateObject(token);
        //todo: Use your object any way you like
      }
    }

    private Object CreateObject(Token token)
    {
      if (token is TerminalToken)
        return CreateObjectFromTerminal((TerminalToken)token);
      else
        return CreateObjectFromNonterminal((NonterminalToken)token);
    }


    private void ScanToken(NonterminalToken token)
    {
      foreach (Token t in token.Tokens)
        CreateObject(t);
    }

    private string GetFullText(Token token)
    {
      string value = "";
      for (int i = 0; i < token.Tokens.Length; i++)
      {
        value += GetText(token, i) + " ";
      }
      return value;
    }

    private string GetText(Token token, int idx)
    {
      string text = Convert.ToString(CreateObject(token.Tokens[idx]));
      return text;
    }


    private Object CreateObjectFromTerminal(TerminalToken token)
    {
      switch (token.Symbol.Id)
      {

        case (int)SymbolConstants.SYMBOL_EOF :
        //(EOF)
        case (int)SymbolConstants.SYMBOL_ERROR :
        //(Error)
        case (int)SymbolConstants.SYMBOL_WHITESPACE :
        //(Whitespace)
        case (int)SymbolConstants.SYMBOL_COMMENTEND :
        //(Comment End)
        case (int)SymbolConstants.SYMBOL_COMMENTLINE :
        //(Comment Line)
        case (int)SymbolConstants.SYMBOL_COMMENTSTART :
        //(Comment Start)
        case (int)SymbolConstants.SYMBOL_MINUS :
        //'-'
        case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
        //'!='
        case (int)SymbolConstants.SYMBOL_PERCENT :
        //'%'
        case (int)SymbolConstants.SYMBOL_AMP :
        //'&'
        case (int)SymbolConstants.SYMBOL_LPARAN :
        //'('
        case (int)SymbolConstants.SYMBOL_RPARAN :
        //')'
        case (int)SymbolConstants.SYMBOL_TIMES :
        //'*'
        case (int)SymbolConstants.SYMBOL_COMMA :
        //','
        case (int)SymbolConstants.SYMBOL_DIV :
        //'/'
        case (int)SymbolConstants.SYMBOL_COLON :
        //':'
        case (int)SymbolConstants.SYMBOL_SEMI :
        //';'
        case (int)SymbolConstants.SYMBOL_CARET :
        //'^'
        case (int)SymbolConstants.SYMBOL_LBRACE :
        //'{'
        case (int)SymbolConstants.SYMBOL_PIPE :
        //'|'
        case (int)SymbolConstants.SYMBOL_RBRACE :
        //'}'
        case (int)SymbolConstants.SYMBOL_TILDE :
        //'~'
        case (int)SymbolConstants.SYMBOL_PLUS :
        //'+'
        case (int)SymbolConstants.SYMBOL_LT :
        //'<'
        case (int)SymbolConstants.SYMBOL_LTEQ :
        //'<='
        case (int)SymbolConstants.SYMBOL_LTGT :
        //'<>'
        case (int)SymbolConstants.SYMBOL_EQ :
        //'='
        case (int)SymbolConstants.SYMBOL_GT :
        //'>'
        case (int)SymbolConstants.SYMBOL_GTEQ :
        //'>='
        case (int)SymbolConstants.SYMBOL_ACTION :
        //ACTION
        case (int)SymbolConstants.SYMBOL_ADD :
        //ADD
        case (int)SymbolConstants.SYMBOL_ALL :
        //ALL
        case (int)SymbolConstants.SYMBOL_ALTER :
        //ALTER
        case (int)SymbolConstants.SYMBOL_AND :
        //AND
        case (int)SymbolConstants.SYMBOL_AS :
        //AS
        case (int)SymbolConstants.SYMBOL_ASC :
        //ASC
        case (int)SymbolConstants.SYMBOL_BETWEEN :
        //BETWEEN
        case (int)SymbolConstants.SYMBOL_BY :
        //BY
        case (int)SymbolConstants.SYMBOL_CASCADE :
        //CASCADE
        case (int)SymbolConstants.SYMBOL_CASE :
        //CASE
        case (int)SymbolConstants.SYMBOL_CASESENSITIVE :
        //CASESENSITIVE
        case (int)SymbolConstants.SYMBOL_CAST :
        //CAST
        case (int)SymbolConstants.SYMBOL_CHECK :
        //CHECK
        case (int)SymbolConstants.SYMBOL_CLUSTERED :
        //CLUSTERED
        case (int)SymbolConstants.SYMBOL_COLLATE :
        //COLLATE
        case (int)SymbolConstants.SYMBOL_COLUMN :
        //COLUMN
        case (int)SymbolConstants.SYMBOL_COMPRESSED :
        //COMPRESSED
        case (int)SymbolConstants.SYMBOL_CONSTRAINT :
        //CONSTRAINT
        case (int)SymbolConstants.SYMBOL_CONVERT :
        //CONVERT
        case (int)SymbolConstants.SYMBOL_CREATE :
        //CREATE
        case (int)SymbolConstants.SYMBOL_CROSS :
        //CROSS
        case (int)SymbolConstants.SYMBOL_DATABASE :
        //DATABASE
        case (int)SymbolConstants.SYMBOL_DEFAULT :
        //DEFAULT
        case (int)SymbolConstants.SYMBOL_DELETE :
        //DELETE
        case (int)SymbolConstants.SYMBOL_DESC :
        //DESC
        case (int)SymbolConstants.SYMBOL_DIFFGRAM :
        //DIFFGRAM
        case (int)SymbolConstants.SYMBOL_DISTINCT :
        //DISTINCT
        case (int)SymbolConstants.SYMBOL_DROP :
        //DROP
        case (int)SymbolConstants.SYMBOL_ELSE :
        //ELSE
        case (int)SymbolConstants.SYMBOL_EMPTY :
        //EMPTY
        case (int)SymbolConstants.SYMBOL_END :
        //END
        case (int)SymbolConstants.SYMBOL_ENFORCECONSTRAINTS :
        //ENFORCECONSTRAINTS
        case (int)SymbolConstants.SYMBOL_ERROR2 :
        //ERROR
        case (int)SymbolConstants.SYMBOL_EXISTS :
        //EXISTS
        case (int)SymbolConstants.SYMBOL_FMTONLY :
        //FMTONLY
        case (int)SymbolConstants.SYMBOL_FOR :
        //FOR
        case (int)SymbolConstants.SYMBOL_FOREIGN :
        //FOREIGN
        case (int)SymbolConstants.SYMBOL_FROM :
        //FROM
        case (int)SymbolConstants.SYMBOL_FULL :
        //FULL
        case (int)SymbolConstants.SYMBOL_GROUP :
        //GROUP
        case (int)SymbolConstants.SYMBOL_HAVING :
        //HAVING
        case (int)SymbolConstants.SYMBOL_HEXLITERAL :
        //HexLiteral
        case (int)SymbolConstants.SYMBOL_IDENDIFIER :
        //Idendifier
        case (int)SymbolConstants.SYMBOL_IDENTIFIER :
        //Identifier
        case (int)SymbolConstants.SYMBOL_IDENTITY :
        //IDENTITY
        case (int)SymbolConstants.SYMBOL_IGNORE :
        //IGNORE
        case (int)SymbolConstants.SYMBOL_IGNORECHANGES :
        //IGNORECHANGES
        case (int)SymbolConstants.SYMBOL_IGNORESCHEMA :
        //IGNORESCHEMA
        case (int)SymbolConstants.SYMBOL_IN :
        //IN
        case (int)SymbolConstants.SYMBOL_INDEX :
        //INDEX
        case (int)SymbolConstants.SYMBOL_INNER :
        //INNER
        case (int)SymbolConstants.SYMBOL_INSERT :
        //INSERT
        case (int)SymbolConstants.SYMBOL_INTEGERLITERAL :
        //IntegerLiteral
        case (int)SymbolConstants.SYMBOL_INTO :
        //INTO
        case (int)SymbolConstants.SYMBOL_IS :
        //IS
        case (int)SymbolConstants.SYMBOL_JOIN :
        //JOIN
        case (int)SymbolConstants.SYMBOL_KEY :
        //KEY
        case (int)SymbolConstants.SYMBOL_LEFT :
        //LEFT
        case (int)SymbolConstants.SYMBOL_LIKE :
        //LIKE
        case (int)SymbolConstants.SYMBOL_MATCHED :
        //MATCHED
        case (int)SymbolConstants.SYMBOL_MERGE :
        //MERGE
        case (int)SymbolConstants.SYMBOL_MISSINGSCHEMAACTION :
        //MISSINGSCHEMAACTION
        case (int)SymbolConstants.SYMBOL_NAMESPACE :
        //NAMESPACE
        case (int)SymbolConstants.SYMBOL_NO :
        //NO
        case (int)SymbolConstants.SYMBOL_NOCHECK :
        //NOCHECK
        case (int)SymbolConstants.SYMBOL_NONCLUSTERED :
        //NONCLUSTERED
        case (int)SymbolConstants.SYMBOL_NOT :
        //NOT
        case (int)SymbolConstants.SYMBOL_NULL :
        //NULL
        case (int)SymbolConstants.SYMBOL_OFF :
        //OFF
        case (int)SymbolConstants.SYMBOL_ON :
        //ON
        case (int)SymbolConstants.SYMBOL_OPENROWSET :
        //OPENROWSET
        case (int)SymbolConstants.SYMBOL_OR :
        //OR
        case (int)SymbolConstants.SYMBOL_ORDER :
        //ORDER
        case (int)SymbolConstants.SYMBOL_OUTER :
        //OUTER
        case (int)SymbolConstants.SYMBOL_PERCENT2 :
        //PERCENT
        case (int)SymbolConstants.SYMBOL_PIVOT :
        //PIVOT
        case (int)SymbolConstants.SYMBOL_PREFIX :
        //PREFIX
        case (int)SymbolConstants.SYMBOL_PRESERVECHANGES :
        //PRESERVECHANGES
        case (int)SymbolConstants.SYMBOL_PRIMARY :
        //PRIMARY
        case (int)SymbolConstants.SYMBOL_REALLITERAL :
        //RealLiteral
        case (int)SymbolConstants.SYMBOL_REFERENCES :
        //REFERENCES
        case (int)SymbolConstants.SYMBOL_RENAME :
        //RENAME
        case (int)SymbolConstants.SYMBOL_RIGHT :
        //RIGHT
        case (int)SymbolConstants.SYMBOL_ROWCOUNT :
        //ROWCOUNT
        case (int)SymbolConstants.SYMBOL_ROWGUIDCOL :
        //ROWGUIDCOL
        case (int)SymbolConstants.SYMBOL_SAVE :
        //SAVE
        case (int)SymbolConstants.SYMBOL_SCHEMA :
        //SCHEMA
        case (int)SymbolConstants.SYMBOL_SELECT :
        //SELECT
        case (int)SymbolConstants.SYMBOL_SET :
        //SET
        case (int)SymbolConstants.SYMBOL_SOURCE :
        //SOURCE
        case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
        //StringLiteral
        case (int)SymbolConstants.SYMBOL_TABLE :
        //TABLE
        case (int)SymbolConstants.SYMBOL_TARGET :
        //TARGET
        case (int)SymbolConstants.SYMBOL_THEN :
        //THEN
        case (int)SymbolConstants.SYMBOL_TO :
        //TO
        case (int)SymbolConstants.SYMBOL_TOP :
        //TOP
        case (int)SymbolConstants.SYMBOL_TRUNCATE :
        //TRUNCATE
        case (int)SymbolConstants.SYMBOL_UNION :
        //UNION
        case (int)SymbolConstants.SYMBOL_UNIQUE :
        //UNIQUE
        case (int)SymbolConstants.SYMBOL_UNPIVOT :
        //UNPIVOT
        case (int)SymbolConstants.SYMBOL_UPDATE :
        //UPDATE
        case (int)SymbolConstants.SYMBOL_USE :
        //USE
        case (int)SymbolConstants.SYMBOL_USING :
        //USING
        case (int)SymbolConstants.SYMBOL_VALUES :
        //VALUES
        case (int)SymbolConstants.SYMBOL_WHEN :
        //WHEN
        case (int)SymbolConstants.SYMBOL_WHERE :
        //WHERE
        case (int)SymbolConstants.SYMBOL_WITH :
        //WITH
        case (int)SymbolConstants.SYMBOL_WRITEHIERARCHY :
        //WRITEHIERARCHY
        case (int)SymbolConstants.SYMBOL_ACTION2 :
        //<Action>
        case (int)SymbolConstants.SYMBOL_ALIAS :
        //<alias>
        case (int)SymbolConstants.SYMBOL_ALLDISTINCT :
        //<all distinct>
        case (int)SymbolConstants.SYMBOL_ALTERCHECKCLAUSE :
        //<alter check clause>
        case (int)SymbolConstants.SYMBOL_ALTERCOLUMNDROP :
        //<alter column drop>
        case (int)SymbolConstants.SYMBOL_ALTERCOLUMNSET :
        //<alter column set>
        case (int)SymbolConstants.SYMBOL_ALTERDATABASESTM :
        //<Alter Database Stm>
        case (int)SymbolConstants.SYMBOL_ALTERNULL :
        //<Alter Null>
        case (int)SymbolConstants.SYMBOL_ALTERTABLESTM :
        //<Alter Table Stm>
        case (int)SymbolConstants.SYMBOL_ALTERTYPE :
        //<alter type>
        case (int)SymbolConstants.SYMBOL_ANDSEARCH :
        //<and search>
        case (int)SymbolConstants.SYMBOL_ARGUMENTLIST :
        //<Argument List>
        case (int)SymbolConstants.SYMBOL_ARGUMENTLISTOPT :
        //<Argument List Opt>
        case (int)SymbolConstants.SYMBOL_ASSIGNLIST :
        //<Assign List>
        case (int)SymbolConstants.SYMBOL_CASE2 :
        //<case>
        case (int)SymbolConstants.SYMBOL_CASEELSE :
        //<caseelse>
        case (int)SymbolConstants.SYMBOL_CASESENSITIVE2 :
        //<casesensitive>
        case (int)SymbolConstants.SYMBOL_CASETYPE :
        //<casetype>
        case (int)SymbolConstants.SYMBOL_CASEWHEN :
        //<casewhen>
        case (int)SymbolConstants.SYMBOL_CASEWHENLIST :
        //<casewhen list>
        case (int)SymbolConstants.SYMBOL_CHECKCONSTRAINT :
        //<Check Constraint>
        case (int)SymbolConstants.SYMBOL_CHECKNOCHECK :
        //<check nocheck>
        case (int)SymbolConstants.SYMBOL_CLUSTEREDUNCLUSTERED :
        //<Clustered UnClustered>
        case (int)SymbolConstants.SYMBOL_COLLATION :
        //<collation>
        case (int)SymbolConstants.SYMBOL_COLUMN2 :
        //<column>
        case (int)SymbolConstants.SYMBOL_COLUMNCONSTRAINT :
        //<Column Constraint>
        case (int)SymbolConstants.SYMBOL_COLUMNCONSTRAINTTYPE :
        //<Column Constraint Type>
        case (int)SymbolConstants.SYMBOL_COLUMNDEFINITION :
        //<Column Definition>
        case (int)SymbolConstants.SYMBOL_COLUMNLIST :
        //<Column List>
        case (int)SymbolConstants.SYMBOL_COLUMNSOURCE :
        //<Column Source>
        case (int)SymbolConstants.SYMBOL_COLUMNS :
        //<Columns>
        case (int)SymbolConstants.SYMBOL_COMPARISONS :
        //<comparisons>
        case (int)SymbolConstants.SYMBOL_COMPRESSED2 :
        //<compressed>
        case (int)SymbolConstants.SYMBOL_CONSTRAINTCOLUMN :
        //<Constraint Column>
        case (int)SymbolConstants.SYMBOL_CONSTRAINTCOLUMNLIST :
        //<Constraint Column List>
        case (int)SymbolConstants.SYMBOL_CONSTRAINTCOLUMNS :
        //<Constraint Columns>
        case (int)SymbolConstants.SYMBOL_CONSTRAINTLIST :
        //<Constraint List>
        case (int)SymbolConstants.SYMBOL_CREATECOLUMN :
        //<Create Column>
        case (int)SymbolConstants.SYMBOL_CREATECOLUMNS :
        //<Create Columns>
        case (int)SymbolConstants.SYMBOL_CREATEDATABASESTM :
        //<Create Database Stm>
        case (int)SymbolConstants.SYMBOL_CREATEFORMAT :
        //<create format>
        case (int)SymbolConstants.SYMBOL_CREATEINDEXSTM :
        //<Create Index Stm>
        case (int)SymbolConstants.SYMBOL_CREATETABLESTM :
        //<Create Table Stm>
        case (int)SymbolConstants.SYMBOL_DATABASENAME :
        //<database name>
        case (int)SymbolConstants.SYMBOL_DATABASEOPTIONS :
        //<database options>
        case (int)SymbolConstants.SYMBOL_DBOPTION :
        //<db option>
        case (int)SymbolConstants.SYMBOL_DBOPTIONSLIST :
        //<db options list>
        case (int)SymbolConstants.SYMBOL_DEFAULTCONSTRAINT :
        //<Default Constraint>
        case (int)SymbolConstants.SYMBOL_DELETESTM :
        //<Delete Stm>
        case (int)SymbolConstants.SYMBOL_DROPCLAUSE :
        //<drop clause>
        case (int)SymbolConstants.SYMBOL_DROPDATABASESTM :
        //<Drop Database Stm>
        case (int)SymbolConstants.SYMBOL_DROPINDEXSTM :
        //<Drop Index Stm>
        case (int)SymbolConstants.SYMBOL_DROPLIST :
        //<drop list>
        case (int)SymbolConstants.SYMBOL_DROPTABLESTM :
        //<Drop Table Stm>
        case (int)SymbolConstants.SYMBOL_ENFORCECONSTRAINTS2 :
        //<enforceconstraints>
        case (int)SymbolConstants.SYMBOL_EXPRESSION :
        //<Expression>
        case (int)SymbolConstants.SYMBOL_EXPRESSIONLIST :
        //<Expression List>
        case (int)SymbolConstants.SYMBOL_FILE :
        //<file>
        case (int)SymbolConstants.SYMBOL_FORCOLUMN :
        //<For Column>
        case (int)SymbolConstants.SYMBOL_FORCE :
        //<force>
        case (int)SymbolConstants.SYMBOL_FOREIGNKEY :
        //<Foreign Key>
        case (int)SymbolConstants.SYMBOL_FROM2 :
        //<From>
        case (int)SymbolConstants.SYMBOL_FROMCLAUSE :
        //<From Clause>
        case (int)SymbolConstants.SYMBOL_FUNCTIONARGS :
        //<function args>
        case (int)SymbolConstants.SYMBOL_GROUPCLAUSE :
        //<Group Clause>
        case (int)SymbolConstants.SYMBOL_HAVINGCLAUSE :
        //<Having Clause>
        case (int)SymbolConstants.SYMBOL_IDLIST :
        //<Id List>
        case (int)SymbolConstants.SYMBOL_IDENTIFIERLIST :
        //<Identifier List>
        case (int)SymbolConstants.SYMBOL_IDENTITYCONSTRAINT :
        //<Identity Constraint>
        case (int)SymbolConstants.SYMBOL_INSERTARRAYS :
        //<Insert Arrays>
        case (int)SymbolConstants.SYMBOL_INSERTCOLUMNS :
        //<Insert Columns>
        case (int)SymbolConstants.SYMBOL_INSERTLIST :
        //<Insert List>
        case (int)SymbolConstants.SYMBOL_INSERTSTM :
        //<Insert Stm>
        case (int)SymbolConstants.SYMBOL_INSERTUPDATEITEM :
        //<Insert Update Item>
        case (int)SymbolConstants.SYMBOL_INTEGERVALUE :
        //<Integer Value>
        case (int)SymbolConstants.SYMBOL_INTO2 :
        //<into>
        case (int)SymbolConstants.SYMBOL_INTOCLAUSE :
        //<Into Clause>
        case (int)SymbolConstants.SYMBOL_JOINTYPE :
        //<join type>
        case (int)SymbolConstants.SYMBOL_JOINEDTABLE :
        //<Joined Table>
        case (int)SymbolConstants.SYMBOL_MERGEOPTION :
        //<merge option>
        case (int)SymbolConstants.SYMBOL_MERGEOPTIONS :
        //<merge options>
        case (int)SymbolConstants.SYMBOL_MERGEOPTIONSLIST :
        //<merge options list>
        case (int)SymbolConstants.SYMBOL_MERGESOURCE :
        //<merge source>
        case (int)SymbolConstants.SYMBOL_MERGESTM :
        //<Merge Stm>
        case (int)SymbolConstants.SYMBOL_MERGE_MATCHED :
        //<merge_matched>
        case (int)SymbolConstants.SYMBOL_MERGE_NOT_MATCHED :
        //<merge_not_matched>
        case (int)SymbolConstants.SYMBOL_MISSINGSCHEMAACTION2 :
        //<missing schema action>
        case (int)SymbolConstants.SYMBOL_MULTEXPRESSION :
        //<Mult Expression>
        case (int)SymbolConstants.SYMBOL_NAMESPACE2 :
        //<namespace>
        case (int)SymbolConstants.SYMBOL_NOT2 :
        //<not>
        case (int)SymbolConstants.SYMBOL_NULLNOTNULL :
        //<Null Not Null>
        case (int)SymbolConstants.SYMBOL_ONOFF :
        //<OnOff>
        case (int)SymbolConstants.SYMBOL_OPTIONALIDENTIFIERLIST :
        //<optional identifier list>
        case (int)SymbolConstants.SYMBOL_ORDERCLAUSE :
        //<Order Clause>
        case (int)SymbolConstants.SYMBOL_ORDERLIST :
        //<Order List>
        case (int)SymbolConstants.SYMBOL_ORDERTYPE :
        //<Order Type>
        case (int)SymbolConstants.SYMBOL_PARAMETER :
        //<Parameter>
        case (int)SymbolConstants.SYMBOL_PIVOT_CLAUSE :
        //<pivot_clause>
        case (int)SymbolConstants.SYMBOL_PIVOTEDTABLE :
        //<Pivoted Table>
        case (int)SymbolConstants.SYMBOL_PREDICATE :
        //<predicate>
        case (int)SymbolConstants.SYMBOL_PREFIX2 :
        //<prefix>
        case (int)SymbolConstants.SYMBOL_PRESERVECHANGES2 :
        //<preserve changes>
        case (int)SymbolConstants.SYMBOL_PRIMARYKEY :
        //<Primary Key>
        case (int)SymbolConstants.SYMBOL_PRIMARYUNIQUE :
        //<Primary Unique>
        case (int)SymbolConstants.SYMBOL_REFCOLUMNS :
        //<Ref Columns>
        case (int)SymbolConstants.SYMBOL_RESTRICTION :
        //<Restriction>
        case (int)SymbolConstants.SYMBOL_ROWGUIDCOL2 :
        //<RowGuidCol>
        case (int)SymbolConstants.SYMBOL_ROWSETFUNCTION :
        //<rowset function>
        case (int)SymbolConstants.SYMBOL_ROWSETSOURCE :
        //<rowset source>
        case (int)SymbolConstants.SYMBOL_RULE :
        //<Rule>
        case (int)SymbolConstants.SYMBOL_SAVEFORMAT :
        //<save format>
        case (int)SymbolConstants.SYMBOL_SAVESCHEMA :
        //<save schema>
        case (int)SymbolConstants.SYMBOL_SAVESTM :
        //<Save Stm>
        case (int)SymbolConstants.SYMBOL_SCHEMAACTION :
        //<schema action>
        case (int)SymbolConstants.SYMBOL_SEARCHLIST :
        //<search list>
        case (int)SymbolConstants.SYMBOL_SELECTSTM :
        //<Select Stm>
        case (int)SymbolConstants.SYMBOL_SETSTM :
        //<Set Stm>
        case (int)SymbolConstants.SYMBOL_SORTTYPE :
        //<Sort Type>
        case (int)SymbolConstants.SYMBOL_SOURCE2 :
        //<source>
        case (int)SymbolConstants.SYMBOL_SPECIALFUNCTION :
        //<special function>
        case (int)SymbolConstants.SYMBOL_SQLSTM :
        //<SQL Stm>
        case (int)SymbolConstants.SYMBOL_SQLSTMS :
        //<SQL Stms>
        case (int)SymbolConstants.SYMBOL_STYLE :
        //<style>
        case (int)SymbolConstants.SYMBOL_TABLECONSTRAINT :
        //<Table Constraint>
        case (int)SymbolConstants.SYMBOL_TABLECONSTRAINTTYPE :
        //<Table Constraint Type>
        case (int)SymbolConstants.SYMBOL_TABLESOURCE :
        //<table source>
        case (int)SymbolConstants.SYMBOL_TABLESOURCELIST :
        //<table source list>
        case (int)SymbolConstants.SYMBOL_TARGET2 :
        //<target>
        case (int)SymbolConstants.SYMBOL_TOP2 :
        //<top>
        case (int)SymbolConstants.SYMBOL_TRUNCATESTM :
        //<Truncate Stm>
        case (int)SymbolConstants.SYMBOL_TYPE :
        //<Type>
        case (int)SymbolConstants.SYMBOL_UNARYEXP :
        //<Unary Exp>
        case (int)SymbolConstants.SYMBOL_UNION2 :
        //<Union>
        case (int)SymbolConstants.SYMBOL_UNIONSTM :
        //<Union Stm>
        case (int)SymbolConstants.SYMBOL_UNIQUE2 :
        //<Unique>
        case (int)SymbolConstants.SYMBOL_UNPIVOT_CLAUSE :
        //<unpivot_clause>
        case (int)SymbolConstants.SYMBOL_UNPIVOTEDTABLE :
        //<Unpivoted Table>
        case (int)SymbolConstants.SYMBOL_UPDATESTM :
        //<Update Stm>
        case (int)SymbolConstants.SYMBOL_USESCHEMA :
        //<use schema>
        case (int)SymbolConstants.SYMBOL_VALUE :
        //<Value>
        case (int)SymbolConstants.SYMBOL_WHENCONDITION :
        //<when condition>
        case (int)SymbolConstants.SYMBOL_WHENCONDITIONLIST :
        //<when condition list>
        case (int)SymbolConstants.SYMBOL_WHENMATCHED :
        //<when matched>
        case (int)SymbolConstants.SYMBOL_WHENSOURCENOTMATCHED :
        //<when source not matched>
        case (int)SymbolConstants.SYMBOL_WHENTARGETNOTMATCHED :
        //<when target not matched>
        case (int)SymbolConstants.SYMBOL_WHERECLAUSE :
        //<Where Clause>
        case (int)SymbolConstants.SYMBOL_WITHCHECKNOCHECK :
        //<with check nocheck>
        case (int)SymbolConstants.SYMBOL_WITHVALUES :
        //<With Values>
        case (int)SymbolConstants.SYMBOL_WRITEHIERARCHY2 :
        //<write hierarchy>
        case (int)SymbolConstants.SYMBOL_XEVAL :
        //<XEval>
        default:
          //Todos os casos que não possuem tratamento específico retornam o texto puro
          return GetFullText(token, aQuery);
      }
    }

    ////////////////////////////////////////////////////////////////
    //Rule Section
    ////////////////////////////////////////////////////////////////
    public Object CreateObjectFromNonterminal(NonterminalToken token)
    {
      switch (token.Rule.Id)
      {
        case (int)RuleConstants.RULE_TYPE_IDENTIFIER :
        //<Type> ::= Identifier
        case (int)RuleConstants.RULE_TYPE_IDENTIFIER_LPARAN_INTEGERLITERAL_RPARAN :
        //<Type> ::= Identifier '(' IntegerLiteral ')'
        case (int)RuleConstants.RULE_TYPE_IDENTIFIER_LPARAN_INTEGERLITERAL_COMMA_INTEGERLITERAL_RPARAN :
        //<Type> ::= Identifier '(' IntegerLiteral ',' IntegerLiteral ')'
        case (int)RuleConstants.RULE_SQLSTMS_SEMI :
        //<SQL Stms> ::= <SQL Stms> ';' <SQL Stm>
        case (int)RuleConstants.RULE_SQLSTMS_SEMI2 :
        //<SQL Stms> ::= <SQL Stms> ';'
        case (int)RuleConstants.RULE_SQLSTMS :
        //<SQL Stms> ::= <SQL Stm>
        case (int)RuleConstants.RULE_SQLSTM :
        //<SQL Stm> ::= <Union Stm>
        case (int)RuleConstants.RULE_SQLSTM2 :
        //<SQL Stm> ::= <Insert Stm>
        case (int)RuleConstants.RULE_SQLSTM3 :
        //<SQL Stm> ::= <Update Stm>
        case (int)RuleConstants.RULE_SQLSTM4 :
        //<SQL Stm> ::= <Delete Stm>
        case (int)RuleConstants.RULE_SQLSTM5 :
        //<SQL Stm> ::= <Truncate Stm>
        case (int)RuleConstants.RULE_SQLSTM6 :
        //<SQL Stm> ::= <Create Table Stm>
        case (int)RuleConstants.RULE_SQLSTM7 :
        //<SQL Stm> ::= <Create Index Stm>
        case (int)RuleConstants.RULE_SQLSTM8 :
        //<SQL Stm> ::= <Drop Table Stm>
        case (int)RuleConstants.RULE_SQLSTM9 :
        //<SQL Stm> ::= <Drop Index Stm>
        case (int)RuleConstants.RULE_SQLSTM10 :
        //<SQL Stm> ::= <Set Stm>
        case (int)RuleConstants.RULE_SQLSTM11 :
        //<SQL Stm> ::= <Save Stm>
        case (int)RuleConstants.RULE_SQLSTM12 :
        //<SQL Stm> ::= <Create Database Stm>
        case (int)RuleConstants.RULE_SQLSTM13 :
        //<SQL Stm> ::= <Drop Database Stm>
        case (int)RuleConstants.RULE_SQLSTM14 :
        //<SQL Stm> ::= <Merge Stm>
        case (int)RuleConstants.RULE_SQLSTM15 :
        //<SQL Stm> ::= <Alter Table Stm>
        case (int)RuleConstants.RULE_SQLSTM16 :
        //<SQL Stm> ::= <Alter Database Stm>
        case (int)RuleConstants.RULE_ALTERDATABASESTM_ALTER_DATABASE_IDENTIFIER :
        //<Alter Database Stm> ::= ALTER DATABASE Identifier <database options>
        case (int)RuleConstants.RULE_ALTERDATABASESTM_ALTER_DATABASE_IDENTIFIER_RENAME_TO_IDENTIFIER :
        //<Alter Database Stm> ::= ALTER DATABASE Identifier RENAME TO Identifier
        case (int)RuleConstants.RULE_ALTERTABLESTM_ALTER_TABLE_IDENTIFIER :
        //<Alter Table Stm> ::= ALTER TABLE Identifier <alter type>
        case (int)RuleConstants.RULE_ALTERTABLESTM_ALTER_TABLE_IDENTIFIER_RENAME_TO_IDENTIFIER :
        //<Alter Table Stm> ::= ALTER TABLE Identifier RENAME TO Identifier
        case (int)RuleConstants.RULE_ALTERTABLESTM_ALTER_TABLE_IDENTIFIER_RENAME_IDENTIFIER_TO_IDENTIFIER :
        //<Alter Table Stm> ::= ALTER TABLE Identifier RENAME <column> Identifier TO Identifier
        case (int)RuleConstants.RULE_COLUMN_COLUMN :
        //<column> ::= COLUMN
        case (int)RuleConstants.RULE_COLUMN :
        //<column> ::= 
        case (int)RuleConstants.RULE_ALTERTYPE_ALTER_COLUMN_IDENTIFIER :
        //<alter type> ::= ALTER COLUMN Identifier <Type> <collation> <Alter Null> <alter column set> <alter column drop>
        case (int)RuleConstants.RULE_ALTERTYPE_ADD :
        //<alter type> ::= <with check nocheck> ADD <Create Columns>
        case (int)RuleConstants.RULE_ALTERTYPE_DROP :
        //<alter type> ::= DROP <drop list>
        case (int)RuleConstants.RULE_ALTERTYPE_CONSTRAINT :
        //<alter type> ::= <check nocheck> CONSTRAINT <alter check clause>
        case (int)RuleConstants.RULE_ALTERCOLUMNSET_SET :
        //<alter column set> ::= SET <Default Constraint>
        case (int)RuleConstants.RULE_ALTERCOLUMNSET_SET2 :
        //<alter column set> ::= SET <Identity Constraint>
        case (int)RuleConstants.RULE_ALTERCOLUMNSET_ADD_ROWGUIDCOL :
        //<alter column set> ::= ADD ROWGUIDCOL
        case (int)RuleConstants.RULE_ALTERCOLUMNSET_SET_ROWGUIDCOL :
        //<alter column set> ::= SET ROWGUIDCOL
        case (int)RuleConstants.RULE_ALTERCOLUMNSET :
        //<alter column set> ::= 
        case (int)RuleConstants.RULE_ALTERCOLUMNDROP_DROP_DEFAULT :
        //<alter column drop> ::= DROP DEFAULT
        case (int)RuleConstants.RULE_ALTERCOLUMNDROP_DROP_IDENTITY :
        //<alter column drop> ::= DROP IDENTITY
        case (int)RuleConstants.RULE_ALTERCOLUMNDROP_DROP_ROWGUIDCOL :
        //<alter column drop> ::= DROP ROWGUIDCOL
        case (int)RuleConstants.RULE_ALTERCOLUMNDROP :
        //<alter column drop> ::= 
        case (int)RuleConstants.RULE_ALTERNULL :
        //<Alter Null> ::= <Null Not Null>
        case (int)RuleConstants.RULE_ALTERNULL2 :
        //<Alter Null> ::= 
        case (int)RuleConstants.RULE_WITHCHECKNOCHECK_WITH_CHECK :
        //<with check nocheck> ::= WITH CHECK
        case (int)RuleConstants.RULE_WITHCHECKNOCHECK_WITH_NOCHECK :
        //<with check nocheck> ::= WITH NOCHECK
        case (int)RuleConstants.RULE_WITHCHECKNOCHECK :
        //<with check nocheck> ::= 
        case (int)RuleConstants.RULE_DROPLIST_COMMA :
        //<drop list> ::= <drop list> ',' <drop clause>
        case (int)RuleConstants.RULE_DROPLIST :
        //<drop list> ::= <drop clause>
        case (int)RuleConstants.RULE_DROPCLAUSE_COLUMN_IDENTIFIER :
        //<drop clause> ::= COLUMN Identifier
        case (int)RuleConstants.RULE_DROPCLAUSE_CONSTRAINT_IDENTIFIER :
        //<drop clause> ::= CONSTRAINT Identifier
        case (int)RuleConstants.RULE_CHECKNOCHECK_CHECK :
        //<check nocheck> ::= CHECK
        case (int)RuleConstants.RULE_CHECKNOCHECK_NOCHECK :
        //<check nocheck> ::= NOCHECK
        case (int)RuleConstants.RULE_ALTERCHECKCLAUSE_ALL :
        //<alter check clause> ::= ALL
        case (int)RuleConstants.RULE_ALTERCHECKCLAUSE :
        //<alter check clause> ::= <Identifier List>
        case (int)RuleConstants.RULE_MERGESTM_MERGE_IDENTIFIER_USING_ON :
        //<Merge Stm> ::= MERGE <top> <into> Identifier <alias> USING <table source> ON <search list> <when condition list>
        case (int)RuleConstants.RULE_MERGESTM_MERGE_DATABASE_IDENTIFIER_USING_IDENTIFIER :
        //<Merge Stm> ::= MERGE DATABASE Identifier USING <merge source> Identifier <merge options>
        case (int)RuleConstants.RULE_MERGESTM_MERGE_TABLE_IDENTIFIER_USING_TABLE_IDENTIFIER :
        //<Merge Stm> ::= MERGE TABLE Identifier USING TABLE Identifier <merge options>
        case (int)RuleConstants.RULE_MERGESOURCE_DATABASE :
        //<merge source> ::= DATABASE
        case (int)RuleConstants.RULE_MERGESOURCE_TABLE :
        //<merge source> ::= TABLE
        case (int)RuleConstants.RULE_MERGEOPTIONS_SET :
        //<merge options> ::= SET <merge options list>
        case (int)RuleConstants.RULE_MERGEOPTIONS :
        //<merge options> ::= 
        case (int)RuleConstants.RULE_MERGEOPTIONSLIST_COMMA :
        //<merge options list> ::= <merge options list> ',' <merge option>
        case (int)RuleConstants.RULE_MERGEOPTIONSLIST :
        //<merge options list> ::= <merge option>
        case (int)RuleConstants.RULE_MERGEOPTION :
        //<merge option> ::= <preserve changes>
        case (int)RuleConstants.RULE_MERGEOPTION2 :
        //<merge option> ::= <missing schema action>
        case (int)RuleConstants.RULE_PRESERVECHANGES_PRESERVECHANGES :
        //<preserve changes> ::= PRESERVECHANGES <OnOff>
        case (int)RuleConstants.RULE_MISSINGSCHEMAACTION_MISSINGSCHEMAACTION :
        //<missing schema action> ::= MISSINGSCHEMAACTION <schema action>
        case (int)RuleConstants.RULE_SCHEMAACTION_ERROR :
        //<schema action> ::= ERROR
        case (int)RuleConstants.RULE_SCHEMAACTION_IGNORE :
        //<schema action> ::= IGNORE
        case (int)RuleConstants.RULE_WHENCONDITIONLIST :
        //<when condition list> ::= <when condition list> <when condition>
        case (int)RuleConstants.RULE_WHENCONDITIONLIST2 :
        //<when condition list> ::= <when condition>
        case (int)RuleConstants.RULE_WHENCONDITION :
        //<when condition> ::= <when matched>
        case (int)RuleConstants.RULE_WHENCONDITION2 :
        //<when condition> ::= <when target not matched>
        case (int)RuleConstants.RULE_WHENCONDITION3 :
        //<when condition> ::= <when source not matched>
        case (int)RuleConstants.RULE_WHENMATCHED_WHEN_MATCHED_THEN :
        //<when matched> ::= WHEN MATCHED <and search> THEN <merge_matched>
        case (int)RuleConstants.RULE_WHENTARGETNOTMATCHED_WHEN_NOT_MATCHED_THEN :
        //<when target not matched> ::= WHEN <target> NOT MATCHED <and search> THEN <merge_not_matched>
        case (int)RuleConstants.RULE_TARGET_TARGET :
        //<target> ::= TARGET
        case (int)RuleConstants.RULE_TARGET :
        //<target> ::= 
        case (int)RuleConstants.RULE_WHENSOURCENOTMATCHED_WHEN_SOURCE_NOT_MATCHED_THEN :
        //<when source not matched> ::= WHEN SOURCE NOT MATCHED <and search> THEN <merge_matched>
        case (int)RuleConstants.RULE_ANDSEARCH_AND :
        //<and search> ::= AND <search list>
        case (int)RuleConstants.RULE_ANDSEARCH :
        //<and search> ::= 
        case (int)RuleConstants.RULE_MERGE_MATCHED_UPDATE_SET :
        //<merge_matched> ::= UPDATE SET <Assign List>
        case (int)RuleConstants.RULE_MERGE_MATCHED_DELETE :
        //<merge_matched> ::= DELETE
        case (int)RuleConstants.RULE_MERGE_NOT_MATCHED_INSERT_VALUES_LPARAN_RPARAN :
        //<merge_not_matched> ::= INSERT <Insert Columns> VALUES '(' <Insert List> ')'
        case (int)RuleConstants.RULE_SAVESTM_SAVE_DATABASE_IDENTIFIER :
        //<Save Stm> ::= SAVE DATABASE Identifier <into> <file> <save format>
        case (int)RuleConstants.RULE_SAVESTM_SAVE_TABLE_IDENTIFIER_STRINGLITERAL :
        //<Save Stm> ::= SAVE TABLE Identifier <into> StringLiteral <save format> <write hierarchy>
        case (int)RuleConstants.RULE_FILE_STRINGLITERAL :
        //<file> ::= StringLiteral
        case (int)RuleConstants.RULE_FILE :
        //<file> ::= 
        case (int)RuleConstants.RULE_SAVEFORMAT_IDENTIFIER :
        //<save format> ::= Identifier <compressed> <save schema>
        case (int)RuleConstants.RULE_SAVEFORMAT :
        //<save format> ::= 
        case (int)RuleConstants.RULE_SAVESCHEMA_IGNORESCHEMA :
        //<save schema> ::= IGNORESCHEMA
        case (int)RuleConstants.RULE_SAVESCHEMA_DIFFGRAM :
        //<save schema> ::= DIFFGRAM
        case (int)RuleConstants.RULE_SAVESCHEMA :
        //<save schema> ::= 
        case (int)RuleConstants.RULE_COMPRESSED_COMPRESSED :
        //<compressed> ::= COMPRESSED
        case (int)RuleConstants.RULE_COMPRESSED :
        //<compressed> ::= 
        case (int)RuleConstants.RULE_WRITEHIERARCHY_WRITEHIERARCHY :
        //<write hierarchy> ::= WRITEHIERARCHY
        case (int)RuleConstants.RULE_WRITEHIERARCHY :
        //<write hierarchy> ::= 
        case (int)RuleConstants.RULE_CREATEDATABASESTM_CREATE_DATABASE :
        //<Create Database Stm> ::= CREATE DATABASE <database name> <source> <database options>
        case (int)RuleConstants.RULE_DATABASENAME_AS_IDENTIFIER :
        //<database name> ::= AS Identifier
        case (int)RuleConstants.RULE_DATABASENAME_IDENTIFIER :
        //<database name> ::= Identifier
        case (int)RuleConstants.RULE_DATABASENAME :
        //<database name> ::= 
        case (int)RuleConstants.RULE_SOURCE_EMPTY :
        //<source> ::= EMPTY
        case (int)RuleConstants.RULE_SOURCE_FROM :
        //<source> ::= FROM <create format>
        case (int)RuleConstants.RULE_CREATEFORMAT_IDENTIFIER_STRINGLITERAL :
        //<create format> ::= Identifier <compressed> StringLiteral <use schema>
        case (int)RuleConstants.RULE_USESCHEMA_USE_SCHEMA_STRINGLITERAL :
        //<use schema> ::= USE SCHEMA <compressed> StringLiteral <namespace> <prefix>
        case (int)RuleConstants.RULE_USESCHEMA :
        //<use schema> ::= 
        case (int)RuleConstants.RULE_NAMESPACE_NAMESPACE_STRINGLITERAL :
        //<namespace> ::= NAMESPACE StringLiteral
        case (int)RuleConstants.RULE_NAMESPACE :
        //<namespace> ::= 
        case (int)RuleConstants.RULE_PREFIX_PREFIX_STRINGLITERAL :
        //<prefix> ::= PREFIX StringLiteral
        case (int)RuleConstants.RULE_PREFIX :
        //<prefix> ::= 
        case (int)RuleConstants.RULE_DATABASEOPTIONS_SET :
        //<database options> ::= SET <db options list>
        case (int)RuleConstants.RULE_DATABASEOPTIONS :
        //<database options> ::= 
        case (int)RuleConstants.RULE_DBOPTIONSLIST_COMMA :
        //<db options list> ::= <db options list> ',' <db option>
        case (int)RuleConstants.RULE_DBOPTIONSLIST :
        //<db options list> ::= <db option>
        case (int)RuleConstants.RULE_DBOPTION :
        //<db option> ::= <casesensitive>
        case (int)RuleConstants.RULE_DBOPTION2 :
        //<db option> ::= <enforceconstraints>
        case (int)RuleConstants.RULE_CASESENSITIVE_CASESENSITIVE :
        //<casesensitive> ::= CASESENSITIVE <OnOff>
        case (int)RuleConstants.RULE_ENFORCECONSTRAINTS_ENFORCECONSTRAINTS :
        //<enforceconstraints> ::= ENFORCECONSTRAINTS <OnOff>
        case (int)RuleConstants.RULE_DROPDATABASESTM_DROP_DATABASE_IDENTIFIER :
        //<Drop Database Stm> ::= DROP DATABASE Identifier <force>
        case (int)RuleConstants.RULE_FORCE_IGNORECHANGES :
        //<force> ::= IGNORECHANGES
        case (int)RuleConstants.RULE_FORCE :
        //<force> ::= 
        case (int)RuleConstants.RULE_SETSTM_SET_FMTONLY :
        //<Set Stm> ::= SET FMTONLY <OnOff>
        case (int)RuleConstants.RULE_SETSTM_SET_ROWCOUNT_INTEGERLITERAL :
        //<Set Stm> ::= SET ROWCOUNT IntegerLiteral
        case (int)RuleConstants.RULE_ONOFF_ON :
        //<OnOff> ::= ON
        case (int)RuleConstants.RULE_ONOFF_OFF :
        //<OnOff> ::= OFF
        case (int)RuleConstants.RULE_ONOFF :
        //<OnOff> ::= 
        case (int)RuleConstants.RULE_CREATETABLESTM_CREATE_TABLE_IDENTIFIER_LPARAN_RPARAN :
        //<Create Table Stm> ::= CREATE TABLE Identifier '(' <Create Columns> ')'
        case (int)RuleConstants.RULE_CREATECOLUMNS_COMMA :
        //<Create Columns> ::= <Create Columns> ',' <Create Column>
        case (int)RuleConstants.RULE_CREATECOLUMNS :
        //<Create Columns> ::= <Create Column>
        case (int)RuleConstants.RULE_CREATECOLUMN :
        //<Create Column> ::= <Column Definition>
        case (int)RuleConstants.RULE_CREATECOLUMN_IDENTIFIER_AS :
        //<Create Column> ::= Identifier AS <Expression>
        case (int)RuleConstants.RULE_CREATECOLUMN_IDENTIFIER_AS_STRINGLITERAL :
        //<Create Column> ::= Identifier <Type> AS StringLiteral
        case (int)RuleConstants.RULE_CREATECOLUMN2 :
        //<Create Column> ::= <Table Constraint>
        case (int)RuleConstants.RULE_TABLECONSTRAINT_CONSTRAINT_IDENTIFIER :
        //<Table Constraint> ::= CONSTRAINT Identifier <Table Constraint Type>
        case (int)RuleConstants.RULE_TABLECONSTRAINT :
        //<Table Constraint> ::= <Table Constraint Type>
        case (int)RuleConstants.RULE_TABLECONSTRAINTTYPE :
        //<Table Constraint Type> ::= <Primary Key>
        case (int)RuleConstants.RULE_TABLECONSTRAINTTYPE2 :
        //<Table Constraint Type> ::= <Foreign Key>
        case (int)RuleConstants.RULE_TABLECONSTRAINTTYPE3 :
        //<Table Constraint Type> ::= <Check Constraint>
        case (int)RuleConstants.RULE_TABLECONSTRAINTTYPE4 :
        //<Table Constraint Type> ::= <Default Constraint>
        case (int)RuleConstants.RULE_COLUMNDEFINITION_IDENTIFIER :
        //<Column Definition> ::= Identifier <Type> <collation> <Constraint List>
        case (int)RuleConstants.RULE_COLLATION_COLLATE_IDENTIFIER :
        //<collation> ::= COLLATE Identifier
        case (int)RuleConstants.RULE_COLLATION :
        //<collation> ::= 
        case (int)RuleConstants.RULE_CONSTRAINTLIST :
        //<Constraint List> ::= <Constraint List> <Column Constraint>
        case (int)RuleConstants.RULE_CONSTRAINTLIST2 :
        //<Constraint List> ::= <Column Constraint>
        case (int)RuleConstants.RULE_CONSTRAINTLIST3 :
        //<Constraint List> ::= 
        case (int)RuleConstants.RULE_COLUMNCONSTRAINT_CONSTRAINT_IDENTIFIER :
        //<Column Constraint> ::= CONSTRAINT Identifier <Column Constraint Type>
        case (int)RuleConstants.RULE_COLUMNCONSTRAINT :
        //<Column Constraint> ::= <Column Constraint Type>
        case (int)RuleConstants.RULE_COLUMNCONSTRAINTTYPE :
        //<Column Constraint Type> ::= <Null Not Null>
        case (int)RuleConstants.RULE_COLUMNCONSTRAINTTYPE2 :
        //<Column Constraint Type> ::= <Default Constraint>
        case (int)RuleConstants.RULE_COLUMNCONSTRAINTTYPE3 :
        //<Column Constraint Type> ::= <Identity Constraint>
        case (int)RuleConstants.RULE_COLUMNCONSTRAINTTYPE4 :
        //<Column Constraint Type> ::= <RowGuidCol>
        case (int)RuleConstants.RULE_COLUMNCONSTRAINTTYPE5 :
        //<Column Constraint Type> ::= <Primary Key>
        case (int)RuleConstants.RULE_COLUMNCONSTRAINTTYPE6 :
        //<Column Constraint Type> ::= <Foreign Key>
        case (int)RuleConstants.RULE_COLUMNCONSTRAINTTYPE7 :
        //<Column Constraint Type> ::= <Check Constraint>
        case (int)RuleConstants.RULE_NULLNOTNULL_NULL :
        //<Null Not Null> ::= NULL
        case (int)RuleConstants.RULE_NULLNOTNULL_NOT_NULL :
        //<Null Not Null> ::= NOT NULL
        case (int)RuleConstants.RULE_ROWGUIDCOL_ROWGUIDCOL :
        //<RowGuidCol> ::= ROWGUIDCOL
        case (int)RuleConstants.RULE_DEFAULTCONSTRAINT_DEFAULT :
        //<Default Constraint> ::= DEFAULT <Expression> <For Column> <With Values>
        case (int)RuleConstants.RULE_FORCOLUMN_FOR_IDENTIFIER :
        //<For Column> ::= FOR Identifier
        case (int)RuleConstants.RULE_FORCOLUMN :
        //<For Column> ::= 
        case (int)RuleConstants.RULE_WITHVALUES_WITH_VALUES :
        //<With Values> ::= WITH VALUES
        case (int)RuleConstants.RULE_WITHVALUES :
        //<With Values> ::= 
        case (int)RuleConstants.RULE_IDENTITYCONSTRAINT_IDENTITY :
        //<Identity Constraint> ::= IDENTITY
        case (int)RuleConstants.RULE_IDENTITYCONSTRAINT_IDENTITY_LPARAN_COMMA_RPARAN :
        //<Identity Constraint> ::= IDENTITY '(' <Integer Value> ',' <Integer Value> ')'
        case (int)RuleConstants.RULE_INTEGERVALUE_MINUS_INTEGERLITERAL :
        //<Integer Value> ::= '-' IntegerLiteral
        case (int)RuleConstants.RULE_INTEGERVALUE_PLUS_INTEGERLITERAL :
        //<Integer Value> ::= '+' IntegerLiteral
        case (int)RuleConstants.RULE_INTEGERVALUE_INTEGERLITERAL :
        //<Integer Value> ::= IntegerLiteral
        case (int)RuleConstants.RULE_PRIMARYKEY :
        //<Primary Key> ::= <Primary Unique> <Clustered UnClustered> <Constraint Columns>
        case (int)RuleConstants.RULE_PRIMARYUNIQUE_PRIMARY_KEY :
        //<Primary Unique> ::= PRIMARY KEY
        case (int)RuleConstants.RULE_PRIMARYUNIQUE_UNIQUE :
        //<Primary Unique> ::= UNIQUE
        case (int)RuleConstants.RULE_CLUSTEREDUNCLUSTERED_CLUSTERED :
        //<Clustered UnClustered> ::= CLUSTERED
        case (int)RuleConstants.RULE_CLUSTEREDUNCLUSTERED_NONCLUSTERED :
        //<Clustered UnClustered> ::= NONCLUSTERED
        case (int)RuleConstants.RULE_CLUSTEREDUNCLUSTERED :
        //<Clustered UnClustered> ::= 
        case (int)RuleConstants.RULE_CONSTRAINTCOLUMNS_LPARAN_RPARAN :
        //<Constraint Columns> ::= '(' <Constraint Column List> ')'
        case (int)RuleConstants.RULE_CONSTRAINTCOLUMNS :
        //<Constraint Columns> ::= 
        case (int)RuleConstants.RULE_FOREIGNKEY_FOREIGN_KEY_REFERENCES_IDENTIFIER :
        //<Foreign Key> ::= FOREIGN KEY REFERENCES Identifier <Ref Columns> <Rule> <Rule>
        case (int)RuleConstants.RULE_FOREIGNKEY_FOREIGN_KEY_LPARAN_RPARAN_REFERENCES_IDENTIFIER :
        //<Foreign Key> ::= FOREIGN KEY '(' <Constraint Column List> ')' REFERENCES Identifier <Ref Columns> <Rule> <Rule>
        case (int)RuleConstants.RULE_FOREIGNKEY_REFERENCES_IDENTIFIER :
        //<Foreign Key> ::= REFERENCES Identifier <Ref Columns> <Rule> <Rule>
        case (int)RuleConstants.RULE_RULE_ON_DELETE :
        //<Rule> ::= ON DELETE <Action>
        case (int)RuleConstants.RULE_RULE_ON_UPDATE :
        //<Rule> ::= ON UPDATE <Action>
        case (int)RuleConstants.RULE_RULE :
        //<Rule> ::= 
        case (int)RuleConstants.RULE_ACTION_CASCADE :
        //<Action> ::= CASCADE
        case (int)RuleConstants.RULE_ACTION_NO_ACTION :
        //<Action> ::= NO ACTION
        case (int)RuleConstants.RULE_ACTION_SET_DEFAULT :
        //<Action> ::= SET DEFAULT
        case (int)RuleConstants.RULE_ACTION_SET_NULL :
        //<Action> ::= SET NULL
        case (int)RuleConstants.RULE_REFCOLUMNS_LPARAN_RPARAN :
        //<Ref Columns> ::= '(' <Id List> ')'
        case (int)RuleConstants.RULE_REFCOLUMNS :
        //<Ref Columns> ::= 
        case (int)RuleConstants.RULE_CHECKCONSTRAINT_CHECK :
        //<Check Constraint> ::= CHECK <search list>
        case (int)RuleConstants.RULE_CONSTRAINTCOLUMNLIST_COMMA :
        //<Constraint Column List> ::= <Constraint Column List> ',' <Constraint Column>
        case (int)RuleConstants.RULE_CONSTRAINTCOLUMNLIST :
        //<Constraint Column List> ::= <Constraint Column>
        case (int)RuleConstants.RULE_CONSTRAINTCOLUMN_IDENTIFIER :
        //<Constraint Column> ::= Identifier <Sort Type>
        case (int)RuleConstants.RULE_CREATEINDEXSTM_CREATE_INDEX_IDENTIFIER_ON_IDENTIFIER_LPARAN_RPARAN :
        //<Create Index Stm> ::= CREATE <Unique> <Clustered UnClustered> INDEX Identifier ON Identifier '(' <Constraint Column List> ')'
        case (int)RuleConstants.RULE_UNIQUE_UNIQUE :
        //<Unique> ::= UNIQUE
        case (int)RuleConstants.RULE_UNIQUE :
        //<Unique> ::= 
        case (int)RuleConstants.RULE_DROPTABLESTM_DROP_TABLE_IDENTIFIER :
        //<Drop Table Stm> ::= DROP TABLE Identifier
        case (int)RuleConstants.RULE_DROPINDEXSTM_DROP_INDEX :
        //<Drop Index Stm> ::= DROP INDEX <Identifier List>
        case (int)RuleConstants.RULE_IDENTIFIERLIST_COMMA_IDENTIFIER :
        //<Identifier List> ::= <Identifier List> ',' Identifier
        case (int)RuleConstants.RULE_IDENTIFIERLIST_IDENTIFIER :
        //<Identifier List> ::= Identifier
        case (int)RuleConstants.RULE_INSERTSTM_INSERT_IDENTIFIER :
        //<Insert Stm> ::= INSERT <into> Identifier <Insert Columns> <Union Stm>
        case (int)RuleConstants.RULE_INSERTSTM_INSERT_IDENTIFIER_VALUES :
        //<Insert Stm> ::= INSERT <into> Identifier <Insert Columns> VALUES <Insert Arrays>
        case (int)RuleConstants.RULE_INSERTSTM_INSERT_IDENTIFIER_DEFAULT_VALUES :
        //<Insert Stm> ::= INSERT <into> Identifier DEFAULT VALUES
        case (int)RuleConstants.RULE_INSERTCOLUMNS_LPARAN_RPARAN :
        //<Insert Columns> ::= '(' <Id List> ')'
        case (int)RuleConstants.RULE_INSERTCOLUMNS :
        //<Insert Columns> ::= 
        case (int)RuleConstants.RULE_INTO_INTO :
        //<into> ::= INTO
        case (int)RuleConstants.RULE_INTO :
        //<into> ::= 
        case (int)RuleConstants.RULE_INSERTUPDATEITEM :
        //<Insert Update Item> ::= <Expression>
        case (int)RuleConstants.RULE_INSERTUPDATEITEM_DEFAULT :
        //<Insert Update Item> ::= DEFAULT
        case (int)RuleConstants.RULE_INSERTLIST_COMMA :
        //<Insert List> ::= <Insert List> ',' <Insert Update Item>
        case (int)RuleConstants.RULE_INSERTLIST :
        //<Insert List> ::= <Insert Update Item>
        case (int)RuleConstants.RULE_INSERTARRAYS_LPARAN_RPARAN_COMMA :
        //<Insert Arrays> ::= '(' <Insert List> ')' ',' <Insert Arrays>
        case (int)RuleConstants.RULE_INSERTARRAYS_LPARAN_RPARAN :
        //<Insert Arrays> ::= '(' <Insert List> ')'
        case (int)RuleConstants.RULE_UPDATESTM_UPDATE_IDENTIFIER_SET :
        //<Update Stm> ::= UPDATE Identifier SET <Assign List> <From Clause> <Where Clause>
        case (int)RuleConstants.RULE_ASSIGNLIST_IDENTIFIER_EQ_COMMA :
        //<Assign List> ::= Identifier '=' <Insert Update Item> ',' <Assign List>
        case (int)RuleConstants.RULE_ASSIGNLIST_IDENTIFIER_EQ :
        //<Assign List> ::= Identifier '=' <Insert Update Item>
        case (int)RuleConstants.RULE_DELETESTM_DELETE_IDENTIFIER :
        //<Delete Stm> ::= DELETE <From> Identifier <Where Clause>
        case (int)RuleConstants.RULE_FROM_FROM :
        //<From> ::= FROM
        case (int)RuleConstants.RULE_FROM :
        //<From> ::= 
        case (int)RuleConstants.RULE_TRUNCATESTM_TRUNCATE_TABLE_IDENTIFIER :
        //<Truncate Stm> ::= TRUNCATE TABLE Identifier
        case (int)RuleConstants.RULE_UNIONSTM :
        //<Union Stm> ::= <Select Stm> <Union> <Union Stm>
        case (int)RuleConstants.RULE_UNIONSTM2 :
        //<Union Stm> ::= <Select Stm>
        case (int)RuleConstants.RULE_UNION_UNION_ALL :
        //<Union> ::= UNION ALL
        case (int)RuleConstants.RULE_UNION_UNION :
        //<Union> ::= UNION
        case (int)RuleConstants.RULE_SELECTSTM_SELECT :
        //<Select Stm> ::= SELECT <Columns> <Into Clause> <From Clause> <Where Clause> <Group Clause> <Having Clause> <Order Clause>
        case (int)RuleConstants.RULE_COLUMNS_TIMES :
        //<Columns> ::= <Restriction> <top> '*'
        case (int)RuleConstants.RULE_COLUMNS :
        //<Columns> ::= <Restriction> <top> <Column List>
        case (int)RuleConstants.RULE_TOP_TOP_INTEGERLITERAL_PERCENT :
        //<top> ::= TOP IntegerLiteral PERCENT
        case (int)RuleConstants.RULE_TOP_TOP_INTEGERLITERAL :
        //<top> ::= TOP IntegerLiteral
        case (int)RuleConstants.RULE_TOP :
        //<top> ::= 
        case (int)RuleConstants.RULE_COLUMNLIST_COMMA :
        //<Column List> ::= <Column Source> ',' <Column List>
        case (int)RuleConstants.RULE_COLUMNLIST :
        //<Column List> ::= <Column Source>
        case (int)RuleConstants.RULE_COLUMNSOURCE_IDENTIFIER_EQ :
        //<Column Source> ::= Identifier '=' <Expression>
        case (int)RuleConstants.RULE_COLUMNSOURCE_STRINGLITERAL_EQ :
        //<Column Source> ::= StringLiteral '=' <Expression>
        case (int)RuleConstants.RULE_COLUMNSOURCE :
        //<Column Source> ::= <Expression> <alias>
        case (int)RuleConstants.RULE_COLUMNSOURCE_IDENDIFIER :
        //<Column Source> ::= Idendifier
        case (int)RuleConstants.RULE_ALIAS_AS_IDENTIFIER :
        //<alias> ::= AS Identifier
        case (int)RuleConstants.RULE_ALIAS_AS_STRINGLITERAL :
        //<alias> ::= AS StringLiteral
        case (int)RuleConstants.RULE_ALIAS_IDENTIFIER :
        //<alias> ::= Identifier
        case (int)RuleConstants.RULE_ALIAS :
        //<alias> ::= 
        case (int)RuleConstants.RULE_ALLDISTINCT_ALL :
        //<all distinct> ::= ALL
        case (int)RuleConstants.RULE_ALLDISTINCT_DISTINCT :
        //<all distinct> ::= DISTINCT
        case (int)RuleConstants.RULE_RESTRICTION :
        //<Restriction> ::= <all distinct>
        case (int)RuleConstants.RULE_RESTRICTION2 :
        //<Restriction> ::= 
        case (int)RuleConstants.RULE_INTOCLAUSE_INTO_IDENTIFIER :
        //<Into Clause> ::= INTO Identifier
        case (int)RuleConstants.RULE_INTOCLAUSE :
        //<Into Clause> ::= 
        case (int)RuleConstants.RULE_FROMCLAUSE_FROM :
        //<From Clause> ::= FROM <table source list>
        case (int)RuleConstants.RULE_FROMCLAUSE :
        //<From Clause> ::= 
        case (int)RuleConstants.RULE_TABLESOURCELIST_COMMA :
        //<table source list> ::= <table source> ',' <table source list>
        case (int)RuleConstants.RULE_TABLESOURCELIST_CROSS_JOIN :
        //<table source list> ::= <table source> CROSS JOIN <table source list>
        case (int)RuleConstants.RULE_TABLESOURCELIST :
        //<table source list> ::= <table source>
        case (int)RuleConstants.RULE_TABLESOURCE_IDENTIFIER :
        //<table source> ::= Identifier <alias>
        case (int)RuleConstants.RULE_TABLESOURCE_LPARAN_RPARAN :
        //<table source> ::= '(' <Union Stm> ')' <alias> <optional identifier list>
        case (int)RuleConstants.RULE_TABLESOURCE :
        //<table source> ::= <Joined Table>
        case (int)RuleConstants.RULE_TABLESOURCE2 :
        //<table source> ::= <Pivoted Table>
        case (int)RuleConstants.RULE_TABLESOURCE3 :
        //<table source> ::= <Unpivoted Table>
        case (int)RuleConstants.RULE_TABLESOURCE4 :
        //<table source> ::= <rowset function>
        case (int)RuleConstants.RULE_OPTIONALIDENTIFIERLIST_LPARAN_RPARAN :
        //<optional identifier list> ::= '(' <Identifier List> ')'
        case (int)RuleConstants.RULE_OPTIONALIDENTIFIERLIST :
        //<optional identifier list> ::= 
        case (int)RuleConstants.RULE_JOINEDTABLE_JOIN_ON :
        //<Joined Table> ::= <table source> <join type> JOIN <table source> ON <search list>
        case (int)RuleConstants.RULE_JOINEDTABLE_LPARAN_RPARAN :
        //<Joined Table> ::= '(' <Joined Table> ')'
        case (int)RuleConstants.RULE_JOINTYPE_INNER :
        //<join type> ::= INNER
        case (int)RuleConstants.RULE_JOINTYPE_LEFT :
        //<join type> ::= LEFT
        case (int)RuleConstants.RULE_JOINTYPE_LEFT_OUTER :
        //<join type> ::= LEFT OUTER
        case (int)RuleConstants.RULE_JOINTYPE_RIGHT :
        //<join type> ::= RIGHT
        case (int)RuleConstants.RULE_JOINTYPE_RIGHT_OUTER :
        //<join type> ::= RIGHT OUTER
        case (int)RuleConstants.RULE_JOINTYPE_FULL :
        //<join type> ::= FULL
        case (int)RuleConstants.RULE_JOINTYPE_FULL_OUTER :
        //<join type> ::= FULL OUTER
        case (int)RuleConstants.RULE_JOINTYPE :
        //<join type> ::= 
        case (int)RuleConstants.RULE_ROWSETFUNCTION_OPENROWSET_LPARAN_STRINGLITERAL_COMMA_STRINGLITERAL_COMMA_RPARAN :
        //<rowset function> ::= OPENROWSET '(' StringLiteral ',' StringLiteral ',' <rowset source> ')' <alias>
        case (int)RuleConstants.RULE_ROWSETFUNCTION_OPENROWSET_LPARAN_STRINGLITERAL_COMMA_RPARAN :
        //<rowset function> ::= OPENROWSET '(' StringLiteral ',' <rowset source> ')' <alias>
        case (int)RuleConstants.RULE_ROWSETSOURCE_IDENTIFIER :
        //<rowset source> ::= Identifier
        case (int)RuleConstants.RULE_ROWSETSOURCE_STRINGLITERAL :
        //<rowset source> ::= StringLiteral
        case (int)RuleConstants.RULE_PIVOTEDTABLE_PIVOT :
        //<Pivoted Table> ::= <table source> PIVOT <pivot_clause> <alias>
        case (int)RuleConstants.RULE_PIVOT_CLAUSE_LPARAN_IDENTIFIER_LPARAN_IDENTIFIER_RPARAN_FOR_IDENTIFIER_IN_LPARAN_RPARAN_RPARAN :
        //<pivot_clause> ::= '(' Identifier '(' Identifier ')' FOR Identifier IN '(' <Column List> ')' ')'
        case (int)RuleConstants.RULE_PIVOT_CLAUSE_LPARAN_IDENTIFIER_LPARAN_IDENTIFIER_RPARAN_FOR_IDENTIFIER_RPARAN :
        //<pivot_clause> ::= '(' Identifier '(' Identifier ')' FOR Identifier ')'
        case (int)RuleConstants.RULE_PIVOT_CLAUSE_LPARAN_IDENTIFIER_LPARAN_IDENTIFIER_RPARAN_FOR_IDENTIFIER_IN_LPARAN_RPARAN_RPARAN2 :
        //<pivot_clause> ::= '(' Identifier '(' Identifier ')' FOR Identifier IN '(' <Union Stm> ')' ')'
        case (int)RuleConstants.RULE_UNPIVOTEDTABLE_UNPIVOT :
        //<Unpivoted Table> ::= <table source> UNPIVOT <unpivot_clause> <alias>
        case (int)RuleConstants.RULE_UNPIVOT_CLAUSE_LPARAN_IDENTIFIER_FOR_IDENTIFIER_IN_LPARAN_RPARAN_RPARAN :
        //<unpivot_clause> ::= '(' Identifier FOR Identifier IN '(' <Column List> ')' ')'
        case (int)RuleConstants.RULE_WHERECLAUSE_WHERE :
        //<Where Clause> ::= WHERE <search list>
        case (int)RuleConstants.RULE_WHERECLAUSE :
        //<Where Clause> ::= 
        case (int)RuleConstants.RULE_GROUPCLAUSE_GROUP_BY :
        //<Group Clause> ::= GROUP BY <Id List>
        case (int)RuleConstants.RULE_GROUPCLAUSE_GROUP_BY_ALL :
        //<Group Clause> ::= GROUP BY ALL
        case (int)RuleConstants.RULE_GROUPCLAUSE :
        //<Group Clause> ::= 
        case (int)RuleConstants.RULE_IDLIST_COMMA :
        //<Id List> ::= <Expression> <alias> ',' <Id List>
        case (int)RuleConstants.RULE_IDLIST :
        //<Id List> ::= <Expression> <alias>
        case (int)RuleConstants.RULE_ORDERCLAUSE_ORDER_BY :
        //<Order Clause> ::= ORDER BY <Order List>
        case (int)RuleConstants.RULE_ORDERCLAUSE :
        //<Order Clause> ::= 
        case (int)RuleConstants.RULE_ORDERLIST_COMMA :
        //<Order List> ::= <Order Type> <Sort Type> ',' <Order List>
        case (int)RuleConstants.RULE_ORDERLIST :
        //<Order List> ::= <Order Type> <Sort Type>
        case (int)RuleConstants.RULE_ORDERTYPE_IDENTIFIER :
        //<Order Type> ::= Identifier
        case (int)RuleConstants.RULE_ORDERTYPE_INTEGERLITERAL :
        //<Order Type> ::= IntegerLiteral
        case (int)RuleConstants.RULE_SORTTYPE_ASC :
        //<Sort Type> ::= ASC
        case (int)RuleConstants.RULE_SORTTYPE_DESC :
        //<Sort Type> ::= DESC
        case (int)RuleConstants.RULE_SORTTYPE :
        //<Sort Type> ::= 
        case (int)RuleConstants.RULE_HAVINGCLAUSE_HAVING :
        //<Having Clause> ::= HAVING <search list>
        case (int)RuleConstants.RULE_HAVINGCLAUSE :
        //<Having Clause> ::= 
        case (int)RuleConstants.RULE_SEARCHLIST_AND :
        //<search list> ::= <search list> AND <not> <predicate> <alias>
        case (int)RuleConstants.RULE_SEARCHLIST_OR :
        //<search list> ::= <search list> OR <not> <predicate> <alias>
        case (int)RuleConstants.RULE_SEARCHLIST :
        //<search list> ::= <not> <predicate> <alias>
        case (int)RuleConstants.RULE_NOT_NOT :
        //<not> ::= NOT
        case (int)RuleConstants.RULE_NOT :
        //<not> ::= 
        case (int)RuleConstants.RULE_PREDICATE :
        //<predicate> ::= <comparisons>
        case (int)RuleConstants.RULE_PREDICATE_LIKE :
        //<predicate> ::= <Expression> <not> LIKE <Expression>
        case (int)RuleConstants.RULE_PREDICATE_BETWEEN_AND :
        //<predicate> ::= <Expression> <not> BETWEEN <Expression> AND <Expression>
        case (int)RuleConstants.RULE_PREDICATE_IS_NULL :
        //<predicate> ::= <Expression> IS <not> NULL
        case (int)RuleConstants.RULE_PREDICATE_IN_LPARAN_RPARAN :
        //<predicate> ::= <Expression> <not> IN '(' <Union Stm> ')'
        case (int)RuleConstants.RULE_PREDICATE_IN_LPARAN_RPARAN2 :
        //<predicate> ::= <Expression> <not> IN '(' <Expression List> ')'
        case (int)RuleConstants.RULE_PREDICATE_EXISTS_LPARAN_RPARAN :
        //<predicate> ::= EXISTS '(' <Union Stm> ')'
        case (int)RuleConstants.RULE_COMPARISONS_GT :
        //<comparisons> ::= <Expression> '>' <Expression>
        case (int)RuleConstants.RULE_COMPARISONS_LT :
        //<comparisons> ::= <Expression> '<' <Expression>
        case (int)RuleConstants.RULE_COMPARISONS_LTEQ :
        //<comparisons> ::= <Expression> '<=' <Expression>
        case (int)RuleConstants.RULE_COMPARISONS_GTEQ :
        //<comparisons> ::= <Expression> '>=' <Expression>
        case (int)RuleConstants.RULE_COMPARISONS_EQ :
        //<comparisons> ::= <Expression> '=' <Expression>
        case (int)RuleConstants.RULE_COMPARISONS_LTGT :
        //<comparisons> ::= <Expression> '<>' <Expression>
        case (int)RuleConstants.RULE_COMPARISONS_EXCLAMEQ :
        //<comparisons> ::= <Expression> '!=' <Expression>
        case (int)RuleConstants.RULE_COMPARISONS :
        //<comparisons> ::= <Expression>
        case (int)RuleConstants.RULE_EXPRESSIONLIST_COMMA :
        //<Expression List> ::= <Expression> ',' <Expression List>
        case (int)RuleConstants.RULE_EXPRESSIONLIST :
        //<Expression List> ::= <Expression>
        case (int)RuleConstants.RULE_EXPRESSION_PLUS :
        //<Expression> ::= <Expression> '+' <Mult Expression>
        case (int)RuleConstants.RULE_EXPRESSION_MINUS :
        //<Expression> ::= <Expression> '-' <Mult Expression>
        case (int)RuleConstants.RULE_EXPRESSION_AMP :
        //<Expression> ::= <Expression> '&' <Mult Expression>
        case (int)RuleConstants.RULE_EXPRESSION_PIPE :
        //<Expression> ::= <Expression> '|' <Mult Expression>
        case (int)RuleConstants.RULE_EXPRESSION_CARET :
        //<Expression> ::= <Expression> '^' <Mult Expression>
        case (int)RuleConstants.RULE_EXPRESSION :
        //<Expression> ::= <Mult Expression>
        case (int)RuleConstants.RULE_MULTEXPRESSION_TIMES :
        //<Mult Expression> ::= <Mult Expression> '*' <Unary Exp>
        case (int)RuleConstants.RULE_MULTEXPRESSION_DIV :
        //<Mult Expression> ::= <Mult Expression> '/' <Unary Exp>
        case (int)RuleConstants.RULE_MULTEXPRESSION_PERCENT :
        //<Mult Expression> ::= <Mult Expression> '%' <Unary Exp>
        case (int)RuleConstants.RULE_MULTEXPRESSION :
        //<Mult Expression> ::= <Unary Exp>
        case (int)RuleConstants.RULE_UNARYEXP_MINUS :
        //<Unary Exp> ::= '-' <Value>
        case (int)RuleConstants.RULE_UNARYEXP_PLUS :
        //<Unary Exp> ::= '+' <Value>
        case (int)RuleConstants.RULE_UNARYEXP_TILDE :
        //<Unary Exp> ::= '~' <Value>
        case (int)RuleConstants.RULE_UNARYEXP :
        //<Unary Exp> ::= <Value>
        case (int)RuleConstants.RULE_VALUE_LPARAN_RPARAN :
        //<Value> ::= '(' <search list> ')'
        case (int)RuleConstants.RULE_VALUE_LPARAN_RPARAN2 :
        //<Value> ::= '(' <Select Stm> ')'
        case (int)RuleConstants.RULE_VALUE_INTEGERLITERAL :
        //<Value> ::= IntegerLiteral
        case (int)RuleConstants.RULE_VALUE_HEXLITERAL :
        //<Value> ::= HexLiteral
        case (int)RuleConstants.RULE_VALUE_REALLITERAL :
        //<Value> ::= RealLiteral
        case (int)RuleConstants.RULE_VALUE_STRINGLITERAL :
        //<Value> ::= StringLiteral
        case (int)RuleConstants.RULE_VALUE_NULL :
        //<Value> ::= NULL
        case (int)RuleConstants.RULE_VALUE :
        //<Value> ::= <case>
        case (int)RuleConstants.RULE_VALUE_IDENTIFIER :
        //<Value> ::= Identifier <Argument List Opt>
        case (int)RuleConstants.RULE_VALUE2 :
        //<Value> ::= <special function>
        case (int)RuleConstants.RULE_VALUE3 :
        //<Value> ::= <Parameter>
        case (int)RuleConstants.RULE_VALUE4 :
        //<Value> ::= <XEval>
        case (int)RuleConstants.RULE_PARAMETER_COLON_IDENTIFIER :
        //<Parameter> ::= ':' Identifier
        case (int)RuleConstants.RULE_XEVAL_LBRACE_STRINGLITERAL_RBRACE :
        //<XEval> ::= '{' StringLiteral '}'
        case (int)RuleConstants.RULE_CASE_CASE_END :
        //<case> ::= CASE <casetype> <casewhen list> <caseelse> END
        case (int)RuleConstants.RULE_CASETYPE :
        //<casetype> ::= <Expression>
        case (int)RuleConstants.RULE_CASETYPE2 :
        //<casetype> ::= 
        case (int)RuleConstants.RULE_CASEWHENLIST :
        //<casewhen list> ::= <casewhen> <casewhen list>
        case (int)RuleConstants.RULE_CASEWHENLIST2 :
        //<casewhen list> ::= <casewhen>
        case (int)RuleConstants.RULE_CASEWHEN_WHEN_THEN :
        //<casewhen> ::= WHEN <search list> THEN <Expression>
        case (int)RuleConstants.RULE_CASEELSE_ELSE :
        //<caseelse> ::= ELSE <Expression>
        case (int)RuleConstants.RULE_CASEELSE :
        //<caseelse> ::= 
        case (int)RuleConstants.RULE_SPECIALFUNCTION_CAST_LPARAN_AS_RPARAN :
        //<special function> ::= CAST '(' <Expression> AS <Type> ')'
        case (int)RuleConstants.RULE_SPECIALFUNCTION_CONVERT_LPARAN_COMMA_RPARAN :
        //<special function> ::= CONVERT '(' <Type> ',' <Expression> <style> ')'
        case (int)RuleConstants.RULE_STYLE_COMMA_INTEGERLITERAL :
        //<style> ::= ',' IntegerLiteral
        case (int)RuleConstants.RULE_STYLE_COMMA_STRINGLITERAL :
        //<style> ::= ',' StringLiteral
        case (int)RuleConstants.RULE_STYLE :
        //<style> ::= 
        case (int)RuleConstants.RULE_ARGUMENTLISTOPT_LPARAN_RPARAN :
        //<Argument List Opt> ::= '(' <Restriction> <Argument List> ')'
        case (int)RuleConstants.RULE_ARGUMENTLISTOPT :
        //<Argument List Opt> ::= 
        case (int)RuleConstants.RULE_ARGUMENTLIST_COMMA :
        //<Argument List> ::= <Argument List> ',' <function args>
        case (int)RuleConstants.RULE_ARGUMENTLIST :
        //<Argument List> ::= <function args>
        case (int)RuleConstants.RULE_FUNCTIONARGS_TIMES :
        //<function args> ::= '*'
        case (int)RuleConstants.RULE_FUNCTIONARGS :
        //<function args> ::= <Expression> <alias>
        case (int)RuleConstants.RULE_FUNCTIONARGS2 :
        //<function args> ::= 
        default:
          //Todos os casos que não possuem tratamento específico retornam o texto puro
          return GetFullText(token, aQuery);

      }
    }
  }
}
