using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Databridge.Interfaces;
using System.ComponentModel;
using Databridge.Engine;
using Databridge.Engine.Parsers;
using Databridge.Engine.Parsers.MergerObjects;
using Databridge.PropertyEditors;
using System.Drawing.Design;

namespace Iris.Runtime.LogOperations
{
  [Serializable]
  public abstract class BaseLogOperation : Operation
  {
    public BaseLogOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    private string message;
    public virtual string Message
    {
      get
      {
        return message;
      }
      set
      {
        message = value;
      }
    }

    protected override void doAfterExecute()
    {
    }

    protected override void doBeforeExecute()
    {
    }

    [Browsable(false)]
    public string MergedMessage
    {
      get
      {
        ExecutionContext context = Structure.GetContext();
        MergerParser parser = MergerParser.GetParser();
        MergingObject mObj = parser.Parse(Message, context);
        return mObj.MergedText;
      }
    }

  }
}
