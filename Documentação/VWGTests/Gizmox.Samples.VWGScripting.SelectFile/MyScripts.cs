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

#endregion

namespace VWGScripting
{

  /// <summary>
  /// Summary description for MyScripts
  /// </summary>
  [ToolboxItem(true)]
  [ToolboxBitmapAttribute(typeof(MyScripts), "VWGScripting.MyScripts.bmp")]
  public partial class MyScripts : Gizmox.WebGUI.Forms.Component
  {
    public event EventHandler FileSelected;

    private string mstrSelectedFile = string.Empty;

    public MyScripts()
    {
      InitializeComponent();
    }

    public void Register()
    {
      this.RegisterSelf();
    }

    public void SelectFile()
    {
      this.InvokeMethodWithId("MyScripts_GetFileName");
    }

    public string SelectedFile
    {
      get
      {
        return mstrSelectedFile;
      }
    }

    protected override void FireEvent(IEvent objEvent)
    {
      switch (objEvent.Type)
      {
        case "FileSelected":
          mstrSelectedFile = objEvent[WGAttributes.Value];
          if (FileSelected != null)
          {
            FileSelected(this, EventArgs.Empty);
          }
          break;
        default:
          base.FireEvent(objEvent);
          break;
      }
    }

    public void Unregister()
    {
      this.UnRegisterSelf();
    }

  }
}