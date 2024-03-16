using System;
using System.Data;
using System.Configuration;
using System.Web;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Forms.Hosts;
using MindFusion.Diagramming.WebForms;
using System.Web.UI;
using Gizmox.WebGUI.Common.Interfaces;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace IrisVwgControls
{
  [ToolboxItem(false)]
  public class CalBackManagerControl : System.Web.UI.WebControls.WebControl, ICallbackEventHandler
  {

    public static CalBackManagerControl CreateCallBackManager(string name, CallBackEventHandler handler)
    {
      CalBackManagerControl control = new CalBackManagerControl();
      control.CallBack += handler;
      control.ID = name;
      return control;
    }

    [field:NonSerialized]
    public event CallBackEventHandler CallBack;

    #region ICallbackEventHandler Members

    public string GetCallbackResult()
    {
      return result;
    }

    private string result;

    public string Result
    {
      get { return result; }
      set { result = value; }
    }

    public void RaiseCallbackEvent(string eventArgument)
    {
      if (CallBack != null)
      {
        CallBackEventArgs args = new CallBackEventArgs(eventArgument);
        CallBack(this, args);
        result = args.Result;
      }
    }    
    #endregion
  }  


}
