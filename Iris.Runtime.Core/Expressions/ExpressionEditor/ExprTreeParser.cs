using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using goldparser.lalr;
using goldparser;
using commons;
using Iris.Runtime.Core.ParserObjects;
using Iris.Runtime.Core.Expressions;
using System.Windows.Forms;
using Iris.Runtime.Core.Iris.ExpressionEditor;

namespace Iris.Runtime.Core
{
  public class ExprTreeParser : BaseParser
  {
    public ExprTreeParser()
      : base("Select")
    {
      sqlParser = new SqlParser();
    }

    SqlParser sqlParser;

    public Expression Parse(string source, TreeNodeCollection nodes)
    {
      NonterminalToken token = parser.Parse(source);
      Expression obj = null;
      if (token != null)
      {
        obj = (Expression)CreateObject(token, nodes, LogicOperator.None);
      }
      return obj;
    }

    private string GetFullText(NonterminalToken token)
    {
      string value = "";
      for (int i = 0; i < token.Tokens.Length; i++)
      {
        value += GetText(token, i) + " ";
      }
      return value;
    }

    private string GetText(NonterminalToken token, int idx)
    {
      string text = Convert.ToString(CreateObject(token.Tokens[idx], null, LogicOperator.None));
      return text;
    }

    private Object CreateOperation(NonterminalToken token, TreeNodeCollection nodes,
      LogicOperator xOper)
    {
      #region Operations
      switch (token.Rule.Id)
      {
        default:
          return null;

        case (int)SQLRuleConstants.RULE_EXPRESSION2:
          //<Expression> ::= <Operation>
          {
            Operation operation = (Operation)CreateOperation((NonterminalToken)token.Tokens[0], nodes, xOper);
            return operation;
          }

        case (int)SQLRuleConstants.RULE_OPERATION_BETWEEN_AND:
          //<Operation> ::= <Value> BETWEEN <Value> AND <Value>
          {
            Object a = CreateObject(token.Tokens[0], nodes, xOper);
            Object b = CreateObject(token.Tokens[2], nodes, xOper);
            Object c = CreateObject(token.Tokens[4], nodes, xOper);
            return new Operation(a, b, c, Operator.Entre_B_e_C);
          }
        case (int)SQLRuleConstants.RULE_OPERATION_NOT_BETWEEN_AND:
          //<Operation> ::= <Value> NOT BETWEEN <Value> AND <Value>
          {
            Object a = CreateObject(token.Tokens[0], nodes, xOper);
            Object b = CreateObject(token.Tokens[3], nodes, xOper);
            Object c = CreateObject(token.Tokens[5], nodes, xOper);
            return new Operation(a, b, c, Operator.Não_Entre_B_e_C);
          }
        case (int)SQLRuleConstants.RULE_OPERATION_IS_NOT_NULL:
          //<Operation> ::= <Value> IS NOT NULL
          {
            Object a = CreateObject(token.Tokens[0], nodes, xOper);
            return new Operation(a, null, null, Operator.Não_é_Nulo);
          }
        case (int)SQLRuleConstants.RULE_OPERATION_IS_NULL:
          //<Operation> ::= <Value> IS NULL
          {
            Object a = CreateObject(token.Tokens[0], nodes, xOper);
            return new Operation(a, null, null, Operator.É_Nulo);
          }
        case (int)SQLRuleConstants.RULE_OPERATION_LIKE:
          //<Operation> ::= <Value> LIKE <Value>
          {
            Object a = CreateObject(token.Tokens[0], nodes, xOper);
            Object b = CreateObject(token.Tokens[2], nodes, xOper);
            return new Operation(a, b, null, Operator.É_Semelhante_a);
          }
        case (int)SQLRuleConstants.RULE_OPERATION_IN:
          //<Operation> ::= <Value> IN <Tuple>
          {
            Object a = CreateObject(token.Tokens[0], nodes, xOper);
            Object b = CreateObject(token.Tokens[2], nodes, xOper);
            return new Operation(a, b, null, Operator.Está_contido_em);
          }
        case (int)SQLRuleConstants.RULE_OPERATION_NOT_IN:
          //<Operation> ::= <Value> NOT IN <Tuple>
          {
            Object a = CreateObject(token.Tokens[0], nodes, xOper);
            Object b = CreateObject(token.Tokens[3], nodes, xOper);
            return new Operation(a, b, null, Operator.Não_está_contido_em);
          }
        case (int)SQLRuleConstants.RULE_OPERATION:
          //<Operation> ::= <Value> <Comp Operator> <Value>
          {
            Object a = CreateObject(token.Tokens[0], nodes, xOper);
            Object b = CreateObject(token.Tokens[2], nodes, xOper);
            Operator oper = Expression.StringToOperator(GetText(token, 1));
            return new Operation(a, b, null, oper);
          }
        case (int)SQLRuleConstants.RULE_OPERATION2:
          //<Operation> ::= <Value>
          {
            return new Operation(CreateObject(token.Tokens[0], nodes, xOper), null, null, Operator.Nenhum);
          }
        case (int)SQLRuleConstants.RULE_TUPLE_LPARAN_RPARAN:
          //<Tuple> ::= '(' <Select Stm> ')'
          {
            string query = GetFullText((NonterminalToken)token.Tokens[1]);
            SelectQuery tuple = (SelectQuery)sqlParser.Parse(query);
            string sTuple = "(" + tuple.GetText() + ")";
            return new Operation(sTuple, null, null, Operator.Nenhum);
          }
        case (int)SQLRuleConstants.RULE_TUPLE_LPARAN_RPARAN2:
          //<Tuple> ::= '(' <Txt Expression> ')'
          {
            string tuple = GetFullText(token);
            return new Operation(tuple, null, null, Operator.Nenhum);
          }
        case (int)SQLRuleConstants.RULE_VALUE_ID:
          //<Value> ::= Id
          {
           IdValue idv = new IdValue(GetFullText(token));
            return idv;
          }
      #endregion
      }
    }


