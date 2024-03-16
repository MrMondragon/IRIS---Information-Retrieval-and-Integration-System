using System;
using System.Linq;
using System.Collections.Generic;
using Iris.Runtime.Model.ClientObjects;

namespace Iris.Interfaces
{
  public interface IProccessLog
  {
    void AddToLog(string logEntry, IOperation operation);
    void AddToLog(string aName, Exception e, IOperation operation);
    void AddToErrorLog(string logEntry, IOperation operation);
    void ClearLog();
    List<ILogItem> GetEntries();    
  }


  public static class ProcessLogExtensions
  {
    public static bool HasErrors(this IProccessLog log)
    {
      return log.GetEntries().Any(x => x.Error);
    }
  }
}
