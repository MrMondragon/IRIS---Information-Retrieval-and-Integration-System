using System;
using System.Collections.Generic;
using System.Text;
using Iris.Designer.BuildSupport;
using System.Drawing;
using Iris.BuilderPlugin.Properties;

namespace Iris.BuilderPlugin
{
  public class AssemblyBuilderPlugin: BaseAssemblyBuilder 
  {
    protected override string GetHint()
    {
      return "Compilar Assembly";
    }

    protected override Image GetImage()
    {
      return Resources.BuildDll;
    }

    public override void DoExecute()
    {
      BuildAssembly(BuildType.Assembly);
    }
  }
}
