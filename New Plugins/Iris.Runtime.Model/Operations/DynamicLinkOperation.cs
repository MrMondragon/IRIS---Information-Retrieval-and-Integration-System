using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.PropertyEditors.Interfaces;

namespace Iris.Runtime.Model.Operations
{
  [Serializable]
  public abstract class DynamicLinkOperation : Operation, IDynamicIOOperation
  {
    public DynamicLinkOperation(Structure aStructure, string aName)
      : base(aStructure, aName)
    {
    }

    protected bool inRefresh;

    public void RefreshIO()
    {
      if (!inRefresh)
      {
        inRefresh = true;
        try
        {
          if (BeforeRefreshIO != null)
            BeforeRefreshIO(this, new EventArgs());

          doRefreshIO();

          if (AfterRefreshIO != null)
            AfterRefreshIO(this, new EventArgs());
        }
        finally
        {
          inRefresh = false;
        }
      }
    }

    protected abstract void doRefreshIO();

    //public override void SetInput(string name, Operation input)
    //{
    //  if (GetInput(name) != input)
    //  {
    //    base.SetInput(name, input);
    //    RefreshIO();
    //  }
    //}

    //public override void SetInput(int idx, Operation input)
    //{
    //  if (GetInput(idx) != input)
    //  {
    //    base.SetInput(idx, input);
    //    RefreshIO();
    //  }
    //}

    //public override void SetOutput(int idx, Operation output)
    //{
    //  if (GetOutput(idx) != output)
    //  {
    //    base.SetOutput(idx, output);
    //    RefreshIO();
    //  }
    //}

    //public override void SetOutput(string name, Operation output)
    //{
    //  if (GetOutput(name) != output)
    //  {
    //    base.SetOutput(name, output);
    //    RefreshIO();
    //  }
    //}

    //public override Operation OnSuccess
    //{
    //  get
    //  {
    //    return base.OnSuccess;
    //  }
    //  set
    //  {
    //    if (value != OnSuccess)
    //    {
    //      base.OnSuccess = value;
    //      RefreshIO();
    //    }
    //  }
    //}

    //public override Operation OnFailure
    //{
    //  get
    //  {
    //    return base.OnFailure;
    //  }
    //  set
    //  {
    //    if (value != OnFailure)
    //    {
    //      base.OnFailure = value;
    //      RefreshIO();
    //    }
    //  }
    //}

    #region IDynamicIOOperation Members
    [field: NonSerialized()]
    public event EventHandler BeforeRefreshIO;
    [field: NonSerialized()]
    public event EventHandler AfterRefreshIO;
    #endregion
  }
}
