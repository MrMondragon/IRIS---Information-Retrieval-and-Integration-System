using System;
using System.Collections.Generic;
using goldparser;
using System.Data;

namespace Iris.Engine
{

  public class XEvalParser : BaseParser<Object>
  {
    public XEvalParser()
      : base("XEval")
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
      return text.Substring(1, text.Length - 2);
    }


    ////////////////////////////////////////////////////////////////
    //Rule Section
    ////////////////////////////////////////////////////////////////
    public Object CreateObjectFromNonterminal(NonterminalToken token)
    {
      switch (token.Rule.Id)
      {
        case (int)XEvalRuleConstants.RULE_EXPRESSION_OR:
          //<Expression> ::= <And Exp> OR <Expression>
          {
            bool b1 = Convert.ToBoolean(CreateObject(token.Tokens[0]));
            bool b2 = Convert.ToBoolean(CreateObject(token.Tokens[2]));
            return b1 || b2;
          }
        case (int)XEvalRuleConstants.RULE_EXPRESSION:
          //<Expression> ::= <And Exp>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_EXPRESSION2:
          //<Expression> ::= 
          return null;
        case (int)XEvalRuleConstants.RULE_ANDEXP_AND:
          //<And Exp> ::= <Not Exp> AND <And Exp>
          {
            bool b1 = Convert.ToBoolean(CreateObject(token.Tokens[0]));
            bool b2 = Convert.ToBoolean(CreateObject(token.Tokens[2]));
            return b1 && b2;
          }
        case (int)XEvalRuleConstants.RULE_ANDEXP:
          //<And Exp> ::= <Not Exp>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_NOTEXP_NOT:
          //<Not Exp> ::= NOT <Pred Exp>
          {
            bool b = Convert.ToBoolean(CreateObject(token.Tokens[1]));
            return !b;
          }
        case (int)XEvalRuleConstants.RULE_NOTEXP:
          //<Not Exp> ::= <Pred Exp>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_PREDEXP_BETWEEN_AND:
          //<Pred Exp> ::= <Add Exp> BETWEEN <Add Exp> AND <Add Exp>
          {
            object obj1 = CreateObject(token.Tokens[0]);
            object obj2 = CreateObject(token.Tokens[2]);
            object obj3 = CreateObject(token.Tokens[4]);

            return (Compare(obj1, obj2) >= 0) && (Compare(obj1, obj3) <= 0);
          }
        case (int)XEvalRuleConstants.RULE_PREDEXP_IS_NOT_NULL:
          //<Pred Exp> ::= <Value> IS NOT NULL
          {
            object obj = CreateObject(token.Tokens[0]);
            return (obj != null) && (!Convert.IsDBNull(obj));
          }
        case (int)XEvalRuleConstants.RULE_PREDEXP_IS_NULL:
          //<Pred Exp> ::= <Value> IS NULL
          {
            object obj = CreateObject(token.Tokens[0]);
            return (obj == null) || (Convert.IsDBNull(obj));
          }
        case (int)XEvalRuleConstants.RULE_PREDEXP_LIKE_STRING:
          //<Pred Exp> ::= <Add Exp> LIKE String
          {
            string st1 = GetString(token, 0);
            string st2 = GetString(token, 2);

            st1 = st1.Substring(0, st2.Length);

            return (st1.ToLowerInvariant() == st2.ToLowerInvariant());
          }
        case (int)XEvalRuleConstants.RULE_PREDEXP_EQEQ:
          //<Pred Exp> ::= <Add Exp> '==' <Add Exp>
          {
            object obj1 = CreateObject(token.Tokens[0]);
            object obj2 = CreateObject(token.Tokens[2]);
            return Compare(obj1, obj2) == 0;
          }
        case (int)XEvalRuleConstants.RULE_PREDEXP_LTGT:
        //<Pred Exp> ::= <Add Exp> '<>' <Add Exp>
        case (int)XEvalRuleConstants.RULE_PREDEXP_EXCLAMEQ:
          //<Pred Exp> ::= <Add Exp> '!=' <Add Exp>
          {
            object obj1 = CreateObject(token.Tokens[0]);
            object obj2 = CreateObject(token.Tokens[2]);
            return Compare(obj1, obj2) != 0;
          }
        case (int)XEvalRuleConstants.RULE_PREDEXP_GT:
          //<Pred Exp> ::= <Add Exp> '>' <Add Exp>
          {
            object obj1 = CreateObject(token.Tokens[0]);
            object obj2 = CreateObject(token.Tokens[2]);
            return Compare(obj1, obj2) > 0;
          }
        case (int)XEvalRuleConstants.RULE_PREDEXP_GTEQ:
          //<Pred Exp> ::= <Add Exp> '>=' <Add Exp>
          {
            object obj1 = CreateObject(token.Tokens[0]);
            object obj2 = CreateObject(token.Tokens[2]);
            return Compare(obj1, obj2) >= 0;
          }
        case (int)XEvalRuleConstants.RULE_PREDEXP_LT:
          //<Pred Exp> ::= <Add Exp> '<' <Add Exp>
          {
            object obj1 = CreateObject(token.Tokens[0]);
            object obj2 = CreateObject(token.Tokens[2]);
            return Compare(obj1, obj2) < 0;
          }
        case (int)XEvalRuleConstants.RULE_PREDEXP_LTEQ:
          //<Pred Exp> ::= <Add Exp> '<=' <Add Exp>
          {
            object obj1 = CreateObject(token.Tokens[0]);
            object obj2 = CreateObject(token.Tokens[2]);
            return Compare(obj1, obj2) <= 0;
          }
        case (int)XEvalRuleConstants.RULE_PREDEXP:
          //<Pred Exp> ::= <Add Exp>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_ADDEXP_PLUS:
          //<Add Exp> ::= <Add Exp> '+' <Mult Exp>
          {
            object obj1 = CreateObject(token.Tokens[0]);
            object obj2 = CreateObject(token.Tokens[2]);
            return Add(obj1, obj2);
          }
        case (int)XEvalRuleConstants.RULE_ADDEXP_MINUS:
          //<Add Exp> ::= <Add Exp> '-' <Mult Exp>
          {
            object obj1 = CreateObject(token.Tokens[0]);
            object obj2 = CreateObject(token.Tokens[2]);
            return Subtract(obj1, obj2);
          }
        case (int)XEvalRuleConstants.RULE_ADDEXP:
          //<Add Exp> ::= <Mult Exp>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_MULTEXP_TIMES:
          //<Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
          {
            float v1 = GetNumber(token, 0);
            float v2 = GetNumber(token, 2);
            return v1 * v2;
          }
        case (int)XEvalRuleConstants.RULE_MULTEXP_DIV:
          //<Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
          {
            float v1 = GetNumber(token, 0);
            float v2 = GetNumber(token, 2);
            return v1 / v2;
          }
        case (int)XEvalRuleConstants.RULE_MULTEXP_PERCENT:
          //<Mult Exp> ::= <Mult Exp> '%' <Negate Exp>
          {
            float v1 = GetNumber(token, 0);
            float v2 = GetNumber(token, 2);
            return v1 % v2;
          }
        case (int)XEvalRuleConstants.RULE_MULTEXP:
          //<Mult Exp> ::= <Negate Exp>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_NEGATEEXP_MINUS:
          //<Negate Exp> ::= '-' <Value>
          {
            float value = GetNumber(token, 1);
            return value * -1D;
          }
        case (int)XEvalRuleConstants.RULE_NEGATEEXP:
          //<Negate Exp> ::= <Value>
          return CreateObject(token.Tokens[0]);

        case (int)XEvalRuleConstants.RULE_VALUE_DD:
        //<Value> ::= Dd
        case (int)XEvalRuleConstants.RULE_VALUE_YY:
        //<Value> ::= Yy
        case (int)XEvalRuleConstants.RULE_VALUE_NUMBER:
          //<Value> ::= Number
          return GetNumber(token, 0);

        case (int)XEvalRuleConstants.RULE_VALUE_STRING:
          //<Value> ::= String
          return GetString(token, 0);
        case (int)XEvalRuleConstants.RULE_VALUE:
          //<Value> ::= <Var>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_VALUE2:
          //<Value> ::= <Function>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_VALUE3:
          //<Value> ::= <Date>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_VALUE_LPARAN_RPARAN:
          //<Value> ::= '(' <Expression> ')'
          return CreateObject(token.Tokens[1]);
        case (int)XEvalRuleConstants.RULE_VAR:
          //<Var> ::= <External Var>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_VAR2:
          //<Var> ::= <DataTable>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_VAR3:
          //<Var> ::= <DataField>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_VAR4:
          //<Var> ::= <External Param>
          return CreateObject(token.Tokens[0]);
        case (int)XEvalRuleConstants.RULE_EXTERNALVAR_AT_ID:
          //<External Var> ::= '@' Id
          {
            return GetExternalVarValue(GetText(token, 1));
          }
        case (int)XEvalRuleConstants.RULE_DATATABLE_NUM_ID:
          //<DataTable> ::= '#' Id
          {
            if (context == null)
              return null;
            else
            {
              DataTable rs = context.Dataset.Tables[GetText(token, 1)];
              return rs;
            }
          }
        case (int)XEvalRuleConstants.RULE_DATAFIELD_LBRACKET_NUMBER_RBRACKET_LBRACKET_ID_RBRACKET:
        //<DataField> ::= <DataTable> '[' number ']' '[' Id ']'
        case (int)XEvalRuleConstants.RULE_DATAFIELD_LBRACKET_RBRACKET_LBRACKET_ID_RBRACKET:
          // <DataField> ::= <DataTable> [ <External Var> ] [ Id ]
          {
            DataTable rs = (DataTable)CreateObject(token.Tokens[0]);
            DataRow row = rs.Rows[GetInt(token, 2)];
            object value = row[GetText(token, 5)];
            return value;
          }
        case (int)XEvalRuleConstants.RULE_EXTERNALPARAM_AMP_ID:
          //<External Param> ::= '&' Id
          {
            string paramName = GetText(token, 1);
            if((context != null)&&(context.Parameters.ContainsKey(paramName)))
              return context.Parameters[paramName];
            else
              return null;
          }
        case (int)XEvalRuleConstants.RULE_DATE_DATE_LPARAN_DD_DIV_DD_DIV_YY_RPARAN:
          //<Date> ::= Date '(' Dd '/' Dd '/' Yy ')'
          {
            int day = GetInt(token, 2);
            int month = GetInt(token, 4);
            int year = GetInt(token, 6);
            DateTime dt = new DateTime(year, month, day);
            return dt;
          }
        case (int)XEvalRuleConstants.RULE_DATE_TODAY:
          //<Date> ::= Today
          return DateTime.Today;
        case (int)XEvalRuleConstants.RULE_DATE_NOW:
          //<Date> ::= Now
          return DateTime.Now;

        case (int)XEvalRuleConstants.RULE_FUNCTION_COUNT_LPARAN_COMMA_ID_RPARAN:
        //<Function> ::= Count ( <DataTable> , Id )
        case (int)XEvalRuleConstants.RULE_FUNCTION_AVG_LPARAN_COMMA_ID_RPARAN:
        //<Function> ::= Avg ( <DataTable> , Id )
        case (int)XEvalRuleConstants.RULE_FUNCTION_MIN_LPARAN_COMMA_ID_RPARAN:
        //<Function> ::= Min ( <DataTable> , Id )
        case (int)XEvalRuleConstants.RULE_FUNCTION_MAX_LPARAN_COMMA_ID_RPARAN:
        //<Function> ::= Max ( <DataTable> , Id )
        case (int)XEvalRuleConstants.RULE_FUNCTION_SUM_LPARAN_COMMA_ID_RPARAN:
        //<Function> ::= Sum ( <DataTable> , Id )
        case (int)XEvalRuleConstants.RULE_FUNCTION_COUNT_LPARAN_COMMA_ID_COMMA_STRING_RPARAN:
        //<Function> ::= Count ( <DataTable> , Id , String )
        case (int)XEvalRuleConstants.RULE_FUNCTION_AVG_LPARAN_COMMA_ID_COMMA_STRING_RPARAN:
        //<Function> ::= Avg ( <DataTable> , Id , String )
        case (int)XEvalRuleConstants.RULE_FUNCTION_MIN_LPARAN_COMMA_ID_COMMA_STRING_RPARAN:
        //<Function> ::= Min ( <DataTable> , Id , String )
        case (int)XEvalRuleConstants.RULE_FUNCTION_MAX_LPARAN_COMMA_ID_COMMA_STRING_RPARAN:
        //<Function> ::= Max ( <DataTable> , Id , String )
        case (int)XEvalRuleConstants.RULE_FUNCTION_SUM_LPARAN_COMMA_ID_COMMA_STRING_RPARAN:
          //<Function> ::= Sum ( <DataTable> , Id , String )
          {
            DataTable table = (DataTable)CreateObject(token.Tokens[2]);
            if (table != null)
            {
              string fieldName = GetText(token, 4);
              string function = GetText(token, 0);
              string expression = function + "(" + fieldName + ")";
              string filter = GetFilter(token);
              return table.Compute(expression, filter);
            }
            else
              return null;
          }

        case (int)XEvalRuleConstants.RULE_FUNCTION_COUNTDISTINCT_LPARAN_COMMA_ID_RPARAN:
        //<Function> ::= CountDistinct ( <DataTable> , Id )
        case (int)XEvalRuleConstants.RULE_FUNCTION_COUNTDISTINCT_LPARAN_COMMA_ID_COMMA_STRING_RPARAN:
        //<Function> ::= CountDistinct ( <DataTable> , Id , String )
        case (int)XEvalRuleConstants.RULE_FUNCTION_AVGDISTINCT_LPARAN_COMMA_ID_RPARAN:
        //<Function> ::= AvgDistinct ( <DataTable> , Id )
        case (int)XEvalRuleConstants.RULE_FUNCTION_AVGDISTINCT_LPARAN_COMMA_ID_COMMA_STRING_RPARAN:
        //<Function> ::= AvgDistinct ( <DataTable> , Id , String )
        case (int)XEvalRuleConstants.RULE_FUNCTION_SUMDISTINCT_LPARAN_COMMA_ID_COMMA_STRING_RPARAN:
        //<Function> ::= SumDistinct ( <DataTable> , Id , String )
        case (int)XEvalRuleConstants.RULE_FUNCTION_SUMDISTINCT_LPARAN_COMMA_ID_RPARAN:
          //<Function> ::= SumDistinct ( <DataTable> , Id )
          {
            List<object> distinctValues = GetDistinctList(token);
            if (distinctValues != null)
            {
              int count = distinctValues.Count;

              if (GetText(token, 0).ToUpper() == "COUNTDISTINCT")
                return count;

              double sum = 0;

              for (int i = 0; i < count; i++)
              {
                if (!Convert.IsDBNull(distinctValues[i]))
                  sum += Convert.ToDouble(distinctValues[i]);
              }

              if (GetText(token, 0).ToUpper() == "AVGDISTINCT")
                return sum / count;
              else
                return sum;
            }
            else
              return null;
          }

        case (int)XEvalRuleConstants.RULE_FUNCTION_SUBSTRING_LPARAN_COMMA_NUMBER_COMMA_NUMBER_RPARAN:
          //<Function> ::= Substring ( <Value> , int , int )
          {
            string value = GetText(token, 2).Trim('"');
            int i = Convert.ToInt32(CreateObject(token.Tokens[4]));
            int f = Convert.ToInt32(CreateObject(token.Tokens[6]));
            return value.Substring(i, f);
          }


        case (int)XEvalRuleConstants.RULE_FUNCTION_REQUESTOBJECT_LPARAN_ID_RPARAN:
          //<Function> ::= RequestObject ( Id )
          {
            if (context == null)
              return null;
            else
            {
              return context.Objects[GetText(token, 2)];
            }
          }

        case (int)XEvalRuleConstants.RULE_FUNCTION_LBRACKET_NUMBER_RBRACKET:
          //<Function> ::= <Var> [ int ]
          {
            int i = Convert.ToInt32(CreateObject(token.Tokens[2]));
            string text = GetText(token, 0);
            if (i < text.Length)
              return Convert.ToString(text[i]);
            else
              return "";
          }
        case (int)XEvalRuleConstants.RULE_FUNCTION_LBRACKET_NUMBER_COMMA_NUMBER_RBRACKET:
          //<Function> ::= <Var> [ int , int ]
          {
            int i = Convert.ToInt32(CreateObject(token.Tokens[2]));
            int f = Convert.ToInt32(CreateObject(token.Tokens[4]));
            return GetText(token, 0).Substring(i, f);
          }
      }
      throw new RuleException("Unknown rule");
    }

