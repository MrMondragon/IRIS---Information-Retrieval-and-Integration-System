#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using System.Globalization;
using System.Text.RegularExpressions;

#endregion

namespace Gizmox.WebGUI.FCKLibrary
{
  public enum LanguageDirection
  {
    LeftToRight,
    RightToLeft
  }

  /// <summary>
  /// Summary description for FCKEditor
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmapAttribute(typeof(FCKEditor), "Gizmox.WebGUI.FCKLibrary.FCKEditor.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  public partial class FCKEditor : Control
  {
    private FCKeditorConfigurations mobjFCKeditorConfigurations = null;

    private string mstrValue = "";

    private string mstrBasePath = null;

    private string mstrToolbarSet = null;

    /// <summary>
    /// Occurs when the Value property changes.  
    /// </summary>
    public event EventHandler ValueChange;

    /// <summary>
    /// Occurs when the Value property changes (Queued).  
    /// </summary>
    public event EventHandler ValueChangeQueued;

    public FCKEditor()
    {
      this.TagName = "Gizmox.WebGUI.FCKLibrary.FCKEditor";

      InitializeComponent();
    }



    private string ClientID
    {
      get
      {
        return "CID_" + ((IRegisteredComponent)this).Guid.ToString();
      }
    }

    private string UniqueID
    {
      get
      {
        return "UID_" + ((IRegisteredComponent)this).Guid.ToString(); ;
      }
    }

    protected override void RenderAttributes(IContext context, IAttributeWriter writer)
    {
      base.RenderAttributes(context, writer);



      string sLink = this.BasePath;
      if (sLink.StartsWith("~"))
      {
        sLink = sLink.Replace("~", "../../../../../");
      }

      string sFile = false ? "fckeditor.original.html" : "fckeditor.html";

      sLink += "editor/" + sFile + "?InstanceName=" + this.ClientID;
      if (this.ToolbarSet.Length > 0) sLink += "&amp;Toolbar=" + this.ToolbarSet;

      writer.WriteAttributeString("ClientID", this.ClientID);
      writer.WriteAttributeString("UniqueID", this.UniqueID);
      writer.WriteAttributeString(WGAttributes.Value, this.Value);
      writer.WriteAttributeString(WGAttributes.Source, sLink);
      writer.WriteAttributeString("Config", this.Config.GetHiddenFieldString());

    }

    protected override void FireEvent(IEvent objEvent)
    {
      switch (objEvent.Type)
      {
        case "ValueChange":
          this.mstrValue = objEvent[WGAttributes.Value];
          OnValueChanged(EventArgs.Empty);
          break;
        default:
          base.FireEvent(objEvent);
          break;
      }
    }

    protected virtual void OnValueChanged(EventArgs e)
    {
      if (ValueChange != null)
      {
        ValueChange(this, e);
      }

      if (ValueChangeQueued != null)
      {
        ValueChangeQueued(this, e);
      }
    }

    protected override EventTypes GetCriticalEvents()
    {
      EventTypes enmEvents = base.GetCriticalEvents();
      if (ValueChange != null) enmEvents |= EventTypes.ValueChange;
      return enmEvents;
    }

    #region Properties

    /// <summary>
    /// <p>
    ///		Sets or gets the virtual path to the editor's directory. It is
    ///		relative to the current page.
    /// </p>
    /// <p>
    ///		The default value is "/FCKeditor/".
    /// </p>
    /// <p>
    ///		The base path can be also set in the Web.config file using the 
    ///		appSettings section. Just set the "FCKeditor:BasePath" for that. 
    ///		For example:
    ///		<code>
    ///		&lt;configuration&gt;
    ///			&lt;appSettings&gt;
    ///				&lt;add key="FCKeditor:BasePath" value="/scripts/FCKeditor/" /&gt;
    ///			&lt;/appSettings&gt;
    ///		&lt;/configuration&gt;
    ///		</code>
    /// </p>
    /// </summary>
    [DefaultValue("/FCKeditor/")]
    public string BasePath
    {
      get
      {
        if (mstrBasePath == null)
          mstrBasePath = System.Configuration.ConfigurationSettings.AppSettings["FCKeditor:BasePath"];

        return (mstrBasePath == null ? "/FCKeditor/" : mstrBasePath);
      }
      set { mstrBasePath = value; }
    }

    [DefaultValue("Default")]
    public string ToolbarSet
    {
      get { return (mstrToolbarSet == null ? "Default" : mstrToolbarSet); }
      set { mstrToolbarSet = value; }
    }

    [DefaultValue("")]
    public string Value
    {
      get
      {
        return mstrValue;
      }
      set
      {
        if (mstrValue != value)
        {
          mstrValue = value;
          OnValueChanged(EventArgs.Empty);
          this.Update();
        }
      }
    }

    [Browsable(false)]
    public FCKeditorConfigurations Config
    {
      get
      {
        if (mobjFCKeditorConfigurations == null)
        {
          mobjFCKeditorConfigurations = new FCKeditorConfigurations();
        }
        return mobjFCKeditorConfigurations;
      }
    }

    #region Configurations Properties

    [Category("Configurations")]
    public string CustomConfigurationsPath
    {
      set { this.Config["CustomConfigurationsPath"] = value; }
    }

    [Category("Configurations")]
    public string EditorAreaCSS
    {
      set { this.Config["EditorAreaCSS"] = value; }
    }

    [Category("Configurations")]
    public string BaseHref
    {
      set { this.Config["BaseHref"] = value; }
    }

    [Category("Configurations")]
    public string SkinPath
    {
      set { this.Config["SkinPath"] = value; }
    }

    [Category("Configurations")]
    public string PluginsPath
    {
      set { this.Config["PluginsPath"] = value; }
    }

    [Category("Configurations")]
    public bool FullPage
    {
      set { this.Config["FullPage"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public bool Debug
    {
      set { this.Config["Debug"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public bool AutoDetectLanguage
    {
      set { this.Config["AutoDetectLanguage"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public string DefaultLanguage
    {
      set { this.Config["DefaultLanguage"] = value; }
    }

    [Category("Configurations")]
    public LanguageDirection ContentLangDirection
    {
      set { this.Config["ContentLangDirection"] = (value == LanguageDirection.LeftToRight ? "ltr" : "rtl"); }
    }

    [Category("Configurations")]
    public bool EnableXHTML
    {
      set { this.Config["EnableXHTML"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public bool EnableSourceXHTML
    {
      set { this.Config["EnableSourceXHTML"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public bool FillEmptyBlocks
    {
      set { this.Config["FillEmptyBlocks"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public bool FormatSource
    {
      set { this.Config["FormatSource"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public bool FormatOutput
    {
      set { this.Config["FormatOutput"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public string FormatIndentator
    {
      set { this.Config["FormatIndentator"] = value; }
    }

    [Category("Configurations")]
    public bool GeckoUseSPAN
    {
      set { this.Config["GeckoUseSPAN"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public bool StartupFocus
    {
      set { this.Config["StartupFocus"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public bool ForcePasteAsPlainText
    {
      set { this.Config["ForcePasteAsPlainText"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public bool ForceSimpleAmpersand
    {
      set { this.Config["ForceSimpleAmpersand"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public int TabSpaces
    {
      set { this.Config["TabSpaces"] = value.ToString(CultureInfo.InvariantCulture); }
    }

    [Category("Configurations")]
    public bool UseBROnCarriageReturn
    {
      set { this.Config["UseBROnCarriageReturn"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public bool ToolbarStartExpanded
    {
      set { this.Config["ToolbarStartExpanded"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public bool ToolbarCanCollapse
    {
      set { this.Config["ToolbarCanCollapse"] = (value ? "true" : "false"); }
    }

    [Category("Configurations")]
    public string FontColors
    {
      set { this.Config["FontColors"] = value; }
    }

    [Category("Configurations")]
    public string FontNames
    {
      set { this.Config["FontNames"] = value; }
    }

    [Category("Configurations")]
    public string FontSizes
    {
      set { this.Config["FontSizes"] = value; }
    }

    [Category("Configurations")]
    public string FontFormats
    {
      set { this.Config["FontFormats"] = value; }
    }

    [Category("Configurations")]
    public string StylesXmlPath
    {
      set { this.Config["StylesXmlPath"] = value; }
    }

    [Category("Configurations")]
    public string LinkBrowserURL
    {
      set { this.Config["LinkBrowserURL"] = value; }
    }

    [Category("Configurations")]
    public string ImageBrowserURL
    {
      set { this.Config["ImageBrowserURL"] = value; }
    }

    #endregion

    #endregion
  }
}