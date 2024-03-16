using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using MindFusion.Diagramming.WinForms;

namespace Iris.Designer.DesignerActions
{
  public class MovementAction : BaseDesignerAction
  {
    public MovementAction(Table[] tables, Dictionary<Table, System.Drawing.PointF> oldCoords)
    {
      this.oldCoords = oldCoords;
      this.newCoords = tables.ToDictionary(x => x, y => new PointF(y.BoundingRect.Left, y.BoundingRect.Top));
    }

    private Dictionary<Table, System.Drawing.PointF> oldCoords;
    private Dictionary<Table, System.Drawing.PointF> newCoords;


    public override void Undo()
    {
      MoveTables(oldCoords);
    }

    private void MoveTables(Dictionary<Table, System.Drawing.PointF> coords)
    {
      Manager.LockActions();
      try
      {
        foreach (KeyValuePair<Table, PointF> item in coords)
        {
          item.Key.Move(item.Value.X, item.Value.Y);
        }
      }
      finally
      {
        Manager.UnlockActions();
      }
    }

    public override void Redo()
    {
      MoveTables(newCoords);
    }

    public override bool AllowNewAction(BaseDesignerAction action)
    {
      if (!(action is MovementAction))
        return true;
      else
      {
        MovementAction movement = (MovementAction)action;
        bool allow = true;

        if (movement.oldCoords.Count == this.newCoords.Count)
        {
          foreach (KeyValuePair<Table, PointF> item in this.newCoords)
          {
            if (movement.newCoords.ContainsKey(item.Key))
            {
              allow &= (Math.Abs(item.Value.X - movement.newCoords[item.Key].X) > 1) &&
                (Math.Abs(item.Value.Y - movement.newCoords[item.Key].Y) > 1);
            }

            if (!allow)
              break;
          }
        }

        return allow;

      }
    }
  }
}
