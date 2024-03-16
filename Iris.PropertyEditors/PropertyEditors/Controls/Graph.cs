using System;
using System.Collections.Generic;
using System.Text;
using MindFusion.Diagramming.WinForms;

namespace Iris.PropertyEditors.PropertyEditors.Controls
{
internal class FCGraph : IGraph
{
  // Fields
  private List<INode> nodes;
  private FlowChart surface;
  private List<ILink> links;

  // Methods
  public FCGraph(FlowChart chart)
  {
    this.surface = chart;
    this.nodes = new List<INode>();
    this.links = new List<ILink>();
  }

  public FCGraph(FlowChart chart, bool keepGroups)
  {
    this.surface = chart;
    this.xda09af88ab899a50(keepGroups, false);
  }

  public FCGraph(FlowChart chart, bool keepGroups, bool ignoreArrowDirection)
  {
    this.surface = chart;
    this.xda09af88ab899a50(keepGroups, ignoreArrowDirection);
  }

  protected virtual IFactory CreateFactory()
  {
    return new StraightFactory();
  }

  public RectangleF GetBounds(bool includeLinks)
  {
    RectangleF empty = RectangleF.Empty;
    foreach (FCNode node in this.nodes)
    {
      empty = Utilities.unionNonEmptyRects(empty, node.Bounds);
    }
    if (includeLinks)
    {
      foreach (FCLink link in this.links)
      {
        foreach (PointF tf in link.Arrow.Points)
        {
          empty = Utilities.unionRects(empty, new RectangleF(tf, SizeF.Empty));
        }
      }
    }
    return empty;
  }

  private void xda09af88ab899a50(bool xb76644e6f42ff960, bool x2abca50552cb1ab7)
  {
    IFactory factory = this.CreateFactory();
    this.nodes = new NodeCollection();
    foreach (Box box in this.surface.Boxes)
    {
      if (box.Frozen)
      {
        continue;
      }
      if (xb76644e6f42ff960)
      {
        if ((box.MasterGroup == null) || (box.MasterGroup.MainObject is Arrow))
        {
          this.nodes.Add(factory.CreateNode(box, xb76644e6f42ff960, x2abca50552cb1ab7));
        }
        continue;
      }
      this.nodes.Add(factory.CreateNode(box, xb76644e6f42ff960, x2abca50552cb1ab7));
    }
    foreach (ControlHost host in this.surface.ControlHosts)
    {
      if (host.Frozen)
      {
        continue;
      }
      if (xb76644e6f42ff960)
      {
        if ((host.MasterGroup == null) || (host.MasterGroup.MainObject is Arrow))
        {
          this.nodes.Add(factory.CreateNode(host, xb76644e6f42ff960, x2abca50552cb1ab7));
        }
        continue;
      }
      this.nodes.Add(factory.CreateNode(host, xb76644e6f42ff960, x2abca50552cb1ab7));
    }
    foreach (Table table in this.surface.Tables)
    {
      if (table.Frozen)
      {
        continue;
      }
      if (xb76644e6f42ff960)
      {
        if ((table.MasterGroup == null) || (table.MasterGroup.MainObject is Arrow))
        {
          this.nodes.Add(factory.CreateNode(table, xb76644e6f42ff960, x2abca50552cb1ab7));
        }
        continue;
      }
      this.nodes.Add(factory.CreateNode(table, xb76644e6f42ff960, x2abca50552cb1ab7));
    }
    this.links = factory.Links;
  }

  // Properties
  public virtual RectangleF DocRect
  {
    get
    {
      return this.surface.DocExtents;
    }
  }

  public virtual LinkCollection Links
  {
    get
    {
      return this.links;
    }
  }

  public virtual NodeCollection Nodes
  {
    get
    {
      return this.nodes;
    }
  }

  public INode Root
  {
    get
    {
      foreach (INode node in this.nodes)
      {
        if (node.InLinks.Count == 0)
        {
          return node;
        }
      }
      return null;
    }
  }
}

  interface ILink
  {
    // Methods
    void SetPoints(ArrayList points);

    // Properties
    INode Destination { get; }
    INode Origin { get; }
    float Weight { get; }
  }

  interface INode
  {
    // Properties
    RectangleF Bounds { get; set; }
    object Data { get; set; }
    LinkCollection InLinks { get; }
    LinkCollection OutLinks { get; }
    float Weight { get; }
  }

  internal interface IGraph
  {
    // Properties
    RectangleF DocRect { get; }
    LinkCollection Links { get; }
    NodeCollection Nodes { get; }
  }


}
