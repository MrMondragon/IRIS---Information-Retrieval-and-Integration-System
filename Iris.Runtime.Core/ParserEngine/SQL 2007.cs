
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace Iris.Runtime.Core
{
  public class XEvalParser: BaseParser
  {
        private LALRParser parser;

        public MyParser():base("GrammarName")
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

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                return null;
                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                return null;
                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //(Whitespace)
                return null;
                case (int)SymbolConstants.SYMBOL_COMMENTEND :
                //(Comment End)
                return null;
                case (int)SymbolConstants.SYMBOL_COMMENTLINE :
                //(Comment Line)
                return null;
                case (int)SymbolConstants.SYMBOL_COMMENTSTART :
                //(Comment Start)
                return null;
                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                return null;
                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                return null;
                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                return null;
                case (int)SymbolConstants.SYMBOL_LPARAN :
                //'('
                return null;
                case (int)SymbolConstants.SYMBOL_RPARAN :
                //')'
                return null;
                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                return null;
                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                return null;
                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                return null;
                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                return null;
                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                return null;
                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                return null;
                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                return null;
                case (int)SymbolConstants.SYMBOL_LTGT :
                //'<>'
                return null;
                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                return null;
                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                return null;
                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                return null;
                case (int)SymbolConstants.SYMBOL_ALL :
                //ALL
                return null;
                case (int)SymbolConstants.SYMBOL_AND :
                //AND
                return null;
                case (int)SymbolConstants.SYMBOL_AS :
                //AS
                return null;
                case (int)SymbolConstants.SYMBOL_ASC :
                //ASC
                return null;
                case (int)SymbolConstants.SYMBOL_AVG :
                //Avg
                return null;
                case (int)SymbolConstants.SYMBOL_BETWEEN :
                //BETWEEN
                return null;
                case (int)SymbolConstants.SYMBOL_BIGINT :
                //Bigint
                return null;
                case (int)SymbolConstants.SYMBOL_BINARY :
                //Binary
                return null;
                case (int)SymbolConstants.SYMBOL_BIT :
                //Bit
                return null;
                case (int)SymbolConstants.SYMBOL_BY :
                //BY
                return null;
                case (int)SymbolConstants.SYMBOL_CASE :
                //CASE
                return null;
                case (int)SymbolConstants.SYMBOL_CAST :
                //CAST
                return null;
                case (int)SymbolConstants.SYMBOL_CHAR :
                //Char
                return null;
                case (int)SymbolConstants.SYMBOL_CHECKSUM :
                //CheckSum
                return null;
                case (int)SymbolConstants.SYMBOL_CHECKSUM_AGG :
                //'CheckSum_AGG'
                return null;
                case (int)SymbolConstants.SYMBOL_CONVERT :
                //CONVERT
                return null;
                case (int)SymbolConstants.SYMBOL_COUNT :
                //Count
                return null;
                case (int)SymbolConstants.SYMBOL_COUNT_BIG :
                //'Count_Big'
                return null;
                case (int)SymbolConstants.SYMBOL_CROSS :
                //CROSS
                return null;
                case (int)SymbolConstants.SYMBOL_CURSOR :
                //Cursor
                return null;
                case (int)SymbolConstants.SYMBOL_DATEADD :
                //DATEADD
                return null;
                case (int)SymbolConstants.SYMBOL_DATEDIFF :
                //DATEDIFF
                return null;
                case (int)SymbolConstants.SYMBOL_DATENAME :
                //DATENAME
                return null;
                case (int)SymbolConstants.SYMBOL_DATEPART :
                //DATEPART
                return null;
                case (int)SymbolConstants.SYMBOL_DATETIME :
                //Datetime
                return null;
                case (int)SymbolConstants.SYMBOL_DAY :
                //DAY
                return null;
                case (int)SymbolConstants.SYMBOL_DECIMAL :
                //Decimal
                return null;
                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //DEFAULT
                return null;
                case (int)SymbolConstants.SYMBOL_DELETE :
                //DELETE
                return null;
                case (int)SymbolConstants.SYMBOL_DESC :
                //DESC
                return null;
                case (int)SymbolConstants.SYMBOL_DISTINCT :
                //DISTINCT
                return null;
                case (int)SymbolConstants.SYMBOL_ELSE :
                //ELSE
                return null;
                case (int)SymbolConstants.SYMBOL_END :
                //END
                return null;
                case (int)SymbolConstants.SYMBOL_FLOAT :
                //Float
                return null;
                case (int)SymbolConstants.SYMBOL_FROM :
                //FROM
                return null;
                case (int)SymbolConstants.SYMBOL_FULL :
                //FULL
                return null;
                case (int)SymbolConstants.SYMBOL_GETDATE :
                //GETDATE
                return null;
                case (int)SymbolConstants.SYMBOL_GETUTCDATE :
                //GETUTCDATE
                return null;
                case (int)SymbolConstants.SYMBOL_GROUP :
                //GROUP
                return null;
                case (int)SymbolConstants.SYMBOL_HAVING :
                //HAVING
                return null;
                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                return null;
                case (int)SymbolConstants.SYMBOL_IMAGE :
                //Image
                return null;
                case (int)SymbolConstants.SYMBOL_IN :
                //IN
                return null;
                case (int)SymbolConstants.SYMBOL_INNER :
                //INNER
                return null;
                case (int)SymbolConstants.SYMBOL_INSERT :
                //INSERT
                return null;
                case (int)SymbolConstants.SYMBOL_INT :
                //Int
                return null;
                case (int)SymbolConstants.SYMBOL_INTEGERLITERAL :
                //IntegerLiteral
                return null;
                case (int)SymbolConstants.SYMBOL_INTO :
                //INTO
                return null;
                case (int)SymbolConstants.SYMBOL_IS :
                //IS
                return null;
                case (int)SymbolConstants.SYMBOL_JOIN :
                //JOIN
                return null;
                case (int)SymbolConstants.SYMBOL_LEFT :
                //LEFT
                return null;
                case (int)SymbolConstants.SYMBOL_LIKE :
                //LIKE
                return null;
                case (int)SymbolConstants.SYMBOL_MAX :
                //Max
                return null;
                case (int)SymbolConstants.SYMBOL_MIN :
                //Min
                return null;
                case (int)SymbolConstants.SYMBOL_MONEY :
                //Money
                return null;
                case (int)SymbolConstants.SYMBOL_MONTH :
                //MONTH
                return null;
                case (int)SymbolConstants.SYMBOL_NCHAR :
                //Nchar
                return null;
                case (int)SymbolConstants.SYMBOL_NOT :
                //NOT
                return null;
                case (int)SymbolConstants.SYMBOL_NTEXT :
                //Ntext
                return null;
                case (int)SymbolConstants.SYMBOL_NULL :
                //NULL
                return null;
                case (int)SymbolConstants.SYMBOL_NUMERIC :
                //Numeric
                return null;
                case (int)SymbolConstants.SYMBOL_NVARCHAR :
                //Nvarchar
                return null;
                case (int)SymbolConstants.SYMBOL_ON :
                //ON
                return null;
                case (int)SymbolConstants.SYMBOL_OR :
                //OR
                return null;
                case (int)SymbolConstants.SYMBOL_ORDER :
                //ORDER
                return null;
                case (int)SymbolConstants.SYMBOL_OUTER :
                //OUTER
                return null;
                case (int)SymbolConstants.SYMBOL_PERCENT2 :
                //PERCENT
                return null;
                case (int)SymbolConstants.SYMBOL_REAL :
                //Real
                return null;
                case (int)SymbolConstants.SYMBOL_REALLITERAL :
                //RealLiteral
                return null;
                case (int)SymbolConstants.SYMBOL_RIGHT :
                //RIGHT
                return null;
                case (int)SymbolConstants.SYMBOL_SELECT :
                //SELECT
                return null;
                case (int)SymbolConstants.SYMBOL_SET :
                //SET
                return null;
                case (int)SymbolConstants.SYMBOL_SMALLDATETIME :
                //Smalldatetime
                return null;
                case (int)SymbolConstants.SYMBOL_SMALLINT :
                //Smallint
                return null;
                case (int)SymbolConstants.SYMBOL_SMALLMONEY :
                //Smallmoney
                return null;
                case (int)SymbolConstants.SYMBOL_SQL_VARIANT :
                //'Sql_Variant'
                return null;
                case (int)SymbolConstants.SYMBOL_STDEV :
                //StDev
                return null;
                case (int)SymbolConstants.SYMBOL_STDEVP :
                //StDevP
                return null;
                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                return null;
                case (int)SymbolConstants.SYMBOL_SUM :
                //Sum
                return null;
                case (int)SymbolConstants.SYMBOL_TEXT :
                //Text
                return null;
                case (int)SymbolConstants.SYMBOL_THEN :
                //THEN
                return null;
                case (int)SymbolConstants.SYMBOL_TIMESTAMP :
                //Timestamp
                return null;
                case (int)SymbolConstants.SYMBOL_TINYINT :
                //Tinyint
                return null;
                case (int)SymbolConstants.SYMBOL_TOP :
                //TOP
                return null;
                case (int)SymbolConstants.SYMBOL_UNION :
                //UNION
                return null;
                case (int)SymbolConstants.SYMBOL_UNIQUEIDENTIFIER :
                //Uniqueidentifier
                return null;
                case (int)SymbolConstants.SYMBOL_UPDATE :
                //UPDATE
                return null;
                case (int)SymbolConstants.SYMBOL_VALUES :
                //VALUES
                return null;
                case (int)SymbolConstants.SYMBOL_VAR :
                //Var
                return null;
                case (int)SymbolConstants.SYMBOL_VARBINARY :
                //Varbinary
                return null;
                case (int)SymbolConstants.SYMBOL_VARCHAR :
                //Varchar
                return null;
                case (int)SymbolConstants.SYMBOL_VARP :
                //VarP
                return null;
                case (int)SymbolConstants.SYMBOL_WHEN :
                //WHEN
                return null;
                case (int)SymbolConstants.SYMBOL_WHERE :
                //WHERE
                return null;
                case (int)SymbolConstants.SYMBOL_XEVALEXPRESION :
                //XEvalExpresion
                return null;
                case (int)SymbolConstants.SYMBOL_YEAR :
                //YEAR
                return null;
                case (int)SymbolConstants.SYMBOL_AGGREGATEFN :
                //<Aggregate Fn>
                return null;
                case (int)SymbolConstants.SYMBOL_ARITHOPERATOR :
                //<Arith Operator>
                return null;
                case (int)SymbolConstants.SYMBOL_ASSIGNLIST :
                //<Assign List>
                return null;
                case (int)SymbolConstants.SYMBOL_BASETYPE :
                //<Base Type>
                return null;
                case (int)SymbolConstants.SYMBOL_CASEELSE :
                //<Case Else>
                return null;
                case (int)SymbolConstants.SYMBOL_COLUMNITEM :
                //<Column Item>
                return null;
                case (int)SymbolConstants.SYMBOL_COLUMNLIST :
                //<Column List>
                return null;
                case (int)SymbolConstants.SYMBOL_COLUMNSOURCE :
                //<Column Source>
                return null;
                case (int)SymbolConstants.SYMBOL_COLUMNRESTRICTION :
                //<ColumnRestriction>
                return null;
                case (int)SymbolConstants.SYMBOL_COLUMNS :
                //<Columns>
                return null;
                case (int)SymbolConstants.SYMBOL_COMPOPERATOR :
                //<Comp Operator>
                return null;
                case (int)SymbolConstants.SYMBOL_CONVERTFN :
                //<Convert Fn>
                return null;
                case (int)SymbolConstants.SYMBOL_DATATYPE :
                //<Data Type>
                return null;
                case (int)SymbolConstants.SYMBOL_DATETIMEFN :
                //<Date Time Fn>
                return null;
                case (int)SymbolConstants.SYMBOL_DELETESTM :
                //<Delete Stm>
                return null;
                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                return null;
                case (int)SymbolConstants.SYMBOL_FROMCLAUSE :
                //<From Clause>
                return null;
                case (int)SymbolConstants.SYMBOL_FROMLIST :
                //<From List>
                return null;
                case (int)SymbolConstants.SYMBOL_FROMMEMBER :
                //<From Member>
                return null;
                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //<Function>
                return null;
                case (int)SymbolConstants.SYMBOL_GROUPCLAUSE :
                //<Group Clause>
                return null;
                case (int)SymbolConstants.SYMBOL_GROUPITEM :
                //<Group Item>
                return null;
                case (int)SymbolConstants.SYMBOL_GROUPLIST :
                //<Group List>
                return null;
                case (int)SymbolConstants.SYMBOL_HAVINGCLAUSE :
                //<Having Clause>
                return null;
                case (int)SymbolConstants.SYMBOL_INSERTCOLUMNS :
                //<Insert Columns>
                return null;
                case (int)SymbolConstants.SYMBOL_INSERTLIST :
                //<Insert List>
                return null;
                case (int)SymbolConstants.SYMBOL_INSERTSTM :
                //<Insert Stm>
                return null;
                case (int)SymbolConstants.SYMBOL_INSERTUPDATEITEM :
                //<Insert Update Item>
                return null;
                case (int)SymbolConstants.SYMBOL_INTO2 :
                //<Into>
                return null;
                case (int)SymbolConstants.SYMBOL_JOIN2 :
                //<Join>
                return null;
                case (int)SymbolConstants.SYMBOL_JOINCHAIN :
                //<Join Chain>
                return null;
                case (int)SymbolConstants.SYMBOL_JOINLIST :
                //<Join List>
                return null;
                case (int)SymbolConstants.SYMBOL_JOINMEMBER :
                //<Join Member>
                return null;
                case (int)SymbolConstants.SYMBOL_JOINTYPE :
                //<Join Type>
                return null;
                case (int)SymbolConstants.SYMBOL_LOGICOPERATOR :
                //<Logic Operator>
                return null;
                case (int)SymbolConstants.SYMBOL_OPERATION :
                //<Operation>
                return null;
                case (int)SymbolConstants.SYMBOL_ORDERCLAUSE :
                //<Order Clause>
                return null;
                case (int)SymbolConstants.SYMBOL_ORDERLIST :
                //<Order List>
                return null;
                case (int)SymbolConstants.SYMBOL_ORDERTYPE :
                //<Order Type>
                return null;
                case (int)SymbolConstants.SYMBOL_PARAMETER :
                //<Parameter>
                return null;
                case (int)SymbolConstants.SYMBOL_QUERY :
                //<Query>
                return null;
                case (int)SymbolConstants.SYMBOL_RESTRICTION :
                //<Restriction>
                return null;
                case (int)SymbolConstants.SYMBOL_SELECTSTM :
                //<Select Stm>
                return null;
                case (int)SymbolConstants.SYMBOL_TUPLE :
                //<Tuple>
                return null;
                case (int)SymbolConstants.SYMBOL_TXTEXPRESSION :
                //<Txt Expression>
                return null;
                case (int)SymbolConstants.SYMBOL_UNION2 :
                //<Union>
                return null;
                case (int)SymbolConstants.SYMBOL_UPDATEFROM :
                //<Update From>
                return null;
                case (int)SymbolConstants.SYMBOL_UPDATESTM :
                //<Update Stm>
                return null;
                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                return null;
                case (int)SymbolConstants.SYMBOL_WHENCASE :
                //<When Case>
                return null;
                case (int)SymbolConstants.SYMBOL_WHENCHAIN :
                //<When Chain>
                return null;
                case (int)SymbolConstants.SYMBOL_WHERECLAUSE :
                //<Where Clause>
                return null;
            }
            throw new SymbolException("Unknown symbol");
        }

        ////////////////////////////////////////////////////////////////
        //Rule Section
        ////////////////////////////////////////////////////////////////
        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_QUERY :
                //<Query> ::= <Select Stm>
                return null;
                case (int)RuleConstants.RULE_QUERY2 :
                //<Query> ::= <Expression>
                return null;
                case (int)RuleConstants.RULE_QUERY3 :
                //<Query> ::= <Insert Stm>
                return null;
                case (int)RuleConstants.RULE_QUERY4 :
                //<Query> ::= <Update Stm>
                return null;
                case (int)RuleConstants.RULE_QUERY5 :
                //<Query> ::= <Delete Stm>
                return null;
                case (int)RuleConstants.RULE_QUERY6 :
                //<Query> ::= 
                return null;
                case (int)RuleConstants.RULE_INSERTSTM_INSERT_ID :
                //<Insert Stm> ::= INSERT <Into> Id <Insert Columns> <Select Stm>
                return null;
                case (int)RuleConstants.RULE_INSERTSTM_INSERT_ID_VALUES_LPARAN_RPARAN :
                //<Insert Stm> ::= INSERT <Into> Id <Insert Columns> VALUES '(' <Insert List> ')'
                return null;
                case (int)RuleConstants.RULE_INSERTCOLUMNS_LPARAN_RPARAN :
                //<Insert Columns> ::= '(' <Column List> ')'
                return null;
                case (int)RuleConstants.RULE_INSERTCOLUMNS :
                //<Insert Columns> ::= 
                return null;
                case (int)RuleConstants.RULE_INTO_INTO :
                //<Into> ::= INTO
                return null;
                case (int)RuleConstants.RULE_INTO :
                //<Into> ::= 
                return null;
                case (int)RuleConstants.RULE_INSERTUPDATEITEM :
                //<Insert Update Item> ::= <Txt Expression>
                return null;
                case (int)RuleConstants.RULE_INSERTUPDATEITEM_DEFAULT :
                //<Insert Update Item> ::= DEFAULT
                return null;
                case (int)RuleConstants.RULE_INSERTLIST_COMMA :
                //<Insert List> ::= <Insert List> ',' <Insert Update Item>
                return null;
                case (int)RuleConstants.RULE_INSERTLIST :
                //<Insert List> ::= <Insert Update Item>
                return null;
                case (int)RuleConstants.RULE_UPDATESTM_UPDATE_ID_SET :
                //<Update Stm> ::= UPDATE Id SET <Assign List> <Update From> <Where Clause>
                return null;
                case (int)RuleConstants.RULE_UPDATEFROM :
                //<Update From> ::= <From Clause>
                return null;
                case (int)RuleConstants.RULE_UPDATEFROM2 :
                //<Update From> ::= 
                return null;
                case (int)RuleConstants.RULE_ASSIGNLIST_ID_EQ_COMMA :
                //<Assign List> ::= Id '=' <Insert Update Item> ',' <Assign List>
                return null;
                case (int)RuleConstants.RULE_ASSIGNLIST_ID_EQ :
                //<Assign List> ::= Id '=' <Insert Update Item>
                return null;
                case (int)RuleConstants.RULE_DELETESTM_DELETE_FROM_ID :
                //<Delete Stm> ::= DELETE FROM Id <Where Clause>
                return null;
                case (int)RuleConstants.RULE_SELECTSTM_SELECT :
                //<Select Stm> ::= SELECT <Columns> <From Clause> <Where Clause> <Group Clause> <Having Clause> <Order Clause> <Union>
                return null;
                case (int)RuleConstants.RULE_COLUMNS_TIMES :
                //<Columns> ::= <ColumnRestriction> '*'
                return null;
                case (int)RuleConstants.RULE_COLUMNS :
                //<Columns> ::= <ColumnRestriction> <Column List>
                return null;
                case (int)RuleConstants.RULE_COLUMNRESTRICTION :
                //<ColumnRestriction> ::= <Restriction>
                return null;
                case (int)RuleConstants.RULE_COLUMNRESTRICTION_TOP_INTEGERLITERAL :
                //<ColumnRestriction> ::= TOP IntegerLiteral
                return null;
                case (int)RuleConstants.RULE_COLUMNRESTRICTION_TOP_INTEGERLITERAL_PERCENT :
                //<ColumnRestriction> ::= TOP IntegerLiteral PERCENT
                return null;
                case (int)RuleConstants.RULE_COLUMNLIST_COMMA :
                //<Column List> ::= <Column Item> ',' <Column List>
                return null;
                case (int)RuleConstants.RULE_COLUMNLIST :
                //<Column List> ::= <Column Item>
                return null;
                case (int)RuleConstants.RULE_COLUMNITEM :
                //<Column Item> ::= <Column Source>
                return null;
                case (int)RuleConstants.RULE_COLUMNITEM_ID :
                //<Column Item> ::= <Column Source> Id
                return null;
                case (int)RuleConstants.RULE_COLUMNITEM_AS_ID :
                //<Column Item> ::= <Column Source> AS Id
                return null;
                case (int)RuleConstants.RULE_COLUMNSOURCE :
                //<Column Source> ::= <Value>
                return null;
                case (int)RuleConstants.RULE_COLUMNSOURCE_ID_EQ_CASE_END :
                //<Column Source> ::= Id '=' CASE <Txt Expression> <When Chain> <Case Else> END
                return null;
                case (int)RuleConstants.RULE_COLUMNSOURCE_ID_EQ_CASE_END2 :
                //<Column Source> ::= Id '=' CASE <When Chain> <Case Else> END
                return null;
                case (int)RuleConstants.RULE_CASEELSE_ELSE :
                //<Case Else> ::= ELSE <Value>
                return null;
                case (int)RuleConstants.RULE_CASEELSE :
                //<Case Else> ::= 
                return null;
                case (int)RuleConstants.RULE_WHENCHAIN :
                //<When Chain> ::= <When Case>
                return null;
                case (int)RuleConstants.RULE_WHENCHAIN2 :
                //<When Chain> ::= <When Case> <When Chain>
                return null;
                case (int)RuleConstants.RULE_WHENCASE_WHEN_THEN :
                //<When Case> ::= WHEN <Txt Expression> THEN <Value>
                return null;
                case (int)RuleConstants.RULE_RESTRICTION_DISTINCT :
                //<Restriction> ::= DISTINCT
                return null;
                case (int)RuleConstants.RULE_RESTRICTION :
                //<Restriction> ::= 
                return null;
                case (int)RuleConstants.RULE_FUNCTION :
                //<Function> ::= <Aggregate Fn>
                return null;
                case (int)RuleConstants.RULE_FUNCTION2 :
                //<Function> ::= <Date Time Fn>
                return null;
                case (int)RuleConstants.RULE_FUNCTION3 :
                //<Function> ::= <Convert Fn>
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_COUNT_LPARAN_TIMES_RPARAN :
                //<Aggregate Fn> ::= Count '(' '*' ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_COUNT_BIG_LPARAN_RPARAN :
                //<Aggregate Fn> ::= 'Count_Big' '(' <Restriction> <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_COUNT_LPARAN_RPARAN :
                //<Aggregate Fn> ::= Count '(' <Restriction> <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_AVG_LPARAN_RPARAN :
                //<Aggregate Fn> ::= Avg '(' <Restriction> <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_MIN_LPARAN_RPARAN :
                //<Aggregate Fn> ::= Min '(' <Restriction> <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_MAX_LPARAN_RPARAN :
                //<Aggregate Fn> ::= Max '(' <Restriction> <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_STDEV_LPARAN_RPARAN :
                //<Aggregate Fn> ::= StDev '(' <Restriction> <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_STDEVP_LPARAN_RPARAN :
                //<Aggregate Fn> ::= StDevP '(' <Restriction> <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_SUM_LPARAN_RPARAN :
                //<Aggregate Fn> ::= Sum '(' <Restriction> <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_VAR_LPARAN_RPARAN :
                //<Aggregate Fn> ::= Var '(' <Restriction> <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_VARP_LPARAN_RPARAN :
                //<Aggregate Fn> ::= VarP '(' <Restriction> <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_CHECKSUM_LPARAN_TIMES_RPARAN :
                //<Aggregate Fn> ::= CheckSum '(' '*' ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_CHECKSUM_LPARAN_RPARAN :
                //<Aggregate Fn> ::= CheckSum '(' <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_AGGREGATEFN_CHECKSUM_AGG_LPARAN_RPARAN :
                //<Aggregate Fn> ::= 'CheckSum_AGG' '(' <Restriction> <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_DATETIMEFN_DATEADD_LPARAN_ID_COMMA_INTEGERLITERAL_COMMA_RPARAN :
                //<Date Time Fn> ::= DATEADD '(' Id ',' IntegerLiteral ',' <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_DATETIMEFN_DATEDIFF_LPARAN_ID_COMMA_COMMA_RPARAN :
                //<Date Time Fn> ::= DATEDIFF '(' Id ',' <Txt Expression> ',' <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_DATETIMEFN_DATENAME_LPARAN_ID_COMMA_RPARAN :
                //<Date Time Fn> ::= DATENAME '(' Id ',' <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_DATETIMEFN_DATEPART_LPARAN_ID_COMMA_RPARAN :
                //<Date Time Fn> ::= DATEPART '(' Id ',' <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_DATETIMEFN_DAY_LPARAN_RPARAN :
                //<Date Time Fn> ::= DAY '(' <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_DATETIMEFN_GETDATE_LPARAN_RPARAN :
                //<Date Time Fn> ::= GETDATE '(' ')'
                return null;
                case (int)RuleConstants.RULE_DATETIMEFN_GETUTCDATE_LPARAN_RPARAN :
                //<Date Time Fn> ::= GETUTCDATE '(' ')'
                return null;
                case (int)RuleConstants.RULE_DATETIMEFN_MONTH_LPARAN_RPARAN :
                //<Date Time Fn> ::= MONTH '(' <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_DATETIMEFN_YEAR_LPARAN_RPARAN :
                //<Date Time Fn> ::= YEAR '(' <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_CONVERTFN_CAST_LPARAN_AS_RPARAN :
                //<Convert Fn> ::= CAST '(' <Txt Expression> AS <Data Type> ')'
                return null;
                case (int)RuleConstants.RULE_CONVERTFN_CONVERT_LPARAN_COMMA_RPARAN :
                //<Convert Fn> ::= CONVERT '(' <Data Type> ',' <Txt Expression> ')'
                return null;
                case (int)RuleConstants.RULE_CONVERTFN_CONVERT_LPARAN_COMMA_COMMA_INTEGERLITERAL_RPARAN :
                //<Convert Fn> ::= CONVERT '(' <Data Type> ',' <Txt Expression> ',' IntegerLiteral ')'
                return null;
                case (int)RuleConstants.RULE_DATATYPE :
                //<Data Type> ::= <Base Type>
                return null;
                case (int)RuleConstants.RULE_DATATYPE_LPARAN_INTEGERLITERAL_RPARAN :
                //<Data Type> ::= <Base Type> '(' IntegerLiteral ')'
                return null;
                case (int)RuleConstants.RULE_DATATYPE_LPARAN_INTEGERLITERAL_COMMA_INTEGERLITERAL_RPARAN :
                //<Data Type> ::= <Base Type> '(' IntegerLiteral ',' IntegerLiteral ')'
                return null;
                case (int)RuleConstants.RULE_BASETYPE_BIGINT :
                //<Base Type> ::= Bigint
                return null;
                case (int)RuleConstants.RULE_BASETYPE_DECIMAL :
                //<Base Type> ::= Decimal
                return null;
                case (int)RuleConstants.RULE_BASETYPE_INT :
                //<Base Type> ::= Int
                return null;
                case (int)RuleConstants.RULE_BASETYPE_NUMERIC :
                //<Base Type> ::= Numeric
                return null;
                case (int)RuleConstants.RULE_BASETYPE_SMALLINT :
                //<Base Type> ::= Smallint
                return null;
                case (int)RuleConstants.RULE_BASETYPE_MONEY :
                //<Base Type> ::= Money
                return null;
                case (int)RuleConstants.RULE_BASETYPE_TINYINT :
                //<Base Type> ::= Tinyint
                return null;
                case (int)RuleConstants.RULE_BASETYPE_SMALLMONEY :
                //<Base Type> ::= Smallmoney
                return null;
                case (int)RuleConstants.RULE_BASETYPE_BIT :
                //<Base Type> ::= Bit
                return null;
                case (int)RuleConstants.RULE_BASETYPE_FLOAT :
                //<Base Type> ::= Float
                return null;
                case (int)RuleConstants.RULE_BASETYPE_REAL :
                //<Base Type> ::= Real
                return null;
                case (int)RuleConstants.RULE_BASETYPE_DATETIME :
                //<Base Type> ::= Datetime
                return null;
                case (int)RuleConstants.RULE_BASETYPE_SMALLDATETIME :
                //<Base Type> ::= Smalldatetime
                return null;
                case (int)RuleConstants.RULE_BASETYPE_CHAR :
                //<Base Type> ::= Char
                return null;
                case (int)RuleConstants.RULE_BASETYPE_TEXT :
                //<Base Type> ::= Text
                return null;
                case (int)RuleConstants.RULE_BASETYPE_VARCHAR :
                //<Base Type> ::= Varchar
                return null;
                case (int)RuleConstants.RULE_BASETYPE_NCHAR :
                //<Base Type> ::= Nchar
                return null;
                case (int)RuleConstants.RULE_BASETYPE_NTEXT :
                //<Base Type> ::= Ntext
                return null;
                case (int)RuleConstants.RULE_BASETYPE_NVARCHAR :
                //<Base Type> ::= Nvarchar
                return null;
                case (int)RuleConstants.RULE_BASETYPE_BINARY :
                //<Base Type> ::= Binary
                return null;
                case (int)RuleConstants.RULE_BASETYPE_IMAGE :
                //<Base Type> ::= Image
                return null;
                case (int)RuleConstants.RULE_BASETYPE_VARBINARY :
                //<Base Type> ::= Varbinary
                return null;
                case (int)RuleConstants.RULE_BASETYPE_CURSOR :
                //<Base Type> ::= Cursor
                return null;
                case (int)RuleConstants.RULE_BASETYPE_TIMESTAMP :
                //<Base Type> ::= Timestamp
                return null;
                case (int)RuleConstants.RULE_BASETYPE_SQL_VARIANT :
                //<Base Type> ::= 'Sql_Variant'
                return null;
                case (int)RuleConstants.RULE_BASETYPE_UNIQUEIDENTIFIER :
                //<Base Type> ::= Uniqueidentifier
                return null;
                case (int)RuleConstants.RULE_FROMCLAUSE_FROM :
                //<From Clause> ::= FROM <From List> <Join Chain>
                return null;
                case (int)RuleConstants.RULE_FROMLIST_COMMA :
                //<From List> ::= <From Member> ',' <From List>
                return null;
                case (int)RuleConstants.RULE_FROMLIST_CROSS_JOIN :
                //<From List> ::= <From Member> CROSS JOIN <From List>
                return null;
                case (int)RuleConstants.RULE_FROMLIST :
                //<From List> ::= <From Member>
                return null;
                case (int)RuleConstants.RULE_FROMMEMBER_ID :
                //<From Member> ::= Id
                return null;
                case (int)RuleConstants.RULE_FROMMEMBER_ID_ID :
                //<From Member> ::= Id Id
                return null;
                case (int)RuleConstants.RULE_FROMMEMBER_ID_AS_ID :
                //<From Member> ::= Id AS Id
                return null;
                case (int)RuleConstants.RULE_FROMMEMBER_LPARAN_RPARAN_ID :
                //<From Member> ::= '(' <Select Stm> ')' Id
                return null;
                case (int)RuleConstants.RULE_FROMMEMBER_LPARAN_RPARAN_AS_ID :
                //<From Member> ::= '(' <Select Stm> ')' AS Id
                return null;
                case (int)RuleConstants.RULE_JOINCHAIN :
                //<Join Chain> ::= <Join> <Join Chain>
                return null;
                case (int)RuleConstants.RULE_JOINCHAIN2 :
                //<Join Chain> ::= 
                return null;
                case (int)RuleConstants.RULE_JOIN_ON :
                //<Join> ::= <Join Type> <Join List> <Join Chain> ON <Expression>
                return null;
                case (int)RuleConstants.RULE_JOINTYPE_INNER_JOIN :
                //<Join Type> ::= INNER JOIN
                return null;
                case (int)RuleConstants.RULE_JOINTYPE_LEFT_JOIN :
                //<Join Type> ::= LEFT JOIN
                return null;
                case (int)RuleConstants.RULE_JOINTYPE_LEFT_OUTER_JOIN :
                //<Join Type> ::= LEFT OUTER JOIN
                return null;
                case (int)RuleConstants.RULE_JOINTYPE_RIGHT_JOIN :
                //<Join Type> ::= RIGHT JOIN
                return null;
                case (int)RuleConstants.RULE_JOINTYPE_RIGHT_OUTER_JOIN :
                //<Join Type> ::= RIGHT OUTER JOIN
                return null;
                case (int)RuleConstants.RULE_JOINTYPE_FULL_JOIN :
                //<Join Type> ::= FULL JOIN
                return null;
                case (int)RuleConstants.RULE_JOINTYPE_FULL_OUTER_JOIN :
                //<Join Type> ::= FULL OUTER JOIN
                return null;
                case (int)RuleConstants.RULE_JOINTYPE_JOIN :
                //<Join Type> ::= JOIN
                return null;
                case (int)RuleConstants.RULE_JOINLIST :
                //<Join List> ::= <Join Member>
                return null;
                case (int)RuleConstants.RULE_JOINLIST_COMMA :
                //<Join List> ::= <Join Member> ',' <Join List>
                return null;
                case (int)RuleConstants.RULE_JOINMEMBER :
                //<Join Member> ::= <From Member>
                return null;
                case (int)RuleConstants.RULE_JOINMEMBER2 :
                //<Join Member> ::= <Join Chain>
                return null;
                case (int)RuleConstants.RULE_WHERECLAUSE_WHERE :
                //<Where Clause> ::= WHERE <Expression>
                return null;
                case (int)RuleConstants.RULE_WHERECLAUSE :
                //<Where Clause> ::= 
                return null;
                case (int)RuleConstants.RULE_GROUPCLAUSE_GROUP_BY :
                //<Group Clause> ::= GROUP BY <Group List>
                return null;
                case (int)RuleConstants.RULE_GROUPCLAUSE :
                //<Group Clause> ::= 
                return null;
                case (int)RuleConstants.RULE_GROUPLIST_COMMA :
                //<Group List> ::= <Group Item> ',' <Group List>
                return null;
                case (int)RuleConstants.RULE_GROUPLIST :
                //<Group List> ::= <Group Item>
                return null;
                case (int)RuleConstants.RULE_GROUPITEM_ID :
                //<Group Item> ::= Id
                return null;
                case (int)RuleConstants.RULE_GROUPITEM_INTEGERLITERAL :
                //<Group Item> ::= IntegerLiteral
                return null;
                case (int)RuleConstants.RULE_GROUPITEM :
                //<Group Item> ::= <Function>
                return null;
                case (int)RuleConstants.RULE_ORDERCLAUSE_ORDER_BY :
                //<Order Clause> ::= ORDER BY <Order List>
                return null;
                case (int)RuleConstants.RULE_ORDERCLAUSE :
                //<Order Clause> ::= 
                return null;
                case (int)RuleConstants.RULE_ORDERLIST_ID_COMMA :
                //<Order List> ::= Id <Order Type> ',' <Order List>
                return null;
                case (int)RuleConstants.RULE_ORDERLIST_ID :
                //<Order List> ::= Id <Order Type>
                return null;
                case (int)RuleConstants.RULE_ORDERTYPE_ASC :
                //<Order Type> ::= ASC
                return null;
                case (int)RuleConstants.RULE_ORDERTYPE_DESC :
                //<Order Type> ::= DESC
                return null;
                case (int)RuleConstants.RULE_ORDERTYPE :
                //<Order Type> ::= 
                return null;
                case (int)RuleConstants.RULE_HAVINGCLAUSE_HAVING :
                //<Having Clause> ::= HAVING <Expression>
                return null;
                case (int)RuleConstants.RULE_HAVINGCLAUSE :
                //<Having Clause> ::= 
                return null;
                case (int)RuleConstants.RULE_UNION_UNION :
                //<Union> ::= UNION <Select Stm>
                return null;
                case (int)RuleConstants.RULE_UNION_UNION_ALL :
                //<Union> ::= UNION ALL <Select Stm>
                return null;
                case (int)RuleConstants.RULE_UNION :
                //<Union> ::= 
                return null;
                case (int)RuleConstants.RULE_TXTEXPRESSION :
                //<Txt Expression> ::= <Expression>
                return null;
                case (int)RuleConstants.RULE_TXTEXPRESSION_COMMA :
                //<Txt Expression> ::= <Expression> ',' <Txt Expression>
                return null;
                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Expression> <Logic Operator> <Expression>
                return null;
                case (int)RuleConstants.RULE_EXPRESSION_NOT_LPARAN_RPARAN :
                //<Expression> ::= NOT '(' <Expression> ')'
                return null;
                case (int)RuleConstants.RULE_EXPRESSION2 :
                //<Expression> ::= <Operation>
                return null;
                case (int)RuleConstants.RULE_EXPRESSION_LPARAN_RPARAN :
                //<Expression> ::= '(' <Expression> ')'
                return null;
                case (int)RuleConstants.RULE_OPERATION_BETWEEN_AND :
                //<Operation> ::= <Value> BETWEEN <Value> AND <Value>
                return null;
                case (int)RuleConstants.RULE_OPERATION_NOT_BETWEEN_AND :
                //<Operation> ::= <Value> NOT BETWEEN <Value> AND <Value>
                return null;
                case (int)RuleConstants.RULE_OPERATION_IS_NOT_NULL :
                //<Operation> ::= <Value> IS NOT NULL
                return null;
                case (int)RuleConstants.RULE_OPERATION_IS_NULL :
                //<Operation> ::= <Value> IS NULL
                return null;
                case (int)RuleConstants.RULE_OPERATION_LIKE :
                //<Operation> ::= <Value> LIKE <Value>
                return null;
                case (int)RuleConstants.RULE_OPERATION_IN :
                //<Operation> ::= <Value> IN <Tuple>
                return null;
                case (int)RuleConstants.RULE_OPERATION :
                //<Operation> ::= <Value> <Comp Operator> <Value>
                return null;
                case (int)RuleConstants.RULE_OPERATION2 :
                //<Operation> ::= <Value>
                return null;
                case (int)RuleConstants.RULE_COMPOPERATOR_EQ :
                //<Comp Operator> ::= '='
                return null;
                case (int)RuleConstants.RULE_COMPOPERATOR_LTGT :
                //<Comp Operator> ::= '<>'
                return null;
                case (int)RuleConstants.RULE_COMPOPERATOR_EXCLAMEQ :
                //<Comp Operator> ::= '!='
                return null;
                case (int)RuleConstants.RULE_COMPOPERATOR_GT :
                //<Comp Operator> ::= '>'
                return null;
                case (int)RuleConstants.RULE_COMPOPERATOR_GTEQ :
                //<Comp Operator> ::= '>='
                return null;
                case (int)RuleConstants.RULE_COMPOPERATOR_LT :
                //<Comp Operator> ::= '<'
                return null;
                case (int)RuleConstants.RULE_COMPOPERATOR_LTEQ :
                //<Comp Operator> ::= '<='
                return null;
                case (int)RuleConstants.RULE_LOGICOPERATOR_AND :
                //<Logic Operator> ::= AND
                return null;
                case (int)RuleConstants.RULE_LOGICOPERATOR_OR :
                //<Logic Operator> ::= OR
                return null;
                case (int)RuleConstants.RULE_VALUE :
                //<Value> ::= <Tuple>
                return null;
                case (int)RuleConstants.RULE_VALUE2 :
                //<Value> ::= <Function>
                return null;
                case (int)RuleConstants.RULE_VALUE3 :
                //<Value> ::= <Parameter>
                return null;
                case (int)RuleConstants.RULE_VALUE_ID :
                //<Value> ::= Id
                return null;
                case (int)RuleConstants.RULE_VALUE_INTEGERLITERAL :
                //<Value> ::= IntegerLiteral
                return null;
                case (int)RuleConstants.RULE_VALUE_REALLITERAL :
                //<Value> ::= RealLiteral
                return null;
                case (int)RuleConstants.RULE_VALUE_STRINGLITERAL :
                //<Value> ::= StringLiteral
                return null;
                case (int)RuleConstants.RULE_VALUE4 :
                //<Value> ::= <Value> <Arith Operator> <Value>
                return null;
                case (int)RuleConstants.RULE_VALUE_LPARAN_RPARAN :
                //<Value> ::= '(' <Value> <Arith Operator> <Value> ')'
                return null;
                case (int)RuleConstants.RULE_VALUE_MINUS :
                //<Value> ::= '-' <Value>
                return null;
                case (int)RuleConstants.RULE_VALUE_XEVALEXPRESION :
                //<Value> ::= XEvalExpresion
                return null;
                case (int)RuleConstants.RULE_VALUE_NULL :
                //<Value> ::= NULL
                return null;
                case (int)RuleConstants.RULE_ARITHOPERATOR_PLUS :
                //<Arith Operator> ::= '+'
                return null;
                case (int)RuleConstants.RULE_ARITHOPERATOR_MINUS :
                //<Arith Operator> ::= '-'
                return null;
                case (int)RuleConstants.RULE_ARITHOPERATOR_TIMES :
                //<Arith Operator> ::= '*'
                return null;
                case (int)RuleConstants.RULE_ARITHOPERATOR_DIV :
                //<Arith Operator> ::= '/'
                return null;
                case (int)RuleConstants.RULE_ARITHOPERATOR_PERCENT :
                //<Arith Operator> ::= '%'
                return null;
                case (int)RuleConstants.RULE_PARAMETER_COLON_ID :
                //<Parameter> ::= ':' Id
                return null;
                case (int)RuleConstants.RULE_TUPLE_LPARAN_RPARAN :
                //<Tuple> ::= '(' <Select Stm> ')'
                return null;
                case (int)RuleConstants.RULE_TUPLE_LPARAN_RPARAN2 :
                //<Tuple> ::= '(' <Txt Expression> ')'
                return null;
            }
            throw new RuleException("Unknown rule");
        }
    }
}
