function IrisFlowChart_Eval(strGuid, code)
{ 
  eval(code);
}

function IrisFlowChart_Alert(strGuid)
{
  alert("teste");
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


function IrisFlowChart_onArrowClicked(arrow, mouseX, mouseY, button)
{
  var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex();
  WebForm_DoCallback('ArrowClicked',args,IrisFlowChart_Eval,null,null,false);
}
 
function IrisFlowChart_onArrowCreated(arrow)
{
  var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex();
  WebForm_DoCallback('ArrowCreated',args,IrisFlowChart_Eval,null,null,false);
}
 
function IrisFlowChart_onArrowCreating(arrow, mouseX, mouseY)
{
  var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex();
  WebForm_DoCallback('ArrowCreating',args,IrisFlowChart_Eval,null,null,false);
}
  
function IrisFlowChart_onArrowDblClicked(arrow, mouseX, mouseY, button)
{
  var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex();
  WebForm_DoCallback('ArrowDblClicked',args,IrisFlowChart_Eval,null,null,false);
} 
 
function IrisFlowChart_onArrowDeleted(arrow)
{
  var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex();
  WebForm_DoCallback('ArrowDeleted',args,IrisFlowChart_Eval,null,null,false);
}
 
function IrisFlowChart_onArrowDeleting(arrow)
{
  var args = String(arrow.tag)+ ';'+ String(arrow.getOrigin().tag)+';'+arrow.getOrgnIndex()+ ';'+ String(arrow.getDestination().tag)+';'+arrow.getDestIndex();
  WebForm_DoCallback('ArrowDeleting',args,IrisFlowChart_Eval,null,null,false);
} 
 
function IrisFlowChart_onDocClicked(mouseX, mouseY, button)
{
  var args = String(mouseX)+';'+String(mouseY);
  alert(args);
  WebForm_DoCallback('DocClicked',args,IrisFlowChart_Eval,null,null,false);
}  
   
function IrisFlowChart_onDocDblClicked(mouseX, mouseY, button)
{
  var args = String(mouseX)+';'+String(mouseY);
  WebForm_DoCallback('DocDblClicked',args,IrisFlowChart_Eval,null,null,false);
}  
 
function IrisFlowChart_onTableClicked(table, mouseX, mouseY, button)
{
  var args = String(table.tag);
  WebForm_DoCallback('TableClicked',args,IrisFlowChart_Eval,null,null,false);
} 
 
function IrisFlowChart_onTableCreated(table)
{
  var args = String(table.tag);
  WebForm_DoCallback('TableCreated',args,IrisFlowChart_Eval,null,null,false);
}
 
function IrisFlowChart_onTableCreating(table, mouseX, mouseY)
{
  var args = String(table.tag)+';'+mouseX+';'+mouseY;
  WebForm_DoCallback('TableCreating',args,IrisFlowChart_Eval,null,null,false);
}
 
function IrisFlowChart_onTableCreating(table, mouseX, mouseY)
{
  var args = String(table.tag)+';'+mouseX+';'+mouseY;
  WebForm_DoCallback('TableCreating',args,IrisFlowChart_Eval,null,null,false);
}  

function IrisFlowChart_onTableDeleted(table)
{
  var args = String(table.tag);
  WebForm_DoCallback('TableDeleted',args,IrisFlowChart_Eval,null,null,false);
}
 
function IrisFlowChart_onTableDeleting(table)
{
  var args = String(table.tag);
  WebForm_DoCallback('TableDeleting',args,IrisFlowChart_Eval,null,null,false);
}
  
function IrisFlowChart_onTableDeselected(table)
{
  var args = String(table.tag);
  WebForm_DoCallback('TableDeselected',args,IrisFlowChart_Eval,null,null,false);
} 

 
function IrisFlowChart_onTableSelected(table)
{
  var args = String(table.tag);
  WebForm_DoCallback('TableSelected',args,IrisFlowChart_Eval,null,null,false);
}
   