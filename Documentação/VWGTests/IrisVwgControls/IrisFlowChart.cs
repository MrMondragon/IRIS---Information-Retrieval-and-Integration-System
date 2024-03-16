#region Using

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
using Gizmox.WebGUI;
using System.Reflection;

#endregion


namespace IrisVwgControls
{
  /// <summary>Encapsulates the methods and properties used for the ReportViewer control.</summary>
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItem(true)]
  public class IrisFlowChart : BaseIrisControlBox
  {

    public IrisFlowChart()
    {
      SetupProperties();
      SetupClientEventData();
    }

    private void SetupClientEventData()
    {
      clientEventArgs = new Dictionary<string, string>();
      callBackArgs = new Dictionary<string, string>();

      clientEventArgs["ArrowClicked"] = "(arrow, mouseX, mouseY, button)";
      callBackArgs["ArrowClicked"] = "var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex()";

      clientEventArgs["ArrowCreated"] = "(arrow)";
      callBackArgs["ArrowCreated"] = "var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex()";

      clientEventArgs["ArrowCreating"] = "(arrow, mouseX, mouseY)";
      callBackArgs["ArrowCreating"] = "var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex()";

      clientEventArgs["ArrowDblClicked"] = "(arrow, mouseX, mouseY, button)";
      callBackArgs["ArrowDblClicked"] = "var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex()";

      clientEventArgs["ArrowDeleted"] = "(arrow)";
      callBackArgs["ArrowDeleted"] = "var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex()";

      clientEventArgs["ArrowDeleting"] = "(arrow)";
      callBackArgs["ArrowDeleting"] = "var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex()";

      clientEventArgs["DocClicked"] = "(mouseX, mouseY, button)";
      callBackArgs["DocClicked"] = "var args = mouseX+';'+mouseY";

      clientEventArgs["DocDblClicked"] = "(mouseX, mouseY, button)";
      callBackArgs["DocDblClicked"] = "var args = String(mouseX)+';'+String(mouseY)";

      clientEventArgs["TableClicked"] = "(table, mouseX, mouseY, button)";
      callBackArgs["TableClicked"] = "var args = String(table.tag)";

      clientEventArgs["TableCreated"] = "(table)";
      callBackArgs["TableCreated"] = "var args = String(table.tag)";

      clientEventArgs["TableCreating"] = "(table, mouseX, mouseY)";
      callBackArgs["TableCreating"] = "var args = String(table.tag)+';'+mouseX+';'+mouseY";

      clientEventArgs["TableDblClicked"] = "(table, mouseX, mouseY, button)";
      callBackArgs["TableDblClicked"] = "var args = String(table.tag)+';'+mouseX+';'+mouseY";

      clientEventArgs["TableDeleted"] = "(table)";
      callBackArgs["TableDeleted"] = "var args = String(table.tag)";

      clientEventArgs["TableDeleting"] = "(table)";
      callBackArgs["TableDeleting"] = "var args = String(table.tag)";

      clientEventArgs["TableSelected"] = "(table)";
      callBackArgs["TableSelected"] = "var args = String(table.tag)";

      clientEventArgs["TableDeselected"] = "(table)";
      callBackArgs["TableDeselected"] = "var args = String(table.tag)";
    }

    private void SetupProperties()
    {
      BackColor = Color.White;
      this.SetProperty("AllowRefLinks", false);
      this.SetProperty("AllowSplitArrows", true);
      this.SetProperty("AllowUnanchoredArrows", false);
      this.SetProperty("AntiAlias", System.Drawing.Drawing2D.SmoothingMode.AntiAlias);
      this.SetProperty("ArrowCascadeOrientation", Gizmox.WebGUI.Forms.Orientation.Horizontal);
      this.SetProperty("ArrowColor", Color.Black);
      this.SetProperty("ArrowCrossings", ArrowCrossings.Arcs);
      this.SetProperty("ArrowEndsMovable", false);
      this.SetProperty("ArrowHead", ArrowHead.BowArrow);
      this.SetProperty("ArrowHeadSize", 16);
      this.SetProperty("ArrowIntermSize", 16);
      this.SetProperty("ArrowSegments", (Int16)3);
      this.SetProperty("ArrowStyle", ArrowStyle.Cascading);
      this.SetProperty("Behavior", BehaviorType.CreateArrow);
      this.SetProperty("CrossingRadius", 4F);
      this.SetProperty("DisabledMnpColor", Color.Gray);
      this.SetProperty("GridColor", Color.FromArgb(224, 224, 224));
      this.SetProperty("GridSizeX", 6F);
      this.SetProperty("GridSizeY", 6F);
      this.SetProperty("GridStyle", GridStyle.Lines);
      this.SetProperty("ShowGrid", true);
      this.SetProperty("MeasureUnit", System.Drawing.GraphicsUnit.Pixel);
      this.SetProperty("DocExtents", new RectangleF(0, 0, this.Width * 10, this.Height * 10));
      this.SetProperty("InplaceEditFont", new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0));
      this.SetProperty("SelHandleSize", 8F);
      this.SetProperty("TableCaptionHeight", 23);
      this.SetProperty("TableColWidth", 30F);
      this.SetProperty("TableRowCount", 0);
      this.SetProperty("TableRowHeight", 17);
      this.SetProperty("ID", "flowChart");
      this.SetProperty("BackColor", Color.White);
    }

    private Dictionary<string, string> callBackArgs;
    private Dictionary<string, string> clientEventArgs;

    /// <summary>
    /// Stores the reporting state
    /// </summary>
    protected override void StoreState()
    {
      state = Surface.SaveToString(true);
    }

    private string state;

    /// <summary>
    /// Restores the reporting state
    /// </summary>
    protected override void RestoreState()
    {
      if (!string.IsNullOrEmpty(state))
        Surface.LoadFromString(state);
    }

    /// <summary>
    /// Return the hosted control type
    /// </summary>
    protected override Type HostedControlType
    {
      get
      {
        return typeof(FlowChart);
      }
    }

    protected FlowChart Surface
    {
      get
      {
        return HostedControl as FlowChart;
      }
    }

    [DefaultValue(typeof(Color), "#FFFFFF")]
    [Browsable(false)]
    public override Color BackColor
    {
      get
      {
        return Color.White;
      }
      set
      {

      }
    }

    public string ID
    {
      get
      {
        return Convert.ToString(GetProperty("ID"));
      }
      set
      {
        SetProperty("ID", value);
      }
    }

    protected override bool IsStatelessHostedControl
    {
      get
      {
        return base.IsStatelessHostedControl;
      }
    }


    protected override void AddCustomAttributes(ref IrisBasePage page, ref WebControl control)
    {
      //Os eventos são criados e registrados dinamicamente para permitir que seja feita uma referência ao Guid do controle,
      //não acessível no cliente
      Type type = this.GetType();
      foreach (KeyValuePair<string, string> clientEvent in clientEventArgs)
      {
        string key = clientEvent.Key;

        //define o nome da função utilizando o ID do componente e o GUID do host
        string functionName = ID + this.Guid + "_on" + key;
        //define o corpo da função
        string script = "<script type=text/javascript> \r\n function ";
        script += functionName + clientEventArgs[key];
        script += "\r\n{\r\n";

        script += callBackArgs[key]+";\r\n";
        script += "var guid = " + this.Guid + ";\r\n";
        script += page.ClientScript.GetCallbackEventReference(page, "args", "IrisFlowChart_Alert", "");
        //script += "var event = Events_CreateEvent(guid, '" + key + "', true);\r\n";
        //script += "Events_SetEventAttribute(event, 'Attr.Value', args);\r\n";
        //script += "Events_RaiseEvents();\r\n";

        script += "\r\n}\r\n </script>";
        //registra o script na página
        page.ClientScript.RegisterClientScriptBlock(type, functionName, script);
        //seta a propriedade no controle
        control.Attributes.Add(clientEvent.Key, functionName);
      }
      string baseScript = "<script DEFER='true' language='JavaScript' src='Resources.Gizmox.WebGUI.Forms.Form.js.wgx'></script>";
      page.ClientScript.RegisterClientScriptBlock(type, "baseScript", baseScript);

      MethodInfo m = page.GetType().GetMethod("RegisterWebFormsScript", BindingFlags.Instance | BindingFlags.NonPublic);
      m.Invoke(page, new object[] { });

      base.AddCustomAttributes(ref page, ref control);
    }

    protected override void FireEvent(IEvent objEvent)
    {
      switch (objEvent.Type)
      {
        default:
          base.FireEvent(objEvent);
          break;
      }
    }

    public void TestScript()
    {
      RegisterSelf();
      string code = string.Format(@"
flowChart = GetFlowChart('{0}').getFlowChart();
flowChart.createTable(7, 7, 100, 100);", this.Guid);
      this.InvokeMethodWithId("IrisFlowChart_Eval", code);
      UnRegisterSelf();
    }


  }
}
