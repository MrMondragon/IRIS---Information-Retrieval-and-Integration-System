using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Engine.QueryObjects.SelectItems
{
  public enum JoinType
  {
    Inner,
    Left,
    LeftOuter,
    Right,
    RightOuter,
    Full,
    FullOuter,
    Cross
  }
}
