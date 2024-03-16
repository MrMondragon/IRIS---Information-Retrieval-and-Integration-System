using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Core.ParserObjects;
using System.ComponentModel;
using Iris.Interfaces;

namespace Iris.Runtime.Core.Expressions
{
  /// <summary>
  /// Ancestral abstrato comum a operação e expressão
  /// </summary>
  [Serializable]
  public abstract class Expression : BaseParserObject, IExpression
  {
    public static Expression CreateExpression(string text)
    {
      SqlParser parser = new SqlParser();
      return (Expression)parser.Parse(text); 
    }

    /// <summary>
    /// Indica se o texto do objeto deve ou não ser envolvido por parênteses
    /// </summary>
    /// <value><c>true</c> if parenthesis; otherwise, <c>false</c>.</value>
    [Browsable(false), Category("Expressão"), DisplayName("Parênteses")]
    public bool Parenthesis
    {
      get { return parenthesis; }
      set { parenthesis = value; }
    }

    protected bool parenthesis;

    /// <summary>
    /// Operators to string.
    /// Retorna a string correspondente ao operador passado como parâmetro
    /// </summary>
    /// <param name="oper">The oper.</param>
    /// <returns></returns>
    public static string OperatorToString(Operator oper)
    {
      switch (oper)
      {
        case Operator.Entre_B_e_C:
          return "BETWEEN";
        case Operator.Não_Entre_B_e_C:
          return "NOT BETWEEN";
        case Operator.É_Nulo:
          return "IS NULL";
        case Operator.Não_é_Nulo:
          return "IS NOT NULL";
        case Operator.É_Semelhante_a:
          return "LIKE";
        case Operator.Está_contido_em:
          return "IN";
        case Operator.Igual_a:
          return "=";
        case Operator.Diferente_de:
          return "<>";
        case Operator.Maior_que:
          return ">";
        case Operator.Maior_ou_Igual:
          return ">=";
        case Operator.Menor_que:
          return "<";
        case Operator.Menor_ou_igual:
          return "<=";
       
        default:
          return "";
      }
    }

    /// <summary>
    /// Strings to operator.
    /// Retorna o operador correspondente à string passada como parâmetro
    /// </summary>
    /// <param name="oper">The oper.</param>
    /// <returns></returns>
    public static Operator StringToOperator(string oper)
    {
      switch (oper.ToUpper().Trim())
      {
        case "NOT BETWEEN":
          return Operator.Não_Entre_B_e_C;
        case "BETWEEN":
          return Operator.Entre_B_e_C;
        case "IS NULL":
          return Operator.Não_é_Nulo;
        case "IS NOT NULL":
          return Operator.É_Nulo;
        case "LIKE":
          return Operator.É_Semelhante_a;
        case "IN":
          return Operator.Está_contido_em;
        case "=":
          return Operator.Igual_a;
        case "<>":
          return Operator.Diferente_de;
        case ">":
          return Operator.Maior_que;
        case ">=":
          return Operator.Maior_ou_Igual;
        case "<":
          return Operator.Menor_que;
        case "<=":
          return Operator.Menor_ou_igual;
       
        default:
          return Operator.Nenhum;
      }
    }
    /// <summary>
    /// Operators to string.
    /// Retorna a string correspondente ao operador passado como parâmetro
    /// </summary>
    /// <param name="oper">The oper.</param>
    /// <returns></returns>
    public static string LogicOperatorToString(LogicOperator oper)
    {
      switch (oper)
      {
        case LogicOperator.AND:
          return "AND";
        case LogicOperator.OR:
          return "OR";
        default:
          return "";
      }
    }

    /// <summary>
    /// Strings to operator.
    /// Retorna o operador correspondente à string passada como parâmetro
    /// </summary>
    /// <param name="oper">The oper.</param>
    /// <returns></returns>
    public static LogicOperator StringToLogicOperator(string oper)
    {
      switch (oper.ToUpper().Trim())
      {
        case "AND":
          return LogicOperator.AND;
        case "OR":
          return LogicOperator.OR;
        default:
          return LogicOperator.None;
      }
    }



    public string GetEvalText(IStructure structure)
    {
      string text = this.GetText();
      if (text.IndexOf('{') != -1)
      {
        XEvalParser parser = new XEvalParser(structure);
        //string workQuery = tmpQuery;
        while (text.IndexOf('{') != -1)
        {
          int i = text.IndexOf('{');
          int f = text.IndexOf('}');
          string xpression = text.Substring(0, f);
          xpression = xpression.Substring(i + 1);
          object value = parser.Parse(xpression);
          string par = GetDelimitedValue(Convert.ToString(value));
          text = text.Substring(0, i) + " " + par + " " + text.Substring(f + 1);
        }
      }
      return text;
    }

    public static string GetDelimitedValue(object obj)
    {
      string valor;

      if ((obj == null) || Convert.IsDBNull(obj))
        return " IS NULL";
      else
        valor = Convert.ToString(obj);

      string type = obj.GetType().ToString();
      char? delim;
      switch (type)
      {
        case "System.Int16":
        case "System.Int32":
        case "System.Int64":
        case "System.UInt16":
        case "System.UInt32":
        case "System.UInt64":
        case "System.Byte":
        case "System.SByte":
        case "System.Decimal":
        case "System.Double":
        case "System.Float":
        case "System.Single": delim = null;
          break;
        default: delim = '\'';
          break;
      }

      if (delim != null)
        return delim + valor + delim;
      else
        return valor;
    }
    
  }
}
