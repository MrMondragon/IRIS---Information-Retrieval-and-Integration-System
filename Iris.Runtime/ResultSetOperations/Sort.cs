using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Operations.ResultSetOperations;
using Iris.Interfaces;
using Iris.Runtime.Model.Entities;

namespace Iris.DataOperations.ResultSetOperations
{
  [Serializable]
  [OperationCategory("Operações de ResultSet", "Sort")]
  public class Sort : ResultSetOperation
  {
    public Sort(Structure aStructure, string aName)
      : base(aStructure,aName)
    {
    }

    private string sortOrder;

    public string SortOrder
    {
      get { return sortOrder; }
      set { sortOrder = value; }
    }

    protected override IEntity doExecute()
    {
      ResultSet rs = (ResultSet)Entrada;
      rs.View.Sort = SortOrder;
      return rs;      
    }
  }
}
