using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors
{
  public class EndPointEditor : BaseListEditor<IEntity>
  {
    protected override List<IEntity> GetItems(object obj)
    {
      IStructure structure = ((IStructure)obj);
      List<IEntity> list = new List<IEntity>();
      list.AddRange((IEntity[])structure.ResultSets);
      list.AddRange((IEntity[])structure.ScalarVars);
      return list;      
    }
  }
}
