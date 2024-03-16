using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Iris.Runtime.NetworkOperations;

namespace Iris.WebOperations
{
  public class WsConfigs 
  {

    public WsConfigs(IBaseWebServiceOperation oper)
    {
      this.Credentials = oper.Credentials;
      this.Port = oper.Port;
      this.ProxyServer = oper.ProxyServer;
      this.UseDefaultCredentials = oper.UseDefaultCredentials;
      this.UseWebProxy = oper.UseWebProxy;
      this.WebCredentials = oper.WebCredentials;
      this.WsdlLocation = oper.WsdlLocation;
    }

    public void SetupOperation(IBaseWebServiceOperation oper)
    {
      oper.Credentials = this.Credentials;
      oper.Port = this.Port;
      oper.ProxyServer = this.ProxyServer;
      oper.UseDefaultCredentials = this.UseDefaultCredentials;
      oper.UseWebProxy = this.UseWebProxy;
      oper.WebCredentials = this.WebCredentials;
      oper.WsdlLocation = this.WsdlLocation;
    }

    public NetworkCredential Credentials
    {
      get;
      set;
    }   

    public NetworkCredential WebCredentials
    {
      get;
      set;
    }  

    public int Port
    {
      get;
      set;
    }

    public string ProxyServer
    {
      get;
      set;
    }

    public bool UseDefaultCredentials
    {
      get;
      set;
    }

    public bool UseWebProxy
    {
      get;
      set;
    }

    public string WsdlLocation
    {
      get;
      set;
    }

  }
}
