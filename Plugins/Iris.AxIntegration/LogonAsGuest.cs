using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Interfaces;
using Iris.Runtime.Model.BaseObjects;
using System.Net;
using System.ComponentModel;
using System.Drawing;
using Iris.AxIntegration.Properties;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing.Design;

namespace Iris.AxIntegration
{
  [Serializable]
  [OperationCategory("Integração AX 4.0", "Logon As Guest")]
  public class LogonAsGuest : AxOperation, ICredentialOperation
  {
    public LogonAsGuest(Structure aStructure, string aName)
      : base(aStructure, aName)
    {      
    }

    private string company;

    public string Company
    {
      get { return company; }
      set { company = value; }
    }

    private string language;

    public string Language
    {
      get { return language; }
      set { language = value; }
    }

    private string objectServer;

    public string ObjectServer
    {
      get { return objectServer; }
      set { objectServer = value; }
    }

    private string configuration;

    public string Configuration
    {
      get { return configuration; }
      set { configuration = value; }
    }

    private NetworkCredential credentials;
    [Editor(typeof(CredentialsEditor), typeof(UITypeEditor))]
    public NetworkCredential Credentials
    {
      get { return credentials; }
      set { credentials = value; }
    }

    protected override IEntity doExecute()
    {
      base.doExecute();
      Context.Ax.LogonAsGuest(Credentials, Company, Language, ObjectServer, Configuration);
      return null;
    }


  }
}
