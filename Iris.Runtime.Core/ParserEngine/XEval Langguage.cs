
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
                case (int)SymbolConstants.SYMBOL_MINUS :
                //-
                return null;
                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //!=
                return null;
                case (int)SymbolConstants.SYMBOL_NUM :
                //#
                return null;
                case (int)SymbolConstants.SYMBOL_PERCENT :
                //%
                return null;
                case (int)SymbolConstants.SYMBOL_AMP :
                //&
                return null;
                case (int)SymbolConstants.SYMBOL_LPARAN :
                //(
                return null;
                case (int)SymbolConstants.SYMBOL_RPARAN :
                //)
                return null;
                case (int)SymbolConstants.SYMBOL_TIMES :
                //*
                return null;
                case (int)SymbolConstants.SYMBOL_COMMA :
                //,
                return null;
                case (int)SymbolConstants.SYMBOL_DIV :
                ///
                return null;
                case (int)SymbolConstants.SYMBOL_AT :
                //@
                return null;
                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //[
                return null;
                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //]
                return null;
                case (int)SymbolConstants.SYMBOL_PLUS :
                //+
                return null;
                case (int)SymbolConstants.SYMBOL_LT :
                //<
                return null;
                case (int)SymbolConstants.SYMBOL_LTEQ :
                //<=
                return null;
                case (int)SymbolConstants.SYMBOL_LTGT :
                //<>
                return null;
                case (int)SymbolConstants.SYMBOL_EQEQ :
                //==
                return null;
                case (int)SymbolConstants.SYMBOL_GT :
                //>
                return null;
                case (int)SymbolConstants.SYMBOL_GTEQ :
                //>=
                return null;
                case (int)SymbolConstants.SYMBOL_AND :
                //AND
                return null;
                case (int)SymbolConstants.SYMBOL_AVG :
                //Avg
                return null;
                case (int)SymbolConstants.SYMBOL_AVGDISTINCT :
                //AvgDistinct
                return null;
                case (int)SymbolConstants.SYMBOL_BETWEEN :
                //BETWEEN
                return null;
                case (int)SymbolConstants.SYMBOL_COUNT :
                //Count
                return null;
                case (int)SymbolConstants.SYMBOL_COUNTDISTINCT :
                //CountDistinct
                return null;
                case (int)SymbolConstants.SYMBOL_DATE :
                //Date
                return null;
                case (int)SymbolConstants.SYMBOL_DD :
                //Dd
                return null;
                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                return null;
                case (int)SymbolConstants.SYMBOL_IS :
                //IS
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
                case (int)SymbolConstants.SYMBOL_NOT :
                //NOT
                return null;
                case (int)SymbolConstants.SYMBOL_NOW :
                //Now
                return null;
                case (int)SymbolConstants.SYMBOL_NULL :
                //NULL
                return null;
                case (int)SymbolConstants.SYMBOL_NUMBER :
                //Number
                return null;
                case (int)SymbolConstants.SYMBOL_OR :
                //OR
                return null;
                case (int)SymbolConstants.SYMBOL_REQUESTOBJECT :
                //RequestObject
                return null;
                case (int)SymbolConstants.SYMBOL_STRING :
                //String
                return null;
                case (int)SymbolConstants.SYMBOL_SUBSTRING :
                //Substring
                return null;
                case (int)SymbolConstants.SYMBOL_SUM :
                //Sum
                return null;
                case (int)SymbolConstants.SYMBOL_SUMDISTINCT :
                //SumDistinct
                return null;
                case (int)SymbolConstants.SYMBOL_TODAY :
                //Today
                return null;
                case (int)SymbolConstants.SYMBOL_YY :
                //Yy
                return null;
                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<Add Exp>
                return null;
                case (int)SymbolConstants.SYMBOL_ANDEXP :
                //<And Exp>
                return null;
                case (int)SymbolConstants.SYMBOL_DATAFIELD :
                //<DataField>
                return null;
                case (int)SymbolConstants.SYMBOL_DATATABLE :
                //<DataTable>
                return null;
                case (int)SymbolConstants.SYMBOL_DATE2 :
                //<Date>
                return null;
                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                return null;
                case (int)SymbolConstants.SYMBOL_EXTERNALPARAM :
                //<External Param>
                return null;
                case (int)SymbolConstants.SYMBOL_EXTERNALVAR :
                //<External Var>
                return null;
                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //<Function>
                return null;
                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                return null;
                case (int)SymbolConstants.SYMBOL_NEGATEEXP :
                //<Negate Exp>
                return null;
                case (int)SymbolConstants.SYMBOL_NOTEXP :
                //<Not Exp>
                return null;
                case (int)SymbolConstants.SYMBOL_PREDEXP :
                //<Pred Exp>
                return null;
                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                return null;
                case (int)SymbolConstants.SYMBOL_VAR :
                //<Var>
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
                case (int)RuleConstants.RULE_EXPRESSION_OR :
                //<Expression> ::= <And Exp> OR <Expression>
                return null;
                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <And Exp>
                return null;
                case (int)RuleConstants.RULE_EXPRESSION2 :
                //<Expression> ::= 
                return null;
                case (int)RuleConstants.RULE_ANDEXP_AND :
                //<And Exp> ::= <Not Exp> AND <And Exp>
                return null;
                case (int)RuleConstants.RULE_ANDEXP :
                //<And Exp> ::= <Not Exp>
                return null;
                case (int)RuleConstants.RULE_NOTEXP_NOT :
                //<Not Exp> ::= NOT <Pred Exp>
                return null;
                case (int)RuleConstants.RULE_NOTEXP :
                //<Not Exp> ::= <Pred Exp>
                return null;
                case (int)RuleConstants.RULE_PREDEXP_BETWEEN_AND :
                //<Pred Exp> ::= <Add Exp> BETWEEN <Add Exp> AND <Add Exp>
                return null;
                case (int)RuleConstants.RULE_PREDEXP_IS_NOT_NULL :
                //<Pred Exp> ::= <Value> IS NOT NULL
                return null;
                case (int)RuleConstants.RULE_PREDEXP_IS_NULL :
                //<Pred Exp> ::= <Value> IS NULL
                return null;
                case (int)RuleConstants.RULE_PREDEXP_LIKE_STRING :
                //<Pred Exp> ::= <Add Exp> LIKE String
                return null;
                case (int)RuleConstants.RULE_PREDEXP_EQEQ :
                //<Pred Exp> ::= <Add Exp> == <Add Exp>
                return null;
                case (int)RuleConstants.RULE_PREDEXP_LTGT :
                //<Pred Exp> ::= <Add Exp> <> <Add Exp>
                return null;
                case (int)RuleConstants.RULE_PREDEXP_EXCLAMEQ :
                //<Pred Exp> ::= <Add Exp> != <Add Exp>
                return null;
                case (int)RuleConstants.RULE_PREDEXP_GT :
                //<Pred Exp> ::= <Add Exp> > <Add Exp>
                return null;
                case (int)RuleConstants.RULE_PREDEXP_GTEQ :
                //<Pred Exp> ::= <Add Exp> >= <Add Exp>
                return null;
                case (int)RuleConstants.RULE_PREDEXP_LT :
                //<Pred Exp> ::= <Add Exp> < <Add Exp>
                return null;
                case (int)RuleConstants.RULE_PREDEXP_LTEQ :
                //<Pred Exp> ::= <Add Exp> <= <Add Exp>
                return null;
                case (int)RuleConstants.RULE_PREDEXP :
                //<Pred Exp> ::= <Add Exp>
                return null;
                case (int)RuleConstants.RULE_ADDEXP_PLUS :
                //<Add Exp> ::= <Add Exp> + <Mult Exp>
                return null;
                case (int)RuleConstants.RULE_ADDEXP_MINUS :
                //<Add Exp> ::= <Add Exp> - <Mult Exp>
                return null;
                case (int)RuleConstants.RULE_ADDEXP :
                //<Add Exp> ::= <Mult Exp>
                return null;
                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> * <Negate Exp>
                return null;
                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> / <Negate Exp>
                return null;
                case (int)RuleConstants.RULE_MULTEXP_PERCENT :
                //<Mult Exp> ::= <Mult Exp> % <Negate Exp>
                return null;
                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Negate Exp>
                return null;
                case (int)RuleConstants.RULE_NEGATEEXP_MINUS :
                //<Negate Exp> ::= - <Value>
                return null;
                case (int)RuleConstants.RULE_NEGATEEXP :
                //<Negate Exp> ::= <Value>
                return null;
                case (int)RuleConstants.RULE_VALUE_NUMBER :
                //<Value> ::= Number
                return null;
                case (int)RuleConstants.RULE_VALUE_DD :
                //<Value> ::= Dd
                return null;
                case (int)RuleConstants.RULE_VALUE_YY :
                //<Value> ::= Yy
                return null;
                case (int)RuleConstants.RULE_VALUE_STRING :
                //<Value> ::= String
                return null;
                case (int)RuleConstants.RULE_VALUE :
                //<Value> ::= <Var>
                return null;
                case (int)RuleConstants.RULE_VALUE2 :
                //<Value> ::= <Function>
                return null;
                case (int)RuleConstants.RULE_VALUE3 :
                //<Value> ::= <Date>
                return null;
                case (int)RuleConstants.RULE_VALUE_LPARAN_RPARAN :
                //<Value> ::= ( <Expression> )
                return null;
                case (int)RuleConstants.RULE_VAR :
                //<Var> ::= <External Var>
                return null;
                case (int)RuleConstants.RULE_VAR2 :
                //<Var> ::= <DataTable>
                return null;
                case (int)RuleConstants.RULE_VAR3 :
                //<Var> ::= <DataField>
                return null;
                case (int)RuleConstants.RULE_VAR4 :
                //<Var> ::= <External Param>
                return null;
                case (int)RuleConstants.RULE_EXTERNALVAR_AT_ID :
                //<External Var> ::= @ Id
                return null;
                case (int)RuleConstants.RULE_DATATABLE_NUM_ID :
                //<DataTable> ::= # Id
                return null;
                case (int)RuleConstants.RULE_DATAFIELD_LBRACKET_NUMBER_RBRACKET_LBRACKET_ID_RBRACKET :
                //<DataField> ::= <DataTable> [ Number ] [ Id ]
                return null;
                case (int)RuleConstants.RULE_DATAFIELD_LBRACKET_RBRACKET_LBRACKET_ID_RBRACKET :
                //<DataField> ::= <DataTable> [ <External Var> ] [ Id ]
                return null;
                case (int)RuleConstants.RULE_EXTERNALPARAM_AMP_ID :
                //<External Param> ::= & Id
                return null;
                case (int)RuleConstants.RULE_DATE_DATE_LPARAN_DD_DIV_DD_DIV_YY_RPARAN :
                //<Date> ::= Date ( Dd / Dd / Yy )
                return null;
                case (int)RuleConstants.RULE_DATE_TODAY :
                //<Date> ::= Today
                return null;
                case (int)RuleConstants.RULE_DATE_NOW :
                //<Date> ::= Now
                return null;
                case (int)RuleConstants.RULE_FUNCTION_COUNT_LPARAN_COMMA_ID_RPARAN :
                //<Function> ::= Count ( <DataTable> , Id )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_AVG_LPARAN_COMMA_ID_RPARAN :
                //<Function> ::= Avg ( <DataTable> , Id )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_MIN_LPARAN_COMMA_ID_RPARAN :
                //<Function> ::= Min ( <DataTable> , Id )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_MAX_LPARAN_COMMA_ID_RPARAN :
                //<Function> ::= Max ( <DataTable> , Id )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_SUM_LPARAN_COMMA_ID_RPARAN :
                //<Function> ::= Sum ( <DataTable> , Id )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_COUNTDISTINCT_LPARAN_COMMA_ID_RPARAN :
                //<Function> ::= CountDistinct ( <DataTable> , Id )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_AVGDISTINCT_LPARAN_COMMA_ID_RPARAN :
                //<Function> ::= AvgDistinct ( <DataTable> , Id )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_SUMDISTINCT_LPARAN_COMMA_ID_RPARAN :
                //<Function> ::= SumDistinct ( <DataTable> , Id )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_COUNT_LPARAN_COMMA_ID_COMMA_STRING_RPARAN :
                //<Function> ::= Count ( <DataTable> , Id , String )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_AVG_LPARAN_COMMA_ID_COMMA_STRING_RPARAN :
                //<Function> ::= Avg ( <DataTable> , Id , String )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_MIN_LPARAN_COMMA_ID_COMMA_STRING_RPARAN :
                //<Function> ::= Min ( <DataTable> , Id , String )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_MAX_LPARAN_COMMA_ID_COMMA_STRING_RPARAN :
                //<Function> ::= Max ( <DataTable> , Id , String )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_SUM_LPARAN_COMMA_ID_COMMA_STRING_RPARAN :
                //<Function> ::= Sum ( <DataTable> , Id , String )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_COUNTDISTINCT_LPARAN_COMMA_ID_COMMA_STRING_RPARAN :
                //<Function> ::= CountDistinct ( <DataTable> , Id , String )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_AVGDISTINCT_LPARAN_COMMA_ID_COMMA_STRING_RPARAN :
                //<Function> ::= AvgDistinct ( <DataTable> , Id , String )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_SUMDISTINCT_LPARAN_COMMA_ID_COMMA_STRING_RPARAN :
                //<Function> ::= SumDistinct ( <DataTable> , Id , String )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_SUBSTRING_LPARAN_COMMA_NUMBER_COMMA_NUMBER_RPARAN :
                //<Function> ::= Substring ( <Value> , Number , Number )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_REQUESTOBJECT_LPARAN_ID_RPARAN :
                //<Function> ::= RequestObject ( Id )
                return null;
                case (int)RuleConstants.RULE_FUNCTION_LBRACKET_NUMBER_RBRACKET :
                //<Function> ::= <Var> [ Number ]
                return null;
                case (int)RuleConstants.RULE_FUNCTION_LBRACKET_NUMBER_COMMA_NUMBER_RBRACKET :
                //<Function> ::= <Var> [ Number , Number ]
                return null;
            }
            throw new RuleException("Unknown rule");
        }
    }
}
