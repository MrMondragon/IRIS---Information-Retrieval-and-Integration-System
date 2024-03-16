using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using goldparser.lalr;
using goldparser;
using commons;
using Iris.Runtime.Core.ParserObjects;
using Iris.Runtime.Core.Expressions;
using Iris.Runtime.Core.ParserEngine.ParserObjects;

namespace Iris.Runtime.Core
{
  [Serializable]
  public class SqlParser : BaseParser
  {
    private BaseParserObject query;

    public SqlParser()
      : base("Select")
    {
      query = new SelectQuery();
    }

    public string GetSelect()
    {
      return query.GetText();
    }

    private void ScanToken(NonterminalToken token, BaseParserObject aQuery, FromList fromList)
    {
      foreach (Token t in token.Tokens)
        CreateObject(t, aQuery, fromList);
    }

    private string GetFullText(NonterminalToken token, BaseParserObject aQuery)
    {
      string value = "";
      for (int i = 0; i < token.Tokens.Length; i++)
      {
        value += GetText(token, i, aQuery) + " ";
      }
      return value;
    }

    private string GetText(NonterminalToken token, int idx, BaseParserObject aQuery)
    {
      string text = Convert.ToString(CreateObject(token.Tokens[idx], aQuery, null));
      return text;
    }


    public BaseParserObject Parse(string source)
    {


      NonterminalToken token = parser.Parse(source);
      query.Clear();
      BaseParserObject obj = null;
      if (token != null)
      {
        obj = (BaseParserObject)CreateObject(token, query, null);
      }
      return obj;
    }

    private Object CreateObject(Token token, BaseParserObject aQuery, FromList fromList)
    {
      if (token is TerminalToken)
        return CreateObjectFromTerminal((TerminalToken)token);
      else
        return CreateObjectFromNonterminal((NonterminalToken)token, aQuery, fromList);
    }


