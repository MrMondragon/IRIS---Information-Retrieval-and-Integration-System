#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;

using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Extensibility;
using System.Web;


using HtmlControls = System.Web.UI.HtmlControls;
using WebControls = System.Web.UI.WebControls;
using System.Reflection;
using System.Collections.Generic;
using System.Web.UI;

#endregion

namespace IrisVwgControls
{
  [ToolboxItem(false)]
  public class BaseIrisControlBox : Gizmox.WebGUI.Forms.Control, IGatewayControl
  {

    #region Members

    /// <summary>
    /// Holds reflection properties
    /// </summary>
    private Hashtable mobjProperties = null;

    /// <summary>
    /// Holds property values
    /// </summary>
    private Hashtable mobjPropertyValues = null;

    /// <summary>
    /// Holds reflection events.
    /// </summary>
    private Hashtable mobjEvents = null;

    /// <summary>
    /// Holds event handlers.
    /// </summary>
    private Hashtable mobjEventHandlers = null;

    /// <summary>
    /// Holds the live ASP.NET control
    /// </summary>
    private System.Web.UI.Control mobjHostedControl = null;

    #endregion

    #region C'Tor

    /// <summary>
    /// Create asp.net control box
    /// </summary>
    public BaseIrisControlBox()
    {
      this.TagName = WGTags.ASPXBox;

      // Create property storage
      mobjProperties = new Hashtable();
      mobjPropertyValues = new Hashtable();
      mobjEvents = new Hashtable();
      mobjEventHandlers = new Hashtable();
    }

    #endregion

    #region Methods

    #region Rendering & Gateway

    /// <summary>
    /// Render control attributes
    /// </summary>
    /// <param name="context"></param>
    /// <param name="writer"></param>
    protected override void RenderAttributes(IContext context, IAttributeWriter writer)
    {
      base.RenderAttributes(context, writer);
      writer.WriteAttributeString("Src", "../../../../../" + (new GatewayReference(this, "ASCXHost")).ToString());
    }

    protected System.Web.UI.Page page;

    /// <summary>
    /// Get ASP.NET page
    /// </summary>
    /// <returns></returns>
    protected System.Web.UI.Page CreateHostPage()
    {
      // Create aspx page
      System.Web.UI.Page objASPPage = new System.Web.UI.Page();

      // Create html tag
      HtmlControls.HtmlControl objASPHtml = new HtmlControls.HtmlGenericControl("html");
      objASPPage.Controls.Add(objASPHtml);

      // Create head
      HtmlControls.HtmlHead objASPHead = new HtmlControls.HtmlHead();
      HtmlControls.HtmlTitle objASPTitle = new HtmlControls.HtmlTitle();
      objASPHead.Controls.Add(objASPTitle);
      objASPHtml.Controls.Add(objASPHead);

      HtmlControls.HtmlControl objASPBody = new HtmlControls.HtmlGenericControl("body");
      objASPBody.Style.Add("margin", "0px");
      objASPBody.Style.Add("overflow", "hidden");
      objASPHtml.Controls.Add(objASPBody);

      // Create ascx control
      System.Web.UI.Control objASPControl = this.GetHostedControl();
      if (objASPControl != null)
      {
        // Get web control
        WebControls.WebControl objWebControl = objASPControl as WebControls.WebControl;
        if (objWebControl != null)
        {
          // Set control dimensions
          objWebControl.Height = new WebControls.Unit("100%");
          objWebControl.Width = new WebControls.Unit("100%");
          AddCustomAttributes(ref objASPPage, ref objWebControl);

        }

        // Get form
        HtmlControls.HtmlForm objASPForm = new HtmlControls.HtmlForm();
        objASPForm.Name = "form1";
        objASPBody.Controls.Add(objASPForm);

        // Add control to form
        objASPForm.Controls.Add(objASPControl);
        List<ICallbackEventHandler> callBackHandlers = GetCallBackHandlers();
        if (callBackHandlers != null)
        {
          foreach (ICallbackEventHandler handler in callBackHandlers)
          {
            System.Web.UI.Control control = handler as System.Web.UI.Control;
            if (control != null)
            {
              ((WebControls.WebControl)control).Attributes["runat"] = "server";
              objASPForm.Controls.Add(control);
            }
          }
        }
      }

      // Return aspx page
      page = objASPPage;
      return objASPPage;
    }

    protected virtual List<ICallbackEventHandler> GetCallBackHandlers()
    {
      return null;
    }

    protected virtual void AddCustomAttributes(ref System.Web.UI.Page objASPPage, ref System.Web.UI.WebControls.WebControl objWebControl)
    {      
    }

    #region IGatewayControl Members

    IGatewayHandler IGatewayControl.GetGatewayHandler(IContext objContext, string strAction)
    {
      IHttpHandler objHttpHandler = CreateHostPage();
      if (objHttpHandler != null)
      {
        objHttpHandler.ProcessRequest(objContext.HttpContext);
      }

      return null;
    }

