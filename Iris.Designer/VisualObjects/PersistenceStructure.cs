using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Iris.Runtime.Model.BaseObjects;
using System.Drawing;
using MindFusion.Diagramming.WinForms;
using Databridge.Engine;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model;
using Iris.Runtime.Core.Connections;

namespace Iris.Designer.VisualObjects
{
  [Serializable]
  public class PersistenceStructure : IDisposable
  {
    private PersistenceStructure(Structure structure, FlowChart surface, string outputPath)
    {
      this.structure = structure;
      operations = new List<PersistenceOperation>();
      foreach (Table table in surface.Tables)
        operations.Add(new PersistenceOperation((VisualOperation)table));

      links = new List<PersistenceLink>();
      foreach (Arrow arrow in surface.Arrows)
      {
        //TODO - TESTAR SE AS DUAS PONTAS PERTENCEM À ESTRUTURA ANTES DE ADICIONAR
        links.Add(new PersistenceLink(arrow));
      }
      this.outputPath = outputPath;
    }

    public void Paste(Structure structure, FlowChart surface, PointF origin, StructureDesigner designer)
    {
      float x0 = operations.Min(o => o.rect.Left);
      float y0 = operations.Min(o => o.rect.Top);
      PointF offset = new PointF(origin.X - x0, origin.Y - y0);

      operations.ForEach(x => x.ApplyOffset(offset));
      links.ForEach(x => x.ApplyOffset(offset));

      //verifica nomes/ids duplicados e trata os itens em memória de acordo
      while (structure.Operations.Any(x => this.structure.Operations.Select(y => y.Name).Contains(x.Name)))
      {
        IEnumerable<IOperation> repeated = this.structure.Operations.Where(x => structure.Operations.Select(y => y.Name).Contains(x.Name));
        foreach (IOperation oper in repeated)
        {
          oper.Name = oper.Name + "_";
        }
      }

      //Adiciona novas entidades à estrutura
      IEnumerable<DynConnection> newConnections = this.structure.Connections.Where(x => !structure.Connections.Any(y => y.Name == x.Name));
      foreach (DynConnection connection in newConnections)
        structure.Connections.Add(connection);

      IEnumerable<ResultSet> newResultsets = this.structure.ResultSets.Where(x => !structure.ResultSets.Any(y => y.Name == x.Name));
      foreach (ResultSet rs in newResultsets)
        structure.ResultSets.Add(rs);

      IEnumerable<ScalarVar> newScalarVars = this.structure.ScalarVars.Where(x => !structure.ScalarVars.Any(y => y.Name == x.Name));
      foreach (ScalarVar sv in newScalarVars)
        structure.ScalarVars.Add(sv);

      IEnumerable<SchemaEntity> newSchemaEntities = this.structure.Schemas.Where(x => !structure.Schemas.Any(y => y.Name == x.Name));
      foreach (SchemaEntity schema in newSchemaEntities)
        structure.Schemas.Add(schema);



      //Redireciona conexões
      this.structure.ResultSets.ForEach(x => x.Connection = structure.Connections.FindByName(x.Connection.Name));

      //redireciona strucutre
      operations.ForEach(x => x.Operation.Structure = structure);

      CreateOperations(surface, this);

      CreateLinks(surface, this);

    }

    public static PersistenceStructure GetPersistenceStructure(Selection selection, Structure structure)
    {
      Structure tmpStructure = new Structure();

      if (selection.Tables.Count > 0)
      {
        foreach (Table item in selection.Tables)
        {
          VisualOperation vo = item as VisualOperation;

          switch (vo.Operation.OperationType)
          {
            case OperationType.Operation:
              tmpStructure.Operations.Add(vo.Operation);
              break;
            case OperationType.ResultSet:
              {
                if (!tmpStructure.Contains(vo.Operation.Name))
                {
                  ResultSet rs = (ResultSet)vo.Operation;
                  tmpStructure.ResultSets.Add(rs);
                  if (!tmpStructure.Contains(rs.Connection.Name))
                  {
                    tmpStructure.Connections.Add(rs.Connection);
                  }
                }
              }
              break;
            case OperationType.ScalarVar:
              {
                if (!tmpStructure.Contains(vo.Operation.Name))
                {
                  tmpStructure.ScalarVars.Add((ScalarVar)vo.Operation);
                }
              }
              break;
            case OperationType.Schema:
              if (!tmpStructure.Contains(vo.Operation.Name))
              {
                tmpStructure.Schemas.Add((SchemaEntity)vo.Operation);
              }
              break;
          }
        }
      }
      return new PersistenceStructure(tmpStructure, selection.Parent, "");
    }

