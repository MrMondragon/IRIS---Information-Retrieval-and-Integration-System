using System;
using System.Collections.Generic;
using System.Text;
using Iris.Designer.BuildSupport;
using System.Drawing;
using Iris.BuilderPlugin.Properties;

namespace Iris.BuilderPlugin
{
  public class PlugBuilderPlugin: BaseAssemblyBuilder 
  {
    protected override string GetHint()
    {
      return "Compilar Plugin";
    }

    protected override Image GetImage()
    {
      return Resources.BuildPlug;
    }

    public override void DoExecute()
    {
      BuildAssembly(BuildType.Plugin);
    }
  }
}


