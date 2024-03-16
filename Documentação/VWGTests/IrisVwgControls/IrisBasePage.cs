using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Gizmox.WebGUI.Forms.Hosts;

namespace IrisVwgControls
{
  public class IrisBasePage : Page, ICallbackEventHandler 
  {

    public IrisBasePage()
    {
      reference = ClientScript.GetCallbackEventReference(this, "''", "'IrisFlowChart_DocClicked'", null); 
    }

    public string reference;
    
    private BaseIrisControlBox mobjPageContext = null;

    internal void SetHost(BaseIrisControlBox objPageContext)
    {
      mobjPageContext = objPageContext;
    }

    protected BaseIrisControlBox PageContext
    {
      get
      {
        return mobjPageContext;
      }
    }

    #region ICallbackEventHandler Members

    public string GetCallbackResult()
    {
      return "Teste";
    }

    public void RaiseCallbackEvent(string eventArgument)
    {
      if (string.IsNullOrEmpty(eventArgument))
      {

      }
    }

    #endregion
  }
}
