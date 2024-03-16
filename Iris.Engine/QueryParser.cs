using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using goldparser;
using System.Data;

namespace Iris.Engine
{
  public class QueryParser : BaseParser<Object>
  {

    public QueryParser()
      : base("IRISSQL")
    {
    }

    public override Object Parse(string source)
    {
      if (string.IsNullOrEmpty(source))
        return null;

      NonterminalToken token = parser.Parse(source);
      if (token != null)
      {
        Object obj = CreateObject(token);
        return obj;
      }
      return null;
    }


    private Object CreateObject(Token token)
    {
      if (token is TerminalToken)
        return CreateObjectFromTerminal((TerminalToken)token);
      else
        return CreateObjectFromNonterminal((NonterminalToken)token);
    }

    private string GetText(NonterminalToken token, int idx)
    {
      string text = Convert.ToString(CreateObject(token.Tokens[idx]));
      return text;
    }

    private int GetInt(NonterminalToken token, int idx)
    {
      int val = Convert.ToInt32(CreateObject(token.Tokens[idx]));
      return val;
    }
    private float GetNumber(NonterminalToken token, int idx)
    {
      float val = Convert.ToSingle(CreateObject(token.Tokens[idx]));
      return val;
    }
    private string GetString(NonterminalToken token, int idx)
    {
      string text = Convert.ToString(CreateObject(token.Tokens[idx]));
      return text.Trim('\'', '"');
    }


    ////////////////////////////////////////////////////////////////
    //Rule Section
    ////////////////////////////////////////////////////////////////