    protected virtual object GetExternalVarValue(string varName)
    {
      object result = null;
      if (context != null)
      {
        if (context.Variables.ContainsKey(varName))
        {
          result = context.Variables[varName];
        }
      }
      return result;
    }

    private string GetFilter(NonterminalToken token)
    {
      string filter = "";
      if (token.Tokens.Length > 6)
      {
        filter = GetText(token, 6);
        filter = filter.Trim('"');
      }
      return filter;
    }

    private List<object> GetDistinctList(NonterminalToken token)
    {
      DataTable table = (DataTable)CreateObject(token.Tokens[2]);
      if (table != null)
      {
        string fieldName = GetText(token, 4);

        List<object> distinctValues = new List<object>();

        string filter = GetFilter(token);

        DataRow[] rows;

        if (string.IsNullOrEmpty(filter))
          rows = table.Select();
        else
          rows = table.Select(filter);

        for (int i = 0; i < rows.Length; i++)
        {
          object value = rows[i][fieldName];
          if (!distinctValues.Contains(value))
            distinctValues.Add(value);
        }
        return distinctValues;
      }
      else
        return null;
    }


    private int Compare(object obj1, object obj2)
    {
      if (obj1 is DateTime)
      {
        DateTime dt1 = (DateTime)obj1;
        DateTime dt2 = (DateTime)obj2;
        return dt1.CompareTo(dt2);
      }
      else if (IsNumber(obj1))
      {
        float f1 = Convert.ToSingle(obj1);
        float f2 = Convert.ToSingle(obj2);
        return f1.CompareTo(f2);
      }
      else if (obj1 is string)
      {
        string st1 = Convert.ToString(obj1);
        string st2 = Convert.ToString(obj2);
        return st1.CompareTo(st2);
      }
      throw new Exception("Tipo inválido" + (obj1.GetType().ToString()));
    }