    private Object CreateObject(Token token, TreeNodeCollection nodes, LogicOperator oper)
    {
      if (token is TerminalToken)
        return CreateObjectFromTerminal((TerminalToken)token);
      else
        return CreateObjectFromNonterminal((NonterminalToken)token, nodes, oper);
    }

    ////////////////////////////////////////////////////////////////
    //Rule Section
    ////////////////////////////////////////////////////////////////
    public Object CreateObjectFromNonterminal(NonterminalToken token, TreeNodeCollection nodes,
      LogicOperator xOper)
    {
      switch (token.Rule.Id)
      {
        #region Query
        case (int)SQLRuleConstants.RULE_QUERIES:
        //<Queries> ::= <Query>
        case (int)SQLRuleConstants.RULE_QUERIES2:
        //<Queries> ::= <Query> <Queries>
        case (int)SQLRuleConstants.RULE_QUERY2:
          //<Query> ::= <Expression>
          return CreateObject(token.Tokens[0], nodes, xOper);

        default:
          //Todos os casos que não possuem tratamento específico retornam o texto puro
          return GetFullText(token);
        #endregion

        #region Expressions
        case (int)SQLRuleConstants.RULE_EXPRESSION:
          //<Expression> ::= <Expression> <Binary Operator> <Expression>
          {
            Expression a = (Expression)CreateObject(token.Tokens[0], nodes, xOper);
            LogicOperator oper = Expression.StringToLogicOperator(GetText(token, 1));
            Expression b = (Expression)CreateObject(token.Tokens[2], nodes, oper);
            return new LogicExpression(a, b, oper, false, false);
          }
        case (int)SQLRuleConstants.RULE_EXPRESSION_NOT_LPARAN_RPARAN:
          //<Operation> ::= NOT '(' <Expression> ')'
          {
            TreeNodeCollection localNodes;
            XNode xNode = new XNode(new Operation(null, null, null, Operator.Nenhum), xOper, true);
            xNode.Negate = true;
            bool isOperation = (CreateOperation((NonterminalToken)token.Tokens[2], nodes, xOper) != null);

            if (!isOperation)
            {
              localNodes = xNode.Nodes;
              nodes.Add(xNode);
              CreateObject(token.Tokens[2], localNodes, xOper);
            }
            else
            {
              localNodes = nodes;
              CreateOperNode((NonterminalToken)token.Tokens[2], localNodes, xOper, true);
            }
            return null;
          }
        case (int)SQLRuleConstants.RULE_EXPRESSION_LPARAN_RPARAN:
          //<Expression> ::= '(' <Expression> ')'
          {
            TreeNodeCollection localNodes;
            XNode xNode = new XNode(new Operation(null, null, null, Operator.Nenhum), xOper, true);
            bool isOperation = (CreateOperation((NonterminalToken)token.Tokens[1], nodes, xOper) != null);

            if (!isOperation)
            {
              localNodes = xNode.Nodes;
              nodes.Add(xNode);
              CreateObject(token.Tokens[1], localNodes, xOper);
            }
            else
            {
              localNodes = nodes;
              CreateOperNode((NonterminalToken)token.Tokens[1], localNodes, xOper, true);
            }
            return null;
          }
        case (int)SQLRuleConstants.RULE_EXPRESSION2:
          //<Expression> ::= <Operation>
          {
            return CreateOperNode(token, nodes, xOper, false);
          }
        #endregion

        case (int)SQLRuleConstants.RULE_VALUE_XEVALEXPRESION:
        //<Value> ::= XEvalExpresion
          return GetFullText(token);

        case (int)SQLRuleConstants.RULE_OPERATION_BETWEEN_AND:
          //<Operation> ::= <Value> BETWEEN <Value> AND <Value>
        case (int)SQLRuleConstants.RULE_OPERATION_NOT_BETWEEN_AND:
          //<Operation> ::= <Value> NOT BETWEEN <Value> AND <Value>
        case (int)SQLRuleConstants.RULE_OPERATION_IS_NOT_NULL:
          //<Operation> ::= <Value> IS NOT NULL
        case (int)SQLRuleConstants.RULE_OPERATION_IS_NULL:
          //<Operation> ::= <Value> IS NULL
        case (int)SQLRuleConstants.RULE_OPERATION_LIKE:
          //<Operation> ::= <Value> LIKE <Value>
        case (int)SQLRuleConstants.RULE_OPERATION_IN:
          //<Operation> ::= <Value> IN <Tuple>
        case (int)SQLRuleConstants.RULE_OPERATION_NOT_IN:
        //<Operation> ::= <Value> NOT IN <Tuple>
        case (int)SQLRuleConstants.RULE_OPERATION:
          //<Operation> ::= <Value> <Comp Operator> <Value>
        case (int)SQLRuleConstants.RULE_OPERATION2:
          //<Operation> ::= <Value>
        case (int)SQLRuleConstants.RULE_TUPLE_LPARAN_RPARAN:
          //<Tuple> ::= '(' <Select Stm> ')'
        case (int)SQLRuleConstants.RULE_TUPLE_LPARAN_RPARAN2:
          //<Tuple> ::= '(' <Txt Expression> ')'
        case (int)SQLRuleConstants.RULE_VALUE_ID:
          //<Value> ::= Id
          return CreateOperation(token,nodes,xOper);
      }
    }

    private object CreateOperNode(NonterminalToken token, TreeNodeCollection nodes, LogicOperator xOper, bool parenth)
    {
      Operation operation = (Operation)CreateObject(token.Tokens[0], nodes, xOper);
      operation.Parenthesis = parenth;
      if (nodes != null)
      {
        XNode xNode = new XNode(operation, xOper, false);
        nodes.Add(xNode);
      }
      return operation;
    }



  }

}
