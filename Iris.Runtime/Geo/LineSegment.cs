using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Runtime.Geo
{
  public struct LineSegment
  {
    public LineSegment(Coordinate origin, Coordinate end)
    {
      Origin = origin;
      End = end;

      Length = Origin.Distance(End);

    }

    public Coordinate Origin;
    public Coordinate End;

    public double Length;

    public double PerpendicularDistanceToPoint(Coordinate p)
    {
      // use comp.graphics.algorithms Frequently Asked Questions method
      /*(2)
                      (Ay-Cy)(Bx-Ax)-(Ax-Cx)(By-Ay)
                  s = -----------------------------
                                   Curve^2

                  Then the distance from C to Point = |s|*Curve.
      */

      double s = ((Origin.Y - p.Y) * (End.X - Origin.X) - (Origin.X - p.X) * (End.Y - Origin.Y))
                  /
                  ((End.X - Origin.X) * (End.X - Origin.X) + (End.Y - Origin.Y) * (End.Y - Origin.Y));

      return Math.Abs(s) * Math.Sqrt(((End.X - Origin.X) * (End.X - Origin.X) + (End.Y - Origin.Y) * (End.Y - Origin.Y)));
    }

    public double DistanceToPoint(Coordinate p)
    {

      double a = p.X - Origin.X;
      double b = p.Y - Origin.Y;
      double c = End.X - Origin.X;
      double d = End.Y - Origin.Y;

      double dot = a * c + b * d;
      double len_sq = c * c + d * d;
      double k = dot / len_sq;

      Coordinate testPoint;

      if (k < 0)
        testPoint = Origin;
      else if (k > 1)
        testPoint = End;
      else
      {
        testPoint = new Coordinate(Origin.X + k * c, Origin.Y + k * d);
      }

      return testPoint.Distance(p);

    }


    public override bool Equals(object obj)
    {
      LineSegment seg = (LineSegment)obj;

      return (seg.Origin == this.Origin) && (seg.End == this.End);
    }

    public override int GetHashCode()
    {
      return Origin.GetHashCode() ^ End.GetHashCode();
    }

    public override string ToString()
    {
      return string.Format("{0} {1}", Origin, End);
    }

    public static bool operator ==(LineSegment obj1, LineSegment obj2)
    {
      return Equals(obj1, obj2);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="obj1"></param>
    /// <param name="obj2"></param>
    /// <returns></returns>
    public static bool operator !=(LineSegment obj1, LineSegment obj2)
    {
      return !(obj1 == obj2);
    }


  }
}
