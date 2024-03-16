<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowChartPage.aspx.cs" Inherits="WApplication2.FlowChartPage" %>

<%@ Register Assembly="NetDiagram" Namespace="MindFusion.Diagramming.WebForms" TagPrefix="ndiag" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; overflow: visible; padding-top: 0px" bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <div>
      <ndiag:flowchart id="flowChart" runat="server" height="100%" width="100%"></ndiag:flowchart>
    
    </div>
    </form>
</body>
</html>
