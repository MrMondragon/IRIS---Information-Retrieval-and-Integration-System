using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using System.Drawing;
using Iris.AxIntegration.Properties;
using Iris.Interfaces;
using System.ComponentModel;
using Iris.AxIntegration.Editors;
using System.Drawing.Design;

namespace Iris.AxIntegration
{
  [Serializable]
  [OperationCategory("Integração AX 4.0", "Call Job")]
  public class CallJob: AxOperation
  {
    public CallJob(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    private string objParams;

    public string ObjName
    {
      get { return objParams; }
      set { objParams = value; }
    }

    private string jobName;
    [Editor(typeof(ObjectSelectorEditor), typeof(UITypeEditor))]
    public string JobName
    {
      get { return jobName; }
      set { jobName = value; }
    }

    protected override IEntity doExecute()
    {
      base.doExecute();
      Context.Ax.CallJob(JobName, Context.Objects[ObjName]);
      return null;
    }
  }
}
