using Iris.Designer.VisualObjects;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using MindFusion.Diagramming.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Iris.Runtime.Model.Entities;
using Iris.Runtime.Model;
using Iris.Runtime.Core.Connections;

namespace Iris.Designer.DesignerActions
{
  [Serializable]
  public class MemoryObjectBundle : BaseMemoryObject
  {

    public MemoryObjectBundle(Selection selection)
    {
      operations = selection.Tables.Cast<Table>().Select(x => (VisualOperation)x).ToList();

      foreach (VisualOperation item in operations)
      {
        if (item.Operation is IResultSet)
        {
          if (((IResultSet)item).Table != null)
            ((IResultSet)item).Table = ((IResultSet)item).Table.Clone();
        }

        item.Surface = null;
        item.Operation.Structure = null;
      }

      links = selection.Arrows.Cast<Arrow>().Select(x => new MemoryLink(x)).ToList();

      links.AddRange(selection.Tables.Cast<Table>().
        SelectMany(x => x.OutgoingArrows.Cast<Arrow>().
          Where(w => operations.Contains((VisualOperation)w.Origin) &&
            operations.Contains((VisualOperation)w.Destination)
          ).Select(y => new MemoryLink(y))));
      links.AddRange(selection.Tables.Cast<Table>().SelectMany(x => x.IncomingArrows.Cast<Arrow>().
          Where(w => operations.Contains((VisualOperation)w.Origin) &&
            operations.Contains((VisualOperation)w.Destination)
          ).Select(y => new MemoryLink(y))));

      links = links.Distinct().ToList();
    }

    private List<VisualOperation> operations;
    private List<MemoryLink> links;

    public void Create(FlowChart surface, Structure structure, StructureDesigner designer)
    {
      CreateAt(surface, structure, designer, new PointF(0f, 0f));
    }

    public void CreateAt(FlowChart surface, Structure structure, StructureDesigner designer, PointF offset)
    {
      float x0 = operations.Min(o => o.BoundingRect.Left);
      float y0 = operations.Min(o => o.BoundingRect.Top);

      offset.X = x0 - offset.X;
      offset.Y = y0 - offset.Y;

      IEnumerable<VisualOperation> realOperatoins = operations.Where(x => !(x.Operation is IEntity));

      //verifica nomes/ids duplicados e trata os itens em memória de acordo
      while (structure.Operations.Any(x => realOperatoins.Select(y => y.Operation.Name).Contains(x.Name)))
      {
        IEnumerable<VisualOperation> repeated = realOperatoins.Where(x => structure.Operations.Select(y => y.Name).Contains(x.Operation.Name));
        foreach (VisualOperation oper in repeated)
        {
          oper.Operation.Name = oper.Operation.Name + "_";
        }
      }

      //itera operações e adiciona uma a uma com offset
      foreach (VisualOperation oper in operations)
      {
        if (surface.Tables.Cast<VisualOperation>().Any(x => x.Id == oper.Id))
          oper.RegenId();

        if (oper.Operation is IEntity)
        {
          IEntity entity = (IEntity)oper.Operation;
          if (entity is ResultSet) 
          {
            ResultSet rs = (ResultSet)entity;
            
            if(!structure.Connections.Any(x=> x.Name == rs.Connection.Name))
            {
              structure.Connections.Add(rs.Connection);
              designer.CreateVisualConnection(rs.Connection);
            }
            if(!structure.ResultSets.Any(x => x.Name == entity.Name))
              structure.ResultSets.Add(rs);            
          }

          if ((entity is ScalarVar) && (!structure.ScalarVars.Any(x => x.Name == entity.Name)))
          {
            structure.ScalarVars.Add((ScalarVar)entity);
            designer.CreateVisualVar((ScalarVar)entity);
          }
          if ((entity is SchemaEntity) && (!structure.Schemas.Any(x => x.Name == entity.Name)))
          {
            structure.Schemas.Add((SchemaEntity)entity);
            designer.CreateVisualSchema((SchemaEntity)entity);
          }
        }

        PointF location = new PointF(oper.BoundingRect.Left + offset.X, oper.BoundingRect.Top + offset.Y);

        oper.BoundingRect = new RectangleF(location, oper.BoundingRect.Size);

        oper.Operation.Structure = structure;
        surface.Add(oper);
      }


      //cria os links para as operações criadas
      //Talvez seja mais interessante achar as operações pelo id do que pela posição, 
      //para evitar links errados 
      //Re-atribuir a structure

      //Garantir que links só sejam carregados para itens que estão no bundle
      foreach (VisualOperation item in operations)
      {



      }

    }
  }
}
