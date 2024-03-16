using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using System.Globalization;
using System.Text.RegularExpressions;

namespace IrisFlowChartEditor
{
  [ToolboxItem(true)]
  [ToolboxBitmapAttribute(typeof(IrisFlowChart), "IrisFlowChartEditor.IrisFlowChart.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  public partial class IrisFlowChart : Control
  {
    public IrisFlowChart()
    {
      this.TagName = "IrisFlowChartEditor.IrisFlowChart";
      InitializeComponent();
    }

    protected override void RenderAttributes(IContext context, IAttributeWriter writer)
    {
      base.RenderAttributes(context, writer);
      writer.WriteAttributeString("ClientID", this.ClientID);
      writer.WriteAttributeString("UniqueID", this.UniqueID);
      //writer.WriteAttributeString(WGAttributes.Source, sLink);
      
    }

    private string ClientID
    {
      get
      {
        return "CID_" + ((IRegisteredComponent)this).Guid.ToString();
      }
    }

    private string UniqueID
    {
      get
      {
        return "UID_" + ((IRegisteredComponent)this).Guid.ToString(); ;
      }
    }

    protected override void FireEvent(IEvent objEvent)
    {
      switch (objEvent.Type)
      {
        //case "ValueChange":
        //  this.mstrValue = objEvent[WGAttributes.Value];
        //  OnValueChanged(EventArgs.Empty);
        //  break;
        default:
          base.FireEvent(objEvent);
          break;
      }
    }

    protected override EventTypes GetCriticalEvents()
    {
      EventTypes enmEvents = base.GetCriticalEvents();
      //if (ValueChange != null) 
      //  enmEvents |= EventTypes.ValueChange;
      return enmEvents;
    }
  }
}
