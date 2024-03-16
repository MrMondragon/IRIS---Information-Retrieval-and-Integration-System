using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using Iris.AxIntegration.Properties;
using System.Drawing;
using System.ComponentModel;

[assembly: OperationPluginAssembly]

namespace Iris.AxIntegration
{
  [Serializable]
  public abstract class AxOperation: Operation
  {
    public AxOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Entrada AX");
    }

    public static Bitmap GetIcon()
    {
      return Resources.Ax;
    }
    
    [NonSerialized]
    protected AxContext context;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public AxContext Context
    {
      get { return context; }
    }

    protected override IEntity doExecute()
    {
      if (GetInput(0) is AxOperation)
        context = ((AxOperation)GetInput(0)).Context;
      else
        context = new AxContext();

      return null;
    }
  }
}
