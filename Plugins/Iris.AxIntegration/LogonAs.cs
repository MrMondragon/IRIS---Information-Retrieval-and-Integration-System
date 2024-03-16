using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.Drawing;
using Iris.AxIntegration.Properties;
using System.Net;
using Iris.Interfaces;
using System.ComponentModel;
using Iris.PropertyEditors;
using System.Drawing.Design;
using Iris.PropertyEditors.PropertyEditors;

namespace Iris.AxIntegration
{
  [Serializable]
  [OperationCategory("Integração AX 4.0", "Logon As")]
  public class LogonAs : AxOperation, ICredentialOperation
  {
    public LogonAs(Structure aStructure, string aName)
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
      Context.Ax.LogonAs(Credentials.UserName, Credentials.Domain, Credentials, Company, Language, ObjectServer, Configuration);
      return null;
    }

  }
}
