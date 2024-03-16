using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LicencingBase
{
  [Serializable]
  public class LicenceFile
  {
    public LicenceFile()
    {
      registeredServers = new List<RegisteredServer>();
    }

    private string clientName;

    public string ClientName
    {
      get { return clientName; }
      set { clientName = value; }
    }

    private List<RegisteredServer> registeredServers;

    public List<RegisteredServer> RegisteredServers
    {
      get { return registeredServers; }
      set { registeredServers = value; }
    }
  }
}
