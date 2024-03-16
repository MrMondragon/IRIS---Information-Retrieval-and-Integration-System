using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Iris.Designer.DesignerActions
{
  public abstract class BaseMemoryObject
  {
    protected PointF OffsetPoint(PointF point, PointF offset)
    {
      return new PointF(point.X + offset.X, point.Y + offset.Y);

    }
  }
}
