using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Designer.DesignerActions
{
  public abstract class BaseDesignerAction
  {
    public ActionManager Manager { get; set; }

    public abstract void Undo();

    public abstract void Redo();

    public virtual bool AllowNewAction(BaseDesignerAction action)
    {
      return true;

    }
  }
}
