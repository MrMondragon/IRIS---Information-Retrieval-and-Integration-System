#region Using

using System;
using System.IO;
using System.Web;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections;

using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Extensibility;


#endregion

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>
  /// Summary description for ASPXHostBox
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmapAttribute(typeof(BaseHostControl), "Gizmox.WebGUI.Forms.Hosts.AspPageBox.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  public class BaseHostControl : Control, IGatewayControl
  {
    private string mstrPath = "";

    public BaseHostControl()
    {
      this.TagName = WGTags.ASPXBox;
    }


    protected override void RenderAttributes(IContext context, IAttributeWriter writer)
    {
      base.RenderAttributes(context, writer);
      string strDir = System.IO.Path.GetDirectoryName(mstrPath) + "/";
      if (strDir == "/") strDir = "";
      strDir = strDir.Replace(@"\", "/");
      writer.WriteAttributeString("Src", "../../../../../" + strDir + (new GatewayReference(this, "ASPXhost")).ToString());
    }


    /// <summary>
    /// The path of the asp page to be displayed
    /// </summary>
    public string Path
    {
      get
      {
        return mstrPath;
      }
      set
      {
        if (mstrPath != value)
        {
          this.mstrPath = value;
          this.Update();
        }
      }
    }

    #region IGatewayControl Members

    IGatewayHandler IGatewayControl.GetGatewayHandler(IContext objContext, string strAction)
    {
      string strUrl = string.Format("~/{0}", mstrPath.Replace("\\", "/"));

      try
      {

        IHttpHandler objHttpHandler = (System.Web.UI.Page)System.Web.UI.PageParser.GetCompiledPageInstance(strUrl, objContext.Server.MapPath(strUrl), objContext.HttpContext);
        if (objHttpHandler != null)
        {
          BasePage objAspPageBase = objHttpHandler as BasePage;
          if (objAspPageBase != null)
          {
            objAspPageBase.SetHost(this);
          }
          objHttpHandler.ProcessRequest(objContext.HttpContext);
          return null;
        }
      }
      catch (Exception objEx)
      {
        throw objEx;//new HttpException(404, string.Format("ASPX page '{0}' was not found.", strUrl));
      }
      return null;
    }

    #endregion
  }
}