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

    #region IDynamicIOOperation Members
    [field: NonSerialized()]
    public event EventHandler BeforeRefreshIO;
    [field: NonSerialized()]
    public event EventHandler AfterRefreshIO;
    #endregion
  }
}
