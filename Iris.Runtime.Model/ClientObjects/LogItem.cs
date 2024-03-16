using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Runtime.Model.ClientObjects
{
  [Serializable]
  public class LogItem : Iris.Runtime.Model.ClientObjects.ILogItem
  {
    public LogItem(string logEntry, string procName)
    {
      Init(logEntry, procName);
    }

    public LogItem(string aName, Exception e, string procName)
    {
      string logEntry = "Falha na execução de [" + aName + "]. Mensagem original: " + GetFullErrorMessage(e);
      error = true;
      Init(logEntry, procName);
    }

    private void Init(string logEntry, string procName)
    {
      time = DateTime.Now;
      text = string.Format("{0} {1} -> {2}", time.ToString(), procName, logEntry);
    }

    /// <summary>
    /// Retorna a mensagem de erro completa, incluindo possíveis excessões internas
    /// </summary>
    /// <param name="e">Exception</param>
    /// <returns></returns>
    private string GetFullErrorMessage(Exception e)
    {
      string msg = e.Message;
      if (e.InnerException != null)
        msg += " | " + GetFullErrorMessage(e.InnerException);
      return msg;
    }



    public override string ToString()
    {
      return Text;
    }

    public object[] GetItemArray()
    {
      return new object[] { Time, Text, Error };
    }

    private string text;

    public string Text
    {
      get { return text; }     
    }
    private bool error;

    public bool Error
    {
      get { return error; }
      set { error = value; }
    }
    private DateTime time;

    public DateTime Time
    {
      get { return time; }
    }
  }
}
