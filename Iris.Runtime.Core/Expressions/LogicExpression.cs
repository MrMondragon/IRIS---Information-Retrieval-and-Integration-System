using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Iris.Runtime.Core.Expressions
{
  /// <summary>
  /// Classe para representação de expressões lógicas compostas
  /// </summary>
  [Serializable]
  public class LogicExpression : Expression
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="LogicExpression"/> class.
    /// </summary>
    /// <param name="a">A.</param>
    /// <param name="b">The b.</param>
    /// <param name="op">The op.</param>
    public LogicExpression(Expression a, Expression b, LogicOperator op, bool not, bool par)
    {
      Oper = op;
      expressionA = a;
      ExpressionB = b;
      negate = not;
      Parenthesis = par;
    }

    private bool grouperOnly;

    public bool GrouperOnly
    {
      get { return grouperOnly; }
      set { grouperOnly = value; }
    }

    private Expression expressionA;
    /// <summary>
    /// Gets or sets the expression A.
    /// </summary>
    /// <value>The expression A.</value>
    [Browsable(true), Category("Expression"), DisplayName("Expressão A")]
    public Expression ExpressionA
    {
      get { return expressionA; }
      set
      {
        expressionA = value;
      }
    }

    private bool negate;

    public bool Negate
    {
      get { return negate; }
      set { negate = value; }
    }


    private Expression expressionB;
    /// <summary>
    /// Gets or sets the expression B.
    /// </summary>
    /// <value>The expression B.</value>
    [Browsable(true), Category("Expression"), DisplayName("Expressão B")]
    public Expression ExpressionB
    {
      get { return expressionB; }
      set 
      {
        expressionB = value;
      }
    }
    private LogicOperator oper;

    /// <summary>
    /// Gets or sets the operator of the expression.
    /// </summary>
    /// <value>The oper.</value>
    [Browsable(true), Category("Expression"), DisplayName("Operador")]
    public LogicOperator Oper
    {
      get { return oper; }
      set 
      { 
        oper = value;
      }
    }

    /// <summary>
    /// Retorna o texto correspondente ao objeto
    /// </summary>
    /// <returns></returns>
    public override string GetText()
    {
      string result = "";
      if (ExpressionB == null)
        result = ExpressionA.GetText();
      else
        result = ExpressionA.GetText() + " " + Expression.LogicOperatorToString(Oper) + " " + ExpressionB.GetText();

      if (((parenthesis) || (Oper == LogicOperator.None)) && (!string.IsNullOrEmpty(result)))
        result = "("+result+")";

      if (negate)
        result = "NOT " + result;

      return result;
    }

  }
}
