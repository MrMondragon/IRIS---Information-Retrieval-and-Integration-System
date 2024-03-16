using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Runtime.Geo
{
  public struct PolyLine
  {
    public PolyLine(IEnumerable<LineSegment> segments)
    {
      Segments = segments.ToArray();
    }

    public LineSegment[] Segments;

    public override bool Equals(object obj)
    {
      PolyLine line = (PolyLine)obj;

      if (Segments.Length != line.Segments.Length)
        return false;

      for (int i = 0; i < Segments.Length; i++)
      {
        if (Segments[i] != line.Segments[i])
          return false;
      }

      return true;     
    }

    public override int GetHashCode()
    {
      if (Segments.Length != 0)
        return Segments[0].GetHashCode();
      else
        return -1;
    }

    public PolyLine Simplify(int iterations)
    {
      if (iterations == 0)
        return this;

      iterations -= 1;
      List<LineSegment> segmentList = Segments.ToList();
      List<LineSegment> newSegments = new List<LineSegment>();

      for (int i = 0; i < segmentList.Count-1; i++)
      {
        LineSegment seg0 = segmentList[i];
        LineSegment seg1 = segmentList[i+1];

        LineSegment seg = new LineSegment(seg0.Origin, seg1.End);
        newSegments.Add(seg);
      }

      if ((iterations == 0)||(newSegments.Count <=1))
        return new PolyLine(newSegments);
      else
        return new PolyLine(newSegments).Simplify(iterations);
    }

    public PolyLine Complexify(int iterations)
    {
      if (iterations == 0)
        return this;

      iterations -= 1;
      List<LineSegment> segmentList = Segments.ToList();
      List<LineSegment> newSegments = new List<LineSegment>();

      for (int i = 0; i < segmentList.Count; i++)
      {
        LineSegment seg0 = segmentList[i];

        double xi = (seg0.Origin.X + seg0.End.X) / 2;
        double yi = (seg0.Origin.Y + seg0.End.Y) / 2;

        Coordinate centerPoint = new Coordinate(xi, yi);

        LineSegment seg1 = new LineSegment(seg0.Origin, centerPoint);
        LineSegment seg2 = new LineSegment(centerPoint, seg0.End);
        newSegments.Add(seg1);
        newSegments.Add(seg2);
      }

      if (iterations == 0)
        return new PolyLine(newSegments);
      else
        return new PolyLine(newSegments).Complexify(iterations);

    }

    public double ShortestPerpendicularDistance(Coordinate point)
    {
      double shortestDistance = double.MaxValue;

      for (int i = 0; i < Segments.Length; i++)
      {
        double distance = Segments[i].PerpendicularDistanceToPoint(point);
        if (distance < shortestDistance)
          shortestDistance = distance;
      }

      return shortestDistance;
    }

    public double ShortestDistanceToPoint(Coordinate point)
    {
      double shortestDistance = double.MaxValue;

      for (int i = 0; i < Segments.Length; i++)
      {
        double distance = Segments[i].DistanceToPoint(point);
        if (distance < shortestDistance)
          shortestDistance = distance;
      }

      return shortestDistance;
    }


    public double ShortestNodeDistance(Coordinate point)
    {
      List<Coordinate> testPoints = new List<Coordinate>();
      testPoints.Add(Segments[0].Origin);
      testPoints.AddRange(Segments.Select(x => x.End));

      double shortestDistance = double.MaxValue;

      for (int i = 0; i < testPoints.Count; i++)
      {
        Coordinate testPoint = testPoints[i];

        double distance = point.Distance(testPoint);
        if(distance < shortestDistance)
        {
          shortestDistance = distance;
        }

      }

      return shortestDistance;

    }

    /*
POINT (-47.5014066696167 -23.501367683042805)
LINESTRING (-47.470482090703278 -23.470042977948815, -47.47086009228272 -23.47026297689165)
POLYGON ((-47.482129706468093 -23.436367146560354, -47.482091943494922 -23.436353595124928, -47.482055525189935 -23.436337207170556, 
 ...
 * -47.482129706468093 -23.436367146560354))
 * */

    public static PolyLine ParsePoints(string points)
    {
      points = points.Replace("LINESTRING", "").Replace("POLYGON", "").Trim('(', ')');
      string[] st_coords = points.Split(',');

      Coordinate[] coords = st_coords.Select(x=> Coordinate.ParsePoint(x)).ToArray();

      List<LineSegment> segs = new List<LineSegment>();

      for (int i = 0; i < coords.Length-1; i++)
      {
        segs.Add(new LineSegment(coords[i], coords[i + 1]));
      }

      return new PolyLine(segs);
    }

    

  }
}
