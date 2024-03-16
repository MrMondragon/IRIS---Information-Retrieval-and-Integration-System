using System;
using System.Collections.Generic;
using System.Text;
using Hermes.Engine;

namespace Iris.Runtime.Core.ParserEngine.ParserObjects
{
  public class XIndicatorEval : XEvalParser
  {
    private IIndicator indicator;

    public XIndicatorEval(IIndicator _indicator)
      : base()
    {
      indicator = _indicator;
    }

    private string coord;

    public string Coord
    {
      get { return coord; }
      set { coord = value; }
    }

    private string filter;

    public string Filter
    {
      get { return filter; }
      set { filter = value; }
    }

    protected override object GetExternalVarValue(string varName)
    {
      return indicator.GetFactValue(varName, coord, filter);
    }
  }
}
