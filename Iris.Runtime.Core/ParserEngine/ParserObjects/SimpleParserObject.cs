using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Core.ParserObjects;

namespace Iris.Runtime.Core.ParserEngine.ParserObjects
{
  [Serializable]
  public class SimpleParserObject: BaseParserObject
  {
    private string text;

    public string Text
    {
      get { return text; }
      set { text = value; }
    }

    public override string GetText()
    {
      return Text;
    }
  }
}
