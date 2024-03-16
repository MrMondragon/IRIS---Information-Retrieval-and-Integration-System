using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.Drawing;
using DF.Properties;


namespace DF
{
  [Serializable]
  [OperationCategory("Operações de WF", "Event")]
  public class Evt: Operation
  {
    public Evt(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    public static Bitmap GetIcon()
    {
      return Resources.evt;
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      return null;
      
    }
  }
}
