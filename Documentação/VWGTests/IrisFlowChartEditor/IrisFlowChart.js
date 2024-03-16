// JScript source code for IrisFlowChart control

/// <method name="Web_AttachEvent">
/// <summary>
/// Attachs an event handler (This functionality will be part of the VWG 
/// services in the next services as Web_AttachEvent)
/// </summary>
/// <param name="objElement">The element to add an event handler to</param>
/// <param name="strEvent">The event name to listen to</param>
/// <param name="fncHandler">The handler function</param>
function FCKEditor_AttachEvent(objElement,strEvent,fncHandler)
{
	if(mcntIsMozilla)
	{
	    // Fix event name for non IE browsers
        if(strEvent.indexOf("on")==0)
        {
            strEvent = strEvent.substring(2);
        }
	    objElement.addEventListener(strEvent,fncHandler,false);
	}
	else
	{
	    // Fix event name for IE
        if(strEvent.indexOf("on")!=0)
        {
            strEvent = "on"+strEvent;
        }
	    objElement.attachEvent(strEvent,fncHandler);
    }
}
/// </method>