using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IrisVwgControls.FlowChartControl
{
  public abstract class BaseBehaviorManager
  {

    private void CreateCallBackHandlers()
    {
    }

    private Dictionary<string, string> clientEventArgs;

    internal Dictionary<string, string> ClientEventArgs
    {
      get
      {
        if (clientEventArgs == null)
          SetupClientEventsCode();
        return clientEventArgs;
      }
    }

    private Dictionary<string, string> callBackArgs;

    internal Dictionary<string, string> CallBackArgs
    {
      get
      {
        if (callBackArgs == null)
          SetupClientEventsCode();
        return callBackArgs;
      }

    }
    private Dictionary<string, CalBackManagerControl> callBackHandlers;

    internal Dictionary<string, CalBackManagerControl> CallBackHandlers
    {
      get
      {
        if (callBackHandlers == null)
          SetupCallBackHandlers();
        return callBackHandlers;
      }
    }

    #region Setup

    private void SetupCallBackHandlers()
    {
      callBackHandlers = new Dictionary<string, CalBackManagerControl>();
      CallBackHandlers["ArrowClicked"] = CalBackManagerControl.CreateCallBackManager("ArrowClicked", ArrowClicked);
      CallBackHandlers["ArrowCreated"] = CalBackManagerControl.CreateCallBackManager("ArrowCreated", ArrowCreated);
      CallBackHandlers["ArrowCreating"] = CalBackManagerControl.CreateCallBackManager("ArrowCreating", ArrowCreating);
      CallBackHandlers["ArrowDblClicked"] = CalBackManagerControl.CreateCallBackManager("ArrowDblClicked", ArrowDblClicked);
      CallBackHandlers["ArrowDeleted"] = CalBackManagerControl.CreateCallBackManager("ArrowDeleted", ArrowDeleted);
      CallBackHandlers["ArrowDeleting"] = CalBackManagerControl.CreateCallBackManager("ArrowDeleting", ArrowDeleting);
      CallBackHandlers["DocClicked"] = CalBackManagerControl.CreateCallBackManager("DocClicked", DocClicked);
      CallBackHandlers["DocDblClicked"] = CalBackManagerControl.CreateCallBackManager("DocDblClicked", DocDblClicked);
      CallBackHandlers["TableClicked"] = CalBackManagerControl.CreateCallBackManager("TableClicked", TableClicked);
      CallBackHandlers["TableCreated"] = CalBackManagerControl.CreateCallBackManager("TableCreated", TableCreated);
      CallBackHandlers["TableCreating"] = CalBackManagerControl.CreateCallBackManager("TableCreating", TableCreating);
      CallBackHandlers["TableDblClicked"] = CalBackManagerControl.CreateCallBackManager("TableDblClicked", TableDblClicked);
      CallBackHandlers["TableDeleted"] = CalBackManagerControl.CreateCallBackManager("TableDeleted", TableDeleted);
      CallBackHandlers["TableDeleting"] = CalBackManagerControl.CreateCallBackManager("TableDeleting", TableDeleting);
      CallBackHandlers["TableDeselected"] = CalBackManagerControl.CreateCallBackManager("TableDeselected", TableDeselected);
      CallBackHandlers["TableSelected"] = CalBackManagerControl.CreateCallBackManager("TableSelected", TableSelected);
    }

    private void SetupClientEventsCode()
    {
      clientEventArgs = new Dictionary<string, string>();
      callBackArgs = new Dictionary<string, string>();

      ClientEventArgs["ArrowClicked"] = "(arrow, mouseX, mouseY, button)";
      CallBackArgs["ArrowClicked"] = "var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex()";

      ClientEventArgs["ArrowCreated"] = "(arrow)";
      CallBackArgs["ArrowCreated"] = "var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex()";

      ClientEventArgs["ArrowCreating"] = "(arrow, mouseX, mouseY)";
      CallBackArgs["ArrowCreating"] = "var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex()";

      ClientEventArgs["ArrowDblClicked"] = "(arrow, mouseX, mouseY, button)";
      CallBackArgs["ArrowDblClicked"] = "var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex()";

      ClientEventArgs["ArrowDeleted"] = "(arrow)";
      CallBackArgs["ArrowDeleted"] = "var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex()";

      ClientEventArgs["ArrowDeleting"] = "(arrow)";
      CallBackArgs["ArrowDeleting"] = "var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex()";

      ClientEventArgs["DocClicked"] = "(mouseX, mouseY, button)";
      CallBackArgs["DocClicked"] = "var args = String(mouseX)+';'+String(mouseY)";

      ClientEventArgs["DocDblClicked"] = "(mouseX, mouseY, button)";
      CallBackArgs["DocDblClicked"] = "var args = String(mouseX)+';'+String(mouseY)";

      ClientEventArgs["TableClicked"] = "(table, mouseX, mouseY, button)";
      CallBackArgs["TableClicked"] = "var args = String(table.tag)";

      ClientEventArgs["TableCreated"] = "(table)";
      CallBackArgs["TableCreated"] = "var args = String(table.tag)";

      ClientEventArgs["TableCreating"] = "(table, mouseX, mouseY)";
      CallBackArgs["TableCreating"] = "var args = String(table.tag)+';'+mouseX+';'+mouseY";

      ClientEventArgs["TableDblClicked"] = "(table, mouseX, mouseY, button)";
      CallBackArgs["TableDblClicked"] = "var args = String(table.tag)+';'+mouseX+';'+mouseY";

      ClientEventArgs["TableDeleted"] = "(table)";
      CallBackArgs["TableDeleted"] = "var args = String(table.tag)";

      ClientEventArgs["TableDeleting"] = "(table)";
      CallBackArgs["TableDeleting"] = "var args = String(table.tag)";

      ClientEventArgs["TableSelected"] = "(table)";
      CallBackArgs["TableSelected"] = "var args = String(table.tag)";

      ClientEventArgs["TableDeselected"] = "(table)";
      CallBackArgs["TableDeselected"] = "var args = String(table.tag)";
    }

    #endregion

    #region Eventos

    #region Arrows

    private void ArrowClicked(object sender, CallBackEventArgs e)
    {
      string[] args = e.EventArgument.Split(';');
      e.Result = doArrowClicked(args[0], args[1], Convert.ToInt32(args[2]), args[3], Convert.ToInt32(args[4]));
    }
    protected abstract string doArrowClicked(string arrow, string origin, int origIdx, string destination, int destIdx);

    private void ArrowCreated(object sender, CallBackEventArgs e)
    {
      string[] args = e.EventArgument.Split(';');
      e.Result = doArrowCreated(args[0], args[1], Convert.ToInt32(args[2]), args[3], Convert.ToInt32(args[4]));
    }
    protected abstract string doArrowCreated(string arrow, string origin, int origIdx, string destination, int destIdx);

    private void ArrowCreating(object sender, CallBackEventArgs e)
    {
      string[] args = e.EventArgument.Split(';');
      e.Result = doArrowCreating(args[0], args[1], Convert.ToInt32(args[2]), args[3], Convert.ToInt32(args[4]));
    }
    protected abstract string doArrowCreating(string arrow, string origin, int origIdx, string destination, int destIdx);

    private void ArrowDblClicked(object sender, CallBackEventArgs e)
    {
      string[] args = e.EventArgument.Split(';');
      e.Result = doArrowDblClicked(args[0], args[1], Convert.ToInt32(args[2]), args[3], Convert.ToInt32(args[4]));
    }
    protected abstract string doArrowDblClicked(string arrow, string origin, int origIdx, string destination, int destIdx);

    private void ArrowDeleted(object sender, CallBackEventArgs e)
    {
      string[] args = e.EventArgument.Split(';');
      e.Result = doArrowDeleted(args[0], args[1], Convert.ToInt32(args[2]), args[3], Convert.ToInt32(args[4]));
    }
    protected abstract string doArrowDeleted(string arrow, string origin, int origIdx, string destination, int destIdx);

    private void ArrowDeleting(object sender, CallBackEventArgs e)
    {
      string[] args = e.EventArgument.Split(';');
      e.Result = doArrowDeleting(args[0], args[1], Convert.ToInt32(args[2]), args[3], Convert.ToInt32(args[4]));
    }
    protected abstract string doArrowDeleting(string arrow, string origin, int origIdx, string destination, int destIdx);

    #endregion

    #region Doc

    private void DocClicked(object sender, CallBackEventArgs e)
    {
      string[] args = e.EventArgument.Split(';');
      e.Result = doDocClicked(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]));
    }
    protected abstract string doDocClicked(int x, int y);

    private void DocDblClicked(object sender, CallBackEventArgs e)
    {
      string[] args = e.EventArgument.Split(';');
      e.Result = doDocDblClicked(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]));
    }
    protected abstract string doDocDblClicked(int x, int y);
    #endregion

    #region Table

    private void TableClicked(object sender, CallBackEventArgs e)
    {
      e.Result = doTableClicked(e.EventArgument);
    }
    protected abstract string doTableClicked(string table);

    private void TableCreated(object sender, CallBackEventArgs e)
    {
      e.Result = doTableCreated(e.EventArgument);
    }
    protected abstract string doTableCreated(string table);

    private void TableCreating(object sender, CallBackEventArgs e)
    {
      e.Result = doTableCreating(e.EventArgument);
    }
    protected abstract string doTableCreating(string table);

    private void TableDblClicked(object sender, CallBackEventArgs e)
    {
      e.Result = doTableDblClicked(e.EventArgument);
    }
    protected abstract string doTableDblClicked(string table);

    private void TableDeleted(object sender, CallBackEventArgs e)
    {
      e.Result = doTableDeleted(e.EventArgument);
    }
    protected abstract string doTableDeleted(string table);

    private void TableDeleting(object sender, CallBackEventArgs e)
    {
      e.Result = doTableDeleting(e.EventArgument);
    }
    protected abstract string doTableDeleting(string table);

    private void TableSelected(object sender, CallBackEventArgs e)
    {
      e.Result = doTableSelected(e.EventArgument);
    }
    protected abstract string doTableSelected(string table);

    private void TableDeselected(object sender, CallBackEventArgs e)
    {
      e.Result = doTableDeselected(e.EventArgument);
    }
    protected abstract string doTableDeselected(string table);

    #endregion

    #endregion


    private IrisFlowChart flowChart;

    public IrisFlowChart FlowChart
    {
      get { return flowChart; }
      set { flowChart = value; }
    }

    public void AddCustomAttributes(Page page, WebControl control)
    {

    }

    private void CreateClientEventScript(Page page, WebControl control, string function)
    {

    }

    public List<ICallbackEventHandler> GetCallBackHandlers()
    {
      List<ICallbackEventHandler> list = new List<ICallbackEventHandler>();
      foreach (KeyValuePair<string, CalBackManagerControl> handler in CallBackHandlers)
      {
        handler.Value.Attributes["runat"] = "server";
        list.Add(handler.Value);
      }
      return list;
    }

  }
}
