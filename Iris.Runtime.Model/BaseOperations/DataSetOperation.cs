using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.BaseObjects;
using System.Data;

namespace Iris.Runtime.Model.Operations
{
  [Serializable]
  public abstract class DataSetOperation: Operation
  {

    public DataSetOperation(Structure _structure, string _name)
      : base(_structure, _name)
    {
      
    }

    protected DataSet Dataset
    {
      get { return Structure.Dataset; }
    }
  }
}
