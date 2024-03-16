using System;
using System.Collections.Generic;
using System.Text;
using Iris.ControlOperations.ProcessOperations;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.PropertyEditors
{
  public class VerbSelectorEditor: BaseListEditor<string>
  {
    protected override List<string> GetItems(object obj)
    {
      IRunProcess instance = (IRunProcess)obj;
      string[] verbs; 

      if (instance.ProcInfo != null)
        verbs = instance.ProcInfo.Verbs;
      else
        verbs = new string[0];

      return new List<string>(verbs);
    }
  }
}
