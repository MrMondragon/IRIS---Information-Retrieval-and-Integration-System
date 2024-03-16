using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.Runtime.Core.Expressions;

namespace Iris.Runtime.Core.Expressions
{
  /// <summary>
  /// Classe para representação de operações lógicas simples
  /// </summary>
  [Serializable]
  public class Operation : Expression
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Operation"/> class.
    /// </summary>
    /// <param name="va">The va.</param>
    /// <param name="vb">The vb.</param>
    /// <param name="vc">The vc.</param>
    /// <param name="op">The op.</param>
    public Operation(object va, object vb, object vc, Operator op)
    {
      Oper = op;
      ValueA = Convert.ToString(va);
      aIsId = va is IdValue;
      ValueB = Convert.ToString(vb);
      bIsId = vb is IdValue;
      ValueC = Convert.ToString(vc);
      cIsId = vc is IdValue;
      validValues = new List<string>();
    }

    [NonSerialized]
    private List<string> validValues;
    /// <summary>
    /// Gets or sets the valid values.
    /// </summary>
    /// <value>The valid values.</value>
    [Browsable(false)]
    public List<string> ValidValues
    {
      get { return validValues; }
      set { validValues = value; }
    }

    private bool aIsId;
    /// <summary>
    /// Gets a value indicating whether [A is id].
    /// </summary>
    /// <value><c>true</c> if [A is id]; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    public bool AIsId
    {
      get { return aIsId; }
      set { aIsId = value; }
    }

    private string valueA;
    /// <summary>
    /// Gets or sets the value A.
    /// </summary>
    /// <value>The value A.</value>
    [Browsable(true), Category(" "), DisplayName("Valor A")]
    public string ValueA
    {
      get
      {
        return valueA;
      }
      set
      {
        valueA = value;
      }
    }

    private bool bIsId;
    /// <summary>
    /// Gets a value indicating whether [B is id].
    /// </summary>
    /// <value><c>true</c> if [B is id]; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    public bool BIsId
    {
      get { return bIsId; }
      set { bIsId = value; }
    }

    private string valueB;
    /// <summary>
    /// Gets or sets the value B.
    /// </summary>
    /// <value>The value B.</value>
    [Browsable(true), Category("Operação"), DisplayName("Valor B")]
    public string ValueB
    {
      get
      {
        return valueB;
      }
      set
      {
        if ((oper == Operator.Nenhum) || (oper == Operator.É_Nulo) || (oper == Operator.Não_é_Nulo))
        {
          valueB = "";
        }
        else
        {
          valueB = value;
        }
      }
    }

    private bool cIsId;
    /// <summary>
    /// Gets a value indicating whether [C is id].
    /// </summary>
    /// <value><c>true</c> if [C is id]; otherwise, <c>false</c>.</value>
    [Browsable(false)]
    public bool CIsId
    {
      get { return cIsId; }
      set { cIsId = value; }
    }

    private string valueC;
    /// <summary>
    /// Gets or sets the value C.
    /// </summary>
    /// <value>The value C.</value>
    [Browsable(true), Category("Operação"), DisplayName("Valor C")]
    public string ValueC
    {
      get
      {
        return valueC;
      }
      set
      {
        if ((oper != Operator.Entre_B_e_C) && (oper != Operator.Não_Entre_B_e_C))
        {
          valueC = "";
        }
        else
        {
          valueC = value;
        }
      }
    }

    private Operator oper;
    /// <summary>
    /// Gets or sets the operator.
    /// </summary>
    /// <value>The oper.</value>
    [Browsable(true), Category("Operação"), DisplayName("Operador")]
    public Operator Oper
    {
      get { return oper; }
      set
      {
        oper = value;
        if ((oper != Operator.Entre_B_e_C) && (oper != Operator.Não_Entre_B_e_C))
          ValueC = "";
        if ((oper == Operator.Nenhum) || (oper == Operator.É_Nulo) || (oper == Operator.Não_é_Nulo))
          ValueB = "";
      }
    }

    /// <summary>
    /// Retorna o texto correspondente ao objeto
    /// </summary>
    /// <returns></returns>
    public override string GetText()
    {
      string result = "";

      switch (oper)
      {
        case Operator.Nenhum:
          result = valueA; 
          break; 
        case Operator.Entre_B_e_C:
          result = valueA + " BETWEEN " + valueB + " AND " + valueC; 
          break;
        case Operator.Não_Entre_B_e_C:
          result = valueA + " NOT BETWEEN " + valueB + " AND " + valueC;
          break;
        case Operator.É_Nulo:
          result = valueA + " IS NULL"; 
          break;
        case Operator.Não_é_Nulo:
          result = valueA + " IS NOT NULL";
          break;
        case Operator.É_Semelhante_a:
          result = valueA + " LIKE " + valueB; 
          break;
        case Operator.Está_contido_em:
          result = valueA + " IN " + valueB; 
          break;
        case Operator.Igual_a:
          result = valueA + " = " + valueB; 
          break;
        case Operator.Diferente_de:
          result = valueA + " <> " + valueB; 
          break;
        case Operator.Maior_que:
          result = valueA + " > " + valueB; 
          break;
        case Operator.Maior_ou_Igual:
          result = valueA + " >= " + valueB;
          break;
        case Operator.Menor_que:
          result = valueA + " < " + valueB;
          break;
        case Operator.Menor_ou_igual:
          result = valueA + " <= " + valueB; 
          break;
        case Operator.Não_está_contido_em:
          result = valueA+" NOT IN "+valueB;
          break;
        default:
          result = valueA;
          break;
      }

      if (Parenthesis)
        result = "(" + result + ")";

      return result;
    }

  }
}
