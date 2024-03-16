using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.Drawing;
using Iris.AxIntegration.Properties;

namespace Iris.AxIntegration
{
  [Serializable]
  [OperationCategory("Integração AX 4.0", "Begin")]
  public class TTSBegin: AxOperation
  {
    public TTSBegin(Structure aStructure, string aName)
      : base(aStructure, aName)
    {      
    }

    protected override IEntity doExecute()
    {
      base.doExecute();
      Context.Ax.TTSBegin();
      return null;
    }
  }
}