    public static void SaveStructure(string fileName, Structure structure, FlowChart surface, string outputPath)
    {
      PersistenceStructure vStructure = new PersistenceStructure(structure, surface, outputPath);
      PersistenceManager<PersistenceStructure>.SaveToFile(fileName, vStructure);
      vStructure.Dispose();
    }

    public static void LoadStructure(string fileName, FlowChart surface, string outputPath, StructureDesigner designer)
    {
      designer.AutoBackup = false;

      designer.loading = true;
      try
      {
        PersistenceStructure vStructure = PersistenceManager<PersistenceStructure>.LoadFromFile(fileName, designer.typeLookupTable);

        designer.outputPath = vStructure.outputPath;
        Structure structure = vStructure.Structure;
        designer.Structure = structure;

        designer.ClearAll();

        CreateEntities(designer, structure);

        CreateOperations(surface, vStructure);

        CreateLinks(surface, vStructure);

        designer.InitStructure();
        designer.RefreshEntryPoins();
        designer.PaintBreakPoints();

        designer.AfterDexChanged(null, null);
      }
      finally
      {
        designer.loading = false;
        designer.AutoBackup = true;
      }
    }

    private static VisualOperation GetObjectById(FlowChart surface, Guid? id)
    {
      if (!id.HasValue)
        return null;

      VisualOperation vo = surface.Tables.Cast<Table>().
        Where(x => (x is VisualOperation) && ((VisualOperation)x).Id == id).
        Select(y => ((VisualOperation)y)).FirstOrDefault();

      return vo;
    }

    private static void CreateLinks(FlowChart surface, PersistenceStructure vStructure)
    {
      foreach (PersistenceLink pl in vStructure.links)
      {
        VisualOperation orig = null;
        orig = GetObjectById(surface, pl.idOrig);
        if (orig == null)
        {
          orig = (VisualOperation)surface.GetTableAt(pl.points[0]);
          if (orig == null)
          {
            PointF p = pl.points[0];
            p.X -= 26;
            orig = (VisualOperation)surface.GetTableAt(p);
          }
        }

        VisualOperation dest = null;
        dest = GetObjectById(surface, pl.idDest);
        if (dest == null)
        {
          dest = (VisualOperation)surface.GetTableAt(pl.points[pl.points.Count - 1]);
          if (dest == null)
          {
            PointF p = pl.points[pl.points.Count - 1];
            p.X += 26;
            dest = (VisualOperation)surface.GetTableAt(p);
          }
        }
        Arrow arrow = surface.CreateArrow(orig, pl.link.origIdx, dest, pl.link.destIdx);

        arrow.PenColor = pl.penColor;
        arrow.FillColor = pl.penColor;

        if (pl.segmentCount >= 3)
        {
          arrow.SegmentCount = pl.segmentCount;
          arrow.ControlPoints.Clear();
          for (int i = 0; i < pl.points.Count; i++)
          {
            arrow.ControlPoints.Add(pl.points[i]);
          }
        }
        arrow.UpdateFromPoints();

        VisualLink link = new VisualLink(arrow);
        arrow.Tag = link;

      }
    }