    public Object CreateObjectFromNonterminal(NonterminalToken token)
    {
      switch (token.Rule.Id)
      {
        case (int)QueryRuleConstants.RULE_TYPE_IDENTIFIER:
          //<Type> ::= Identifier
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TYPE_IDENTIFIER_LPARAN_INTEGERLITERAL_RPARAN:
          //<Type> ::= Identifier '(' IntegerLiteral ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TYPE_IDENTIFIER_LPARAN_INTEGERLITERAL_COMMA_INTEGERLITERAL_RPARAN:
          //<Type> ::= Identifier '(' IntegerLiteral ',' IntegerLiteral ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SQLSTMS:
          //<SQL Stms> ::= <SQL Stm> <Go> <SQL Stms>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SQLSTMS2:
          //<SQL Stms> ::= <SQL Stm> <Go>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SQLSTM:
          //<SQL Stm> ::= <Union Stm>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SQLSTM2:
          //<SQL Stm> ::= <Insert Stm>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SQLSTM3:
          //<SQL Stm> ::= <Update Stm>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SQLSTM4:
          //<SQL Stm> ::= <Delete Stm>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SQLSTM5:
          //<SQL Stm> ::= <Truncate Stm>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SQLSTM6:
          //<SQL Stm> ::= <Set Stm>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SQLSTM7:
          //<SQL Stm> ::= <Declare Stm>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SQLSTM8:
          //<SQL Stm> ::= <Eval Stm>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_GO_GO:
          //<Go> ::= GO
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_GO_SEMI:
          //<Go> ::= ';'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_GO:
          //<Go> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_EVALSTM_EVAL:
          //<Eval Stm> ::= EVAL <base expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_DECLARESTM_DECLARE:
          //<Declare Stm> ::= DECLARE <Declare Variables>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_DECLAREVARIABLES_COMMA:
          //<Declare Variables> ::= <Declare Variables> ',' <Declare Variable>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_DECLAREVARIABLES:
          //<Declare Variables> ::= <Declare Variable>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_DECLAREVARIABLE_IDENTIFIER:
          //<Declare Variable> ::= Identifier <Type> <Default Value>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_DEFAULTVALUE_EQ:
          //<Default Value> ::= '=' <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_DEFAULTVALUE:
          //<Default Value> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SETSTM_SET_IDENTIFIER_EQ:
          //<Set Stm> ::= SET Identifier '=' <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INSERTSTM_INSERT_IDENTIFIER:
          //<Insert Stm> ::= INSERT <Into> Identifier <Insert Columns> <Union Stm>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INSERTSTM_INSERT_IDENTIFIER_VALUES:
          //<Insert Stm> ::= INSERT <Into> Identifier <Insert Columns> VALUES <Insert Arrays>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INSERTSTM_INSERT_IDENTIFIER_DEFAULT_VALUES:
          //<Insert Stm> ::= INSERT <Into> Identifier DEFAULT VALUES
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INSERTSTM_INSERT_IDENTIFIER_SET:
          //<Insert Stm> ::= INSERT <Into> Identifier SET <Assign List>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INSERTCOLUMNS_LPARAN_RPARAN:
          //<Insert Columns> ::= '(' <Id List> ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INSERTCOLUMNS:
          //<Insert Columns> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INTO_INTO:
          //<Into> ::= INTO
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INTO:
          //<Into> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INSERTLIST_COMMA:
          //<Insert List> ::= <Insert List> ',' <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INSERTLIST:
          //<Insert List> ::= <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INSERTARRAYS_LPARAN_RPARAN_COMMA:
          //<Insert Arrays> ::= '(' <Insert List> ')' ',' <Insert Arrays>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INSERTARRAYS_LPARAN_RPARAN:
          //<Insert Arrays> ::= '(' <Insert List> ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_UPDATESTM_UPDATE_IDENTIFIER_SET:
          //<Update Stm> ::= UPDATE Identifier SET <Assign List> <From Clause> <Where Clause>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ASSIGNLIST_IDENTIFIER_EQ_COMMA:
          //<Assign List> ::= Identifier '=' <Expression> ',' <Assign List>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ASSIGNLIST_IDENTIFIER_EQ:
          //<Assign List> ::= Identifier '=' <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_DELETESTM_DELETE_IDENTIFIER:
          //<Delete Stm> ::= DELETE <From> Identifier <Where Clause>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_FROM_FROM:
          //<From> ::= FROM
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_FROM:
          //<From> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TRUNCATESTM_TRUNCATE_TABLE_IDENTIFIER:
          //<Truncate Stm> ::= TRUNCATE TABLE Identifier
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_UNIONSTM:
          //<Union Stm> ::= <Select Stm> <Union> <Union Stm>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_UNIONSTM2:
          //<Union Stm> ::= <Select Stm>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_UNION_UNION_ALL:
          //<Union> ::= UNION ALL
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_UNION_UNION:
          //<Union> ::= UNION
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SELECTSTM_SELECT:
          //<Select Stm> ::= SELECT <Columns> <Into Clause> <From Clause> <Where Clause> <Group Clause> <Having Clause> <Order Clause>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COLUMNS_TIMES:
          //<Columns> ::= <Restriction> <top> '*'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COLUMNS:
          //<Columns> ::= <Restriction> <top> <Column List>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TOP_TOP_INTEGERLITERAL_PERCENT:
          //<top> ::= TOP IntegerLiteral PERCENT
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TOP_TOP_INTEGERLITERAL:
          //<top> ::= TOP IntegerLiteral
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TOP:
          //<top> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COLUMNLIST_COMMA:
          //<Column List> ::= <Column Source> ',' <Column List>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COLUMNLIST:
          //<Column List> ::= <Column Source>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COLUMNSOURCE_IDENTIFIER_EQ:
          //<Column Source> ::= Identifier '=' <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COLUMNSOURCE:
          //<Column Source> ::= <Expression> <alias>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COLUMNSOURCE_IDENDIFIER:
          //<Column Source> ::= Idendifier
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ALIAS_AS_IDENTIFIER:
          //<alias> ::= AS Identifier
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ALIAS_AS_STRINGLITERAL:
          //<alias> ::= AS StringLiteral
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ALIAS_IDENTIFIER:
          //<alias> ::= Identifier
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ALIAS:
          //<alias> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ALLDISTINCT_ALL:
          //<all distinct> ::= ALL
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ALLDISTINCT_DISTINCT:
          //<all distinct> ::= DISTINCT
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_RESTRICTION:
          //<Restriction> ::= <all distinct>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_RESTRICTION2:
          //<Restriction> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INTOCLAUSE_INTO_IDENTIFIER:
          //<Into Clause> ::= INTO Identifier
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_INTOCLAUSE:
          //<Into Clause> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_FROMCLAUSE_FROM:
          //<From Clause> ::= FROM <table source list>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_FROMCLAUSE:
          //<From Clause> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TABLESOURCELIST_COMMA:
          //<table source list> ::= <table source> ',' <table source list>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TABLESOURCELIST_CROSS_JOIN:
          //<table source list> ::= <table source> CROSS JOIN <table source list>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TABLESOURCELIST:
          //<table source list> ::= <table source>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TABLESOURCE_IDENTIFIER:
          //<table source> ::= Identifier <alias>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TABLESOURCE_LPARAN_RPARAN:
          //<table source> ::= '(' <Union Stm> ')' <alias>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TABLESOURCE_LPARAN_RPARAN2:
          //<table source> ::= '(' <table source list> ')' <alias>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_TABLESOURCE:
          //<table source> ::= <Joined Table>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_JOINEDTABLE_JOIN_ON:
          //<Joined Table> ::= <table source> <join type> JOIN <table source> ON <search list>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_JOINEDTABLE_LPARAN_RPARAN:
          //<Joined Table> ::= '(' <Joined Table> ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_JOINTYPE_INNER:
          //<join type> ::= INNER
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_JOINTYPE_LEFT:
          //<join type> ::= LEFT
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_JOINTYPE_LEFT_OUTER:
          //<join type> ::= LEFT OUTER
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_JOINTYPE_RIGHT:
          //<join type> ::= RIGHT
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_JOINTYPE_RIGHT_OUTER:
          //<join type> ::= RIGHT OUTER
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_JOINTYPE_FULL:
          //<join type> ::= FULL
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_JOINTYPE_FULL_OUTER:
          //<join type> ::= FULL OUTER
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_JOINTYPE:
          //<join type> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_WHERECLAUSE_WHERE:
          //<Where Clause> ::= WHERE <search list>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_WHERECLAUSE:
          //<Where Clause> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_GROUPCLAUSE_GROUP_BY:
          //<Group Clause> ::= GROUP BY <Id List>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_GROUPCLAUSE_GROUP_BY_ALL:
          //<Group Clause> ::= GROUP BY ALL
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_GROUPCLAUSE:
          //<Group Clause> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_IDLIST_COMMA:
          //<Id List> ::= <Expression> <alias> ',' <Id List>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_IDLIST:
          //<Id List> ::= <Expression> <alias>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ORDERCLAUSE_ORDER_BY:
          //<Order Clause> ::= ORDER BY <Order List>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ORDERCLAUSE:
          //<Order Clause> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ORDERLIST_COMMA:
          //<Order List> ::= <Order Type> <Sort Type> ',' <Order List>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ORDERLIST:
          //<Order List> ::= <Order Type> <Sort Type>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ORDERTYPE_IDENTIFIER:
          //<Order Type> ::= Identifier
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ORDERTYPE_INTEGERLITERAL:
          //<Order Type> ::= IntegerLiteral
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SORTTYPE_ASC:
          //<Sort Type> ::= ASC
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SORTTYPE_DESC:
          //<Sort Type> ::= DESC
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SORTTYPE:
          //<Sort Type> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_HAVINGCLAUSE_HAVING:
          //<Having Clause> ::= HAVING <search list>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_HAVINGCLAUSE:
          //<Having Clause> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_BASEEXPRESSION:
          //<base expression> ::= <search list>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_BASEEXPRESSION2:
          //<base expression> ::= <predicate>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SEARCHLIST_AND:
          //<search list> ::= <search list> AND <not> <predicate> <alias>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SEARCHLIST_OR:
          //<search list> ::= <search list> OR <not> <predicate> <alias>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SEARCHLIST:
          //<search list> ::= <not> <predicate> <alias>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_NOT_NOT:
          //<not> ::= NOT
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_NOT:
          //<not> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_PREDICATE:
          //<predicate> ::= <comparison>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_PREDICATE2:
          //<predicate> ::= <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_PREDICATE_LIKE:
          //<predicate> ::= <Expression> <not> LIKE <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_PREDICATE_BETWEEN_AND:
          //<predicate> ::= <Expression> <not> BETWEEN <Expression> AND <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_PREDICATE_IS_NULL:
          //<predicate> ::= <Expression> IS <not> NULL
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_PREDICATE_IN_LPARAN_RPARAN:
          //<predicate> ::= <Expression> <not> IN '(' <Union Stm> ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_PREDICATE_IN_LPARAN_RPARAN2:
          //<predicate> ::= <Expression> <not> IN '(' <Expression List> ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_PREDICATE_EXISTS_LPARAN_RPARAN:
          //<predicate> ::= EXISTS '(' <Union Stm> ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COMPARISON_GT:
          //<comparison> ::= <Expression> '>' <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COMPARISON_LT:
          //<comparison> ::= <Expression> '<' <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COMPARISON_LTEQ:
          //<comparison> ::= <Expression> '<=' <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COMPARISON_GTEQ:
          //<comparison> ::= <Expression> '>=' <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COMPARISON_EQ:
          //<comparison> ::= <Expression> '=' <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COMPARISON_LTGT:
          //<comparison> ::= <Expression> '<>' <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_COMPARISON_EXCLAMEQ:
          //<comparison> ::= <Expression> '!=' <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_EXPRESSIONLIST_COMMA:
          //<Expression List> ::= <Expression> ',' <Expression List>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_EXPRESSIONLIST:
          //<Expression List> ::= <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_EXPRESSION_PLUS:
          //<Expression> ::= <Expression> '+' <Mult Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_EXPRESSION_MINUS:
          //<Expression> ::= <Expression> '-' <Mult Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_EXPRESSION_AMP:
          //<Expression> ::= <Expression> '&' <Mult Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_EXPRESSION_PIPE:
          //<Expression> ::= <Expression> '|' <Mult Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_EXPRESSION_CARET:
          //<Expression> ::= <Expression> '^' <Mult Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_EXPRESSION:
          //<Expression> ::= <Mult Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_MULTEXPRESSION_TIMES:
          //<Mult Expression> ::= <Mult Expression> '*' <Unary Exp>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_MULTEXPRESSION_DIV:
          //<Mult Expression> ::= <Mult Expression> '/' <Unary Exp>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_MULTEXPRESSION_PERCENT:
          //<Mult Expression> ::= <Mult Expression> '%' <Unary Exp>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_MULTEXPRESSION:
          //<Mult Expression> ::= <Unary Exp>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_UNARYEXP_MINUS:
          //<Unary Exp> ::= '-' <Value>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_UNARYEXP_PLUS:
          //<Unary Exp> ::= '+' <Value>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_UNARYEXP_TILDE:
          //<Unary Exp> ::= '~' <Value>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_UNARYEXP:
          //<Unary Exp> ::= <Value>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_VALUE_LPARAN_RPARAN:
          //<Value> ::= '(' <search list> ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_VALUE_LPARAN_RPARAN2:
          //<Value> ::= '(' <Union Stm> ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_VALUE_INTEGERLITERAL:
          //<Value> ::= IntegerLiteral
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_VALUE_REALLITERAL:
          //<Value> ::= RealLiteral
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_VALUE_STRINGLITERAL:
          //<Value> ::= StringLiteral
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_VALUE_NULL:
          //<Value> ::= NULL
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_VALUE_DEFAULT:
          //<Value> ::= DEFAULT
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_VALUE:
          //<Value> ::= <case>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_VALUE_IDENTIFIER:
          //<Value> ::= Identifier <Argument List Opt>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_VALUE2:
          //<Value> ::= <special function>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_VALUE3:
          //<Value> ::= <Parameter>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_VALUE_XEVALEXPRESION:
          //<Value> ::= XEvalExpresion
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_PARAMETER_COLON_IDENTIFIER:
          //<Parameter> ::= ':' Identifier
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_CASE_CASE_END:
          //<case> ::= CASE <casetype> <casewhen list> <caseelse> END
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_CASETYPE:
          //<casetype> ::= <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_CASETYPE2:
          //<casetype> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_CASEWHENLIST:
          //<casewhen list> ::= <casewhen> <casewhen list>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_CASEWHENLIST2:
          //<casewhen list> ::= <casewhen>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_CASEWHEN_WHEN_THEN:
          //<casewhen> ::= WHEN <search list> THEN <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_CASEELSE_ELSE:
          //<caseelse> ::= ELSE <Expression>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_CASEELSE:
          //<caseelse> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SPECIALFUNCTION_CAST_LPARAN_AS_RPARAN:
          //<special function> ::= CAST '(' <Expression> AS <Type> ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_SPECIALFUNCTION_CONVERT_LPARAN_COMMA_RPARAN:
          //<special function> ::= CONVERT '(' <Type> ',' <Expression> <style> ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_STYLE_COMMA_INTEGERLITERAL:
          //<style> ::= ',' IntegerLiteral
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_STYLE_COMMA_STRINGLITERAL:
          //<style> ::= ',' StringLiteral
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_STYLE:
          //<style> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ARGUMENTLISTOPT_LPARAN_RPARAN:
          //<Argument List Opt> ::= '(' <Restriction> <Argument List> ')'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ARGUMENTLISTOPT:
          //<Argument List Opt> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ARGUMENTLIST_COMMA:
          //<Argument List> ::= <Argument List> ',' <function args>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_ARGUMENTLIST:
          //<Argument List> ::= <function args>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_FUNCTIONARGS_TIMES:
          //<function args> ::= '*'
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_FUNCTIONARGS:
          //<function args> ::= <Expression> <alias>
          //todo: Create a new object using the stored tokens.
          return null;

        case (int)QueryRuleConstants.RULE_FUNCTIONARGS2:
          //<function args> ::= 
          //todo: Create a new object using the stored tokens.
          return null;

      }
      throw new RuleException("Unknown rule");
    }
  }
}
