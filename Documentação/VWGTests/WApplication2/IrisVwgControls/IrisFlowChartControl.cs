using System;
using System.Collections.Generic;
using System.Text;
using MindFusion.Diagramming.WebForms;
using System.Web.UI;
using System.ComponentModel;

namespace IrisVwgControls
{
  [ToolboxItem(false)]
  public class IrisFlowChartControl: FlowChart, ICallbackEventHandler
  {
    #region ICallbackEventHandler Members

    public string GetCallbackResult()
    {
      return "alert('yay');";
    }

    public void RaiseCallbackEvent(string eventArgument)
    {
      
    }

    #endregion
  }
}
