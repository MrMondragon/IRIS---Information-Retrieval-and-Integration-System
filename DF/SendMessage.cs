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
  [OperationCategory("Operações de WF", "Send")]
  public class SendMessage : Operation
  {
    public SendMessage(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Msg");
    }

    public static Bitmap GetIcon()
    {
      return Resources.sound2;
    }

    protected override Iris.Interfaces.IEntity doExecute()
    {
      return null;
      
    }
  }
}