    private object Add(object obj1, object obj2)
    {
      if (obj1 is DateTime)
      {
        DateTime dt1 = (DateTime)obj1;
        if (obj2 is DateTime)
        {
          throw new Exception("Impossível somar duas datas");
        }
        else
        {
          float f2 = Convert.ToSingle(obj2);
          DateTime dt2 = dt1.AddDays(f2);
          return dt2;
        }
      }
      else if (IsNumber(obj1) && IsNumber(obj2))
      {
        float f1 = Convert.ToSingle(obj1);
        float f2 = Convert.ToSingle(obj2);
        return f1 + f2;
      }
      else
      {
        string st1 = Convert.ToString(obj1);
        string st2 = Convert.ToString(obj2);
        return st1 + st2;
      }


    }

    private object Subtract(object obj1, object obj2)
    {
      if (obj1 is DateTime)
      {
        DateTime dt1 = (DateTime)obj1;
        if (obj2 is DateTime)
        {
          DateTime dt2 = (DateTime)obj2;
          TimeSpan ts1 = dt1 - dt2;
          return ts1;
        }
        else
        {
          float f2 = Convert.ToSingle(obj2) * -1;
          DateTime dt2 = dt1.AddDays(f2);
          return dt2;
        }
      }
      else if (IsNumber(obj1))
      {
        float f1 = Convert.ToSingle(obj1);
        if (obj2 is DateTime)
        {
          throw new Exception("Impossível subtrair número e data");
        }
        else
        {
          float f2 = Convert.ToSingle(obj2);
          return f1 - f2;
        }
      }
      throw new Exception("Tipo inválido" + (obj1.GetType().ToString()));
    }

    private bool IsNumber(object obj)
    {
      float f;
      return float.TryParse(Convert.ToString(obj), out f);
    }


  }
}
