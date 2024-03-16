using System;
using System.Collections.Generic;
using System.Text;
using Iris.PropertyEditors;

namespace Iris.AxIntegration.Editors
{
  public class ContainerSelectorEditor: BaseListEditor<string>
  {
    protected override List<string> GetItems(object obj)
    {
      AxContext context = (AxContext)obj;
      return context.GetContainerNames();
    }
  }
}