<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WApplication2.WebForm1" %>

<%@ Register Assembly="NetDiagram" Namespace="MindFusion.Diagramming.WebForms" TagPrefix="ndiag" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style>body{margin:0px}</style>
    <script language="javascript">

    var xhr;
    if (window.XMLHttpRequest) {
      xhr = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {
      xhr = new ActiveXObject("Msxml2.XMLHTTP");
    }
    
    function onBoxCreated(table)
    {
//      xhr.open( "post", "WebForm2.aspx", false);
//      xhr.send();
      
        <%= ClientScript.GetCallbackEventReference(this,"'column'", "ShowResult", null) %>

      
      alert(xhr.responseText);
      table.setCaption("Tadaaaa");
    }
    
    function ShowResult(val, ctx)
    {
        
    }
    </script>
    
</head>
<body style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; overflow: visible; padding-top: 0px" bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">
    <form id="form1" runat="server">

    </form>
</body>
</html>
