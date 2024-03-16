using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Runtime.Core
{
  [Serializable]
  public enum Operator
  {
    Nenhum,
    Entre_B_e_C,
    N�o_Entre_B_e_C,
    �_Nulo,
    N�o_�_Nulo,
    �_Semelhante_a,
    Est�_contido_em,
    Igual_a,
    Diferente_de,
    Maior_que,
    Maior_ou_Igual,
    Menor_que,
    Menor_ou_igual,
    N�o_est�_contido_em
  }

  [Serializable]
  public enum LogicOperator
  {
    AND,
    OR,
    None
  }
}
