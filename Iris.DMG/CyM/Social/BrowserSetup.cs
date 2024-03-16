using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;
using System.Data;
using Databridge.Engine.Extensions;
using Databridge.Engine.Web;
using HtmlAgilityPack;
using System.Net;


namespace Iris.DMG.CyM.Social
{
  [Serializable]
  [OperationCategory("Facebook", "SetupBrowser")]
  public class BrowserSetup : Operation
  {
    public BrowserSetup(Structure aStructure, string aName) : base(aStructure, aName)
    {
    }

    public string Url { get; set; }

    protected override IEntity doExecute()
    {
      BrowserDialog dlg = new BrowserDialog();
      dlg.Navigate(Url);
      return null;      
    }
  }
}