    #endregion

    #endregion

    /// <summary>
    /// Create the hosted control
    /// </summary>
    /// <returns></returns>
    protected virtual System.Web.UI.Control GetHostedControl()
    {
      // Get the currently hosted control
      System.Web.UI.Control objControl = this.HostedControl;

      // If is stateless control
      if (this.IsStatelessHostedControl)
      {
        // Store state before destroying hosted control 
        StoreState();

        // Destroy the control after using it
        mobjHostedControl = null;

        RestoreState();
      }

      // Return the live control
      return objControl;
    }

    /// <summary>
    /// Sets a hosted control property value
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="objValue"></param>
    protected void SetProperty(string strName, object objValue)
    {
      // If there is a property info for this name
      PropertyInfo objPropertyInfo = GetPropertyInfo(strName);
      if (objPropertyInfo != null)
      {
        // If is state less control store property value on host
        if (this.IsStatelessHostedControl)
        {
          // Store property value
          mobjPropertyValues[strName] = objValue;
        }

        // If there is a live hosted control
        if (mobjHostedControl != null || !this.IsStatelessHostedControl)
        {
          // Set control value
          objPropertyInfo.SetValue(this.HostedControl, objValue, null);
        }
      }
    }

    /// <summary>
    /// Gets a hosted control boolean property value
    /// </summary>
    /// <param name="strName"></param>
    /// <returns></returns>
    protected bool GetBoolProperty(string strName)
    {
      return (bool)GetProperty(strName);
    }

    /// <summary>
    /// Gets a hosted control integer property value
    /// </summary>
    /// <param name="strName"></param>
    /// <returns></returns>
    protected int GetIntProperty(string strName)
    {
      return (int)GetProperty(strName);
    }

    /// <summary>
    /// Gets a hosted control color property value
    /// </summary>
    /// <param name="strName"></param>
    /// <returns></returns>
    protected Color GetColorProperty(string strName)
    {
      return (Color)GetProperty(strName);
    }

    /// <summary>
    /// Gets a hosted control property value
    /// </summary>
    /// <param name="strName"></param>
    /// <returns></returns>
    protected object GetProperty(string strName)
    {
      // If property value contains name
      if (this.IsStatelessHostedControl && mobjPropertyValues.Contains(strName))
      {
        return mobjPropertyValues[strName];
      }
      else
      {
        return GetHostedPropertyValue(strName);
      }
    }

    /// <summary>
    /// Add an event handler to one of the control's event infos.
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="objEventHandler"></param>
    protected void AddEventHandler(string strName, Delegate objEventHandler)
    {
      // If there is an event info for this name
      EventInfo objEventInfo = GetEventInfo(strName);

      if (objEventInfo != null)
      {
        // If is state less control store event handler on host
        if (this.IsStatelessHostedControl)
        {
          // Get the event info's event handlers sorted list.
          ArrayList objEventHandlers = null;
          if (mobjEventHandlers.Contains(strName) && mobjEventHandlers[strName] != null)
          {
            objEventHandlers = mobjEventHandlers[strName] as ArrayList;
          }
          else
          {
            objEventHandlers = new ArrayList();
            mobjEventHandlers.Add(strName, objEventHandlers);
          }

          if (objEventHandlers != null)
          {
            // Store the event handler
            objEventHandlers.Add(objEventHandler);
          }
        }

        // If there is a live hosted control
        if (mobjHostedControl != null || !this.IsStatelessHostedControl)
        {
          // Ad an event handler.
          objEventInfo.AddEventHandler(this.HostedControl, objEventHandler);
        }
      }
    }

    /// <summary>
    /// Removes an event handler from one of the control's event infos.
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="objEventHandler"></param>
    protected void RemoveEventHandler(string strName, Delegate objEventHandler)
    {
      // If there is an event info for this name
      EventInfo objEventInfo = GetEventInfo(strName);

      if (objEventInfo != null)
      {
        // If is state less control store event handler on host
        if (this.IsStatelessHostedControl && mobjEventHandlers.Contains(strName))
        {
          // Get the event info's event handlers sorted list.
          if (mobjEventHandlers.Contains(strName) && mobjEventHandlers[strName] != null)
          {
            ArrayList objEventHandlers = mobjEventHandlers[strName] as ArrayList;

            if (objEventHandlers != null && objEventHandlers.Contains(objEventHandler))
            {
              // Removes the event handler from sorted list.
              objEventHandlers.Remove(objEventHandler);
            }
          }
        }

        // If there is a live hosted control
        if (mobjHostedControl != null || !this.IsStatelessHostedControl)
        {
          // Removes the event's handler.
          objEventInfo.RemoveEventHandler(this.HostedControl, objEventHandler);
        }
      }
    }

