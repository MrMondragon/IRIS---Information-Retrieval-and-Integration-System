using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.DisignSuport;
using System.Drawing;
using Iris.AxIntegration.Properties;
using Iris.Interfaces;

namespace Iris.AxIntegration
{
  [Serializable]
  [OperationCategory("Integração AX 4.0", "Logon")]
  public class Logon: AxOperation
  {
    public Logon(Structure aStructure, string aName)
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

    protected override IEntity doExecute()
    {
      base.doExecute();
      Context.Ax.Logon(Company, Language, ObjectServer, Configuration);
      return null;
    }

  }
}
