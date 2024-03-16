using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LicencingBase
{
  [Serializable]
  public class AuthorizedPlugin
  {
    private string pluginName;

    public string PluginName
    {
      get { return pluginName; }
      set { pluginName = value; }
    }

    private string pluginAssembly;

    public string PluginAssembly
    {
      get { return pluginAssembly; }
      set { pluginAssembly = value; }
    }

    private DateTime? expireDate;

    public DateTime? ExpireDate
    {
      get { return expireDate; }
      set { expireDate = value; }
    }
  }
}
