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
  [OperationCategory("Integração AX 4.0", "Refresh")]
  public class Refresh : AxOperation
  {
    public Refresh(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected override IEntity doExecute()
    {
      base.doExecute();
      Context.Ax.Refresh();
      return null;
    }
  }
}
