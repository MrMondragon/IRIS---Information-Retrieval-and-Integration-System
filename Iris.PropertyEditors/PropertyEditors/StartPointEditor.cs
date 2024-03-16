using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors
{
  public class StartPointEditor: BaseListEditor<IOperation>
  {

    protected override List<IOperation> GetItems(object obj)
    {
      return new List<IOperation>(((IStructure)obj).Operations);
    }
  }
}
