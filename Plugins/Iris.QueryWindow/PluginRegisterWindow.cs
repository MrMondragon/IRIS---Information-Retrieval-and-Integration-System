using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.Designer.PluginSupport;
using Iris.Plugins.Properties;
using LicencingBase;

namespace Iris.Plugins
{
  public class PluginRegisterWindow : BaseToolbarPlugin
  {
    protected override string GetHint()
    {
      return "Gerenciar Plugins";
    }

    protected override System.Drawing.Image GetImage()
    {
      return Resources.Plugins;
    }

    public override void DoExecute()
    {
      PluginRegistrator plugDlg = new PluginRegistrator();
      plugDlg.ShowDialog();      
    }
  }
}