    ////////////////////////////////////////////////////////////////
    //Rule Section
    ////////////////////////////////////////////////////////////////
    public Object CreateObjectFromNonterminal(NonterminalToken token, BaseParserObject aQuery, FromList fromList)
    {
      switch (token.Rule.Id)
      {
        default:
          //Todos os casos que não possuem tratamento específico retornam o texto puro
          return GetFullText(token, aQuery);

        #region Query
        case (int)SQLRuleConstants.RULE_QUERIES:
          //<Queries> ::= <Query>
        case (int)SQLRuleConstants.RULE_QUERIES2:
          //<Queries> ::= <Query> <Queries>
        case (int)SQLRuleConstants.RULE_QUERY:
          //<Query> ::= <Select Stm>
        case (int)SQLRuleConstants.RULE_QUERY2:
          //<Query> ::= <Expression>
        case (int)SQLRuleConstants.RULE_QUERY3:
          //<Query> ::= <Insert Stm> <GO>
        case (int)SQLRuleConstants.RULE_QUERY4:
          //<Query> ::= <Update Stm> <GO>
        case (int)SQLRuleConstants.RULE_QUERY5:
          //<Query> ::= <Delete Stm> <GO>
          return CreateObject(token.Tokens[0], aQuery, fromList);
        #endregion

        #region Insert
        case (int)SQLRuleConstants.RULE_INSERTSTM_INSERT_ID:
        // <Insert Stm> ::= INSERT <Into> Id <Insert Columns> <Select Stm>
        case (int)SQLRuleConstants.RULE_INSERTSTM_INSERT_ID_VALUES_LPARAN_RPARAN:
          // <Insert Stm> ::= INSERT <Into> Id <Insert Columns> VALUES '(' <Insert List> ')'
          {
            SimpleParserObject command = new SimpleParserObject();
            String commandText = GetFullText(token, command);
            command.Text = commandText;
            return command;
          }

        #endregion

        # region Delete
        case (int)SQLRuleConstants.RULE_DELETESTM_DELETE_FROM_ID:
          //<Delete Stm> ::= DELETE FROM Id <Where Clause>
          {
            SimpleParserObject command = new SimpleParserObject();
            SelectQuery deleteQuery = new SelectQuery();
            ScanToken(token, deleteQuery, deleteQuery.FromClause);
            command.Text = "DELETE FROM " + GetText(token, 2, command);
            if (deleteQuery.Where != null)
              command.Text += " WHERE " + deleteQuery.Where.GetText();

            command.Parameters = deleteQuery.Parameters;
            return command;
          }


        #endregion

        #region Update
        case (int)SQLRuleConstants.RULE_UPDATESTM_UPDATE_ID_SET:
          //<Update Stm> ::= UPDATE Id SET <Assign List> <Update From> <Where Clause>
          {
            SimpleParserObject command = new SimpleParserObject();
            SelectQuery updateQuery = new SelectQuery();
            ScanToken(token, updateQuery, updateQuery.FromClause);
            command.Text = "UPDATE " + GetText(token, 1, command) + " SET " + GetText(token, 3, command);
            if(! String.IsNullOrEmpty(updateQuery.FromClause.GetText()))
              command.Text += " FROM "+updateQuery.FromClause.GetText();
            if (updateQuery.Where!= null)
              command.Text += " WHERE " + updateQuery.Where.GetText();

            command.Parameters = updateQuery.Parameters;
            return command;
          }
          

        #endregion

        #region Select
        case (int)SQLRuleConstants.RULE_SELECTSTM_SELECT:
          //<Select Stm> ::= SELECT <Columns> <From Clause> <Where Clause> <Group Clause> <Having Clause> <Order Clause> <Union>
          SelectQuery lQuery = new SelectQuery();
          ScanToken(token, lQuery, null);
          return lQuery;
        #endregion

        #region Functions
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_COUNT_LPARAN_TIMES_RPARAN:
        //<Aggregate Fn> ::= Count '(' '*' ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_COUNT_BIG_LPARAN_RPARAN:
        //<Aggregate Fn> ::= 'Count_Big' '(' <Restriction> <Expression> ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_COUNT_LPARAN_RPARAN:
        //<Aggregate Fn> ::= Count '(' <Restriction> <Expression> ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_AVG_LPARAN_RPARAN:
        //<Aggregate Fn> ::= Avg '(' <Restriction> <Expression> ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_MIN_LPARAN_RPARAN:
        //<Aggregate Fn> ::= Min '(' <Restriction> <Expression> ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_MAX_LPARAN_RPARAN:
        //<Aggregate Fn> ::= Max '(' <Restriction> <Expression> ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_STDEV_LPARAN_RPARAN:
        //<Aggregate Fn> ::= StDev '(' <Restriction> <Expression> ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_STDEVP_LPARAN_RPARAN:
        //<Aggregate Fn> ::= StDevP '(' <Restriction> <Expression> ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_SUM_LPARAN_RPARAN:
        //<Aggregate Fn> ::= Sum '(' <Restriction> <Expression> ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_VAR_LPARAN_RPARAN:
        //<Aggregate Fn> ::= Var '(' <Restriction> <Expression> ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_VARP_LPARAN_RPARAN:
        //<Aggregate Fn> ::= VarP '(' <Restriction> <Expression> ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_CHECKSUM_LPARAN_TIMES_RPARAN:
        //<Aggregate Fn> ::= CheckSum '(' '*' ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_CHECKSUM_LPARAN_RPARAN:
        //<Aggregate Fn> ::= CheckSum '(' <Expr List> ')'
        case (int)SQLRuleConstants.RULE_AGGREGATEFN_CHECKSUM_AGG_LPARAN_RPARAN:
        //<Aggregate Fn> ::= 'CheckSum_AGG' '(' <Restriction> <Expression> ')'
        case (int)SQLRuleConstants.RULE_DATETIMEFN_DATEADD_LPARAN_ID_COMMA_INTEGERLITERAL_COMMA_RPARAN:
        //<Date Time Fn> ::= DATEADD '(' Id ',' IntegerLiteral ',' <Expression> ')'
        case (int)SQLRuleConstants.RULE_DATETIMEFN_DATEDIFF_LPARAN_ID_COMMA_COMMA_RPARAN:
        //<Date Time Fn> ::= DATEDIFF '(' Id ',' <Expression> ',' <Expression> ')'
        case (int)SQLRuleConstants.RULE_DATETIMEFN_DATENAME_LPARAN_ID_COMMA_RPARAN:
        //<Date Time Fn> ::= DATENAME '(' Id ',' <Expression> ')'
        case (int)SQLRuleConstants.RULE_DATETIMEFN_DATEPART_LPARAN_ID_COMMA_RPARAN:
        //<Date Time Fn> ::= DATEPART '(' Id ',' <Expression> ')'
        case (int)SQLRuleConstants.RULE_DATETIMEFN_DAY_LPARAN_RPARAN:
        //<Date Time Fn> ::= DAY '(' <Expression> ')'
        case (int)SQLRuleConstants.RULE_DATETIMEFN_GETDATE_LPARAN_RPARAN:
        //<Date Time Fn> ::= GETDATE '(' ')'
        case (int)SQLRuleConstants.RULE_DATETIMEFN_GETUTCDATE_LPARAN_RPARAN:
        //<Date Time Fn> ::= GETUTCDATE '(' ')'
        case (int)SQLRuleConstants.RULE_DATETIMEFN_MONTH_LPARAN_RPARAN:
        //<Date Time Fn> ::= MONTH '(' <Expression> ')'
        case (int)SQLRuleConstants.RULE_DATETIMEFN_YEAR_LPARAN_RPARAN:
        //<Date Time Fn> ::= YEAR '(' <Expression> ')'
        case (int)SQLRuleConstants.RULE_CONVERTFN_CAST_LPARAN_AS_RPARAN:
        //<Convert Fn> ::= CAST '(' <Expression> AS <Data Type> ')'
        case (int)SQLRuleConstants.RULE_CONVERTFN_CONVERT_LPARAN_COMMA_RPARAN:
        //<Convert Fn> ::= CONVERT '(' <Data Type> ',' <Expression> ')'
        case (int)SQLRuleConstants.RULE_CONVERTFN_CONVERT_LPARAN_COMMA_COMMA_INTEGERLITERAL_RPARAN:
          //<Convert Fn> ::= CONVERT '(' <Data Type> ',' <Expression> ',' IntegerLiteral ')'
          {
            string function = GetFullText(token, aQuery);
            function = function.Replace(" (", "(");
            return function;
          }
        #endregion

        #region Restrictions

        case (int)SQLRuleConstants.RULE_COLUMNRESTRICTION:
        //<ColumnRestriction> ::= <Restriction>
        case (int)SQLRuleConstants.RULE_COLUMNRESTRICTION_TOP_INTEGERLITERAL:
        //<ColumnRestriction> ::= TOP IntegerLiteral
        case (int)SQLRuleConstants.RULE_COLUMNRESTRICTION_TOP_INTEGERLITERAL_PERCENT:
          //<ColumnRestriction> ::= TOP IntegerLiteral PERCENT
          {
            string restriction = "";
            for (int i = 0; i < token.Tokens.Length; i++)
            {
              restriction += GetText(token, i, aQuery) + " ";
            }
            ((SelectQuery)aQuery).Restriction = restriction;
          }
          return null;

        #endregion

        #region Columns
        case (int)SQLRuleConstants.RULE_COLUMNLIST_COMMA:
        //<Column List> ::= <Column Item> ',' <Column List>
        case (int)SQLRuleConstants.RULE_COLUMNLIST:
          //<Column List> ::= <Column Item>
          {
            string colulmn = GetText(token, 0, aQuery);
            ((SelectQuery)aQuery).Columns.Add(colulmn);
          }
          if (token.Tokens.Length == 3)
            CreateObject(token.Tokens[2], aQuery, null);
          return null;
        case (int)SQLRuleConstants.RULE_COLUMNSOURCE:
          //<Column Source> ::= <Function>
          return CreateObject(token.Tokens[0], aQuery, null);
        case (int)SQLRuleConstants.RULE_COLUMNS_TIMES:
          //<Columns> ::= <ColumnRestriction> '*'
          {
            ((SelectQuery)aQuery).Columns.Add("*");
            CreateObject(token.Tokens[0], aQuery, fromList);
          }
          return null;
        case (int)SQLRuleConstants.RULE_COLUMNS:
          //<Columns> ::= <ColumnRestriction> <Column List>
          ScanToken(token, aQuery, null);
          return null;

        #endregion

        #region From
        case (int)SQLRuleConstants.RULE_FROMCLAUSE_FROM:
          //<From Clause> ::= FROM <From List> <Join Chain>
          CreateObject(token.Tokens[1], aQuery, ((SelectQuery)aQuery).FromClause);
          CreateObject(token.Tokens[2], aQuery, null);
          return null;

        case (int)SQLRuleConstants.RULE_FROMLIST_COMMA:
        //<From List> ::= <From Member> ',' <From List>
        case (int)SQLRuleConstants.RULE_FROMLIST:
          //<From List> ::= <From Member>
          {
            CreateObject(token.Tokens[0], aQuery, fromList);
          }
          if (token.Tokens.Length > 1)
            CreateObject(token.Tokens[2], aQuery, fromList);
          return null;

        case (int)SQLRuleConstants.RULE_FROMLIST_CROSS_JOIN:
          //<From List> ::= <From Member> CROSS JOIN <From List>
          FromMember member = (FromMember)CreateObject(token.Tokens[0], aQuery, fromList);
          member.CrossJoin = true;
          CreateObject(token.Tokens[3], aQuery, ((SelectQuery)aQuery).FromClause);
          return null;

        case (int)SQLRuleConstants.RULE_FROMMEMBER_ID:
          //<From Member> ::= Id
          {
            FromTable table = new FromTable(GetText(token, 0, aQuery), "");
            fromList.Members.Add(table);
            return table;
          }
        case (int)SQLRuleConstants.RULE_FROMMEMBER_ID_ID:
          //<From Member> ::= Id Id
          {
            FromTable table = new FromTable(GetText(token, 0, aQuery), GetText(token, 1, aQuery));
            fromList.Members.Add(table);
            return table;
          }
        case (int)SQLRuleConstants.RULE_FROMMEMBER_ID_AS_ID:
          //<From Member> ::= Id AS Id
          {
            FromTable table = new FromTable(GetText(token, 0, aQuery), GetText(token, 2, aQuery));
            fromList.Members.Add(table);
            return table;
          }
        case (int)SQLRuleConstants.RULE_FROMMEMBER_LPARAN_RPARAN_ID:
          //<From Member> ::= '(' <Select Stm> ')' Id
          {
            SubQuery subQuery = new SubQuery(GetText(token, 3, aQuery));
            subQuery.Query = (SelectQuery)CreateObject(token.Tokens[1], new SelectQuery(), fromList);
            fromList.Members.Add(subQuery);
            return subQuery;
          }
        case (int)SQLRuleConstants.RULE_FROMMEMBER_LPARAN_RPARAN_AS_ID:
          //<From Member> ::= '(' <Select Stm> ')' AS Id
          {
            SubQuery subQuery = new SubQuery(GetText(token, 4, aQuery));
            subQuery.Query = (SelectQuery)CreateObject(token.Tokens[1], new SelectQuery(), fromList);
            fromList.Members.Add(subQuery);
            return subQuery;
          }

        #region Join
        case (int)SQLRuleConstants.RULE_JOINCHAIN:
        //<Join Chain> ::= <Join> <Join Chain>
        case (int)SQLRuleConstants.RULE_JOINCHAIN2:
          //<Join Chain> ::= 
          ScanToken(token, aQuery, fromList);
          return null;

        case (int)SQLRuleConstants.RULE_JOINLIST:
        //<Join List> ::= <Join Member>
        case (int)SQLRuleConstants.RULE_JOINLIST_COMMA:
          //<Join List> ::= <Join Member> ',' <Join List>
          ScanToken(token, aQuery, fromList);
          return null;

        case (int)SQLRuleConstants.RULE_JOIN_ON:
          //<Join> ::= <Join Type> <Join List> <Join Chain> ON <Expression>
          {
            string joinType = GetText(token, 0, aQuery);
            Token fromMember = token.Tokens[1];
            Token joinChain = token.Tokens[2];

            Expression onSection = (Expression)CreateObject(token.Tokens[4], aQuery, fromList);
            FromList joinList = new FromList(joinType, onSection);

            CreateObject(fromMember, aQuery, joinList);
            CreateObject(joinChain, aQuery, joinList);

            if (fromList == null)
              ((SelectQuery)aQuery).JoinChain.Add(joinList);
            else
              fromList.Members.Add(joinList);

          }
          return null;


        case (int)SQLRuleConstants.RULE_JOINMEMBER:
        //<Join Member> ::= <From Member>
        case (int)SQLRuleConstants.RULE_JOINMEMBER2:
          //<Join Member> ::= <Join Chain>
          CreateObject(token.Tokens[0], aQuery, fromList);
          return null;

        #endregion

        #endregion

        #region Where
        case (int)SQLRuleConstants.RULE_WHERECLAUSE_WHERE:
          //<Where Clause> ::= WHERE <Expression>
          {
            Expression where = (Expression)CreateObject(token.Tokens[1], aQuery, fromList);
            ((SelectQuery)aQuery).Where = where;
          }
          return null;

        case (int)SQLRuleConstants.RULE_PARAMETER_COLON_ID:
          //<Parameter> ::= ':' Id
          {
            string param = GetFullText(token, aQuery);
            while (param.IndexOf(" ") > -1)
              param = param.Replace(" ", "");
            if (!aQuery.Parameters.ContainsKey(param))
              aQuery.Parameters.Add(param, null);
            return param;
          }

        #endregion

        #region Group by
        case (int)SQLRuleConstants.RULE_GROUPCLAUSE_GROUP_BY:
        //<Group Clause> ::= GROUP BY <Group List>
        case (int)SQLRuleConstants.RULE_GROUPLIST_COMMA:
        //<Group List> ::= <Group Item> ',' <Group List>
        case (int)SQLRuleConstants.RULE_GROUPLIST:
          //<Group List> ::= <Group Item>
          ScanToken(token, aQuery, null);
          return null;
        case (int)SQLRuleConstants.RULE_GROUPITEM_ID:
        //<Group Item> ::= Id
        case (int)SQLRuleConstants.RULE_GROUPITEM_INTEGERLITERAL:
        //<Group Item> ::= IntegerLiteral
        case (int)SQLRuleConstants.RULE_GROUPITEM:
          //<Group Item> ::= <Function>
          {
            string gItem = GetFullText(token, aQuery);
            ((SelectQuery)aQuery).GroupBy.Add(gItem);
          }
          return null;
        #endregion

        #region Order By

        case (int)SQLRuleConstants.RULE_ORDERCLAUSE_ORDER_BY:
          //<Order Clause> ::= ORDER BY <Order List>
          ScanToken(token, aQuery, fromList);
          return null;
        case (int)SQLRuleConstants.RULE_ORDERLIST_ID_COMMA:
          //<Order List> ::= Id <Order Type> ',' <Order List>
          {
            string orderItem = GetText(token, 0, aQuery) + " " + GetText(token, 1, aQuery);
            ((SelectQuery)aQuery).OrderBy.Add(orderItem);
          }
          ScanToken(token, aQuery, fromList);
          return null;
        case (int)SQLRuleConstants.RULE_ORDERLIST_ID:
          //<Order List> ::= Id <Order Type>
          {
            string orderItem = GetFullText(token, aQuery);
            ((SelectQuery)aQuery).OrderBy.Add(orderItem);
          }
          return null;


        #endregion

        #region Having
        case (int)SQLRuleConstants.RULE_HAVINGCLAUSE_HAVING:
          //<Having Clause> ::= HAVING <Expression>
          {
            Expression having = (Expression)CreateObject(token.Tokens[1], aQuery, fromList);
            ((SelectQuery)aQuery).Having = having;
          }

          return null;
        #endregion

        #region Union
        case (int)SQLRuleConstants.RULE_UNION_UNION:
          //<Union> ::= UNION <Select Stm>
          {
            ((SelectQuery)aQuery).UnionType = " UNION ";
            ((SelectQuery)aQuery).Union = new SelectQuery();
            CreateObject(token.Tokens[1], ((SelectQuery)aQuery).Union, fromList);
          }
          return null;
        case (int)SQLRuleConstants.RULE_UNION_UNION_ALL:
          //<Union> ::= UNION ALL <Select Stm>
          {
            ((SelectQuery)aQuery).UnionType = " UNION ALL ";
            ((SelectQuery)aQuery).Union = new SelectQuery();
            CreateObject(token.Tokens[2], ((SelectQuery)aQuery).Union, fromList);
          }
          return null;
        #endregion

        #region Expressions
        case (int)SQLRuleConstants.RULE_TXTEXPRESSION:
          //<Txt Expression> ::= <Expression>
          {
            Expression X = (Expression)CreateObject(token.Tokens[0], aQuery, fromList);
            return X.GetText();
          }
        case (int)SQLRuleConstants.RULE_TXTEXPRESSION_COMMA:
          //<Txt Expression> ::= <Expression> ',' <Txt Expression>
          {
            Expression X = (Expression)CreateObject(token.Tokens[0], aQuery, fromList);
            return X.GetText() + ", " + GetText(token, 2, aQuery);
          }

        case (int)SQLRuleConstants.RULE_EXPRESSION:
          //<Expression> ::= <Expression> <Binary Operator> <Expression>
          {
            Expression a = (Expression)CreateObject(token.Tokens[0], aQuery, fromList);
            LogicOperator oper = Expression.StringToLogicOperator(GetText(token, 1, aQuery));
            Expression b = (Expression)CreateObject(token.Tokens[2], aQuery, fromList);
            LogicExpression X = new LogicExpression(a, b, oper, false, false);
            return X;
          }
        case (int)SQLRuleConstants.RULE_EXPRESSION_NOT_LPARAN_RPARAN:
          //<Operation> ::= NOT '(' <Expression> ')'
          {
            Expression x = (Expression)CreateObject(token.Tokens[2], aQuery, fromList);
            LogicExpression gX = new LogicExpression(x, null, LogicOperator.None, true, true);
            return gX;
          }
        case (int)SQLRuleConstants.RULE_EXPRESSION2:
          //<Expression> ::= <Operation>
          {
            object obj = CreateObject(token.Tokens[0], aQuery, fromList);
            Operation operation = (Operation)obj;
            return operation;
          }
        case (int)SQLRuleConstants.RULE_EXPRESSION_LPARAN_RPARAN:
          //<Expression> ::= '(' <Expression> ')'
          {
            Expression x = (Expression)CreateObject(token.Tokens[1], aQuery, fromList);
            LogicExpression gX = new LogicExpression(x, null, LogicOperator.None, false, true);
            return gX;
          }

        case (int)SQLRuleConstants.RULE_OPERATION_BETWEEN_AND:
          //<Operation> ::= <Value> BETWEEN <Value> AND <Value>
          {
            Object a = CreateObject(token.Tokens[0], aQuery, fromList);
            Object b = CreateObject(token.Tokens[2], aQuery, fromList);
            Object c = CreateObject(token.Tokens[4], aQuery, fromList);
            return new Operation(a, b, c, Operator.Entre_B_e_C);
          }
        case (int)SQLRuleConstants.RULE_OPERATION_NOT_BETWEEN_AND:
          //<Operation> ::= <Value> NOT BETWEEN <Value> AND <Value>
          {
            Object a = CreateObject(token.Tokens[0], aQuery, fromList);
            Object b = CreateObject(token.Tokens[3], aQuery, fromList);
            Object c = CreateObject(token.Tokens[5], aQuery, fromList);
            return new Operation(a, b, c, Operator.Não_Entre_B_e_C);
          }
        case (int)SQLRuleConstants.RULE_OPERATION_IS_NOT_NULL:
          //<Operation> ::= <Value> IS NOT NULL
          {
            Object a = CreateObject(token.Tokens[0], aQuery, fromList);
            return new Operation(a, null, null, Operator.Não_é_Nulo);
          }
        case (int)SQLRuleConstants.RULE_OPERATION_IS_NULL:
          //<Operation> ::= <Value> IS NULL
          {
            Object a = CreateObject(token.Tokens[0], aQuery, fromList);
            return new Operation(a, null, null, Operator.É_Nulo);
          }
        case (int)SQLRuleConstants.RULE_OPERATION_LIKE:
          //<Operation> ::= <Value> LIKE <Value>
          {
            Object a = CreateObject(token.Tokens[0], aQuery, fromList);
            Object b = CreateObject(token.Tokens[2], aQuery, fromList);
            return new Operation(a, b, null, Operator.É_Semelhante_a);
          }
        case (int)SQLRuleConstants.RULE_OPERATION_IN:
          //<Operation> ::= <Value> IN <Tuple>
          {
            Object a = CreateObject(token.Tokens[0], aQuery, fromList);
            Object b = CreateObject(token.Tokens[2], aQuery, fromList);
            return new Operation(a, b, null, Operator.Está_contido_em);
          }
        case (int)SQLRuleConstants.RULE_OPERATION_NOT_IN:
          //<Operation> ::= <Value> NOT IN <Tuple>
          {
            Object a = CreateObject(token.Tokens[0], aQuery, fromList);
            Object b = CreateObject(token.Tokens[3], aQuery, fromList);
            Operation oper = new Operation(a, b, null, Operator.Não_está_contido_em);
            return oper;
          }

        case (int)SQLRuleConstants.RULE_OPERATION:
          //<Operation> ::= <Value> <Comp Operator> <Value>
          {
            Object a = CreateObject(token.Tokens[0], aQuery, fromList);
            Object b = CreateObject(token.Tokens[2], aQuery, fromList);
            Operator oper = Expression.StringToOperator(GetText(token, 1, aQuery));
            return new Operation(a, b, null, oper);
          }
        case (int)SQLRuleConstants.RULE_OPERATION2:
          //<Operation> ::= <Value>
          {
            return new Operation(CreateObject(token.Tokens[0], aQuery, fromList), null, null, Operator.Nenhum);
          }
        case (int)SQLRuleConstants.RULE_TUPLE_LPARAN_RPARAN:
          //<Tuple> ::= '(' <Select Stm> ')'
          {
            SelectQuery tuple = new SelectQuery();
            tuple = (SelectQuery)CreateObject(token.Tokens[1], tuple, fromList);
            return "(" + tuple.GetText() + ")";
          }
        case (int)SQLRuleConstants.RULE_VALUE_ID:
          //<Value> ::= Id
          {
            IdValue idv = new IdValue(GetFullText(token, aQuery));
            return idv;
          }
        #endregion
      }
    }



  }
}
