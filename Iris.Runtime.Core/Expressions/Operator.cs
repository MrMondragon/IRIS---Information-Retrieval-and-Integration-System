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
    Não_Entre_B_e_C,
    É_Nulo,
    Não_é_Nulo,
    É_Semelhante_a,
    Está_contido_em,
    Igual_a,
    Diferente_de,
    Maior_que,
    Maior_ou_Igual,
    Menor_que,
    Menor_ou_igual,
    Não_está_contido_em
  }

  [Serializable]
  public enum LogicOperator
  {
    AND,
    OR,
    None
  }
}
