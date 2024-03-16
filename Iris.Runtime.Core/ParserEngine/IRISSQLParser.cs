using System;
using System.IO;
using System.Runtime.Serialization;
using goldparser;

namespace Iris.Runtime.Core
{
  public class Parser : BaseParser
  {

    public Parser()
      : base("IRISSQL")
    {
    }

    public void Parse(string source)
    {
      NonterminalToken token = parser.Parse(source);
      if (token != null)
      {
        Object obj = CreateObject(token);
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
      if (token is NonterminalToken)
      {
        string value = "";
        for (int i = 0; i < ((NonterminalToken)token).Tokens.Length; i++)
        {
          value += GetText(token, i) + " ";
        }
        return value;
      }
      else
        return ((TerminalToken)token).Text;
    }

    private string GetText(Token token, int idx)
    {
      if (token is NonterminalToken)
      {
        string text = Convert.ToString(CreateObject(((NonterminalToken)token).Tokens[idx]));
        return text;
      }
      else
        return ((TerminalToken)token).Text;
    }

    protected override Object CreateObjectFromTerminal(TerminalToken token)
    {
      switch (token.Symbol.Id)
      {

        case (int)IRISSQLSymbolConstants.SYMBOL_EOF :
        //(EOF)
        case (int)IRISSQLSymbolConstants.SYMBOL_ERROR :
        //(Error)
        case (int)IRISSQLSymbolConstants.SYMBOL_WHITESPACE :
        //(Whitespace)
        case (int)IRISSQLSymbolConstants.SYMBOL_COMMENTEND :
        //(Comment End)
        case (int)IRISSQLSymbolConstants.SYMBOL_COMMENTLINE :
        //(Comment Line)
        case (int)IRISSQLSymbolConstants.SYMBOL_COMMENTSTART :
        //(Comment Start)
        case (int)IRISSQLSymbolConstants.SYMBOL_MINUS :
        //'-'
        case (int)IRISSQLSymbolConstants.SYMBOL_EXCLAMEQ :
        //'!='
        case (int)IRISSQLSymbolConstants.SYMBOL_PERCENT :
        //'%'
        case (int)IRISSQLSymbolConstants.SYMBOL_AMP :
        //'&'
        case (int)IRISSQLSymbolConstants.SYMBOL_LPARAN :
        //'('
        case (int)IRISSQLSymbolConstants.SYMBOL_RPARAN :
        //')'
        case (int)IRISSQLSymbolConstants.SYMBOL_TIMES :
        //'*'
        case (int)IRISSQLSymbolConstants.SYMBOL_COMMA :
        //','
        case (int)IRISSQLSymbolConstants.SYMBOL_DIV :
        //'/'
        case (int)IRISSQLSymbolConstants.SYMBOL_COLON :
        //':'
        case (int)IRISSQLSymbolConstants.SYMBOL_CARET :
        //'^'
        case (int)IRISSQLSymbolConstants.SYMBOL_LBRACE :
        //'{'
        case (int)IRISSQLSymbolConstants.SYMBOL_PIPE :
        //'|'
        case (int)IRISSQLSymbolConstants.SYMBOL_RBRACE :
        //'}'
        case (int)IRISSQLSymbolConstants.SYMBOL_TILDE :
        //'~'
        case (int)IRISSQLSymbolConstants.SYMBOL_PLUS :
        //'+'
        case (int)IRISSQLSymbolConstants.SYMBOL_LT :
        //'<'
        case (int)IRISSQLSymbolConstants.SYMBOL_LTEQ :
        //'<='
        case (int)IRISSQLSymbolConstants.SYMBOL_LTGT :
        //'<>'
        case (int)IRISSQLSymbolConstants.SYMBOL_EQ :
        //'='
        case (int)IRISSQLSymbolConstants.SYMBOL_GT :
        //'>'
        case (int)IRISSQLSymbolConstants.SYMBOL_GTEQ :
        //'>='
        case (int)IRISSQLSymbolConstants.SYMBOL_ACTION :
        //ACTION
        case (int)IRISSQLSymbolConstants.SYMBOL_ADD :
        //ADD
        case (int)IRISSQLSymbolConstants.SYMBOL_ALL :
        //ALL
        case (int)IRISSQLSymbolConstants.SYMBOL_ALTER :
        //ALTER
        case (int)IRISSQLSymbolConstants.SYMBOL_AND :
        //AND
        case (int)IRISSQLSymbolConstants.SYMBOL_AS :
        //AS
        case (int)IRISSQLSymbolConstants.SYMBOL_ASC :
        //ASC
        case (int)IRISSQLSymbolConstants.SYMBOL_BETWEEN :
        //BETWEEN
        case (int)IRISSQLSymbolConstants.SYMBOL_BY :
        //BY
        case (int)IRISSQLSymbolConstants.SYMBOL_CASCADE :
        //CASCADE
        case (int)IRISSQLSymbolConstants.SYMBOL_CASE :
        //CASE
        case (int)IRISSQLSymbolConstants.SYMBOL_CASESENSITIVE :
        //CASESENSITIVE
        case (int)IRISSQLSymbolConstants.SYMBOL_CAST :
        //CAST
        case (int)IRISSQLSymbolConstants.SYMBOL_CHECK :
        //CHECK
        case (int)IRISSQLSymbolConstants.SYMBOL_CLUSTERED :
        //CLUSTERED
        case (int)IRISSQLSymbolConstants.SYMBOL_COLLATE :
        //COLLATE
        case (int)IRISSQLSymbolConstants.SYMBOL_COLUMN :
        //COLUMN
        case (int)IRISSQLSymbolConstants.SYMBOL_COMPRESSED :
        //COMPRESSED
        case (int)IRISSQLSymbolConstants.SYMBOL_CONSTRAINT :
        //CONSTRAINT
        case (int)IRISSQLSymbolConstants.SYMBOL_CONVERT :
        //CONVERT
        case (int)IRISSQLSymbolConstants.SYMBOL_CREATE :
        //CREATE
        case (int)IRISSQLSymbolConstants.SYMBOL_CROSS :
        //CROSS
        case (int)IRISSQLSymbolConstants.SYMBOL_DATABASE :
        //DATABASE
        case (int)IRISSQLSymbolConstants.SYMBOL_DEFAULT :
        //DEFAULT
        case (int)IRISSQLSymbolConstants.SYMBOL_DELETE :
        //DELETE
        case (int)IRISSQLSymbolConstants.SYMBOL_DESC :
        //DESC
        case (int)IRISSQLSymbolConstants.SYMBOL_DIFFGRAM :
        //DIFFGRAM
        case (int)IRISSQLSymbolConstants.SYMBOL_DISTINCT :
        //DISTINCT
        case (int)IRISSQLSymbolConstants.SYMBOL_DROP :
        //DROP
        case (int)IRISSQLSymbolConstants.SYMBOL_ELSE :
        //ELSE
        case (int)IRISSQLSymbolConstants.SYMBOL_EMPTY :
        //EMPTY
        case (int)IRISSQLSymbolConstants.SYMBOL_END :
        //END
        case (int)IRISSQLSymbolConstants.SYMBOL_ENFORCECONSTRAINTS :
        //ENFORCECONSTRAINTS
        case (int)IRISSQLSymbolConstants.SYMBOL_ERROR2 :
        //ERROR
        case (int)IRISSQLSymbolConstants.SYMBOL_EXISTS :
        //EXISTS
        case (int)IRISSQLSymbolConstants.SYMBOL_FMTONLY :
        //FMTONLY
        case (int)IRISSQLSymbolConstants.SYMBOL_FOR :
        //FOR
        case (int)IRISSQLSymbolConstants.SYMBOL_FOREIGN :
        //FOREIGN
        case (int)IRISSQLSymbolConstants.SYMBOL_FROM :
        //FROM
        case (int)IRISSQLSymbolConstants.SYMBOL_FULL :
        //FULL
        case (int)IRISSQLSymbolConstants.SYMBOL_GROUP :
        //GROUP
        case (int)IRISSQLSymbolConstants.SYMBOL_HAVING :
        //HAVING
        case (int)IRISSQLSymbolConstants.SYMBOL_HEXLITERAL :
        //HexLiteral
        case (int)IRISSQLSymbolConstants.SYMBOL_IDENDIFIER :
        //Idendifier
        case (int)IRISSQLSymbolConstants.SYMBOL_IDENTIFIER :
        //Identifier
        case (int)IRISSQLSymbolConstants.SYMBOL_IDENTITY :
        //IDENTITY
        case (int)IRISSQLSymbolConstants.SYMBOL_IGNORE :
        //IGNORE
        case (int)IRISSQLSymbolConstants.SYMBOL_IGNORECHANGES :
        //IGNORECHANGES
        case (int)IRISSQLSymbolConstants.SYMBOL_IGNORESCHEMA :
        //IGNORESCHEMA
        case (int)IRISSQLSymbolConstants.SYMBOL_IN :
        //IN
        case (int)IRISSQLSymbolConstants.SYMBOL_INDEX :
        //INDEX
        case (int)IRISSQLSymbolConstants.SYMBOL_INNER :
        //INNER
        case (int)IRISSQLSymbolConstants.SYMBOL_INSERT :
        //INSERT
        case (int)IRISSQLSymbolConstants.SYMBOL_INTEGERLITERAL :
        //IntegerLiteral
        case (int)IRISSQLSymbolConstants.SYMBOL_INTO :
        //INTO
        case (int)IRISSQLSymbolConstants.SYMBOL_IS :
        //IS
        case (int)IRISSQLSymbolConstants.SYMBOL_JOIN :
        //JOIN
        case (int)IRISSQLSymbolConstants.SYMBOL_KEY :
        //KEY
        case (int)IRISSQLSymbolConstants.SYMBOL_LEFT :
        //LEFT
        case (int)IRISSQLSymbolConstants.SYMBOL_LIKE :
        //LIKE
        case (int)IRISSQLSymbolConstants.SYMBOL_MATCHED :
        //MATCHED
        case (int)IRISSQLSymbolConstants.SYMBOL_MERGE :
        //MERGE
        case (int)IRISSQLSymbolConstants.SYMBOL_MISSINGSCHEMAACTION :
        //MISSINGSCHEMAACTION
        case (int)IRISSQLSymbolConstants.SYMBOL_NAMESPACE :
        //NAMESPACE
        case (int)IRISSQLSymbolConstants.SYMBOL_NO :
        //NO
        case (int)IRISSQLSymbolConstants.SYMBOL_NOCHECK :
        //NOCHECK
        case (int)IRISSQLSymbolConstants.SYMBOL_NONCLUSTERED :
        //NONCLUSTERED
        case (int)IRISSQLSymbolConstants.SYMBOL_NOT :
        //NOT
        case (int)IRISSQLSymbolConstants.SYMBOL_NULL :
        //NULL
        case (int)IRISSQLSymbolConstants.SYMBOL_OFF :
        //OFF
        case (int)IRISSQLSymbolConstants.SYMBOL_ON :
        //ON
        case (int)IRISSQLSymbolConstants.SYMBOL_OPENROWSET :
        //OPENROWSET
        case (int)IRISSQLSymbolConstants.SYMBOL_OR :
        //OR
        case (int)IRISSQLSymbolConstants.SYMBOL_ORDER :
        //ORDER
        case (int)IRISSQLSymbolConstants.SYMBOL_OUTER :
        //OUTER
        case (int)IRISSQLSymbolConstants.SYMBOL_PERCENT2 :
        //PERCENT
        case (int)IRISSQLSymbolConstants.SYMBOL_PIVOT :
        //PIVOT
        case (int)IRISSQLSymbolConstants.SYMBOL_PREFIX :
        //PREFIX
        case (int)IRISSQLSymbolConstants.SYMBOL_PRESERVECHANGES :
        //PRESERVECHANGES
        case (int)IRISSQLSymbolConstants.SYMBOL_PRIMARY :
        //PRIMARY
        case (int)IRISSQLSymbolConstants.SYMBOL_REALLITERAL :
        //RealLiteral
        case (int)IRISSQLSymbolConstants.SYMBOL_REFERENCES :
        //REFERENCES
        case (int)IRISSQLSymbolConstants.SYMBOL_RENAME :
        //RENAME
        case (int)IRISSQLSymbolConstants.SYMBOL_RIGHT :
        //RIGHT
        case (int)IRISSQLSymbolConstants.SYMBOL_ROWCOUNT :
        //ROWCOUNT
        case (int)IRISSQLSymbolConstants.SYMBOL_ROWGUIDCOL :
        //ROWGUIDCOL
        case (int)IRISSQLSymbolConstants.SYMBOL_SAVE :
        //SAVE
        case (int)IRISSQLSymbolConstants.SYMBOL_SCHEMA :
        //SCHEMA
        case (int)IRISSQLSymbolConstants.SYMBOL_SELECT :
        //SELECT
        case (int)IRISSQLSymbolConstants.SYMBOL_SET :
        //SET
        case (int)IRISSQLSymbolConstants.SYMBOL_SOURCE :
        //SOURCE
        case (int)IRISSQLSymbolConstants.SYMBOL_STRINGLITERAL :
        //StringLiteral
        case (int)IRISSQLSymbolConstants.SYMBOL_TABLE :
        //TABLE
        case (int)IRISSQLSymbolConstants.SYMBOL_TARGET :
        //TARGET
        case (int)IRISSQLSymbolConstants.SYMBOL_THEN :
        //THEN
        case (int)IRISSQLSymbolConstants.SYMBOL_TO :
        //TO
        case (int)IRISSQLSymbolConstants.SYMBOL_TOP :
        //TOP
        case (int)IRISSQLSymbolConstants.SYMBOL_TRUNCATE :
        //TRUNCATE
        case (int)IRISSQLSymbolConstants.SYMBOL_UNION :
        //UNION
        case (int)IRISSQLSymbolConstants.SYMBOL_UNIQUE :
        //UNIQUE
        case (int)IRISSQLSymbolConstants.SYMBOL_UNPIVOT :
        //UNPIVOT
        case (int)IRISSQLSymbolConstants.SYMBOL_UPDATE :
        //UPDATE
        case (int)IRISSQLSymbolConstants.SYMBOL_USE :
        //USE
        case (int)IRISSQLSymbolConstants.SYMBOL_USING :
        //USING
        case (int)IRISSQLSymbolConstants.SYMBOL_VALUES :
        //VALUES
        case (int)IRISSQLSymbolConstants.SYMBOL_WHEN :
        //WHEN
        case (int)IRISSQLSymbolConstants.SYMBOL_WHERE :
        //WHERE
        case (int)IRISSQLSymbolConstants.SYMBOL_WITH :
        //WITH
        case (int)IRISSQLSymbolConstants.SYMBOL_WRITEHIERARCHY :
        //WRITEHIERARCHY
        case (int)IRISSQLSymbolConstants.SYMBOL_ACTION2 :
        //<Action>
        case (int)IRISSQLSymbolConstants.SYMBOL_ALIAS :
        //<alias>
        case (int)IRISSQLSymbolConstants.SYMBOL_ALLDISTINCT :
        //<all distinct>
        case (int)IRISSQLSymbolConstants.SYMBOL_ALTERCHECKCLAUSE :
        //<alter check clause>
        case (int)IRISSQLSymbolConstants.SYMBOL_ALTERCOLUMNDROP :
        //<alter column drop>
        case (int)IRISSQLSymbolConstants.SYMBOL_ALTERCOLUMNSET :
        //<alter column set>
        case (int)IRISSQLSymbolConstants.SYMBOL_ALTERDATABASESTM :
        //<Alter Database Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_ALTERNULL :
        //<Alter Null>
        case (int)IRISSQLSymbolConstants.SYMBOL_ALTERTABLESTM :
        //<Alter Table Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_ALTERTYPE :
        //<alter type>
        case (int)IRISSQLSymbolConstants.SYMBOL_ANDSEARCH :
        //<and search>
        case (int)IRISSQLSymbolConstants.SYMBOL_ARGUMENTLIST :
        //<Argument List>
        case (int)IRISSQLSymbolConstants.SYMBOL_ARGUMENTLISTOPT :
        //<Argument List Opt>
        case (int)IRISSQLSymbolConstants.SYMBOL_ASSIGNLIST :
        //<Assign List>
        case (int)IRISSQLSymbolConstants.SYMBOL_CASE2 :
        //<case>
        case (int)IRISSQLSymbolConstants.SYMBOL_CASEELSE :
        //<caseelse>
        case (int)IRISSQLSymbolConstants.SYMBOL_CASESENSITIVE2 :
        //<casesensitive>
        case (int)IRISSQLSymbolConstants.SYMBOL_CASETYPE :
        //<casetype>
        case (int)IRISSQLSymbolConstants.SYMBOL_CASEWHEN :
        //<casewhen>
        case (int)IRISSQLSymbolConstants.SYMBOL_CASEWHENLIST :
        //<casewhen list>
        case (int)IRISSQLSymbolConstants.SYMBOL_CHECKCONSTRAINT :
        //<Check Constraint>
        case (int)IRISSQLSymbolConstants.SYMBOL_CHECKNOCHECK :
        //<check nocheck>
        case (int)IRISSQLSymbolConstants.SYMBOL_CLUSTEREDUNCLUSTERED :
        //<Clustered UnClustered>
        case (int)IRISSQLSymbolConstants.SYMBOL_COLLATION :
        //<collation>
        case (int)IRISSQLSymbolConstants.SYMBOL_COLUMN2 :
        //<column>
        case (int)IRISSQLSymbolConstants.SYMBOL_COLUMNCONSTRAINT :
        //<Column Constraint>
        case (int)IRISSQLSymbolConstants.SYMBOL_COLUMNCONSTRAINTTYPE :
        //<Column Constraint Type>
        case (int)IRISSQLSymbolConstants.SYMBOL_COLUMNDEFINITION :
        //<Column Definition>
        case (int)IRISSQLSymbolConstants.SYMBOL_COLUMNLIST :
        //<Column List>
        case (int)IRISSQLSymbolConstants.SYMBOL_COLUMNSOURCE :
        //<Column Source>
        case (int)IRISSQLSymbolConstants.SYMBOL_COLUMNS :
        //<Columns>
        case (int)IRISSQLSymbolConstants.SYMBOL_COMPARISONS :
        //<comparisons>
        case (int)IRISSQLSymbolConstants.SYMBOL_COMPRESSED2 :
        //<compressed>
        case (int)IRISSQLSymbolConstants.SYMBOL_CONSTRAINTCOLUMN :
        //<Constraint Column>
        case (int)IRISSQLSymbolConstants.SYMBOL_CONSTRAINTCOLUMNLIST :
        //<Constraint Column List>
        case (int)IRISSQLSymbolConstants.SYMBOL_CONSTRAINTCOLUMNS :
        //<Constraint Columns>
        case (int)IRISSQLSymbolConstants.SYMBOL_CONSTRAINTLIST :
        //<Constraint List>
        case (int)IRISSQLSymbolConstants.SYMBOL_CREATECOLUMN :
        //<Create Column>
        case (int)IRISSQLSymbolConstants.SYMBOL_CREATECOLUMNS :
        //<Create Columns>
        case (int)IRISSQLSymbolConstants.SYMBOL_CREATEDATABASESTM :
        //<Create Database Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_CREATEFORMAT :
        //<create format>
        case (int)IRISSQLSymbolConstants.SYMBOL_CREATEINDEXSTM :
        //<Create Index Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_CREATETABLESTM :
        //<Create Table Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_DATABASENAME :
        //<database name>
        case (int)IRISSQLSymbolConstants.SYMBOL_DATABASEOPTIONS :
        //<database options>
        case (int)IRISSQLSymbolConstants.SYMBOL_DBOPTION :
        //<db option>
        case (int)IRISSQLSymbolConstants.SYMBOL_DBOPTIONSLIST :
        //<db options list>
        case (int)IRISSQLSymbolConstants.SYMBOL_DEFAULTCONSTRAINT :
        //<Default Constraint>
        case (int)IRISSQLSymbolConstants.SYMBOL_DELETESTM :
        //<Delete Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_DROPCLAUSE :
        //<drop clause>
        case (int)IRISSQLSymbolConstants.SYMBOL_DROPDATABASESTM :
        //<Drop Database Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_DROPINDEXSTM :
        //<Drop Index Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_DROPLIST :
        //<drop list>
        case (int)IRISSQLSymbolConstants.SYMBOL_DROPTABLESTM :
        //<Drop Table Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_ENFORCECONSTRAINTS2 :
        //<enforceconstraints>
        case (int)IRISSQLSymbolConstants.SYMBOL_EXPRESSION :
        //<Expression>
        case (int)IRISSQLSymbolConstants.SYMBOL_EXPRESSIONLIST :
        //<Expression List>
        case (int)IRISSQLSymbolConstants.SYMBOL_FILE :
        //<file>
        case (int)IRISSQLSymbolConstants.SYMBOL_FORCOLUMN :
        //<For Column>
        case (int)IRISSQLSymbolConstants.SYMBOL_FORCE :
        //<force>
        case (int)IRISSQLSymbolConstants.SYMBOL_FOREIGNKEY :
        //<Foreign Key>
        case (int)IRISSQLSymbolConstants.SYMBOL_FROM2 :
        //<From>
        case (int)IRISSQLSymbolConstants.SYMBOL_FROMCLAUSE :
        //<From Clause>
        case (int)IRISSQLSymbolConstants.SYMBOL_FUNCTIONARGS :
        //<function args>
        case (int)IRISSQLSymbolConstants.SYMBOL_GROUPCLAUSE :
        //<Group Clause>
        case (int)IRISSQLSymbolConstants.SYMBOL_HAVINGCLAUSE :
        //<Having Clause>
        case (int)IRISSQLSymbolConstants.SYMBOL_IDLIST :
        //<Id List>
        case (int)IRISSQLSymbolConstants.SYMBOL_IDENTIFIERLIST :
        //<Identifier List>
        case (int)IRISSQLSymbolConstants.SYMBOL_IDENTITYCONSTRAINT :
        //<Identity Constraint>
        case (int)IRISSQLSymbolConstants.SYMBOL_INSERTARRAYS :
        //<Insert Arrays>
        case (int)IRISSQLSymbolConstants.SYMBOL_INSERTCOLUMNS :
        //<Insert Columns>
        case (int)IRISSQLSymbolConstants.SYMBOL_INSERTLIST :
        //<Insert List>
        case (int)IRISSQLSymbolConstants.SYMBOL_INSERTSTM :
        //<Insert Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_INSERTUPDATEITEM :
        //<Insert Update Item>
        case (int)IRISSQLSymbolConstants.SYMBOL_INTEGERVALUE :
        //<Integer Value>
        case (int)IRISSQLSymbolConstants.SYMBOL_INTO2 :
        //<into>
        case (int)IRISSQLSymbolConstants.SYMBOL_INTOCLAUSE :
        //<Into Clause>
        case (int)IRISSQLSymbolConstants.SYMBOL_JOINTYPE :
        //<join type>
        case (int)IRISSQLSymbolConstants.SYMBOL_JOINEDTABLE :
        //<Joined Table>
        case (int)IRISSQLSymbolConstants.SYMBOL_MERGEOPTION :
        //<merge option>
        case (int)IRISSQLSymbolConstants.SYMBOL_MERGEOPTIONS :
        //<merge options>
        case (int)IRISSQLSymbolConstants.SYMBOL_MERGEOPTIONSLIST :
        //<merge options list>
        case (int)IRISSQLSymbolConstants.SYMBOL_MERGESOURCE :
        //<merge source>
        case (int)IRISSQLSymbolConstants.SYMBOL_MERGESTM :
        //<Merge Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_MERGE_MATCHED :
        //<merge_matched>
        case (int)IRISSQLSymbolConstants.SYMBOL_MERGE_NOT_MATCHED :
        //<merge_not_matched>
        case (int)IRISSQLSymbolConstants.SYMBOL_MISSINGSCHEMAACTION2 :
        //<missing schema action>
        case (int)IRISSQLSymbolConstants.SYMBOL_MULTEXPRESSION :
        //<Mult Expression>
        case (int)IRISSQLSymbolConstants.SYMBOL_NAMESPACE2 :
        //<namespace>
        case (int)IRISSQLSymbolConstants.SYMBOL_NOT2 :
        //<not>
        case (int)IRISSQLSymbolConstants.SYMBOL_NULLNOTNULL :
        //<Null Not Null>
        case (int)IRISSQLSymbolConstants.SYMBOL_ONOFF :
        //<OnOff>
        case (int)IRISSQLSymbolConstants.SYMBOL_OPTIONALIDENTIFIERLIST :
        //<optional identifier list>
        case (int)IRISSQLSymbolConstants.SYMBOL_ORDERCLAUSE :
        //<Order Clause>
        case (int)IRISSQLSymbolConstants.SYMBOL_ORDERLIST :
        //<Order List>
        case (int)IRISSQLSymbolConstants.SYMBOL_ORDERTYPE :
        //<Order Type>
        case (int)IRISSQLSymbolConstants.SYMBOL_PARAMETER :
        //<Parameter>
        case (int)IRISSQLSymbolConstants.SYMBOL_PIVOT_CLAUSE :
        //<pivot_clause>
        case (int)IRISSQLSymbolConstants.SYMBOL_PIVOTEDTABLE :
        //<Pivoted Table>
        case (int)IRISSQLSymbolConstants.SYMBOL_PREDICATE :
        //<predicate>
        case (int)IRISSQLSymbolConstants.SYMBOL_PREFIX2 :
        //<prefix>
        case (int)IRISSQLSymbolConstants.SYMBOL_PRESERVECHANGES2 :
        //<preserve changes>
        case (int)IRISSQLSymbolConstants.SYMBOL_PRIMARYKEY :
        //<Primary Key>
        case (int)IRISSQLSymbolConstants.SYMBOL_PRIMARYUNIQUE :
        //<Primary Unique>
        case (int)IRISSQLSymbolConstants.SYMBOL_REFCOLUMNS :
        //<Ref Columns>
        case (int)IRISSQLSymbolConstants.SYMBOL_RESTRICTION :
        //<Restriction>
        case (int)IRISSQLSymbolConstants.SYMBOL_ROWGUIDCOL2 :
        //<RowGuidCol>
        case (int)IRISSQLSymbolConstants.SYMBOL_ROWSETFUNCTION :
        //<rowset function>
        case (int)IRISSQLSymbolConstants.SYMBOL_ROWSETSOURCE :
        //<rowset source>
        case (int)IRISSQLSymbolConstants.SYMBOL_RULE :
        //<Rule>
        case (int)IRISSQLSymbolConstants.SYMBOL_SAVEFORMAT :
        //<save format>
        case (int)IRISSQLSymbolConstants.SYMBOL_SAVESCHEMA :
        //<save schema>
        case (int)IRISSQLSymbolConstants.SYMBOL_SAVESTM :
        //<Save Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_SCHEMAACTION :
        //<schema action>
        case (int)IRISSQLSymbolConstants.SYMBOL_SEARCHLIST :
        //<search list>
        case (int)IRISSQLSymbolConstants.SYMBOL_SELECTSTM :
        //<Select Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_SETSTM :
        //<Set Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_SORTTYPE :
        //<Sort Type>
        case (int)IRISSQLSymbolConstants.SYMBOL_SOURCE2 :
        //<source>
        case (int)IRISSQLSymbolConstants.SYMBOL_SPECIALFUNCTION :
        //<special function>
        case (int)IRISSQLSymbolConstants.SYMBOL_SQLSTM :
        //<SQL Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_STYLE :
        //<style>
        case (int)IRISSQLSymbolConstants.SYMBOL_TABLECONSTRAINT :
        //<Table Constraint>
        case (int)IRISSQLSymbolConstants.SYMBOL_TABLECONSTRAINTTYPE :
        //<Table Constraint Type>
        case (int)IRISSQLSymbolConstants.SYMBOL_TABLESOURCE :
        //<table source>
        case (int)IRISSQLSymbolConstants.SYMBOL_TABLESOURCELIST :
        //<table source list>
        case (int)IRISSQLSymbolConstants.SYMBOL_TARGET2 :
        //<target>
        case (int)IRISSQLSymbolConstants.SYMBOL_TOP2 :
        //<top>
        case (int)IRISSQLSymbolConstants.SYMBOL_TRUNCATESTM :
        //<Truncate Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_TYPE :
        //<Type>
        case (int)IRISSQLSymbolConstants.SYMBOL_UNARYEXP :
        //<Unary Exp>
        case (int)IRISSQLSymbolConstants.SYMBOL_UNION2 :
        //<Union>
        case (int)IRISSQLSymbolConstants.SYMBOL_UNIONSTM :
        //<Union Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_UNIQUE2 :
        //<Unique>
        case (int)IRISSQLSymbolConstants.SYMBOL_UNPIVOT_CLAUSE :
        //<unpivot_clause>
        case (int)IRISSQLSymbolConstants.SYMBOL_UNPIVOTEDTABLE :
        //<Unpivoted Table>
        case (int)IRISSQLSymbolConstants.SYMBOL_UPDATESTM :
        //<Update Stm>
        case (int)IRISSQLSymbolConstants.SYMBOL_USESCHEMA :
        //<use schema>
        case (int)IRISSQLSymbolConstants.SYMBOL_VALUE :
        //<Value>
        case (int)IRISSQLSymbolConstants.SYMBOL_WHENCONDITION :
        //<when condition>
        case (int)IRISSQLSymbolConstants.SYMBOL_WHENCONDITIONLIST :
        //<when condition list>
        case (int)IRISSQLSymbolConstants.SYMBOL_WHENMATCHED :
        //<when matched>
        case (int)IRISSQLSymbolConstants.SYMBOL_WHENSOURCENOTMATCHED :
        //<when source not matched>
        case (int)IRISSQLSymbolConstants.SYMBOL_WHENTARGETNOTMATCHED :
        //<when target not matched>
        case (int)IRISSQLSymbolConstants.SYMBOL_WHERECLAUSE :
        //<Where Clause>
        case (int)IRISSQLSymbolConstants.SYMBOL_WITHCHECKNOCHECK :
        //<with check nocheck>
        case (int)IRISSQLSymbolConstants.SYMBOL_WITHVALUES :
        //<With Values>
        case (int)IRISSQLSymbolConstants.SYMBOL_WRITEHIERARCHY2 :
        //<write hierarchy>
        case (int)IRISSQLSymbolConstants.SYMBOL_XEVAL :
        //<XEval>
        default:
          //Todos os casos que não possuem tratamento específico retornam o texto puro
          return GetFullText(token);
      }
    }

    ////////////////////////////////////////////////////////////////
    //Rule Section
    ////////////////////////////////////////////////////////////////
    public Object CreateObjectFromNonterminal(NonterminalToken token)
    {
      switch (token.Rule.Id)
      {
        case (int)IRISSQLRuleConstants.RULE_TYPE_IDENTIFIER :
        //<Type> ::= Identifier
        case (int)IRISSQLRuleConstants.RULE_TYPE_IDENTIFIER_LPARAN_INTEGERLITERAL_RPARAN :
        //<Type> ::= Identifier '(' IntegerLiteral ')'
        case (int)IRISSQLRuleConstants.RULE_TYPE_IDENTIFIER_LPARAN_INTEGERLITERAL_COMMA_INTEGERLITERAL_RPARAN :
        //<Type> ::= Identifier '(' IntegerLiteral ',' IntegerLiteral ')'
        case (int)IRISSQLRuleConstants.RULE_SQLSTM :
        //<SQL Stm> ::= <Union Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM2 :
        //<SQL Stm> ::= <Insert Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM3 :
        //<SQL Stm> ::= <Update Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM4 :
        //<SQL Stm> ::= <Delete Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM5 :
        //<SQL Stm> ::= <Truncate Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM6 :
        //<SQL Stm> ::= <Create Table Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM7 :
        //<SQL Stm> ::= <Create Index Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM8 :
        //<SQL Stm> ::= <Drop Table Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM9 :
        //<SQL Stm> ::= <Drop Index Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM10 :
        //<SQL Stm> ::= <Set Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM11 :
        //<SQL Stm> ::= <Save Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM12 :
        //<SQL Stm> ::= <Create Database Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM13 :
        //<SQL Stm> ::= <Drop Database Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM14 :
        //<SQL Stm> ::= <Merge Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM15 :
        //<SQL Stm> ::= <Alter Table Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM16 :
        //<SQL Stm> ::= <Alter Database Stm>
        case (int)IRISSQLRuleConstants.RULE_SQLSTM17 :
        //<SQL Stm> ::= <search list>
        case (int)IRISSQLRuleConstants.RULE_ALTERDATABASESTM_ALTER_DATABASE_IDENTIFIER :
        //<Alter Database Stm> ::= ALTER DATABASE Identifier <database options>
        case (int)IRISSQLRuleConstants.RULE_ALTERDATABASESTM_ALTER_DATABASE_IDENTIFIER_RENAME_TO_IDENTIFIER :
        //<Alter Database Stm> ::= ALTER DATABASE Identifier RENAME TO Identifier
        case (int)IRISSQLRuleConstants.RULE_ALTERTABLESTM_ALTER_TABLE_IDENTIFIER :
        //<Alter Table Stm> ::= ALTER TABLE Identifier <alter type>
        case (int)IRISSQLRuleConstants.RULE_ALTERTABLESTM_ALTER_TABLE_IDENTIFIER_RENAME_TO_IDENTIFIER :
        //<Alter Table Stm> ::= ALTER TABLE Identifier RENAME TO Identifier
        case (int)IRISSQLRuleConstants.RULE_ALTERTABLESTM_ALTER_TABLE_IDENTIFIER_RENAME_IDENTIFIER_TO_IDENTIFIER :
        //<Alter Table Stm> ::= ALTER TABLE Identifier RENAME <column> Identifier TO Identifier
        case (int)IRISSQLRuleConstants.RULE_COLUMN_COLUMN :
        //<column> ::= COLUMN
        case (int)IRISSQLRuleConstants.RULE_COLUMN :
        //<column> ::= 
        case (int)IRISSQLRuleConstants.RULE_ALTERTYPE_ALTER_COLUMN_IDENTIFIER :
        //<alter type> ::= ALTER COLUMN Identifier <Type> <collation> <Alter Null> <alter column set> <alter column drop>
        case (int)IRISSQLRuleConstants.RULE_ALTERTYPE_ADD :
        //<alter type> ::= <with check nocheck> ADD <Create Columns>
        case (int)IRISSQLRuleConstants.RULE_ALTERTYPE_DROP :
        //<alter type> ::= DROP <drop list>
        case (int)IRISSQLRuleConstants.RULE_ALTERTYPE_CONSTRAINT :
        //<alter type> ::= <check nocheck> CONSTRAINT <alter check clause>
        case (int)IRISSQLRuleConstants.RULE_ALTERCOLUMNSET_SET :
        //<alter column set> ::= SET <Default Constraint>
        case (int)IRISSQLRuleConstants.RULE_ALTERCOLUMNSET_SET2 :
        //<alter column set> ::= SET <Identity Constraint>
        case (int)IRISSQLRuleConstants.RULE_ALTERCOLUMNSET_ADD_ROWGUIDCOL :
        //<alter column set> ::= ADD ROWGUIDCOL
        case (int)IRISSQLRuleConstants.RULE_ALTERCOLUMNSET_SET_ROWGUIDCOL :
        //<alter column set> ::= SET ROWGUIDCOL
        case (int)IRISSQLRuleConstants.RULE_ALTERCOLUMNSET :
        //<alter column set> ::= 
        case (int)IRISSQLRuleConstants.RULE_ALTERCOLUMNDROP_DROP_DEFAULT :
        //<alter column drop> ::= DROP DEFAULT
        case (int)IRISSQLRuleConstants.RULE_ALTERCOLUMNDROP_DROP_IDENTITY :
        //<alter column drop> ::= DROP IDENTITY
        case (int)IRISSQLRuleConstants.RULE_ALTERCOLUMNDROP_DROP_ROWGUIDCOL :
        //<alter column drop> ::= DROP ROWGUIDCOL
        case (int)IRISSQLRuleConstants.RULE_ALTERCOLUMNDROP :
        //<alter column drop> ::= 
        case (int)IRISSQLRuleConstants.RULE_ALTERNULL :
        //<Alter Null> ::= <Null Not Null>
        case (int)IRISSQLRuleConstants.RULE_ALTERNULL2 :
        //<Alter Null> ::= 
        case (int)IRISSQLRuleConstants.RULE_WITHCHECKNOCHECK_WITH_CHECK :
        //<with check nocheck> ::= WITH CHECK
        case (int)IRISSQLRuleConstants.RULE_WITHCHECKNOCHECK_WITH_NOCHECK :
        //<with check nocheck> ::= WITH NOCHECK
        case (int)IRISSQLRuleConstants.RULE_WITHCHECKNOCHECK :
        //<with check nocheck> ::= 
        case (int)IRISSQLRuleConstants.RULE_DROPLIST_COMMA :
        //<drop list> ::= <drop list> ',' <drop clause>
        case (int)IRISSQLRuleConstants.RULE_DROPLIST :
        //<drop list> ::= <drop clause>
        case (int)IRISSQLRuleConstants.RULE_DROPCLAUSE_COLUMN_IDENTIFIER :
        //<drop clause> ::= COLUMN Identifier
        case (int)IRISSQLRuleConstants.RULE_DROPCLAUSE_CONSTRAINT_IDENTIFIER :
        //<drop clause> ::= CONSTRAINT Identifier
        case (int)IRISSQLRuleConstants.RULE_CHECKNOCHECK_CHECK :
        //<check nocheck> ::= CHECK
        case (int)IRISSQLRuleConstants.RULE_CHECKNOCHECK_NOCHECK :
        //<check nocheck> ::= NOCHECK
        case (int)IRISSQLRuleConstants.RULE_ALTERCHECKCLAUSE_ALL :
        //<alter check clause> ::= ALL
        case (int)IRISSQLRuleConstants.RULE_ALTERCHECKCLAUSE :
        //<alter check clause> ::= <Identifier List>
        case (int)IRISSQLRuleConstants.RULE_MERGESTM_MERGE_IDENTIFIER_USING_ON :
        //<Merge Stm> ::= MERGE <top> <into> Identifier <alias> USING <table source> ON <search list> <when condition list>
        case (int)IRISSQLRuleConstants.RULE_MERGESTM_MERGE_DATABASE_IDENTIFIER_USING_IDENTIFIER :
        //<Merge Stm> ::= MERGE DATABASE Identifier USING <merge source> Identifier <merge options>
        case (int)IRISSQLRuleConstants.RULE_MERGESTM_MERGE_TABLE_IDENTIFIER_USING_TABLE_IDENTIFIER :
        //<Merge Stm> ::= MERGE TABLE Identifier USING TABLE Identifier <merge options>
        case (int)IRISSQLRuleConstants.RULE_MERGESOURCE_DATABASE :
        //<merge source> ::= DATABASE
        case (int)IRISSQLRuleConstants.RULE_MERGESOURCE_TABLE :
        //<merge source> ::= TABLE
        case (int)IRISSQLRuleConstants.RULE_MERGEOPTIONS_SET :
        //<merge options> ::= SET <merge options list>
        case (int)IRISSQLRuleConstants.RULE_MERGEOPTIONS :
        //<merge options> ::= 
        case (int)IRISSQLRuleConstants.RULE_MERGEOPTIONSLIST_COMMA :
        //<merge options list> ::= <merge options list> ',' <merge option>
        case (int)IRISSQLRuleConstants.RULE_MERGEOPTIONSLIST :
        //<merge options list> ::= <merge option>
        case (int)IRISSQLRuleConstants.RULE_MERGEOPTION :
        //<merge option> ::= <preserve changes>
        case (int)IRISSQLRuleConstants.RULE_MERGEOPTION2 :
        //<merge option> ::= <missing schema action>
        case (int)IRISSQLRuleConstants.RULE_PRESERVECHANGES_PRESERVECHANGES :
        //<preserve changes> ::= PRESERVECHANGES <OnOff>
        case (int)IRISSQLRuleConstants.RULE_MISSINGSCHEMAACTION_MISSINGSCHEMAACTION :
        //<missing schema action> ::= MISSINGSCHEMAACTION <schema action>
        case (int)IRISSQLRuleConstants.RULE_SCHEMAACTION_ERROR :
        //<schema action> ::= ERROR
        case (int)IRISSQLRuleConstants.RULE_SCHEMAACTION_IGNORE :
        //<schema action> ::= IGNORE
        case (int)IRISSQLRuleConstants.RULE_WHENCONDITIONLIST :
        //<when condition list> ::= <when condition list> <when condition>
        case (int)IRISSQLRuleConstants.RULE_WHENCONDITIONLIST2 :
        //<when condition list> ::= <when condition>
        case (int)IRISSQLRuleConstants.RULE_WHENCONDITION :
        //<when condition> ::= <when matched>
        case (int)IRISSQLRuleConstants.RULE_WHENCONDITION2 :
        //<when condition> ::= <when target not matched>
        case (int)IRISSQLRuleConstants.RULE_WHENCONDITION3 :
        //<when condition> ::= <when source not matched>
        case (int)IRISSQLRuleConstants.RULE_WHENMATCHED_WHEN_MATCHED_THEN :
        //<when matched> ::= WHEN MATCHED <and search> THEN <merge_matched>
        case (int)IRISSQLRuleConstants.RULE_WHENTARGETNOTMATCHED_WHEN_NOT_MATCHED_THEN :
        //<when target not matched> ::= WHEN <target> NOT MATCHED <and search> THEN <merge_not_matched>
        case (int)IRISSQLRuleConstants.RULE_TARGET_TARGET :
        //<target> ::= TARGET
        case (int)IRISSQLRuleConstants.RULE_TARGET :
        //<target> ::= 
        case (int)IRISSQLRuleConstants.RULE_WHENSOURCENOTMATCHED_WHEN_SOURCE_NOT_MATCHED_THEN :
        //<when source not matched> ::= WHEN SOURCE NOT MATCHED <and search> THEN <merge_matched>
        case (int)IRISSQLRuleConstants.RULE_ANDSEARCH_AND :
        //<and search> ::= AND <search list>
        case (int)IRISSQLRuleConstants.RULE_ANDSEARCH :
        //<and search> ::= 
        case (int)IRISSQLRuleConstants.RULE_MERGE_MATCHED_UPDATE_SET :
        //<merge_matched> ::= UPDATE SET <Assign List>
        case (int)IRISSQLRuleConstants.RULE_MERGE_MATCHED_DELETE :
        //<merge_matched> ::= DELETE
        case (int)IRISSQLRuleConstants.RULE_MERGE_NOT_MATCHED_INSERT_VALUES_LPARAN_RPARAN :
        //<merge_not_matched> ::= INSERT <Insert Columns> VALUES '(' <Insert List> ')'
        case (int)IRISSQLRuleConstants.RULE_SAVESTM_SAVE_DATABASE_IDENTIFIER :
        //<Save Stm> ::= SAVE DATABASE Identifier <into> <file> <save format>
        case (int)IRISSQLRuleConstants.RULE_SAVESTM_SAVE_TABLE_IDENTIFIER_STRINGLITERAL :
        //<Save Stm> ::= SAVE TABLE Identifier <into> StringLiteral <save format> <write hierarchy>
        case (int)IRISSQLRuleConstants.RULE_FILE_STRINGLITERAL :
        //<file> ::= StringLiteral
        case (int)IRISSQLRuleConstants.RULE_FILE :
        //<file> ::= 
        case (int)IRISSQLRuleConstants.RULE_SAVEFORMAT_IDENTIFIER :
        //<save format> ::= Identifier <compressed> <save schema>
        case (int)IRISSQLRuleConstants.RULE_SAVEFORMAT :
        //<save format> ::= 
        case (int)IRISSQLRuleConstants.RULE_SAVESCHEMA_IGNORESCHEMA :
        //<save schema> ::= IGNORESCHEMA
        case (int)IRISSQLRuleConstants.RULE_SAVESCHEMA_DIFFGRAM :
        //<save schema> ::= DIFFGRAM
        case (int)IRISSQLRuleConstants.RULE_SAVESCHEMA :
        //<save schema> ::= 
        case (int)IRISSQLRuleConstants.RULE_COMPRESSED_COMPRESSED :
        //<compressed> ::= COMPRESSED
        case (int)IRISSQLRuleConstants.RULE_COMPRESSED :
        //<compressed> ::= 
        case (int)IRISSQLRuleConstants.RULE_WRITEHIERARCHY_WRITEHIERARCHY :
        //<write hierarchy> ::= WRITEHIERARCHY
        case (int)IRISSQLRuleConstants.RULE_WRITEHIERARCHY :
        //<write hierarchy> ::= 
        case (int)IRISSQLRuleConstants.RULE_CREATEDATABASESTM_CREATE_DATABASE :
        //<Create Database Stm> ::= CREATE DATABASE <database name> <source> <database options>
        case (int)IRISSQLRuleConstants.RULE_DATABASENAME_AS_IDENTIFIER :
        //<database name> ::= AS Identifier
        case (int)IRISSQLRuleConstants.RULE_DATABASENAME_IDENTIFIER :
        //<database name> ::= Identifier
        case (int)IRISSQLRuleConstants.RULE_DATABASENAME :
        //<database name> ::= 
        case (int)IRISSQLRuleConstants.RULE_SOURCE_EMPTY :
        //<source> ::= EMPTY
        case (int)IRISSQLRuleConstants.RULE_SOURCE_FROM :
        //<source> ::= FROM <create format>
        case (int)IRISSQLRuleConstants.RULE_CREATEFORMAT_IDENTIFIER_STRINGLITERAL :
        //<create format> ::= Identifier <compressed> StringLiteral <use schema>
        case (int)IRISSQLRuleConstants.RULE_USESCHEMA_USE_SCHEMA_STRINGLITERAL :
        //<use schema> ::= USE SCHEMA <compressed> StringLiteral <namespace> <prefix>
        case (int)IRISSQLRuleConstants.RULE_USESCHEMA :
        //<use schema> ::= 
        case (int)IRISSQLRuleConstants.RULE_NAMESPACE_NAMESPACE_STRINGLITERAL :
        //<namespace> ::= NAMESPACE StringLiteral
        case (int)IRISSQLRuleConstants.RULE_NAMESPACE :
        //<namespace> ::= 
        case (int)IRISSQLRuleConstants.RULE_PREFIX_PREFIX_STRINGLITERAL :
        //<prefix> ::= PREFIX StringLiteral
        case (int)IRISSQLRuleConstants.RULE_PREFIX :
        //<prefix> ::= 
        case (int)IRISSQLRuleConstants.RULE_DATABASEOPTIONS_SET :
        //<database options> ::= SET <db options list>
        case (int)IRISSQLRuleConstants.RULE_DATABASEOPTIONS :
        //<database options> ::= 
        case (int)IRISSQLRuleConstants.RULE_DBOPTIONSLIST_COMMA :
        //<db options list> ::= <db options list> ',' <db option>
        case (int)IRISSQLRuleConstants.RULE_DBOPTIONSLIST :
        //<db options list> ::= <db option>
        case (int)IRISSQLRuleConstants.RULE_DBOPTION :
        //<db option> ::= <casesensitive>
        case (int)IRISSQLRuleConstants.RULE_DBOPTION2 :
        //<db option> ::= <enforceconstraints>
        case (int)IRISSQLRuleConstants.RULE_CASESENSITIVE_CASESENSITIVE :
        //<casesensitive> ::= CASESENSITIVE <OnOff>
        case (int)IRISSQLRuleConstants.RULE_ENFORCECONSTRAINTS_ENFORCECONSTRAINTS :
        //<enforceconstraints> ::= ENFORCECONSTRAINTS <OnOff>
        case (int)IRISSQLRuleConstants.RULE_DROPDATABASESTM_DROP_DATABASE_IDENTIFIER :
        //<Drop Database Stm> ::= DROP DATABASE Identifier <force>
        case (int)IRISSQLRuleConstants.RULE_FORCE_IGNORECHANGES :
        //<force> ::= IGNORECHANGES
        case (int)IRISSQLRuleConstants.RULE_FORCE :
        //<force> ::= 
        case (int)IRISSQLRuleConstants.RULE_SETSTM_SET_FMTONLY :
        //<Set Stm> ::= SET FMTONLY <OnOff>
        case (int)IRISSQLRuleConstants.RULE_SETSTM_SET_ROWCOUNT_INTEGERLITERAL :
        //<Set Stm> ::= SET ROWCOUNT IntegerLiteral
        case (int)IRISSQLRuleConstants.RULE_ONOFF_ON :
        //<OnOff> ::= ON
        case (int)IRISSQLRuleConstants.RULE_ONOFF_OFF :
        //<OnOff> ::= OFF
        case (int)IRISSQLRuleConstants.RULE_ONOFF :
        //<OnOff> ::= 
        case (int)IRISSQLRuleConstants.RULE_CREATETABLESTM_CREATE_TABLE_IDENTIFIER_LPARAN_RPARAN :
        //<Create Table Stm> ::= CREATE TABLE Identifier '(' <Create Columns> ')'
        case (int)IRISSQLRuleConstants.RULE_CREATECOLUMNS_COMMA :
        //<Create Columns> ::= <Create Columns> ',' <Create Column>
        case (int)IRISSQLRuleConstants.RULE_CREATECOLUMNS :
        //<Create Columns> ::= <Create Column>
        case (int)IRISSQLRuleConstants.RULE_CREATECOLUMN :
        //<Create Column> ::= <Column Definition>
        case (int)IRISSQLRuleConstants.RULE_CREATECOLUMN_IDENTIFIER_AS :
        //<Create Column> ::= Identifier AS <Expression>
        case (int)IRISSQLRuleConstants.RULE_CREATECOLUMN_IDENTIFIER_AS_STRINGLITERAL :
        //<Create Column> ::= Identifier <Type> AS StringLiteral
        case (int)IRISSQLRuleConstants.RULE_CREATECOLUMN2 :
        //<Create Column> ::= <Table Constraint>
        case (int)IRISSQLRuleConstants.RULE_TABLECONSTRAINT_CONSTRAINT_IDENTIFIER :
        //<Table Constraint> ::= CONSTRAINT Identifier <Table Constraint Type>
        case (int)IRISSQLRuleConstants.RULE_TABLECONSTRAINT :
        //<Table Constraint> ::= <Table Constraint Type>
        case (int)IRISSQLRuleConstants.RULE_TABLECONSTRAINTTYPE :
        //<Table Constraint Type> ::= <Primary Key>
        case (int)IRISSQLRuleConstants.RULE_TABLECONSTRAINTTYPE2 :
        //<Table Constraint Type> ::= <Foreign Key>
        case (int)IRISSQLRuleConstants.RULE_TABLECONSTRAINTTYPE3 :
        //<Table Constraint Type> ::= <Check Constraint>
        case (int)IRISSQLRuleConstants.RULE_TABLECONSTRAINTTYPE4 :
        //<Table Constraint Type> ::= <Default Constraint>
        case (int)IRISSQLRuleConstants.RULE_COLUMNDEFINITION_IDENTIFIER :
        //<Column Definition> ::= Identifier <Type> <collation> <Constraint List>
        case (int)IRISSQLRuleConstants.RULE_COLLATION_COLLATE_IDENTIFIER :
        //<collation> ::= COLLATE Identifier
        case (int)IRISSQLRuleConstants.RULE_COLLATION :
        //<collation> ::= 
        case (int)IRISSQLRuleConstants.RULE_CONSTRAINTLIST :
        //<Constraint List> ::= <Constraint List> <Column Constraint>
        case (int)IRISSQLRuleConstants.RULE_CONSTRAINTLIST2 :
        //<Constraint List> ::= <Column Constraint>
        case (int)IRISSQLRuleConstants.RULE_CONSTRAINTLIST3 :
        //<Constraint List> ::= 
        case (int)IRISSQLRuleConstants.RULE_COLUMNCONSTRAINT_CONSTRAINT_IDENTIFIER :
        //<Column Constraint> ::= CONSTRAINT Identifier <Column Constraint Type>
        case (int)IRISSQLRuleConstants.RULE_COLUMNCONSTRAINT :
        //<Column Constraint> ::= <Column Constraint Type>
        case (int)IRISSQLRuleConstants.RULE_COLUMNCONSTRAINTTYPE :
        //<Column Constraint Type> ::= <Null Not Null>
        case (int)IRISSQLRuleConstants.RULE_COLUMNCONSTRAINTTYPE2 :
        //<Column Constraint Type> ::= <Default Constraint>
        case (int)IRISSQLRuleConstants.RULE_COLUMNCONSTRAINTTYPE3 :
        //<Column Constraint Type> ::= <Identity Constraint>
        case (int)IRISSQLRuleConstants.RULE_COLUMNCONSTRAINTTYPE4 :
        //<Column Constraint Type> ::= <RowGuidCol>
        case (int)IRISSQLRuleConstants.RULE_COLUMNCONSTRAINTTYPE5 :
        //<Column Constraint Type> ::= <Primary Key>
        case (int)IRISSQLRuleConstants.RULE_COLUMNCONSTRAINTTYPE6 :
        //<Column Constraint Type> ::= <Foreign Key>
        case (int)IRISSQLRuleConstants.RULE_COLUMNCONSTRAINTTYPE7 :
        //<Column Constraint Type> ::= <Check Constraint>
        case (int)IRISSQLRuleConstants.RULE_NULLNOTNULL_NULL :
        //<Null Not Null> ::= NULL
        case (int)IRISSQLRuleConstants.RULE_NULLNOTNULL_NOT_NULL :
        //<Null Not Null> ::= NOT NULL
        case (int)IRISSQLRuleConstants.RULE_ROWGUIDCOL_ROWGUIDCOL :
        //<RowGuidCol> ::= ROWGUIDCOL
        case (int)IRISSQLRuleConstants.RULE_DEFAULTCONSTRAINT_DEFAULT :
        //<Default Constraint> ::= DEFAULT <Expression> <For Column> <With Values>
        case (int)IRISSQLRuleConstants.RULE_FORCOLUMN_FOR_IDENTIFIER :
        //<For Column> ::= FOR Identifier
        case (int)IRISSQLRuleConstants.RULE_FORCOLUMN :
        //<For Column> ::= 
        case (int)IRISSQLRuleConstants.RULE_WITHVALUES_WITH_VALUES :
        //<With Values> ::= WITH VALUES
        case (int)IRISSQLRuleConstants.RULE_WITHVALUES :
        //<With Values> ::= 
        case (int)IRISSQLRuleConstants.RULE_IDENTITYCONSTRAINT_IDENTITY :
        //<Identity Constraint> ::= IDENTITY
        case (int)IRISSQLRuleConstants.RULE_IDENTITYCONSTRAINT_IDENTITY_LPARAN_COMMA_RPARAN :
        //<Identity Constraint> ::= IDENTITY '(' <Integer Value> ',' <Integer Value> ')'
        case (int)IRISSQLRuleConstants.RULE_INTEGERVALUE_MINUS_INTEGERLITERAL :
        //<Integer Value> ::= '-' IntegerLiteral
        case (int)IRISSQLRuleConstants.RULE_INTEGERVALUE_PLUS_INTEGERLITERAL :
        //<Integer Value> ::= '+' IntegerLiteral
        case (int)IRISSQLRuleConstants.RULE_INTEGERVALUE_INTEGERLITERAL :
        //<Integer Value> ::= IntegerLiteral
        case (int)IRISSQLRuleConstants.RULE_PRIMARYKEY :
        //<Primary Key> ::= <Primary Unique> <Clustered UnClustered> <Constraint Columns>
        case (int)IRISSQLRuleConstants.RULE_PRIMARYUNIQUE_PRIMARY_KEY :
        //<Primary Unique> ::= PRIMARY KEY
        case (int)IRISSQLRuleConstants.RULE_PRIMARYUNIQUE_UNIQUE :
        //<Primary Unique> ::= UNIQUE
        case (int)IRISSQLRuleConstants.RULE_CLUSTEREDUNCLUSTERED_CLUSTERED :
        //<Clustered UnClustered> ::= CLUSTERED
        case (int)IRISSQLRuleConstants.RULE_CLUSTEREDUNCLUSTERED_NONCLUSTERED :
        //<Clustered UnClustered> ::= NONCLUSTERED
        case (int)IRISSQLRuleConstants.RULE_CLUSTEREDUNCLUSTERED :
        //<Clustered UnClustered> ::= 
        case (int)IRISSQLRuleConstants.RULE_CONSTRAINTCOLUMNS_LPARAN_RPARAN :
        //<Constraint Columns> ::= '(' <Constraint Column List> ')'
        case (int)IRISSQLRuleConstants.RULE_CONSTRAINTCOLUMNS :
        //<Constraint Columns> ::= 
        case (int)IRISSQLRuleConstants.RULE_FOREIGNKEY_FOREIGN_KEY_REFERENCES_IDENTIFIER :
        //<Foreign Key> ::= FOREIGN KEY REFERENCES Identifier <Ref Columns> <Rule> <Rule>
        case (int)IRISSQLRuleConstants.RULE_FOREIGNKEY_FOREIGN_KEY_LPARAN_RPARAN_REFERENCES_IDENTIFIER :
        //<Foreign Key> ::= FOREIGN KEY '(' <Constraint Column List> ')' REFERENCES Identifier <Ref Columns> <Rule> <Rule>
        case (int)IRISSQLRuleConstants.RULE_FOREIGNKEY_REFERENCES_IDENTIFIER :
        //<Foreign Key> ::= REFERENCES Identifier <Ref Columns> <Rule> <Rule>
        case (int)IRISSQLRuleConstants.RULE_RULE_ON_DELETE :
        //<Rule> ::= ON DELETE <Action>
        case (int)IRISSQLRuleConstants.RULE_RULE_ON_UPDATE :
        //<Rule> ::= ON UPDATE <Action>
        case (int)IRISSQLRuleConstants.RULE_RULE :
        //<Rule> ::= 
        case (int)IRISSQLRuleConstants.RULE_ACTION_CASCADE :
        //<Action> ::= CASCADE
        case (int)IRISSQLRuleConstants.RULE_ACTION_NO_ACTION :
        //<Action> ::= NO ACTION
        case (int)IRISSQLRuleConstants.RULE_ACTION_SET_DEFAULT :
        //<Action> ::= SET DEFAULT
        case (int)IRISSQLRuleConstants.RULE_ACTION_SET_NULL :
        //<Action> ::= SET NULL
        case (int)IRISSQLRuleConstants.RULE_REFCOLUMNS_LPARAN_RPARAN :
        //<Ref Columns> ::= '(' <Id List> ')'
        case (int)IRISSQLRuleConstants.RULE_REFCOLUMNS :
        //<Ref Columns> ::= 
        case (int)IRISSQLRuleConstants.RULE_CHECKCONSTRAINT_CHECK :
        //<Check Constraint> ::= CHECK <search list>
        case (int)IRISSQLRuleConstants.RULE_CONSTRAINTCOLUMNLIST_COMMA :
        //<Constraint Column List> ::= <Constraint Column List> ',' <Constraint Column>
        case (int)IRISSQLRuleConstants.RULE_CONSTRAINTCOLUMNLIST :
        //<Constraint Column List> ::= <Constraint Column>
        case (int)IRISSQLRuleConstants.RULE_CONSTRAINTCOLUMN_IDENTIFIER :
        //<Constraint Column> ::= Identifier <Sort Type>
        case (int)IRISSQLRuleConstants.RULE_CREATEINDEXSTM_CREATE_INDEX_IDENTIFIER_ON_IDENTIFIER_LPARAN_RPARAN :
        //<Create Index Stm> ::= CREATE <Unique> <Clustered UnClustered> INDEX Identifier ON Identifier '(' <Constraint Column List> ')'
        case (int)IRISSQLRuleConstants.RULE_UNIQUE_UNIQUE :
        //<Unique> ::= UNIQUE
        case (int)IRISSQLRuleConstants.RULE_UNIQUE :
        //<Unique> ::= 
        case (int)IRISSQLRuleConstants.RULE_DROPTABLESTM_DROP_TABLE_IDENTIFIER :
        //<Drop Table Stm> ::= DROP TABLE Identifier
        case (int)IRISSQLRuleConstants.RULE_DROPINDEXSTM_DROP_INDEX :
        //<Drop Index Stm> ::= DROP INDEX <Identifier List>
        case (int)IRISSQLRuleConstants.RULE_IDENTIFIERLIST_COMMA_IDENTIFIER :
        //<Identifier List> ::= <Identifier List> ',' Identifier
        case (int)IRISSQLRuleConstants.RULE_IDENTIFIERLIST_IDENTIFIER :
        //<Identifier List> ::= Identifier
        case (int)IRISSQLRuleConstants.RULE_INSERTSTM_INSERT_IDENTIFIER :
        //<Insert Stm> ::= INSERT <into> Identifier <Insert Columns> <Union Stm>
        case (int)IRISSQLRuleConstants.RULE_INSERTSTM_INSERT_IDENTIFIER_VALUES :
        //<Insert Stm> ::= INSERT <into> Identifier <Insert Columns> VALUES <Insert Arrays>
        case (int)IRISSQLRuleConstants.RULE_INSERTSTM_INSERT_IDENTIFIER_DEFAULT_VALUES :
        //<Insert Stm> ::= INSERT <into> Identifier DEFAULT VALUES
        case (int)IRISSQLRuleConstants.RULE_INSERTCOLUMNS_LPARAN_RPARAN :
        //<Insert Columns> ::= '(' <Id List> ')'
        case (int)IRISSQLRuleConstants.RULE_INSERTCOLUMNS :
        //<Insert Columns> ::= 
        case (int)IRISSQLRuleConstants.RULE_INTO_INTO :
        //<into> ::= INTO
        case (int)IRISSQLRuleConstants.RULE_INTO :
        //<into> ::= 
        case (int)IRISSQLRuleConstants.RULE_INSERTUPDATEITEM :
        //<Insert Update Item> ::= <Expression>
        case (int)IRISSQLRuleConstants.RULE_INSERTUPDATEITEM_DEFAULT :
        //<Insert Update Item> ::= DEFAULT
        case (int)IRISSQLRuleConstants.RULE_INSERTLIST_COMMA :
        //<Insert List> ::= <Insert List> ',' <Insert Update Item>
        case (int)IRISSQLRuleConstants.RULE_INSERTLIST :
        //<Insert List> ::= <Insert Update Item>
        case (int)IRISSQLRuleConstants.RULE_INSERTARRAYS_LPARAN_RPARAN_COMMA :
        //<Insert Arrays> ::= '(' <Insert List> ')' ',' <Insert Arrays>
        case (int)IRISSQLRuleConstants.RULE_INSERTARRAYS_LPARAN_RPARAN :
        //<Insert Arrays> ::= '(' <Insert List> ')'
        case (int)IRISSQLRuleConstants.RULE_UPDATESTM_UPDATE_IDENTIFIER_SET :
        //<Update Stm> ::= UPDATE Identifier SET <Assign List> <From Clause> <Where Clause>
        case (int)IRISSQLRuleConstants.RULE_ASSIGNLIST_IDENTIFIER_EQ_COMMA :
        //<Assign List> ::= Identifier '=' <Insert Update Item> ',' <Assign List>
        case (int)IRISSQLRuleConstants.RULE_ASSIGNLIST_IDENTIFIER_EQ :
        //<Assign List> ::= Identifier '=' <Insert Update Item>
        case (int)IRISSQLRuleConstants.RULE_DELETESTM_DELETE_IDENTIFIER :
        //<Delete Stm> ::= DELETE <From> Identifier <Where Clause>
        case (int)IRISSQLRuleConstants.RULE_FROM_FROM :
        //<From> ::= FROM
        case (int)IRISSQLRuleConstants.RULE_FROM :
        //<From> ::= 
        case (int)IRISSQLRuleConstants.RULE_TRUNCATESTM_TRUNCATE_TABLE_IDENTIFIER :
        //<Truncate Stm> ::= TRUNCATE TABLE Identifier
        case (int)IRISSQLRuleConstants.RULE_UNIONSTM :
        //<Union Stm> ::= <Select Stm> <Union> <Union Stm>
        case (int)IRISSQLRuleConstants.RULE_UNIONSTM2 :
        //<Union Stm> ::= <Select Stm>
        case (int)IRISSQLRuleConstants.RULE_UNION_UNION_ALL :
        //<Union> ::= UNION ALL
        case (int)IRISSQLRuleConstants.RULE_UNION_UNION :
        //<Union> ::= UNION
        case (int)IRISSQLRuleConstants.RULE_SELECTSTM_SELECT :
        //<Select Stm> ::= SELECT <Columns> <Into Clause> <From Clause> <Where Clause> <Group Clause> <Having Clause> <Order Clause>
        case (int)IRISSQLRuleConstants.RULE_COLUMNS_TIMES :
        //<Columns> ::= <Restriction> <top> '*'
        case (int)IRISSQLRuleConstants.RULE_COLUMNS :
        //<Columns> ::= <Restriction> <top> <Column List>
        case (int)IRISSQLRuleConstants.RULE_TOP_TOP_INTEGERLITERAL_PERCENT :
        //<top> ::= TOP IntegerLiteral PERCENT
        case (int)IRISSQLRuleConstants.RULE_TOP_TOP_INTEGERLITERAL :
        //<top> ::= TOP IntegerLiteral
        case (int)IRISSQLRuleConstants.RULE_TOP :
        //<top> ::= 
        case (int)IRISSQLRuleConstants.RULE_COLUMNLIST_COMMA :
        //<Column List> ::= <Column Source> ',' <Column List>
        case (int)IRISSQLRuleConstants.RULE_COLUMNLIST :
        //<Column List> ::= <Column Source>
        case (int)IRISSQLRuleConstants.RULE_COLUMNSOURCE_IDENTIFIER_EQ :
        //<Column Source> ::= Identifier '=' <Expression>
        case (int)IRISSQLRuleConstants.RULE_COLUMNSOURCE_STRINGLITERAL_EQ :
        //<Column Source> ::= StringLiteral '=' <Expression>
        case (int)IRISSQLRuleConstants.RULE_COLUMNSOURCE :
        //<Column Source> ::= <Expression> <alias>
        case (int)IRISSQLRuleConstants.RULE_COLUMNSOURCE_IDENDIFIER :
        //<Column Source> ::= Idendifier
        case (int)IRISSQLRuleConstants.RULE_ALIAS_AS_IDENTIFIER :
        //<alias> ::= AS Identifier
        case (int)IRISSQLRuleConstants.RULE_ALIAS_AS_STRINGLITERAL :
        //<alias> ::= AS StringLiteral
        case (int)IRISSQLRuleConstants.RULE_ALIAS_IDENTIFIER :
        //<alias> ::= Identifier
        case (int)IRISSQLRuleConstants.RULE_ALIAS :
        //<alias> ::= 
        case (int)IRISSQLRuleConstants.RULE_ALLDISTINCT_ALL :
        //<all distinct> ::= ALL
        case (int)IRISSQLRuleConstants.RULE_ALLDISTINCT_DISTINCT :
        //<all distinct> ::= DISTINCT
        case (int)IRISSQLRuleConstants.RULE_RESTRICTION :
        //<Restriction> ::= <all distinct>
        case (int)IRISSQLRuleConstants.RULE_RESTRICTION2 :
        //<Restriction> ::= 
        case (int)IRISSQLRuleConstants.RULE_INTOCLAUSE_INTO_IDENTIFIER :
        //<Into Clause> ::= INTO Identifier
        case (int)IRISSQLRuleConstants.RULE_INTOCLAUSE :
        //<Into Clause> ::= 
        case (int)IRISSQLRuleConstants.RULE_FROMCLAUSE_FROM :
        //<From Clause> ::= FROM <table source list>
        case (int)IRISSQLRuleConstants.RULE_FROMCLAUSE :
        //<From Clause> ::= 
        case (int)IRISSQLRuleConstants.RULE_TABLESOURCELIST_COMMA :
        //<table source list> ::= <table source> ',' <table source list>
        case (int)IRISSQLRuleConstants.RULE_TABLESOURCELIST_CROSS_JOIN :
        //<table source list> ::= <table source> CROSS JOIN <table source list>
        case (int)IRISSQLRuleConstants.RULE_TABLESOURCELIST :
        //<table source list> ::= <table source>
        case (int)IRISSQLRuleConstants.RULE_TABLESOURCE_IDENTIFIER :
        //<table source> ::= Identifier <alias>
        case (int)IRISSQLRuleConstants.RULE_TABLESOURCE_LPARAN_RPARAN :
        //<table source> ::= '(' <Union Stm> ')' <alias> <optional identifier list>
        case (int)IRISSQLRuleConstants.RULE_TABLESOURCE :
        //<table source> ::= <Joined Table>
        case (int)IRISSQLRuleConstants.RULE_TABLESOURCE2 :
        //<table source> ::= <Pivoted Table>
        case (int)IRISSQLRuleConstants.RULE_TABLESOURCE3 :
        //<table source> ::= <Unpivoted Table>
        case (int)IRISSQLRuleConstants.RULE_TABLESOURCE4 :
        //<table source> ::= <rowset function>
        case (int)IRISSQLRuleConstants.RULE_OPTIONALIDENTIFIERLIST_LPARAN_RPARAN :
        //<optional identifier list> ::= '(' <Identifier List> ')'
        case (int)IRISSQLRuleConstants.RULE_OPTIONALIDENTIFIERLIST :
        //<optional identifier list> ::= 
        case (int)IRISSQLRuleConstants.RULE_JOINEDTABLE_JOIN_ON :
        //<Joined Table> ::= <table source> <join type> JOIN <table source> ON <search list>
        case (int)IRISSQLRuleConstants.RULE_JOINEDTABLE_LPARAN_RPARAN :
        //<Joined Table> ::= '(' <Joined Table> ')'
        case (int)IRISSQLRuleConstants.RULE_JOINTYPE_INNER :
        //<join type> ::= INNER
        case (int)IRISSQLRuleConstants.RULE_JOINTYPE_LEFT :
        //<join type> ::= LEFT
        case (int)IRISSQLRuleConstants.RULE_JOINTYPE_LEFT_OUTER :
        //<join type> ::= LEFT OUTER
        case (int)IRISSQLRuleConstants.RULE_JOINTYPE_RIGHT :
        //<join type> ::= RIGHT
        case (int)IRISSQLRuleConstants.RULE_JOINTYPE_RIGHT_OUTER :
        //<join type> ::= RIGHT OUTER
        case (int)IRISSQLRuleConstants.RULE_JOINTYPE_FULL :
        //<join type> ::= FULL
        case (int)IRISSQLRuleConstants.RULE_JOINTYPE_FULL_OUTER :
        //<join type> ::= FULL OUTER
        case (int)IRISSQLRuleConstants.RULE_JOINTYPE :
        //<join type> ::= 
        case (int)IRISSQLRuleConstants.RULE_ROWSETFUNCTION_OPENROWSET_LPARAN_STRINGLITERAL_COMMA_STRINGLITERAL_COMMA_RPARAN :
        //<rowset function> ::= OPENROWSET '(' StringLiteral ',' StringLiteral ',' <rowset source> ')' <alias>
        case (int)IRISSQLRuleConstants.RULE_ROWSETFUNCTION_OPENROWSET_LPARAN_STRINGLITERAL_COMMA_RPARAN :
        //<rowset function> ::= OPENROWSET '(' StringLiteral ',' <rowset source> ')' <alias>
        case (int)IRISSQLRuleConstants.RULE_ROWSETSOURCE_IDENTIFIER :
        //<rowset source> ::= Identifier
        case (int)IRISSQLRuleConstants.RULE_ROWSETSOURCE_STRINGLITERAL :
        //<rowset source> ::= StringLiteral
        case (int)IRISSQLRuleConstants.RULE_PIVOTEDTABLE_PIVOT :
        //<Pivoted Table> ::= <table source> PIVOT <pivot_clause> <alias>
        case (int)IRISSQLRuleConstants.RULE_PIVOT_CLAUSE_LPARAN_IDENTIFIER_LPARAN_IDENTIFIER_RPARAN_FOR_IDENTIFIER_IN_LPARAN_RPARAN_RPARAN :
        //<pivot_clause> ::= '(' Identifier '(' Identifier ')' FOR Identifier IN '(' <Column List> ')' ')'
        case (int)IRISSQLRuleConstants.RULE_PIVOT_CLAUSE_LPARAN_IDENTIFIER_LPARAN_IDENTIFIER_RPARAN_FOR_IDENTIFIER_RPARAN :
        //<pivot_clause> ::= '(' Identifier '(' Identifier ')' FOR Identifier ')'
        case (int)IRISSQLRuleConstants.RULE_PIVOT_CLAUSE_LPARAN_IDENTIFIER_LPARAN_IDENTIFIER_RPARAN_FOR_IDENTIFIER_IN_LPARAN_RPARAN_RPARAN2 :
        //<pivot_clause> ::= '(' Identifier '(' Identifier ')' FOR Identifier IN '(' <Union Stm> ')' ')'
        case (int)IRISSQLRuleConstants.RULE_UNPIVOTEDTABLE_UNPIVOT :
        //<Unpivoted Table> ::= <table source> UNPIVOT <unpivot_clause> <alias>
        case (int)IRISSQLRuleConstants.RULE_UNPIVOT_CLAUSE_LPARAN_IDENTIFIER_FOR_IDENTIFIER_IN_LPARAN_RPARAN_RPARAN :
        //<unpivot_clause> ::= '(' Identifier FOR Identifier IN '(' <Column List> ')' ')'
        case (int)IRISSQLRuleConstants.RULE_WHERECLAUSE_WHERE :
        //<Where Clause> ::= WHERE <search list>
        case (int)IRISSQLRuleConstants.RULE_WHERECLAUSE :
        //<Where Clause> ::= 
        case (int)IRISSQLRuleConstants.RULE_GROUPCLAUSE_GROUP_BY :
        //<Group Clause> ::= GROUP BY <Id List>
        case (int)IRISSQLRuleConstants.RULE_GROUPCLAUSE_GROUP_BY_ALL :
        //<Group Clause> ::= GROUP BY ALL
        case (int)IRISSQLRuleConstants.RULE_GROUPCLAUSE :
        //<Group Clause> ::= 
        case (int)IRISSQLRuleConstants.RULE_IDLIST_COMMA :
        //<Id List> ::= <Expression> <alias> ',' <Id List>
        case (int)IRISSQLRuleConstants.RULE_IDLIST :
        //<Id List> ::= <Expression> <alias>
        case (int)IRISSQLRuleConstants.RULE_ORDERCLAUSE_ORDER_BY :
        //<Order Clause> ::= ORDER BY <Order List>
        case (int)IRISSQLRuleConstants.RULE_ORDERCLAUSE :
        //<Order Clause> ::= 
        case (int)IRISSQLRuleConstants.RULE_ORDERLIST_COMMA :
        //<Order List> ::= <Order Type> <Sort Type> ',' <Order List>
        case (int)IRISSQLRuleConstants.RULE_ORDERLIST :
        //<Order List> ::= <Order Type> <Sort Type>
        case (int)IRISSQLRuleConstants.RULE_ORDERTYPE_IDENTIFIER :
        //<Order Type> ::= Identifier
        case (int)IRISSQLRuleConstants.RULE_ORDERTYPE_INTEGERLITERAL :
        //<Order Type> ::= IntegerLiteral
        case (int)IRISSQLRuleConstants.RULE_SORTTYPE_ASC :
        //<Sort Type> ::= ASC
        case (int)IRISSQLRuleConstants.RULE_SORTTYPE_DESC :
        //<Sort Type> ::= DESC
        case (int)IRISSQLRuleConstants.RULE_SORTTYPE :
        //<Sort Type> ::= 
        case (int)IRISSQLRuleConstants.RULE_HAVINGCLAUSE_HAVING :
        //<Having Clause> ::= HAVING <search list>
        case (int)IRISSQLRuleConstants.RULE_HAVINGCLAUSE :
        //<Having Clause> ::= 
        case (int)IRISSQLRuleConstants.RULE_SEARCHLIST_AND :
        //<search list> ::= <search list> AND <not> <predicate> <alias>
        case (int)IRISSQLRuleConstants.RULE_SEARCHLIST_OR :
        //<search list> ::= <search list> OR <not> <predicate> <alias>
        case (int)IRISSQLRuleConstants.RULE_SEARCHLIST :
        //<search list> ::= <not> <predicate> <alias>
        case (int)IRISSQLRuleConstants.RULE_NOT_NOT :
        //<not> ::= NOT
        case (int)IRISSQLRuleConstants.RULE_NOT :
        //<not> ::= 
        case (int)IRISSQLRuleConstants.RULE_PREDICATE :
        //<predicate> ::= <comparisons>
        case (int)IRISSQLRuleConstants.RULE_PREDICATE_LIKE :
        //<predicate> ::= <Expression> <not> LIKE <Expression>
        case (int)IRISSQLRuleConstants.RULE_PREDICATE_BETWEEN_AND :
        //<predicate> ::= <Expression> <not> BETWEEN <Expression> AND <Expression>
        case (int)IRISSQLRuleConstants.RULE_PREDICATE_IS_NULL :
        //<predicate> ::= <Expression> IS <not> NULL
        case (int)IRISSQLRuleConstants.RULE_PREDICATE_IN_LPARAN_RPARAN :
        //<predicate> ::= <Expression> <not> IN '(' <Union Stm> ')'
        case (int)IRISSQLRuleConstants.RULE_PREDICATE_IN_LPARAN_RPARAN2 :
        //<predicate> ::= <Expression> <not> IN '(' <Expression List> ')'
        case (int)IRISSQLRuleConstants.RULE_PREDICATE_EXISTS_LPARAN_RPARAN :
        //<predicate> ::= EXISTS '(' <Union Stm> ')'
        case (int)IRISSQLRuleConstants.RULE_COMPARISONS_GT :
        //<comparisons> ::= <Expression> '>' <Expression>
        case (int)IRISSQLRuleConstants.RULE_COMPARISONS_LT :
        //<comparisons> ::= <Expression> '<' <Expression>
        case (int)IRISSQLRuleConstants.RULE_COMPARISONS_LTEQ :
        //<comparisons> ::= <Expression> '<=' <Expression>
        case (int)IRISSQLRuleConstants.RULE_COMPARISONS_GTEQ :
        //<comparisons> ::= <Expression> '>=' <Expression>
        case (int)IRISSQLRuleConstants.RULE_COMPARISONS_EQ :
        //<comparisons> ::= <Expression> '=' <Expression>
        case (int)IRISSQLRuleConstants.RULE_COMPARISONS_LTGT :
        //<comparisons> ::= <Expression> '<>' <Expression>
        case (int)IRISSQLRuleConstants.RULE_COMPARISONS_EXCLAMEQ :
        //<comparisons> ::= <Expression> '!=' <Expression>
        case (int)IRISSQLRuleConstants.RULE_COMPARISONS :
        //<comparisons> ::= <Expression>
        case (int)IRISSQLRuleConstants.RULE_EXPRESSIONLIST_COMMA :
        //<Expression List> ::= <Expression> ',' <Expression List>
        case (int)IRISSQLRuleConstants.RULE_EXPRESSIONLIST :
        //<Expression List> ::= <Expression>
        case (int)IRISSQLRuleConstants.RULE_EXPRESSION_PLUS :
        //<Expression> ::= <Expression> '+' <Mult Expression>
        case (int)IRISSQLRuleConstants.RULE_EXPRESSION_MINUS :
        //<Expression> ::= <Expression> '-' <Mult Expression>
        case (int)IRISSQLRuleConstants.RULE_EXPRESSION_AMP :
        //<Expression> ::= <Expression> '&' <Mult Expression>
        case (int)IRISSQLRuleConstants.RULE_EXPRESSION_PIPE :
        //<Expression> ::= <Expression> '|' <Mult Expression>
        case (int)IRISSQLRuleConstants.RULE_EXPRESSION_CARET :
        //<Expression> ::= <Expression> '^' <Mult Expression>
        case (int)IRISSQLRuleConstants.RULE_EXPRESSION :
        //<Expression> ::= <Mult Expression>
        case (int)IRISSQLRuleConstants.RULE_MULTEXPRESSION_TIMES :
        //<Mult Expression> ::= <Mult Expression> '*' <Unary Exp>
        case (int)IRISSQLRuleConstants.RULE_MULTEXPRESSION_DIV :
        //<Mult Expression> ::= <Mult Expression> '/' <Unary Exp>
        case (int)IRISSQLRuleConstants.RULE_MULTEXPRESSION_PERCENT :
        //<Mult Expression> ::= <Mult Expression> '%' <Unary Exp>
        case (int)IRISSQLRuleConstants.RULE_MULTEXPRESSION :
        //<Mult Expression> ::= <Unary Exp>
        case (int)IRISSQLRuleConstants.RULE_UNARYEXP_MINUS :
        //<Unary Exp> ::= '-' <Value>
        case (int)IRISSQLRuleConstants.RULE_UNARYEXP_PLUS :
        //<Unary Exp> ::= '+' <Value>
        case (int)IRISSQLRuleConstants.RULE_UNARYEXP_TILDE :
        //<Unary Exp> ::= '~' <Value>
        case (int)IRISSQLRuleConstants.RULE_UNARYEXP :
        //<Unary Exp> ::= <Value>
        case (int)IRISSQLRuleConstants.RULE_VALUE_LPARAN_RPARAN :
        //<Value> ::= '(' <search list> ')'
        case (int)IRISSQLRuleConstants.RULE_VALUE_LPARAN_RPARAN2 :
        //<Value> ::= '(' <Select Stm> ')'
        case (int)IRISSQLRuleConstants.RULE_VALUE_INTEGERLITERAL :
        //<Value> ::= IntegerLiteral
        case (int)IRISSQLRuleConstants.RULE_VALUE_HEXLITERAL :
        //<Value> ::= HexLiteral
        case (int)IRISSQLRuleConstants.RULE_VALUE_REALLITERAL :
        //<Value> ::= RealLiteral
        case (int)IRISSQLRuleConstants.RULE_VALUE_STRINGLITERAL :
        //<Value> ::= StringLiteral
        case (int)IRISSQLRuleConstants.RULE_VALUE_NULL :
        //<Value> ::= NULL
        case (int)IRISSQLRuleConstants.RULE_VALUE :
        //<Value> ::= <case>
        case (int)IRISSQLRuleConstants.RULE_VALUE_IDENTIFIER :
        //<Value> ::= Identifier <Argument List Opt>
        case (int)IRISSQLRuleConstants.RULE_VALUE2 :
        //<Value> ::= <special function>
        case (int)IRISSQLRuleConstants.RULE_VALUE3 :
        //<Value> ::= <Parameter>
        case (int)IRISSQLRuleConstants.RULE_VALUE4 :
        //<Value> ::= <XEval>
        case (int)IRISSQLRuleConstants.RULE_PARAMETER_COLON_IDENTIFIER :
        //<Parameter> ::= ':' Identifier
        case (int)IRISSQLRuleConstants.RULE_XEVAL_LBRACE_STRINGLITERAL_RBRACE :
        //<XEval> ::= '{' StringLiteral '}'
        case (int)IRISSQLRuleConstants.RULE_CASE_CASE_END :
        //<case> ::= CASE <casetype> <casewhen list> <caseelse> END
        case (int)IRISSQLRuleConstants.RULE_CASETYPE :
        //<casetype> ::= <Expression>
        case (int)IRISSQLRuleConstants.RULE_CASETYPE2 :
        //<casetype> ::= 
        case (int)IRISSQLRuleConstants.RULE_CASEWHENLIST :
        //<casewhen list> ::= <casewhen> <casewhen list>
        case (int)IRISSQLRuleConstants.RULE_CASEWHENLIST2 :
        //<casewhen list> ::= <casewhen>
        case (int)IRISSQLRuleConstants.RULE_CASEWHEN_WHEN_THEN :
        //<casewhen> ::= WHEN <search list> THEN <Expression>
        case (int)IRISSQLRuleConstants.RULE_CASEELSE_ELSE :
        //<caseelse> ::= ELSE <Expression>
        case (int)IRISSQLRuleConstants.RULE_CASEELSE :
        //<caseelse> ::= 
        case (int)IRISSQLRuleConstants.RULE_SPECIALFUNCTION_CAST_LPARAN_AS_RPARAN :
        //<special function> ::= CAST '(' <Expression> AS <Type> ')'
        case (int)IRISSQLRuleConstants.RULE_SPECIALFUNCTION_CONVERT_LPARAN_COMMA_RPARAN :
        //<special function> ::= CONVERT '(' <Type> ',' <Expression> <style> ')'
        case (int)IRISSQLRuleConstants.RULE_STYLE_COMMA_INTEGERLITERAL :
        //<style> ::= ',' IntegerLiteral
        case (int)IRISSQLRuleConstants.RULE_STYLE_COMMA_STRINGLITERAL :
        //<style> ::= ',' StringLiteral
        case (int)IRISSQLRuleConstants.RULE_STYLE :
        //<style> ::= 
        case (int)IRISSQLRuleConstants.RULE_ARGUMENTLISTOPT_LPARAN_RPARAN :
        //<Argument List Opt> ::= '(' <Restriction> <Argument List> ')'
        case (int)IRISSQLRuleConstants.RULE_ARGUMENTLISTOPT :
        //<Argument List Opt> ::= 
        case (int)IRISSQLRuleConstants.RULE_ARGUMENTLIST_COMMA :
        //<Argument List> ::= <Argument List> ',' <function args>
        case (int)IRISSQLRuleConstants.RULE_ARGUMENTLIST :
        //<Argument List> ::= <function args>
        case (int)IRISSQLRuleConstants.RULE_FUNCTIONARGS_TIMES :
        //<function args> ::= '*'
        case (int)IRISSQLRuleConstants.RULE_FUNCTIONARGS :
        //<function args> ::= <Expression> <alias>
        case (int)IRISSQLRuleConstants.RULE_FUNCTIONARGS2 :
        //<function args> ::= 
        default:
          //Todos os casos que não possuem tratamento específico retornam o texto puro
          return GetFullText(token);

      }
    }
  }
}
