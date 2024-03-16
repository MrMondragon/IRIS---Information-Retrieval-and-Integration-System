using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LicencingBase
{
  [Serializable]
  public class RegisteredServer
  {
    public RegisteredServer()
    {
      authorizedPlugins = new List<AuthorizedPlugin>();
    }

    private string macAddress;

    public string MacAddress
    {
      get { return macAddress; }
      set { macAddress = value; }
    }

    private List<AuthorizedPlugin> authorizedPlugins;

    public List<AuthorizedPlugin> AuthorizedPlugins
    {
      get { return authorizedPlugins; }
      set { authorizedPlugins = value; }
    }
  }
}
