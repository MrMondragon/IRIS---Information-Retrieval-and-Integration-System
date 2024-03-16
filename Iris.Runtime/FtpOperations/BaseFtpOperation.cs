using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Interfaces;
using System.ComponentModel;
using Iris.Runtime.Model.Entities;

namespace Iris.Runtime.Model.Operations.FtpOperations
{
  [Serializable]
  public abstract class BaseFtpOperation : Operation
  {
    public BaseFtpOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
      SetInputs("Folder");

      server = "localhost";
      remotePort = 21;
      port = 21;
      timeOut = 10;
      username = "anonymous";
      password = "anonymous@anonymous.net";
    }

    private bool verboseLog;

    public bool VerboseLog
    {
      get { return verboseLog; }
      set { verboseLog = value; }
    }

    private string server;

    public string Server
    {
      get { return server; }
      set { server = value; }
    }

    private string username;

    public string Username
    {
      get { return username; }
      set { username = value; }
    }

    private string password;

    public string Password
    {
      get { return password; }
      set { password = value; }
    }

    private int timeOut;

    public int TimeOut
    {
      get { return timeOut; }
      set { timeOut = value; }
    }

    private int port;

    public int Port
    {
      get { return port; }
      set { port = value; }
    }

    private bool binaryMode;

    public bool BinaryMode
    {
      get { return binaryMode; }
      set { binaryMode = value; }
    }

    private int remotePort;

    public int RemotePort
    {
      get { return remotePort; }
      set { remotePort = value; }
    }


    protected FtpClient Client
    {
      get
      {
        return new FtpClient(Server, Username, Password, Structure.Log);
      }
    }
    private string dir;
    [DisplayName("Folder"), Category("Arquivo"), Description("O caminho de origem dos arquivos")]
    public virtual string Dir
    {
      get
      {
        IOperation oper = GetInput(0);
        if (oper != null)
        {
          ScalarVar var = oper.EntityValue as ScalarVar;
          if (var != null)
            return Convert.ToString(var.RawValue);
          else
            return string.Empty;
        }
        else
          return dir;
      }
      set { dir = value; }
    }

    protected override IEntity doExecute()
    {
      return null;
    }

  }
}