    private static void CreateOperations(FlowChart surface, PersistenceStructure vStructure)
    {
      foreach (PersistenceOperation po in vStructure.operations)
      {
        IOperation oper = (IOperation)vStructure.structure.GetObject(po.name);

        if (GetObjectById(surface, po.Id) != null)
        {
          UpdateIds(po, vStructure);
        }

        VisualOperation vo = new VisualOperation(surface, oper, vStructure.structure, po.x, po.y);
  
        vo.Id = po.Id;
      }
    }

    private static void UpdateIds(PersistenceOperation po, PersistenceStructure vStructure)
    {
      Guid oldId = po.Id;

      Guid newId = Guid.NewGuid();
      foreach (PersistenceLink link in vStructure.links)
      {
        if (link.idOrig == oldId)
          link.idOrig = newId;

        if (link.idDest == oldId)
          link.idDest = newId;
      }
      po.Id = newId;
    }

    private static void CreateEntities(StructureDesigner designer, Structure structure)
    {
      for (int i = 0; i < structure.Connections.Count; i++)
      {
        if ((designer.Structure == structure) || (!designer.Structure.Connections.Any(x => x.Name == structure.Connections[i].Name)))
          designer.CreateVisualConnection(structure.Connections[i]);
      }

      for (int i = 0; i < structure.ResultSets.Count; i++)
      {
        if ((designer.Structure == structure) || (!designer.Structure.ResultSets.Any(x => x.Name == structure.ResultSets[i].Name)))
          designer.CreateVisualResultSet(structure.ResultSets[i]);
      }

      for (int i = 0; i < structure.ScalarVars.Count; i++)
      {
        if ((designer.Structure == structure) || (!designer.Structure.ScalarVars.Any(x => x.Name == structure.ScalarVars[i].Name)))
          designer.CreateVisualVar(structure.ScalarVars[i]);
      }

      for (int i = 0; i < structure.Schemas.Count; i++)
      {
        if ((designer.Structure == structure) || (!designer.Structure.Schemas.Any(x => x.Name == structure.Schemas[i].Name)))
          designer.CreateVisualSchema(structure.Schemas[i]);
      }
    }

    internal string outputPath;
    private Structure structure;

    private Structure Structure
    {
      get { return structure; }
      set { structure = value; }
    }
    private List<PersistenceOperation> operations;
    private List<PersistenceLink> links;

    #region IDisposable Members

    public void Dispose()
    {
      structure = null;
      operations.Clear();
      links.Clear();
    }

    #endregion
  }

  [Serializable]
  class PersistenceOperation
  {
    public PersistenceOperation(VisualOperation oper)
    {
      name = oper.Operation.Name;
      rect = oper.BoundingRect;
      Operation = oper.Operation;
      Id = oper.Id;
    }

    public Guid Id { get; set; }

    internal IOperation Operation { get; set; }

    internal void ApplyOffset(PointF offset)
    {
      rect = new RectangleF(x + offset.X, y + offset.Y, rect.Width, rect.Height);
    }

    internal string name;
    internal RectangleF rect;
    internal float x
    {
      get { return rect.Left; }
    }
    internal float y
    {
      get { return rect.Top; }
    }
  }

  [Serializable]
  class PersistenceLink
  {
    public PersistenceLink(Arrow arrow)
    {
      link = (VisualLink)arrow.Tag;
      penColor = arrow.PenColor;
      segmentCount = arrow.SegmentCount;
      points = new List<PointF>();
      for (int i = 0; i < arrow.ControlPoints.Count; i++)
      {
        points.Add(arrow.ControlPoints[i]);
      }

      idOrig = ((VisualOperation)arrow.Origin).Id;
      idDest = ((VisualOperation)arrow.Destination).Id;
    }

    internal void ApplyOffset(PointF offset)
    {
      for (int i = 0; i < points.Count; i++)
      {
        points[i] = new PointF(points[i].X + offset.X, points[i].Y + offset.Y);
      }
    }

    internal Guid? idOrig;
    internal Guid? idDest;
    internal VisualLink link;
    internal Color penColor;
    internal List<PointF> points;
    internal short segmentCount;
  }

}
