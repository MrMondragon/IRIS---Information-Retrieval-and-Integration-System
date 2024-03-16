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
using IrisVwgControls.FlowChartControl;

#endregion


namespace IrisVwgControls
{
  /// <summary>Encapsulates the methods and properties used for the ReportViewer control.</summary>
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItem(true)]
  public class IrisFlowChart : AspControlBoxBase
  {

    public IrisFlowChart()
    {
      SetupProperties();
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
      this.Behavior = DesignerBehaviorType.None;
    }

    private BaseBehaviorManager behaviorManager;

    public BaseBehaviorManager BehaviorManager
    {
      get { return behaviorManager; }
    }

    private DesignerBehaviorType behavior;

    public DesignerBehaviorType Behavior
    {
      get { return behavior; }
      set 
      { 
        behavior = value;
        switch (behavior)
        {
          case DesignerBehaviorType.None:
            behaviorManager = null;
            break;
          case DesignerBehaviorType.StructureDesigner:
            behaviorManager = new StructureDesignerBehaviorManager();
            break;
          case DesignerBehaviorType.TableMapDesigner:
            behaviorManager = new TableMapBehaviorManager();
            break;
        }

        if (behaviorManager != null)
          behaviorManager.FlowChart = this;
      }
    }

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
        return typeof(IrisFlowChartControl);
      }
    }

    protected IrisFlowChartControl Surface
    {
      get
      {
        return HostedControl as IrisFlowChartControl;
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

    //protected override void AddCustomAttributes(ref Page page, ref WebControl control)
    //{
    //  if (behaviorManager != null)
    //  {
    //    foreach (KeyValuePair<string, CalBackManagerControl> handler in behaviorManager.CallBackHandlers)
    //    {
    //      //define o nome da função utilizando o ID do componente e o GUID do host
    //      string functionName = "IrisFlowChart_on" + handler.Key;
    //      //seta a propriedade no controle
    //      control.Attributes.Add(handler.Key, functionName);
    //      SetProperty(handler.Key, functionName);
    //      control.Attributes.Add(handler.Key+"script", functionName);
    //      SetProperty(handler.Key + "script", functionName);
    //    }
    //  }
    //  base.AddCustomAttributes(ref page, ref control);
    //}

    //protected override List<ICallbackEventHandler> GetCallBackHandlers()
    //{
    //  if (behaviorManager != null)
    //    return behaviorManager.GetCallBackHandlers();
    //  else
    //    return null;
    //}

    public void InvokeClientScript(string script)
    {
      RegisterSelf();
      this.InvokeMethodWithId("IrisFlowChart_Alert");
      UnRegisterSelf();
    }

    #region Zona de testes

    public void TestScript()
    {
     // RegisterSelf();
     // string code = page.ClientScript.GetCallbackEventReference(HostedControl, "'teste'", "IrisFlowChart_Eval", null);
     // this.InvokeMethodWithId("IrisFlowChart_Eval", code);
     // UnRegisterSelf();
    }

    #endregion


  }
}