    /// <summary>
    /// Gets a hosted control property value
    /// </summary>
    /// <param name="strName"></param>
    /// <returns></returns>
    private object GetHostedPropertyValue(string strName)
    {
      // Get property value
      PropertyInfo objPropertyInfo = GetPropertyInfo(strName);
      if (objPropertyInfo != null)
      {
        return objPropertyInfo.GetValue(this.HostedControl, null);
      }
      else
      {
        return null;
      }
    }

    /// <summary>
    /// Get property info
    /// </summary>
    /// <param name="strName"></param>
    /// <returns></returns>
    protected PropertyInfo GetPropertyInfo(string strName)
    {
      PropertyInfo objPropertyInfo = null;

      // If there is a cached property info
      if (mobjProperties.Contains(strName))
      {
        // Get cached property info
        objPropertyInfo = mobjProperties[strName] as PropertyInfo;
      }

      // If no cached property info
      if (objPropertyInfo == null)
      {
        // Get property info
        mobjProperties[strName] = objPropertyInfo = this.HostedControlType.GetProperty(strName);
      }

      // Return property info
      return objPropertyInfo;
    }

    /// <summary>
    /// Get an event information object.
    /// </summary>
    /// <param name="strEventName"></param>
    /// <returns></returns>
    protected EventInfo GetEventInfo(string strName)
    {
      EventInfo objEventInfo = null;

      // If there is a cached event info
      if (mobjEvents.Contains(strName))
      {
        // Get cached event info
        objEventInfo = mobjEvents[strName] as EventInfo;
      }

      // If no cached event info
      if (objEventInfo == null)
      {
        // Get property info
        mobjEvents[strName] = objEventInfo = this.HostedControlType.GetEvent(strName);
      }

      // Return property info
      return objEventInfo;
    }


    /// <summary>
    /// Apply hosted control properties
    /// </summary>
    private void ApplyControlProperties()
    {
      // If there is a valid hosted control
      if (mobjHostedControl != null && this.IsStatelessHostedControl)
      {
        // Loop all property infos
        foreach (PropertyInfo objPropertyInfo in mobjProperties.Values)
        {
           

          if ((objPropertyInfo != null) && (mobjPropertyValues.Contains(objPropertyInfo.Name) && objPropertyInfo.CanWrite))
          {
            // Set current property value
            objPropertyInfo.SetValue(mobjHostedControl, mobjPropertyValues[objPropertyInfo.Name], null);
          }
        }
      }
    }

    /// <summary>
    /// Apply hosted control events
    /// </summary>
    private void ApplyControlEvents()
    {
      // If there is a valid hosted control
      if (mobjHostedControl != null && this.IsStatelessHostedControl)
      {
        // Loop all event infos
        foreach (EventInfo objEventInfo in mobjEvents.Values)
        {
          if (mobjEventHandlers.Contains(objEventInfo.Name) && mobjEventHandlers[objEventInfo.Name] != null)
          {
            ArrayList objEventHandlers = mobjEventHandlers[objEventInfo.Name] as ArrayList;

            if (objEventHandlers != null)
            {
              foreach (Delegate objEventHandler in objEventHandlers)
              {
                // Add an event handler to the current event info.
                objEventInfo.AddEventHandler(this.HostedControl, objEventHandler);
              }
            }
          }
        }
      }
    }

    /// <summary>
    /// Called after hosted control was created to enable restoring state
    /// </summary>
    protected virtual void RestoreState()
    {
    }

    /// <summary>
    /// Called before hosted control is destroyed to enable storing state
    /// </summary>
    protected virtual void StoreState()
    {
    }

    /// <summary>
    /// Creates the hosted control instance based on a givven type
    /// </summary>
    /// <param name="objType"></param>
    /// <returns></returns>
    protected virtual System.Web.UI.Control CreateHostedControlInstance(Type objType)
    {
      return Activator.CreateInstance(objType) as System.Web.UI.Control;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Get the currently hosted control
    /// </summary>
    protected System.Web.UI.Control HostedControl
    {
      get
      {
        // If hosted control needs to be created
        if (mobjHostedControl == null)
        {
          // Create hosted control from hosted control type
          mobjHostedControl = CreateHostedControlInstance(this.HostedControlType);

          // Apply properties to the newly created control
          ApplyControlProperties();

          // Apply events to the newly created control
          ApplyControlEvents();

          // Restore custom state
          RestoreState();
        }

        return mobjHostedControl;
      }
    }

    /// <summary>
    /// The hosted ASP.NET control type
    /// </summary>
    protected virtual Type HostedControlType
    {
      get
      {
        return typeof(System.Web.UI.Control);
      }
    }

    /// <summary>
    /// Indicates if the control should be created and destroyed on every request
    /// </summary>
    protected virtual bool IsStatelessHostedControl
    {
      get
      {
        return true;
      }
    }

    #endregion

  }
}
