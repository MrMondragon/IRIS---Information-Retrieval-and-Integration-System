using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Gizmox.WebGUI.Forms.Hosts
{
  public class BasePage : Page
  {

    private BaseHostControl mobjPageContext = null;

    internal void SetHost(BaseHostControl objPageContext)
    {
      mobjPageContext = objPageContext;
    }

    protected BaseHostControl PageContext
    {
      get
      {
        return mobjPageContext;
      }
    }
  }
}
