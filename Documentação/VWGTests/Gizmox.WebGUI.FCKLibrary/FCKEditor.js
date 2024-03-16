// JScript source code for FCKEditor control

/// <summary>
/// Holds references of form instances
/// </summary>
var mobjFCKEditorForms = {};

/// <summary>
/// A flag indicating if in suspended events mode
/// </summary>
var mblnFCKEditorSuspended = false;

/// <method name="FCKEditor_OnLoad">
/// <summary>
/// Called to initialize FCKEditor
/// </summary>
/// <param name="objForm"></param>
function FCKEditor_OnLoad(objIFrame,objForm)
{
    // Set the submit handler
    objForm.submit = FCKEditor_OnSubmit;
        
    // Get the owner control id
    var strGuid = Web_GetAttribute(objForm,"vwgguid");
    
    // Set the onunload handler
    FCKEditor_AttachEvent(objIFrame.contentWindow,"onunload",new Function("FCKEditor_OnUnLoad("+strGuid+")"));
    
    // Store the form reference
    mobjFCKEditorForms[strGuid] = objForm;
    
    // Attach to the onsubmit method
    Events_AttachOnSubmit(strGuid,FCKEditor_OnEventQueueSubmit)
}
/// </method>

/// <method name="FCKEditor_OnUnLoad">
/// <summary>
/// Called on FCKEditor unloading
/// </summary>
function FCKEditor_OnUnLoad(strGuid)
{
    // Get form
    var objForm = mobjFCKEditorForms[strGuid];
    if(objForm)
    {
        // Suspend events
        mblnFCKEditorSuspended = true;
        
        // Protect from browser close event 
        try
        {
            // Cause the submit event to store value
            objForm.submit();
        }
        catch(e){}
        
        // Resume events
        mblnFCKEditorSuspended = false;
        
        // Detach onsubmit event
        Events_DetachOnSubmit(strGuid);
    }
}
/// </method>


/// <method name="FCKEditor_OnEventQueueSubmit">
/// <summary>
/// 
/// </summary>
/// <param name="strGuid"></param>
function FCKEditor_OnEventQueueSubmit(strGuid)
{
    // Get form instance
    var objForm = mobjFCKEditorForms[strGuid];
    if(objForm)
    {
        // Cause form submition to add value to queue if needed
        objForm.submit();
    }
}
/// </method>


/// <method name="FCKEditor_OnSubmit">
/// <summary>
/// Gets a data ID format "XXX".
/// </summary>
/// <param name="strId">Data node ID.</param>
function FCKEditor_OnSubmit()
{  
    // If form was not sent to method
    var objForm = this;
    
    // Get the current control value
    var strValue = this.firstChild.value;
    
    // Get control ID
    var strGuid = Web_GetAttribute(this,"vwgguid");
    
    // Get control node
	var objNode = Data_GetNode(strGuid);
	if(objNode)
	{
	    // If value has changed
	    if(!Xml_IsAttribute(objNode,"Attr.Value",strValue))
	    {
	        // Update data behind
			Data_SetAttribute(strGuid,"Attr.Value",strValue);
			
			// If not in event suspended mode
			if(!mblnFCKEditorSuspended)
			{
			    // Create event
			    var objValueChangeEvent = Events_CreateEvent(strGuid,"ValueChange",null,true);
    			
			    // Set event text attribuet
			    Events_SetEventAttribute(objValueChangeEvent,"Attr.Value",strValue);
    			
			    // Raise event if critical
			    if(Data_IsCriticalEvent(strGuid,"ValueChange")) 
			    {
			        // Raise events
			        Events_RaiseEvents();
			    }	
			}	
	    }
	}
	
	// Cancel submition
    return false;
}
/// </method>

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