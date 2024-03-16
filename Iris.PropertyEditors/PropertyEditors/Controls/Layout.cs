using System;
using System.Collections.Generic;
using System.Text;
using MindFusion.Diagramming.WinForms.Layout;
using MindFusion.Diagramming.WinForms;
using System.ComponentModel;

namespace Iris.PropertyEditors.PropertyEditors.Controls
{

public class LayeredLayout : ILayout
{
  // Fields
  private LayoutProgress progress;
  private Direction direction;
  private long timeLimit;
  private float layerDistance;
  private float arrowsCompactFactor;
  private Anchoring anchoring;
  private bool keepGroups;
  private float yGap;
  private bool splitLayers;
  private Node node;
  private float nodeDistance;
  private float xGap;
  private Orientation orientation;

  // Methods
  public LayeredLayout()
  {
    this.keepGroups = false;
    this.anchoring = Anchoring.Ignore;
    this.orientation = Orientation.Vertical;
    this.direction = Direction.Straight;
    this.layerDistance = 25f;
    this.nodeDistance = 20f;
    this.xGap = 5f;
    this.yGap = 5f;
    this.splitLayers = false;
    this.arrowsCompactFactor = 1f;
    this.timeLimit = 10000L;
  }

  public LayeredLayout(Orientation orientation, float layerDistance, float nodeDistance, float xGap, float yGap)
  {
    this.keepGroups = false;
    this.anchoring = Anchoring.Ignore;
    this.orientation = orientation;
    this.direction = Direction.Straight;
    this.layerDistance = layerDistance;
    this.nodeDistance = nodeDistance;
    this.xGap = xGap;
    this.yGap = yGap;
    this.splitLayers = false;
    this.arrowsCompactFactor = 1f;
    this.timeLimit = 10000L;
  }

  public virtual bool Arrange(FlowChart chart)
  {
    FCGraph initial = new FCGraph(chart, this.keepGroups);
    INode node = null;
    if (this.node != null)
    {
      foreach (FCNode node2 in initial.Nodes)
      {
        if (node2.Node == this.node)
        {
          node = node2;
          break;
        }
      }
    }
    IGraph[] graphArray = GraphSplitter.Split(initial, new FCGraphBuilder(chart, false));
    if (node == null)
    {
      foreach (Arrow arrow in chart.Arrows)
      {
        if (!arrow.x1a39e60e215cc3be())
        {
          arrow.AutoRoute = false;
          arrow.Style = ArrowStyle.Polyline;
          arrow.SegmentCount = 1;
        }
      }
    }
    else
    {
      foreach (FCGraph graph2 in graphArray)
      {
        if (graph2.Nodes.Contains(node))
        {
          foreach (FCLink link in graph2.Links)
          {
            Arrow arrow2 = link.Arrow;
            if (!arrow2.x1a39e60e215cc3be())
            {
              arrow2.AutoRoute = false;
              arrow2.Style = ArrowStyle.Polyline;
              arrow2.SegmentCount = 1;
            }
          }
          break;
        }
      }
    }
    LayeredLayout layout = new LayeredLayout();
    LayoutProgress progress = null;
    if (this.progress != null)
    {
      progress = new LayoutProgress(this.xd4978173eeda0a28);
    }
    LayeredLayoutInfo info = new LayeredLayoutInfo();
    info.ArrowsCompactFactor = this.ArrowsCompactFactor;
    info.Direction = (Direction) this.Direction;
    info.LayerDistance = this.LayerDistance;
    info.NodeDistance = this.NodeDistance;
    info.Orientation = (Orientation) this.Orientation;
    info.SplitLayers = this.SplitLayers;
    info.XGap = this.XGap;
    info.YGap = this.YGap;
    info.TimeLimit = this.TimeLimit;
    float xGap = this.XGap;
    foreach (FCGraph graph3 in graphArray)
    {
      if ((node == null) || graph3.Nodes.Contains(node))
      {
        layout.Arrange(graph3, info, progress);
        RectangleF bounds = graph3.GetBounds(true);
        float num2 = xGap - bounds.X;
        float num3 = this.YGap - bounds.Y;
        foreach (FCNode node3 in graph3.Nodes)
        {
          RectangleF ef2 = node3.Bounds;
          ef2.X += num2;
          ef2.Y += num3;
          node3.Bounds = ef2;
        }
        foreach (FCLink link2 in graph3.Links)
        {
          if (link2.Arrow.RetainForm)
          {
            continue;
          }
          for (int i = 1; i < (link2.Arrow.Points.Count - 1); i++)
          {
            PointF tf = link2.Arrow.Points[i];
            tf.X += num2;
            tf.Y += num3;
            link2.Arrow.Points[i] = tf;
          }
        }
        xGap += bounds.Width + this.XGap;
        foreach (FCLink link3 in graph3.Links)
        {
          Arrow arrow3 = link3.Arrow;
          if (arrow3.IgnoreLayout)
          {
            continue;
          }
          if (arrow3.SegmentCount == 1)
          {
            arrow3.x68d0a5cdf5dccb1a(this.anchoring);
          }
          else
          {
            int orgnAnchor = arrow3.OrgnAnchor;
            int destAnchor = arrow3.DestAnchor;
            arrow3.Points[0] = arrow3.x31eebfc56db21c95().x7516705f40340873(arrow3.Origin.x769b17159954d995(), arrow3.Points[1]);
            arrow3.Points[arrow3.Points.Count - 1] = arrow3.x74b20f8b013a77b4().x7516705f40340873(arrow3.Points[arrow3.Points.Count - 2], arrow3.Destination.x769b17159954d995());
            int num7 = 0;
            switch (this.anchoring)
            {
              case Anchoring.Ignore:
                goto Label_058C;

              case Anchoring.Keep:
                if (orgnAnchor >= 0)
                {
                  arrow3.OrgnAnchor = -1;
                  arrow3.OrgnAnchor = orgnAnchor;
                }
                if (destAnchor >= 0)
                {
                  arrow3.DestAnchor = -1;
                  arrow3.DestAnchor = destAnchor;
                }
                goto Label_058C;

              case Anchoring.Reassign:
                arrow3.Points[0] = arrow3.Origin.x5222ffcca77ccfec(arrow3.Points[0], arrow3, false, ref num7);
                arrow3.Points[arrow3.Points.Count - 1] = arrow3.Destination.x5222ffcca77ccfec(arrow3.Points[arrow3.Points.Count - 1], arrow3, true, ref num7);
                goto Label_058C;
            }
          }
        Label_058C:
          arrow3.UpdateFromPoints();
        }
      }
    }
    chart.Invalidate();
    chart.UndoManager.xa4e23896540466aa(undoEnabled);
    chart.UndoManager.xcbca249fb1cadf1e();
    return true;
  }

