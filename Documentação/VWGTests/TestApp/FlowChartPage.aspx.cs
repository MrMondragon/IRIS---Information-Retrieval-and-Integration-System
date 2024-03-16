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
using MindFusion.Diagramming.WebForms;
using System.Drawing;

namespace WApplication2
{
  public partial class FlowChartPage : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      FlowChart.AllowRefLinks = false;
      FlowChart.AllowSplitArrows =  true;
      FlowChart.AllowUnanchoredArrows =  false;
      FlowChart.AntiAlias =  System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
      FlowChart.ArrowCascadeOrientation = MindFusion.Diagramming.WebForms.Orientation.Horizontal;
      FlowChart.ArrowColor =  Color.Black;
      FlowChart.ArrowCrossings =  ArrowCrossings.Arcs;
      FlowChart.ArrowEndsMovable =  false;
      FlowChart.ArrowHead =  ArrowHead.BowArrow;
      FlowChart.ArrowHeadSize =  16;
      FlowChart.ArrowIntermSize =  16;
      FlowChart.ArrowSegments = 3;
      FlowChart.ArrowStyle =  ArrowStyle.Cascading;
      FlowChart.Behavior =  BehaviorType.CreateArrow;
      FlowChart.CrossingRadius =  4F;
      FlowChart.DisabledMnpColor =  Color.Gray;
      FlowChart.GridColor =  Color.FromArgb(224, 224, 224);
      FlowChart.GridSizeX =  6F;
      FlowChart.GridSizeY =  6F;
      FlowChart.GridStyle =  GridStyle.Lines;
      FlowChart.ShowGrid =  true;
      FlowChart.MeasureUnit =  System.Drawing.GraphicsUnit.Pixel;
      //flowChart.DocExtents = new RectangleF(0, 0, flowChart.Width * 10, flowChart.Width * 2);
      FlowChart.SelHandleSize =  8F;
      FlowChart.TableCaptionHeight =  23;
      FlowChart.TableColWidth =  30F;
      FlowChart.TableRowCount =  0;
      FlowChart.TableRowHeight =  17;
      FlowChart.ID =  "flowChart";
      FlowChart.BackColor =  Color.White;
    }

    private FlowChart flowChart;

    internal FlowChart FlowChart
    {
      get { return flowChart; }
      set { flowChart = value; }
    }
  }
}
