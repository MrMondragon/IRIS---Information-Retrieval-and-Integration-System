using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.Designer.DesignerActions
{
  public class CreationAction: BaseDesignerAction
  {
    public CreationAction()
    {

    }

    public Operation MyProperty { get; set; }

    public override void Undo()
    {
      throw new NotImplementedException();
    }

    public override void Redo()
    {
      throw new NotImplementedException();
    }
  }
}