  private void xd4978173eeda0a28(int x3bd62873fafa6252, int xb1c30745a1525188)
  {
    this.progress(x3bd62873fafa6252, xb1c30745a1525188);
  }

  // Properties
  [Description("Specifies how to align arrows to the anchor points of nodes."), Category("Settings"), DefaultValue(typeof(Anchoring), "Ignore")]
  public Anchoring Anchoring
  {
    get
    {
      return this.anchoring;
    }
    set
    {
      this.anchoring = value;
    }
  }

  [Description("A value indicating how much to compact the outermost arrows."), DefaultValue((float) 1f), Category("Settings")]
  public float ArrowsCompactFactor
  {
    get
    {
      return this.arrowsCompactFactor;
    }
    set
    {
      this.arrowsCompactFactor = value;
    }
  }

  [Category("Settings"), DefaultValue(typeof(Direction), "Straight"), Description("The direction of the layout.")]
  public Direction Direction
  {
    get
    {
      return this.direction;
    }
    set
    {
      this.direction = value;
    }
  }

  [Category("Settings"), DefaultValue(false), Description("A flag specifying whether the node disposition within groups is kept intact.")]
  public bool KeepGroupLayout
  {
    get
    {
      return this.keepGroups;
    }
    set
    {
      this.keepGroups = value;
    }
  }

  [Category("Settings"), DefaultValue((float) 25f), Description("The distance between adjacent layers.")]
  public float LayerDistance
  {
    get
    {
      return this.layerDistance;
    }
    set
    {
      this.layerDistance = value;
    }
  }

  [Category("Settings"), Description("The minimal distance between adjacent nodes on the same layer."), DefaultValue((float) 20f)]
  public float NodeDistance
  {
    get
    {
      return this.nodeDistance;
    }
    set
    {
      this.nodeDistance = value;
    }
  }

  [Description("The orientation of the layout."), Category("Settings"), DefaultValue(typeof(Orientation), "Vertical")]
  public Orientation Orientation
  {
    get
    {
      return this.orientation;
    }
    set
    {
      this.orientation = value;
    }
  }

  [DefaultValue((string) null), Browsable(false)]
  public LayoutProgress Progress
  {
    get
    {
      return this.progress;
    }
    set
    {
      this.progress = value;
    }
  }

  [DefaultValue((string) null), Browsable(false)]
  public Node Root
  {
    get
    {
      return this.node;
    }
    set
    {
      this.node = value;
    }
  }

  [Browsable(false), DefaultValue(false)]
  public bool SplitLayers
  {
    get
    {
      return this.splitLayers;
    }
    set
    {
      this.splitLayers = value;
    }
  }

  [Category("Settings"), Description("A time-out value for the path-finding part of the layered layout algorithm."), DefaultValue((long) 10000L)]
  public long TimeLimit
  {
    get
    {
      return this.timeLimit;
    }
    set
    {
      this.timeLimit = value;
    }
  }

  [Description("The distance between the leftmost node in the arranged diagram and the left border of the document."), DefaultValue((float) 5f), Category("Settings")]
  public float XGap
  {
    get
    {
      return this.xGap;
    }
    set
    {
      this.xGap = value;
    }
  }

  [Description("The distance between the topmost node in the arranged diagram and the top border of the document."), Category("Settings"), DefaultValue((float) 5f)]
  public float YGap
  {
    get
    {
      return this.yGap;
    }
    set
    {
      this.yGap = value;
    }
  }



  #region ILayout Members


  public LayoutLink LayoutLink
  {
    get
    {
      throw new Exception("The method or operation is not implemented.");
    }
    set
    {
      throw new Exception("The method or operation is not implemented.");
    }
  }

  public LayoutNode LayoutNode
  {
    get
    {
      throw new Exception("The method or operation is not implemented.");
    }
    set
    {
      throw new Exception("The method or operation is not implemented.");
    }
  }

  #endregion
}

  public enum Direction
  {
    Straight,
    Reversed
  }

 

}
