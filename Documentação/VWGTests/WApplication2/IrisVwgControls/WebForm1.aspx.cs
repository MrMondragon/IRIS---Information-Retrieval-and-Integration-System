using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace WApplication2
{
  public partial class WebForm1 : System.Web.UI.Page, ICallbackEventHandler
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Session["Text"] = "Tadaaaaa";
    }

    #region ICallbackEventHandler Members

    public string GetCallbackResult()
    {
      return Convert.ToString(Session["Text"]);
    }

    public void RaiseCallbackEvent(string eventArgument)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion
  }
}
