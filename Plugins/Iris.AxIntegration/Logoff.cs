using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.Drawing;
using Iris.AxIntegration.Properties;
using Iris.Interfaces;

namespace Iris.AxIntegration
{
  [Serializable]
  [OperationCategory("Integração AX 4.0", "Logoff")]
  public class Logoff: AxOperation
  {
    public Logoff(Structure aStructure, string aName)
      : base(aStructure, aName)
    {      
    }
       
    protected override IEntity doExecute()
    {
      base.doExecute();
      Context.Ax.Logoff();
      return null;
    }
  }
}
