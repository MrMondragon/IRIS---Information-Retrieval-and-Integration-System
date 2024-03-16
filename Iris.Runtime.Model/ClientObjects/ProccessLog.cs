using System;
using System.Collections.Generic;
using System.Text;
using Iris.Interfaces;
using System.Linq;

namespace Iris.Runtime.Model.ClientObjects
{
  [Serializable]
  public class ProccessLog: List<LogItem>, IProccessLog 
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

    [field: NonSerialized()]
    public event EventHandler<LogEventArgs> OnAddItem;

    private void AddItem(LogItem item)
    {
      this.Add(item);
      if (OnAddItem != null)
        OnAddItem(this, new LogEventArgs(item.ToString(), item.Error));
    }

    #region IProccessLog Members

    public void AddToLog(string logEntry, IOperation operation)
    {
      if(operation != null)
        AddItem(new LogItem(logEntry, operation.Name));
      else
        AddItem(new LogItem(logEntry, ""));
    }

    public void AddToLog(string aName, Exception e, IOperation operation)
    {
      error = true;
      if (operation != null)
        AddItem(new LogItem(aName, e, operation.Name));
      else
        AddItem(new LogItem(aName, e, ""));
    }

    public void AddToErrorLog(string logEntry, IOperation operation)
    {
      string procName = "";
      if (operation != null)
        procName = operation.Name;

      LogItem item = new LogItem(logEntry, procName);
      item.Error = true;
      AddItem(item);
    }

    public void ClearLog()
    {
      this.Clear();
    }


    public List<ILogItem> GetEntries()
    {
      return this.Select(x => (ILogItem)x).ToList();
    }

    #endregion

  }
}