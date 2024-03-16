using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Core.ParserObjects;

namespace Iris.Runtime.Core.Expressions
{
  /// <summary>
  /// Classe auxiliar que serve para diferenciar valores literais de 
  /// colunas de tabelas do banco
  /// </summary>
  [Serializable]
  public class IdValue: BaseParserObject
  {
    public IdValue(string aValue)
    {
      Value = aValue;
    }


    private string value;

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
    public string Value
    {
      get { return this.value; }
      set { this.value = value; }
    }

    /// <summary>
    /// Retorna o texto correspondente ao objeto
    /// </summary>
    /// <returns></returns>
    public override string GetText()
    {
      return value;
    }
  }
}
