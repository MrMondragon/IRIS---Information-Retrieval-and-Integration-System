<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<%@ Register Assembly="NetDiagram" Namespace="MindFusion.Diagramming.WebForms" TagPrefix="ndiag" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript">
function onDocClicked(x, y, button)
{
    var c = fc();
    var ss2 = shapeSize/2.0;
    var box = c.createBox(x - ss2, y - ss2, shapeSize, shapeSize);
}

shapeSize = 0.2;
labelWidth = 2.0;

function fc() { 
    var a = applet();
    if (!a) return null;
    if (a.getFlowChart)
        return a.getFlowChart();
    return null;
}

function applet(){
    return document.getElementById('FlowChart1');
}

</script>
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <ndiag:FlowChart ID="FlowChart1" runat="server" Height="387px" Width="455px" DocClickedScript="onDocClicked" />
    
    </div>
    </form>
</body>
</html>
