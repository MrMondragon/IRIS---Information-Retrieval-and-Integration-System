using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using System.Net;
using System.ComponentModel;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing.Design;
using Iris.Interfaces;
using Iris.Runtime.NetworkOperations;

namespace Iris.Runtime.Model.Operations.NetworkOperations
{
  [Serializable]
  public abstract class NetworkOperation : Operation, INetworkOperation
  {
    public NetworkOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {

    }

    protected string webDomain;
    protected string webUserName;
    protected string webUserPass;
    [NonSerialized]
    protected NetworkCredential webCredentials;
    [Category("Web Service"), DisplayName("Usuário"), Description("Credenciais de acesso para o servidor")]
    [Editor(typeof(WebCredentialsEditor), typeof(UITypeEditor))]
    public virtual NetworkCredential WebCredentials
    {
      get
      {
        if ((webCredentials == null) &&
          ((!String.IsNullOrEmpty(webUserName) || (!String.IsNullOrEmpty(webUserPass)) || (!String.IsNullOrEmpty(webDomain)))))
        {
          WebCredentials = new NetworkCredential(webUserName, webUserPass, webDomain);
        }

        return webCredentials;
      }
      set
      {

        webCredentials = value;
        if (webCredentials != null)
        {
          webUserName = webCredentials.UserName;
          webUserPass = webCredentials.Password;
          webDomain = webCredentials.Domain;
        }

      }
    }

  }
}
