#if !LockClient
using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;

namespace Iris.Runtime.Model.ClientObjects
{
  [Serializable]
  public class ProccessLog: List<LogItem> 
  {
    private DateTime startTime;

    public DateTime StartTime
    {
      get { return startTime; }
      set { startTime = value; }
    }

    private DateTime endTime;

    public DateTime EndTime
    {
      get { return endTime; }
      set { endTime = value; }
    }

    private bool error;

    public bool Error
    {
      get { return error; }
      set { error = value; }
    }

    public override string ToString()
    {
      string err;
      if (error)
        err = "Erro! - ";
      else
        err = "OK - ";

      return err + String.Format("{0} {1}", StartTime, EndTime);
    }

    public List<LogItem> Items
    {
      get { return this; }
    }
  }
}
#endif