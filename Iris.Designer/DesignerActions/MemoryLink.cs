using Iris.Designer.VisualObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using MindFusion.Diagramming.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Iris.Designer.DesignerActions
{
  [Serializable]
  public class MemoryLink: BaseMemoryObject
  {
    public MemoryLink(Arrow arrow)
    {
      DestIdx = arrow.DestIndex;
      OrigIdx = arrow.OrgnIndex;

      VisualOperation tabOrigem = (VisualOperation)arrow.Origin;
      VisualOperation tabDestino = (VisualOperation)arrow.Destination;
      IOperation objOrigem = tabOrigem.Operation;
      IOperation objDestino = tabDestino.Operation;

      DestId = tabOrigem.Id;
      OrigId = tabOrigem.Id;

      DestName = objDestino.Name;
      OrigName = objOrigem.Name;
      PenColor = arrow.PenColor;
      SegmentCount = arrow.SegmentCount;
      Points = arrow.ControlPoints.GetArray();
    }
        
    public void CreateArrow(FlowChart surface, PointF offset)
    {
      PointF p = OffsetPoint(Points[0], offset);

      VisualOperation source = (VisualOperation)surface.GetTableAt(p);
      if (source == null)
      {
        p.X -= 26;
        source = (VisualOperation)surface.GetTableAt(p);
      }
      
      p = Points[Points.Length - 1];

      VisualOperation dest = (VisualOperation)surface.GetTableAt(p);
      if (dest == null)
      {
        p.X += 26;
        dest = (VisualOperation)surface.GetTableAt(p);
      }

      Arrow arrow = surface.CreateArrow(source, OrigIdx, dest, DestIdx);

      arrow.PenColor = PenColor;
      arrow.FillColor = PenColor;

      if (SegmentCount >= 3)
      {
        arrow.SegmentCount = SegmentCount;
        arrow.ControlPoints.Clear();
        for (int i = 0; i < Points.Length; i++)
        {
          arrow.ControlPoints.Add(OffsetPoint(Points[i], offset));
        }
      }

      arrow.UpdateFromPoints();

      VisualLink link = new VisualLink(arrow);
      arrow.Tag = link;
    }

    public string Id
    {
      get
      {
        return string.Format("{0}.{1}-{2}.{3}", OrigName, OrigIdx, DestName, DestIdx);
      }
    }
    
    public int DestIdx { get; set; }
    public int OrigIdx { get; set; }

    public Guid DestId { get; set; }
    public Guid OrigId { get; set; }

    public string DestName { get; set; }
    public string OrigName { get; set; }

    public PointF[] Points { get; set; }
    
    public Color PenColor { get; set; }

    public short SegmentCount { get; set; }

    public override bool Equals(object obj)
    {
      return this.Id == ((MemoryLink)obj).Id;
    }
    public override int GetHashCode()
    {
      return this.Id.GetHashCode();
    }

    public override string ToString()
    {
      return this.Id;
    }
  }
}
