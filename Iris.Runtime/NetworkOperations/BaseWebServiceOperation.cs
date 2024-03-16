using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Reflection;
using Iris.Runtime.Core.Networking;
using Iris.Runtime.Model.Operations.NetworkOperations;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.Runtime.Model.BaseObjects;
using Iris.PropertyEditors.PropertyEditors;
using Iris.Runtime.NetworkOperations;
using Iris.Interfaces;

namespace Iris.WebOperations
{
  [Serializable]
  public abstract class BaseWebServiceOperation : NetworkOperation, IBaseWebServiceOperation, ICredentialOperation
  {
    public BaseWebServiceOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      Port = 8080;
      UseDefaultCredentials = true;
      SetInputs("Configs");
    }

    protected void SetupConfigs()
    {
       if (GetInput("Configs") != null)
      {
        IScalarVar configVar = GetInput("Configs") as IScalarVar;
        if (configVar != null)
        {
          if (configVar.RawValue is WsConfigs)
          {
            WsConfigs configs = (WsConfigs)configVar.RawValue;
            configs.SetupOperation(this);
          }
        }
      }
    }

    protected string domain;
    protected string userName;
    protected string userPass;
    [NonSerialized]
    private NetworkCredential credentials;
    [Editor(typeof(CredentialsEditor), typeof(UITypeEditor))]
    [Category("Proxy Settings"), DisplayName("Usuário"), Description("Credenciais de acesso para o servidor de proxy")]
    public NetworkCredential Credentials
    {
      get
      {
        if ((credentials == null) &&
          ((!String.IsNullOrEmpty(userName) || (!String.IsNullOrEmpty(userPass)) || (!String.IsNullOrEmpty(domain)))))
        {
          Credentials = new NetworkCredential(userName, userPass, domain);
        }

        return credentials;
      }
      set
      {
        if (value != credentials)
        {
          wProxy = null;
          credentials = value;
          if (credentials != null)
          {
            userName = credentials.UserName;
            userPass = credentials.Password;
            domain = credentials.Domain;
          }
          Proxy.Credentials = credentials;
          UseDefaultCredentials = (value == null);
        }
      }
    }

    //protected string webDomain;
    //protected string webUserName;
    //protected string webUserPass;
    //[NonSerialized]
    //private NetworkCredential webCredentials;
    //[Editor(typeof(WebCredentialsEditor), typeof(UITypeEditor))]
    //[Category("Web Service"), DisplayName("Usuário"), Description("Credenciais de acesso para o servidor")]
    //public NetworkCredential WebCredentials
    //{
    //  get
    //  {
    //    if ((webCredentials == null) &&
    //      ((!String.IsNullOrEmpty(webUserName) || (!String.IsNullOrEmpty(webUserPass)) || (!String.IsNullOrEmpty(webDomain)))))
    //    {
    //      WebCredentials = new NetworkCredential(webUserName, webUserPass, webDomain);
    //    }

    //    return webCredentials;
    //  }
    //  set
    //  {
    //    if (value != webCredentials)
    //    {
    //      webCredentials = value;
    //      if (webCredentials != null)
    //      {
    //        webUserName = webCredentials.UserName;
    //        webUserPass = webCredentials.Password;
    //        webDomain = webCredentials.Domain;
    //      }

    //    }
    //  }
    //}



    [NonSerialized]
    protected ParameterInfo[] paramInfos;

    protected ParameterInfo[] ParamInfos
    {
      get 
      {
        if(paramInfos == null)
          paramInfos = Proxy.GetParameters(Method.Name);
        return paramInfos; 
      }
      set { paramInfos = value; }
    }

