
var mobjMyScriptsInput = null;

function MyScripts_GetFileName(strGuid)
{
    if(!mobjMyScriptsInput)
    {
        mobjMyScriptsInput = document.createElement("input")
        mobjMyScriptsInput.style.display = "none";
        mobjMyScriptsInput.type = "file";
        mobjMyScriptsInput.onchange=function(){MyScripts_FileNameSelected(strGuid)};
        
        document.body.appendChild(mobjMyScriptsInput);
    }
    
    
    mobjMyScriptsInput.click();
}


function MyScripts_FileNameSelected(strGuid)
{
    var objEvent = Events_CreateEvent(strGuid,"FileSelected",true);
	Events_SetEventAttribute(objEvent,"Attr.Value",mobjMyScriptsInput.value);
	Events_RaiseEvents();
}