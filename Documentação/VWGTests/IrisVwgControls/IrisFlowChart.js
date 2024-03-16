var controlID;

function IrisFlowChart_SetID(strGuid)
{ 
  controlID = strGuid;
  alert(controlID);
}

function IrisFlowChart_Eval(strGuid, code)
{ 
  eval(code);
}

function IrisFlowChart_Alert()
{ 
  alert("CallBack");
}

function GetFlowChart(strGuid)
{
  var id = "TRG_"+strGuid;
  var docElement = document.all[id].contentWindow || document.all[id].contentDocument;
  if(docElement)
  {
    var flowChart = docElement.document.getElementById('flowChart');
    return flowChart;
  }
  return null;
}

function GetSurface(strGuid)
{
  return GetFlowChart(strGuid).getFlowChart();
}

function GetScriptHelper(strGuid)
{
  return GetFlowChart(strGuid).getScriptHelper();
}