    protected string methodSignature;
    [NonSerialized]
    private MethodInfo method;
    [Category("Web Service"), DisplayName("Método"), Description("Método do web-service que será utilizado")]
    [Editor(typeof(WSMethodEditor), typeof(UITypeEditor))]
    public virtual MethodInfo Method
    {
      get
      {
        if (((proxy == null)|| (method ==null)) && (!String.IsNullOrEmpty(methodSignature)))
        {
          SetupWsdlLocation(wsdlLocation);
        }
        return method;
      }
      set
      {
        if (method != value)
        {
          method = value;
          paramInfos = Proxy.GetParameters(method.Name);
          methodSignature = method.ToString();
        }
      }
    }



    [NonSerialized]
    private MethodInfo[] methodList;
    [Browsable(false)]
    public MethodInfo[] MethodList
    {
      get { return methodList; }
    }

    private int port;
    [Category("Proxy Settings"), DisplayName("Port"), Description("Porta utilizada pelo servidor de proxy")]
    public int Port
    {
      get { return port; }
      set
      {
        if (value != port)
        {
          wProxy = null;
          port = value;
        }
      }
    }

    [NonSerialized]
    private DynamicProxy proxy;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected DynamicProxy Proxy
    {
      get
      {
        if (proxy == null)
        {
          proxy = new DynamicProxy(new Uri(wsdlLocation), WProxy);
          proxy.Credentials = WebCredentials;
        }
        return proxy;
      }
    }

    private string proxyServer;
    [Category("Proxy Settings"), DisplayName("Host"), Description("Endereço do proxy server")]
    public string ProxyServer
    {
      get { return proxyServer; }
      set
      {
        if (value != proxyServer)
        {
          wProxy = null;
          proxyServer = value;
        }

      }
    }

    private bool useDefaultCredentials;
    [Category("Proxy Settings"), DisplayName("Usar usuário padrão"), Description("Utiliza o usuário atual para acesso ao proxy")]
    public bool UseDefaultCredentials
    {
      get { return useDefaultCredentials; }
      set
      {
        if (useDefaultCredentials != value)
        {
          wProxy = null;
          useDefaultCredentials = value;
        }
      }
    }

    private bool useWebProxy;
    [Category("Proxy Settings"), DisplayName("Utilizar Proxy"), Description("Indica se será necessário o uso de um servidor de proxy")]
    public bool UseWebProxy
    {
      get { return useWebProxy; }
      set
      {
        if (value != useWebProxy)
        {
          if (!value)
          {
            ProxyServer = null;
            Credentials = null;
          }
          proxy = null;
          useWebProxy = value;
        }
      }
    }

    [NonSerialized]
    protected WebProxy wProxy;
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected WebProxy WProxy
    {
      get
      {
        if (UseWebProxy)
        {
          if (wProxy == null)
          {
            wProxy = new WebProxy(ProxyServer, Port);
            wProxy.UseDefaultCredentials = UseDefaultCredentials;
            if (!UseDefaultCredentials)
              wProxy.Credentials = Credentials;
          }
        }
        else
          wProxy = null;

        return wProxy;
      }
    }

    protected string wsdlLocation;
    [Category("Web Service"), DisplayName("WSDL"), Description("Endereço do documento wsdl de definição do webservice")]
    public virtual string WsdlLocation
    {
      get { return wsdlLocation; }
      set
      {
        if (wsdlLocation != value)
        {
          SetupWsdlLocation(value);
        }
      }
    }

    public override void AssignObject(object value)
    {
      this.WsdlLocation = Convert.ToString(value);
    }

    protected void SetupWsdlLocation(string value)
    {
      proxy = null;
      wsdlLocation = value;
      method = null;

      if (string.IsNullOrEmpty(wsdlLocation))
      {
        methodList = new MethodInfo[0];
      }
      else
      {
        methodList = Proxy.GetWebMethods();
        if ((methodList.Length > 0) && (string.IsNullOrEmpty(methodSignature)))
          Method = methodList[0];
        else
        {
          method = methodList.Where(x => x.ToString() == methodSignature).FirstOrDefault();
        }
      }
    }

    #region IBaseWebServiceOperation Members


    public Type GetRemoteType(string typeName)
    {
      return Proxy.GetRemoteType(typeName);
    }

    #endregion
  }
}
