using System;
using System.Collections.Generic;
using System.Text;
using Iris.Plugins.Properties;
using Iris.Designer;
using Iris.Designer.PluginSupport;
using Iris.Designer.Plugins;


namespace Iris.Plugins
{
  public class QueryWindowPlugin : BaseToolbarPlugin
  {
    protected override string GetHint()
    {
      return "Query Window (Ctrl+W)";
    }

    protected override System.Drawing.Image GetImage()
    {
      return Resources.ImediateWindow;
    }

    public override void DoExecute()
    {
      QueryWindow queryWindow = new QueryWindow(this.Structure);
      queryWindow.Show();
    }

    protected override bool isHotKey(System.Windows.Forms.KeyEventArgs e)
    {
      return ((e.Control) && (e.KeyValue == 87));
    }
  }
}
